using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using XStats.Core;
using XStats.Repos.Converters;
using XStats.Repos.Dto;

namespace XStats.Repos
{

    public class UpdateRepository
    {
        private readonly XStatsContext _ctx;
        private readonly IConfiguration _configuration;
        public UpdateRepository(XStatsContext ctx, 
            IConfiguration configuration)
        {
            _ctx = ctx;
            _configuration = configuration;
        }

        public async Task<List<string>> UpdateAsync()
        {
            HttpClient client = new HttpClient();
            var url = _configuration["Update:GithubUrl"];

            var jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.Converters.Add(new IntJsonConverter());

            var data = await client.GetStringAsync(url);
            Console.WriteLine(data);
            data = data.Replace("NaN", "0");

            var list = JsonSerializer.Deserialize<List<DailyLossesReadJson>>(data, jsonSerializerOptions);

            var existing = _ctx.DailyLosses.ToList();

            var messageList = new List<string>();

            foreach (var item in list)
            {
                if (!existing.Any(x => x.Date == item.Date))
                {
                    messageList.Add($"Додано дані за {item.Date.Value.ToString("dd.MM.yyyy")}.");

                    await _ctx.DailyLosses.AddRangeAsync(new List<DailyLosses> {
                        new DailyLosses
                        {
                            Date = item.Date.Value,
                            Type = await _ctx.EquipmentTypes.FindAsync(1),
                            Count = item.Aircraft
                        },
                        new DailyLosses
                        {
                            Date = item.Date.Value,
                            Type = await _ctx.EquipmentTypes.FindAsync(2),
                            Count = item.Helicopter
                        },
                         new DailyLosses
                        {
                            Date = item.Date.Value,
                            Type = await _ctx.EquipmentTypes.FindAsync(3),
                            Count = item.Drone
                        },
                          new DailyLosses
                        {
                            Date = item.Date.Value,
                            Type = await _ctx.EquipmentTypes.FindAsync(4),
                            Count = item.Anti_aircraft_warfare
                        },
                        new DailyLosses
                        {
                            Date = item.Date.Value,
                            Type = await _ctx.EquipmentTypes.FindAsync(5),
                            Count = item.Cruise_missiles
                        },
                         new DailyLosses
                        {
                            Date = item.Date.Value,
                            Type = await _ctx.EquipmentTypes.FindAsync(6),
                            Count = item.Tank
                        },
                           new DailyLosses
                        {
                            Date = item.Date.Value,
                            Type = await _ctx.EquipmentTypes.FindAsync(7),
                            Count = item.APC
                        },
                                 new DailyLosses
                        {
                            Date = item.Date.Value,
                            Type = await _ctx.EquipmentTypes.FindAsync(8),
                            Count = item.Field_artillery
                        },
                        new DailyLosses
                        {
                            Date = item.Date.Value,
                            Type = await _ctx.EquipmentTypes.FindAsync(9),
                            Count = item.MRL
                        },
                        new DailyLosses
                        {
                            Date = item.Date.Value,
                            Type = await _ctx.EquipmentTypes.FindAsync(10),
                            Count = item.Fuel_tank + item.Vehicles_and_fuel_tanks + item.Military_auto
                    },
                        new DailyLosses
                        {
                            Date = item.Date.Value,
                            Type = await _ctx.EquipmentTypes.FindAsync(11),
                            Count = item.Naval_ship
                        },
                           new DailyLosses
                        {
                            Date = item.Date.Value,
                            Type = await _ctx.EquipmentTypes.FindAsync(12),
                            Count = item.Special_equipment
                        }
                    });

                }
            }

            await _ctx.SaveChangesAsync();

            if(!messageList.Any())
            {
                messageList.Add($"Оновлення не відбулося. Інформація у базі даних актуальна!!!");
            }

            return messageList;
        }
    }
}
