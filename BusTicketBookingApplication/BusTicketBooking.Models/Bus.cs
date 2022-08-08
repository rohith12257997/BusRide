using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusTicketBooking.Models
{
    public class Bus
    {
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string BusNumber { get; set; }

        public string SeatCapacity { get; set; }
    }
}
