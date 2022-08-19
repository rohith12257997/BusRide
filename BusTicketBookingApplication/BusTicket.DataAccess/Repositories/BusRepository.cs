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
    public class BusRepository : GenricRepository<Bus>, IBusRepository
    {
        private readonly ApplicationDbContext _context;

        public BusRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Bus bus)
        {
            var BusFromDb = _context.Bus.FirstOrDefault(x => x.Id == bus.Id);
            if (BusFromDb != null)
            {
                BusFromDb.BusNumber = bus.BusNumber;
                BusFromDb.SeatCapacity = bus.SeatCapacity;
            }
        }
    }
}
