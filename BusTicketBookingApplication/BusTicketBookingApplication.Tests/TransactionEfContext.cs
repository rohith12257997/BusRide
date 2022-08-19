using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF = BusTicketBooking.Models;
using BusTicket.DataAccess;
using Moq;

namespace BusTicketBookingApplication.Tests
{
    public static class TransactionEfContext
    {
        public static List<EF.Bus> _busList;
        public static List<EF.SeatDetails> _seatDetail;

        public static Mock<ApplicationDbContext> Get()
        {
            var context = new Mock<ApplicationDbContext> { CallBase = true };

            _busList = new List<EF.Bus>()
            {
                new EF.Bus()
                {
                    Id = 1,
                    BusNumber = "123",
                    SeatCapacity = "20"
                },
                new EF.Bus()
                {
                    Id = 1,
                    BusNumber = "456",
                    SeatCapacity = "30"
                },
                new EF.Bus()
                {
                    Id = 1,
                    BusNumber = "789",
                    SeatCapacity = "10"
                },
                new EF.Bus()
                {
                    Id = 1,
                    BusNumber = "478",
                    SeatCapacity = "10"
                },
                new EF.Bus()
                {
                    Id = 1,
                    BusNumber = "897",
                    SeatCapacity = "25"
                },
                new EF.Bus()
                {
                    Id = 1,
                    BusNumber = "478956",
                    SeatCapacity = "35"
                },
                new EF.Bus()
                {
                    Id = 1,
                    BusNumber = "456",
                    SeatCapacity = "12"
                }
            };

            context.Setup(m => m.SaveChanges()).Returns(1).Verifiable();

            return context;
        }
    }
}
