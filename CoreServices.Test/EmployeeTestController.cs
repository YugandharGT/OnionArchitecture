using Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using OA.Concrete;
using OA.Data.Context;
using OA.Interface;
using System;
using WebAPI.Controllers;
using Xunit;

namespace CoreServices.Test
{
    public class EmployeeTestController
    {
        private IEmployeeTaskRepository repository;
        public static DbContextOptions<CoreDbContext> dbContextOptions { get; }
        public static string connectionString = "Server=DESKTOP-PC\\SQLEXPRESS;Database=CoreDb;Integrated Security=SSPI;";


        static EmployeeTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<CoreDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public EmployeeTestController()
        {
            var context = new CoreDbContext(dbContextOptions);
            DummyDataDBInitializer dummyDataDBInitializer = new DummyDataDBInitializer();
            dummyDataDBInitializer.Seed(context);

            repository = new EmployeeTaskRepository(context);
        }

        #region Get By Id
        [Fact]
        public async void Task_GetEmployeeById_ValidData_OkResult()
        {
            var mock = new Mock<IEmployeeTaskRepsoitory>();
            
            //Arrange
            var empController = new EmployeeController(repository);
            int? postId = 1;
            //Act
            var data = await empController.Index(postId);
            //Assert
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var post = okResult.Value.Should().BeAssignableTo<Employee>().Subject;

            Assert.Equal("CSHARP", post.Name);
            Assert.Equal("csharp", post.Email);

        }

        [Fact]
        public async void Task_GetEmployeeById_ValidData_BadResult()
        {
            var empController = new EmployeeController(repository);
            var postId = 3;
            
            var data = await empController.Index(postId);
            
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetEmployeeById_InValidData_NotFoundResult()
        {
            var empController = new EmployeeController(repository);
            int? postId = null;

            var data = await empController.Index(postId);

            Assert.IsType<NotFoundResult>(data);
        }
        #endregion
        
        //#region Get All
        //[Fact]
        //public async void Task_GetAllEmployee_ValidData_OkResult()
        //{

        //}

        //[Fact]
        //public async void Task_GetAllEmployee_ValidData_BadResult()
        //{

        //}

        //[Fact]
        //public async void Task_GetAllEmployee_InValidData_NotFoundResult()
        //{

        //}
        //#endregion

        //#region Post
        //[Fact]
        //public async void Task_PostEmployee_ValidData_OkResult()
        //{

        //}

        //[Fact]
        //public async void Task_PostEmployee_ValidData_BadResult()
        //{

        //}

        //[Fact]
        //public async void Task_PostEmployee_InValidData_NotFoundResult()
        //{

        //}
        //#endregion

        //#region Put
        //[Fact]
        //public async void Task_PutEmployee_ValidData_OkResult()
        //{

        //}

        //[Fact]
        //public async void Task_PutEmployee_ValidData_BadResult()
        //{

        //}

        //[Fact]
        //public async void Task_PutEmployee_InValidData_NotFoundResult()
        //{

        //}
        //#endregion

        //#region Delete
        //[Fact]
        //public async void Task_DeleteEmployee_ValidData_OkResult()
        //{

        //}

        //[Fact]
        //public async void Task_DeleteEmployee_ValidData_BadResult()
        //{

        //}

        //[Fact]
        //public async void Task_DeleteEmployee_InValidData_NotFoundResult()
        //{

        //}
        //#endregion
    }
}
