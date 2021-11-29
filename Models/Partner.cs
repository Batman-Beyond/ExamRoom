using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PartnerAPI.Models
{
    public class Partner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TimeSlot> TimeSlots { get; set; }
    }
}
