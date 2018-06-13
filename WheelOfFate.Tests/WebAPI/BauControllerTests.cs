using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WheelOfFate.Domain.Entities;
using WheelOfFate.Domain.Interfaces.Services;
using WheelOfFate.WebAPI.Controllers;
using Xunit;

namespace WheelOfFate.Tests.WebAPI
{
    public class BauControllerTests
    {
        protected BauController ControllerUnderTest { get; }
        protected Mock<IBauService> BauServiceMock { get; }

        public BauControllerTests()
        {
            BauServiceMock = new Mock<IBauService>();  // IBauService mock
            ControllerUnderTest = new BauController(BauServiceMock.Object);
        }

        public class GenerateBauSchedule : BauControllerTests
        {
            [Fact]
            public void Should_return_JsonResult_with_bauschedules()
            {
                // Assert
                var startDate = new DateTime(2018, 6, 11);
                var endDate = new DateTime(2018, 6, 22);
                var numShifts = 2;
                var numEmployees = 10;

                var expectedBauSchedules = new List<BauSchedule>();
                var bauSchedule1 = new BauSchedule(startDate);
                bauSchedule1.Baus.AddRange(new Bau[]
                {
                    new Bau(new Employee(1, "Employee 1"), new Shift("Shift 1")),
                    new Bau(new Employee(1, "Employee 2"), new Shift("Shift 2"))
                });
                var bauSchedule2 = new BauSchedule(startDate.AddDays(1));
                bauSchedule2.Baus.AddRange(new Bau[]
                {
                    new Bau(new Employee(1, "Employee 3"), new Shift("Shift 1")),
                    new Bau(new Employee(1, "Employee 4"), new Shift("Shift 2"))
                });
                var bauSchedule3 = new BauSchedule(startDate.AddDays(2));
                bauSchedule3.Baus.AddRange(new Bau[]
                {
                    new Bau(new Employee(1, "Employee 5"), new Shift("Shift 1")),
                    new Bau(new Employee(1, "Employee 6"), new Shift("Shift 2"))
                });
                expectedBauSchedules.AddRange(new BauSchedule[] { bauSchedule1, bauSchedule2, bauSchedule3 });
                
                BauServiceMock
                    .Setup(x => x.GenerateBauSchedules(startDate, endDate, numShifts, numEmployees))
                    .Returns(expectedBauSchedules); // Mocked the GenerateBauSchedules() method

                // Act
                var result = ControllerUnderTest.GenerateBauSchedule(startDate, endDate, numShifts, numEmployees);

                // Assert
                var jsonResult = Assert.IsType<JsonResult>(result);
                Assert.Same(expectedBauSchedules, jsonResult.Value);
            }

            [Fact]
            public void Should_return_BadRequest()
            {
                // Assert
                var startDate = new DateTime(2018, 6, 11);
                var endDate = new DateTime(2018, 6, 22);
                var numShifts = 0; // Cannot be zero, should return bad request
                var numEmployees = 10;

                // Act
                var result = ControllerUnderTest.GenerateBauSchedule(startDate, endDate, numShifts, numEmployees);

                // Assert
                var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
                Assert.Equal("Invalid data!", badRequestResult.Value);
            }
        }
    }
}
