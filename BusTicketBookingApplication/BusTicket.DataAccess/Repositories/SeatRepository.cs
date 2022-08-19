using BusTicket.DataAccess.Infrastructure;
using BusTicketBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.DataAccess.Repositories
{
    public class SeatRepositoy : GenricRepository<SeatDetails>, ISeatRepository
    {
        private readonly ApplicationDbContext _context;

        public SeatRepositoy(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public void Update(SeatDetails seat)
        {
            var SeatFromDb = _context.SeatDetails.FirstOrDefault(x => x.Id == seat.Id);
            if(SeatFromDb != null)
            {
                SeatFromDb.SeatNo = seat.SeatNo;
                SeatFromDb.Description = seat.Description;
                SeatFromDb.BusId = seat.BusId;
            }
        }
    }
}
