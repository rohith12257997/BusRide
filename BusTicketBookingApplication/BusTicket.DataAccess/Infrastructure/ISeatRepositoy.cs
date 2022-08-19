using BusTicket.DataAccess.Infrastructure;
using BusTicketBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.DataAccess.Infrastructure
{
    public interface ISeatRepository : IGenricRepository<SeatDetails>
    {
        void Update(SeatDetails seat);
    }
}
