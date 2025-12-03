using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace AutoTrade.Tests
{
    [TestFixture]
    public class DealerShopTests
    {
        private DealerShop shop;
        private Vehicle car;

        [SetUp]
        public void Setup()
        {
            shop = new DealerShop(2);
            car = new Vehicle("BMW", "M3", 2020);
        }

        [Test]
        public void Constructor_Should_Set_Capacity()
        {
            Assert.AreEqual(2, shop.Capacity);
        }

        [Test]
        public void Constructor_Should_Throw_When_Capacity_Is_Invalid()
        {
            Assert.Throws<ArgumentException>(() => new DealerShop(0));
        }

        [Test]
        public void AddVehicle_Should_Add_Successfully()
        {
            string result = shop.AddVehicle(car);

            Assert.AreEqual(1, shop.Vehicles.Count);
            Assert.AreEqual("Added 2020 BMW M3", result);
        }

        [Test]
        public void AddVehicle_Should_Throw_When_Full()
        {
            shop.AddVehicle(car);
            shop.AddVehicle(new Vehicle("Audi", "A4", 2019));

            Assert.Throws<InvalidOperationException>(() =>
                shop.AddVehicle(new Vehicle("VW", "Golf", 2018)));
        }

        [Test]
        public void SellVehicle_Should_Return_True_When_Exists()
        {
            shop.AddVehicle(car);

            bool result = shop.SellVehicle(car);

            Assert.IsTrue(result);
            Assert.AreEqual(0, shop.Vehicles.Count);
        }

        [Test]
        public void SellVehicle_Should_Return_False_When_Not_Found()
        {
            bool result = shop.SellVehicle(car);
            Assert.IsFalse(result);
        }

        [Test]
        public void Vehicles_Should_Be_ReadOnly()
        {
            shop.AddVehicle(car);

            Assert.AreEqual(1, shop.Vehicles.Count);
            Assert.IsTrue(shop.Vehicles.Contains(car));
        }

        [Test]
        public void InventoryReport_Should_Return_Correct_Format()
        {
            shop.AddVehicle(car);
            var audi = new Vehicle("Audi", "A4", 2019);
            shop.AddVehicle(audi);

            string report = shop.InventoryReport();
            string[] lines = report.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            Assert.AreEqual("Inventory Report", lines[0]);
            Assert.AreEqual("Capacity: 2", lines[1]);
            Assert.AreEqual("Vehicles: 2", lines[2]);
            Assert.IsTrue(lines.Contains("2020 BMW M3"));
            Assert.IsTrue(lines.Contains("2019 Audi A4"));
        }



        [Test]
        public void Vehicle_ToString_Should_Return_Correct_Format()
        {
            Assert.AreEqual("2020 BMW M3", car.ToString());
        }

    }
}
