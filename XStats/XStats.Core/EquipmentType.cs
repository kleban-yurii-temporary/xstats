using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XStats.Core
{
    public class EquipmentType
    {
        [Key]
        public int Id { get; set; }
        public int Order { get; set; }
        public string? Title { get; set; }
        public string? FileTitle { get; set; }
        public string? IconPath { get; set; } 
        public virtual ICollection<DailyLosses>? Losses { get; set; }
    }
}
