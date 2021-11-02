using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClient.Models;
using ApiClient.Processors;
using ApiClient.Repositories;
using FluentAssertions;
using Moq;
using Xunit;

namespace EmployeeTests
{
    public class EmployeeTests
    {
        public class TestBase : IAsyncLifetime
        {
            protected string ProcessedCommand;
            protected Mock<IEmployeeApi> EmployeeApi;
            protected List<Employee> EmployeeList;
            protected Employee Employee;
            protected Employee ProcessedEmployee;
            protected Guid Id;

            public async Task InitializeAsync()
                => await Run();

            public Task DisposeAsync()
                => Task.CompletedTask;

            protected virtual async Task Run()
                => await Task.CompletedTask;
            
        }

        public class WhenTheEmployeeListIsRequested : TestBase
        {
            public WhenTheEmployeeListIsRequested()
            {
                EmployeeList = new EmployeeSeed().GetDetailedEmployeeList(10);

                EmployeeApi = new Mock<IEmployeeApi>();
                EmployeeApi
                    .Setup(e => e.GetAllEmployees())
                    .ReturnsAsync(EmployeeList);
            }

            protected override async Task Run()
                => ProcessedCommand = await new CommandProcessor(EmployeeApi.Object).DisplayEmployeeList();

            [Fact]
            public void EmployeeApiIsCalled()
                => EmployeeApi.Verify(e => e.GetAllEmployees(), Times.Once);

            [Fact]
            public void EmployeeApiReturnsData()
            {
                var processedString = EmployeeList.Aggregate("", (current, employee)
                    => current + ($"ID: {employee.Id}\r\n" + $"Name: {employee.Name}\r\n" + $"Start Date: {employee.StartDate:dd/MM/yyyy}\r\n\r\n"));
                ProcessedCommand.Should().BeEquivalentTo(processedString);
            }
        }

        public class WhenASingleEmployeeIsRequested : TestBase
        {
            public WhenASingleEmployeeIsRequested()
            {
                Id = Guid.NewGuid();
                Employee = new EmployeeSeed().GetDetailedEmployeeWithId(Id);

                EmployeeApi = new Mock<IEmployeeApi>();
                EmployeeApi
                    .Setup(e => e.GetEmployee(It.Is<Guid>(i => i == Id)))
                    .ReturnsAsync(Employee);
            }

            protected override async Task Run()
                => ProcessedCommand = await new CommandProcessor(EmployeeApi.Object).DisplaySingleEmployee(Id);

            [Fact]
            public void EmployeeApiIsCalled()
                => EmployeeApi.Verify(e => e.GetEmployee(It.Is<Guid>(i => i == Id)), Times.Once);

            [Fact]
            public void EmployeeApiReturnsData()
                => ProcessedCommand.Should().BeEquivalentTo(Employee.ToString());
        }

        public class WhenAnEmployeeCreationIsRequested : TestBase
        {
            public WhenAnEmployeeCreationIsRequested()
            {
                Employee = new EmployeeSeed().GetSingleEmployee();

                EmployeeApi = new Mock<IEmployeeApi>();
                EmployeeApi
                    .Setup(e => e.CreateEmployee(It.Is<Employee>(i => i == Employee)))
                    .Callback((Employee e) => ProcessedEmployee = e)
                    ;
            }

            protected override async Task Run()
                => await new CommandProcessor(EmployeeApi.Object).CreateNewEmployee(Employee);

            [Fact]
            public void EmployeeApiIsCalled()
                => EmployeeApi.Verify(e => e.CreateEmployee(It.Is<Employee>(i => i == Employee)), Times.Once);

            [Fact]
            public void EmployeeApiCreatesThePassedId()
                => ProcessedEmployee.Should().BeEquivalentTo(Employee);
        }

        public class WhenAnEmployeeUpdateIsRequested : TestBase
        {
            public WhenAnEmployeeUpdateIsRequested()
            {
                Employee = new EmployeeSeed().GetSingleEmployee();

                EmployeeApi = new Mock<IEmployeeApi>();
                EmployeeApi
                    .Setup(e => e.UpdateEmployee(It.Is<Employee>(i => i == Employee)))
                    .Callback((Employee e) => ProcessedEmployee = e)
                    ;
            }

            protected override async Task Run()
                => await new CommandProcessor(EmployeeApi.Object).UpdateEmployee(Employee);

            [Fact]
            public void EmployeeApiIsCalled()
                => EmployeeApi.Verify(e => e.UpdateEmployee(It.Is<Employee>(i => i == Employee)), Times.Once);

            [Fact]
            public void EmployeeApiCreatesThePassedId()
                => ProcessedEmployee.Should().BeEquivalentTo(Employee);
        }

        public class WhenAnEmployeeDeleteIsRequested : TestBase
        {
            public WhenAnEmployeeDeleteIsRequested()
            {
                Id = Guid.NewGuid();

                EmployeeApi = new Mock<IEmployeeApi>();
                EmployeeApi
                    .Setup(e => e.DeleteEmployee(It.Is<Guid>(i => i == Id)));
            }

            protected override async Task Run()
                => await new CommandProcessor(EmployeeApi.Object).DeleteEmployee(Id);

            [Fact]
            public void EmployeeApiIsCalled()
                => EmployeeApi.Verify(e => e.DeleteEmployee(It.Is<Guid>(i => i == Id)), Times.Once);
        }
    }
}
