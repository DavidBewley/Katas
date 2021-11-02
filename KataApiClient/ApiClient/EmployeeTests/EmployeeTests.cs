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
        public class WhenTheEmployeeListIsRequested : IAsyncLifetime
        {
            private string _processedCommand;
            private readonly Mock<IEmployeeApi> _employeeApi;
            private readonly List<Employee> _employees;

            public WhenTheEmployeeListIsRequested()
            {
                _employees = new EmployeeSeed().GetDetailedEmployeeList(10);

                _employeeApi = new Mock<IEmployeeApi>();
                _employeeApi
                    .Setup(e => e.GetAllEmployees())
                    .ReturnsAsync(_employees);
            }

            public async Task InitializeAsync()
                => _processedCommand = await new CommandProcessor(_employeeApi.Object).DisplayEmployeeList();

            [Fact]
            public void EmployeeApiIsCalled()
                => _employeeApi.Verify(e => e.GetAllEmployees(), Times.Once);

            [Fact]
            public void EmployeeApiReturnsData()
            {
                var processedString = _employees.Aggregate("", (current, employee)
                    => current + ($"ID: {employee.Id}\r\n" + $"Name: {employee.Name}\r\n" + $"Start Date: {employee.StartDate:dd/MM/yyyy}\r\n\r\n"));
                _processedCommand.Should().BeEquivalentTo(processedString);
            }

            public Task DisposeAsync() 
                => Task.CompletedTask;
        }

        public class WhenASingleEmployeeIsRequested : IAsyncLifetime
        {
            private string _processedCommand;
            private readonly Mock<IEmployeeApi> _employeeApi;
            private readonly Employee _employee;
            private readonly Guid _id;

            public WhenASingleEmployeeIsRequested()
            {
                _id = Guid.NewGuid();
                _employee = new EmployeeSeed().GetDetailedEmployeeWithId(_id);

                _employeeApi = new Mock<IEmployeeApi>();
                _employeeApi
                    .Setup(e => e.GetEmployee(It.Is<Guid>(i => i == _id)))
                    .ReturnsAsync(_employee);
            }

            public async Task InitializeAsync()
                => _processedCommand = await new CommandProcessor(_employeeApi.Object).DisplaySingleEmployee(_id);

            [Fact]
            public void EmployeeApiIsCalled()
                => _employeeApi.Verify(e => e.GetEmployee(It.Is<Guid>(i=>i == _id)), Times.Once);

            [Fact]
            public void EmployeeApiReturnsData()
                => _processedCommand.Should().BeEquivalentTo(_employee.ToString());

            public Task DisposeAsync()
                => Task.CompletedTask;
        }

        public class WhenAnEmployeeCreationIsRequested : IAsyncLifetime
        {
            private readonly Mock<IEmployeeApi> _employeeApi;
            private readonly Employee _employee;
            private Employee _createdEmployee;

            public WhenAnEmployeeCreationIsRequested()
            {
                _employee = new EmployeeSeed().GetSingleEmployee();

                _employeeApi = new Mock<IEmployeeApi>();
                _employeeApi
                    .Setup(e => e.CreateEmployee(It.Is<Employee>(i => i == _employee)))
                    .Callback((Employee e) => _createdEmployee = e)
                    ;
            }

            public async Task InitializeAsync()
                => await new CommandProcessor(_employeeApi.Object).CreateNewEmployee(_employee);

            [Fact]
            public void EmployeeApiIsCalled()
                => _employeeApi.Verify(e => e.CreateEmployee(It.Is<Employee>(i => i == _employee)), Times.Once);

            [Fact]
            public void EmployeeApiCreatesThePassedId() 
                => _createdEmployee.Should().BeEquivalentTo(_employee);

            public Task DisposeAsync()
                => Task.CompletedTask;
        }

        public class WhenAnEmployeeUpdateIsRequested : IAsyncLifetime
        {
            private readonly Mock<IEmployeeApi> _employeeApi;
            private readonly Employee _employee;
            private Employee _updatedEmployee;

            public WhenAnEmployeeUpdateIsRequested()
            {
                _employee = new EmployeeSeed().GetSingleEmployee();

                _employeeApi = new Mock<IEmployeeApi>();
                _employeeApi
                    .Setup(e => e.UpdateEmployee(It.Is<Employee>(i => i == _employee)))
                    .Callback((Employee e) => _updatedEmployee = e)
                    ;
            }

            public async Task InitializeAsync()
                => await new CommandProcessor(_employeeApi.Object).UpdateEmployee(_employee);

            [Fact]
            public void EmployeeApiIsCalled()
                => _employeeApi.Verify(e => e.UpdateEmployee(It.Is<Employee>(i => i == _employee)), Times.Once);

            [Fact]
            public void EmployeeApiCreatesThePassedId()
                => _updatedEmployee.Should().BeEquivalentTo(_employee);

            public Task DisposeAsync()
                => Task.CompletedTask;
        }

        public class WhenAnEmployeeDeleteIsRequested : IAsyncLifetime
        {
            private readonly Mock<IEmployeeApi> _employeeApi;
            private readonly Guid _id;

            public WhenAnEmployeeDeleteIsRequested()
            {
                _id = Guid.NewGuid();

                _employeeApi = new Mock<IEmployeeApi>();
                _employeeApi
                    .Setup(e => e.DeleteEmployee(It.Is<Guid>(i => i == _id)));
            }

            public async Task InitializeAsync()
                => await new CommandProcessor(_employeeApi.Object).DeleteEmployee(_id);

            [Fact]
            public void EmployeeApiIsCalled()
                => _employeeApi.Verify(e => e.DeleteEmployee(It.Is<Guid>(i => i == _id)), Times.Once);

            public Task DisposeAsync()
                => Task.CompletedTask;
        }
    }
}
