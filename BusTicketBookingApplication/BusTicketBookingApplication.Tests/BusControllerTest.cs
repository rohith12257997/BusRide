using BusTicket.DataAccess;
using BusTicket.DataAccess.Infrastructure;
using BusTicket.DataAccess.Repositories;
using BusTicketBooking.Models;
using BusTicketBooking.Models.ViewModels;
using BusTicketBookingApplication.Areas.Admin.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBookingApplication.Tests
{
    [TestClass()]
    public class BusControllerTest
    {
        private readonly BusController busController;
        private readonly IUnitOfWork unitOfWork;
        private readonly Mock<ApplicationDbContext> _context;
        private readonly DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptions<ApplicationDbContext>();

        public BusControllerTest()
        {
            _context = TransactionEfContext.Get();
            var mockDbSet = Substitute.For<DbSet<Bus>, IQueryable<Bus>>();
            unitOfWork = new UnitOfWork(_context.Object);
            busController = new BusController(unitOfWork);
        }

        [TestMethod()]
        public void GetAllBusTests()
        {
            var res = busController.GetAllBus();
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void Create_WithIdZero_ReturnsResponse()
        {
            var res = busController.CreateUpdate(0);
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void Update_WithValidId_ReturnsResponse()
        {
            var res = busController.CreateUpdate(1);
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void Create_WithValidBusVM_ReturnsResponse()
        {
            var res = busController.CreateUpdate(new BusVm() { Bus = new Bus() { Id = 0, BusNumber = "125", SeatCapacity = "30"} });
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void Update_WithValidBusVM_ReturnsResponse()
        {
            var res = busController.CreateUpdate(new BusVm() { Bus = new Bus() { Id = 6, BusNumber = "1525", SeatCapacity = "20" } });
            Assert.IsNotNull(res);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var res = busController.Delete(2);
            Assert.IsNotNull(res);
        }
    }
}
