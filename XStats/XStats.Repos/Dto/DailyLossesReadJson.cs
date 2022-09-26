using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XStats.Repos.Dto
{
    public class DailyLossesReadJson
    {
        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }

        [JsonPropertyName("day")]
        public int Day { get; set; }

        [JsonPropertyName("aircraft")]
        public int Aircraft { get; set; }

        [JsonPropertyName("helicopter")]
        public int Helicopter { get; set; }

        [JsonPropertyName("tank")]
        public int Tank { get; set; }

        [JsonPropertyName("APC")]
        public int APC { get; set; }

        [JsonPropertyName("field artillery")]
        public int Field_artillery { get; set; }

        [JsonPropertyName("MRL")]
        public int MRL { get; set; }

        [JsonPropertyName("military auto")]
        public int Military_auto { get; set; }

        [JsonPropertyName("fuel tank")]
        public int Fuel_tank { get; set; }

        [JsonPropertyName("drone")]
        public int Drone { get; set; }

        [JsonPropertyName("naval ship")]
        public int Naval_ship { get; set; }

        [JsonPropertyName("anti-aircraft warfare")]
        public int Anti_aircraft_warfare { get; set; }

        [JsonPropertyName("special equipment")]
        public int Special_equipment { get; set; }

        [JsonPropertyName("mobile SRBM system")]
        public int Mobile_SRBM_system { get; set; }

        [JsonPropertyName("vehicles and fuel tanks")]
        public int Vehicles_and_fuel_tanks { get; set; }

        [JsonPropertyName("cruise missiles")]
        public int Cruise_missiles { get; set; }
    }
}
