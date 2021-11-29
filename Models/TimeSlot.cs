using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PartnerAPI.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public int Partner_Id { get; set; }
        public Partner Partner { get; set; }
        public string Time { get; set; }
    }
}
