namespace Cars.Tests.JustMock
{
    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    using Cars.Tests.JustMock.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;


    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new JustMockCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        public void ConrollerDetailsShouldReturnDetailsAboutCarByID()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(1));

            Assert.AreEqual(1, model.Id, "ID should be 1");
            Assert.AreEqual("Audi", model.Make, "Audi should be the make");
            Assert.AreEqual("A4", model.Model, "A4 shpuld be the model");
            Assert.AreEqual(2005, model.Year, "2005 should be the year");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CotrollerDetailsCalledWithInvalidIdShouldThrowException()
        {
            this.controller.Details(100);
        }

        [TestMethod]
        public void SearchShouldReturnCarMakeEqualsToBmw()
        {
            var car = (ICollection<Car>)this.GetModel(() => this.controller.Search("make"));

            Assert.AreEqual("BMW", car.First().Make);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SearchByEmptyOrNullStringShouldThrowException()
        {
            this.controller.Search("");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SearchByInvalidStringShouldThrowException()
        {
            this.controller.Search("swordfish");
        }

        [TestMethod]
        public void SearchByModelShouldReturnMercedes()
        {
            var cars = (ICollection<Car>)this.GetModel(() => this.controller.Search("model"));

            Assert.AreEqual("500SEL", cars.First().Model, "Car model should be 500SEL.");
        }

        [TestMethod]
        public void SortByMakeControllerShouldReturnSortedByMakeCars()
        {
            var cars = (IList<Car>)this.controller.Sort("make").Model;

            Assert.AreEqual("Audi", cars.First().Make, "First car's make should be Audi");
            Assert.AreEqual("Opel", cars.Last().Make, "Last car's make should be Opel");
        }

        [TestMethod]
        public void SortByYearControllerShouldReturnSortedByYearCars()
        {
            var cars = (IList<Car>)this.controller.Sort("year").Model;

            Assert.AreEqual(1990, cars.First().Year, "First car's year should be 1990");
            Assert.AreEqual(2010, cars.Last().Year, "Last car's make should be 2010");
        }

        [TestMethod]
        public void AllShouldReturnAllCars()
        {
            var cars = this.carsData.All();

            Assert.AreEqual(4, cars.Count, "Should have 4 cars in the repository");
        }

        [TestMethod]
        public void GetByIdShouldReturnFirstCar()
        {
            var car = this.carsData.GetById(12);

            Assert.AreEqual("Audi", car.Make);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
