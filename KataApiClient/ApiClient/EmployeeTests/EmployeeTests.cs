using System;
using System.Collections.Generic;
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
        public class WhenTheEmployeeListIsRequested
        {
            private readonly List<Employee> _processedCommand;
            private readonly Mock<IEmployeeApi> _employeeApi;
            private readonly List<Employee> _employees;

            public WhenTheEmployeeListIsRequested()
            {
                _employees = new EmployeeSeed().GetDetailedEmployeeList(10);

                _employeeApi = new Mock<IEmployeeApi>();
                _employeeApi
                    .Setup(e => e.GetAllEmployees())
                    .Returns(_employees);

                _processedCommand = new CommandProcessor(_employeeApi.Object).GetEmployeeList();
            }

            [Fact]
            public void EmployeeApiIsCalled()
                => _employeeApi.Verify(e => e.GetAllEmployees(), Times.Once);

            [Fact]
            public void EmployeeApiReturnsData()
                => _processedCommand.Should().BeEquivalentTo(_employees);
        }

        public class WhenASingleEmployeeIsRequested
        {
            private readonly Employee _processedCommand;
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
                    .Returns(_employee);

                _processedCommand = new CommandProcessor(_employeeApi.Object).GetEmployee(_id);
            }

            [Fact]
            public void EmployeeApiIsCalled()
                => _employeeApi.Verify(e => e.GetEmployee(It.Is<Guid>(i=>i == _id)), Times.Once);

            [Fact]
            public void EmployeeApiReturnsData()
                => _processedCommand.Should().BeEquivalentTo(_employee);
        }

        public class WhenAnEmployeeCreationIsRequested
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

                new CommandProcessor(_employeeApi.Object).CreateEmployee(_employee);
            }

            [Fact]
            public void EmployeeApiIsCalled()
                => _employeeApi.Verify(e => e.CreateEmployee(It.Is<Employee>(i => i == _employee)), Times.Once);

            [Fact]
            public void EmployeeApiCreatesThePassedId() 
                => _createdEmployee.Should().BeEquivalentTo(_employee);
        }

        public class WhenAnEmployeeUpdateIsRequested
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

                new CommandProcessor(_employeeApi.Object).UpdateEmployee(_employee);
            }

            [Fact]
            public void EmployeeApiIsCalled()
                => _employeeApi.Verify(e => e.UpdateEmployee(It.Is<Employee>(i => i == _employee)), Times.Once);

            [Fact]
            public void EmployeeApiCreatesThePassedId()
                => _updatedEmployee.Should().BeEquivalentTo(_employee);
        }

        public class WhenAnEmployeeDeleteIsRequested
        {
            private readonly Mock<IEmployeeApi> _employeeApi;
            private readonly Guid _id;

            public WhenAnEmployeeDeleteIsRequested()
            {
                _id = Guid.NewGuid();

                _employeeApi = new Mock<IEmployeeApi>();
                _employeeApi
                    .Setup(e => e.DeleteEmployee(It.Is<Guid>(i => i == _id)));

                 new CommandProcessor(_employeeApi.Object).DeleteEmployee(_id);
            }

            [Fact]
            public void EmployeeApiIsCalled()
                => _employeeApi.Verify(e => e.DeleteEmployee(It.Is<Guid>(i => i == _id)), Times.Once);
        }
    }
}
