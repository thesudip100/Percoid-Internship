using ApplicationLayer.Services;
using Castle.Core.Resource;
using DapperCRUD.Controllers;
using DomainLayer.Entities;
using InfrastructureLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Moq;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UnitTests
{
    public class CustomerControllerTest
    {
        private Mock<IService<Customer>> CustomerServiceMock;

        public CustomerControllerTest()
        {
            CustomerServiceMock = new Mock<IService<Customer>>();
        }

        [Fact]
        public async void Test_GetAllCustomer()
        {
            //1)Arrange
            CustomerServiceMock.Setup(service => service.GetAllDataAsync()).ReturnsAsync(new List<Customer>());
            var customerController = new CustomerAPIController(CustomerServiceMock.Object);


            //2)Act
            var result = (OkObjectResult)await customerController.GetAllAsync();


            //3)Assert

            //Test response status code
            Assert.Equal(200, result.StatusCode);

            //Test response data type
            Assert.IsType<List<Customer>>(result.Value);

            // Test that the response is a list of Customer objects
            var customers = result.Value as IEnumerable<Customer>;
        }



        /*
            i) Fact: Used for tests that don’t take any input parameters.It's good for simple, straightforward tests that don’t need different data inputs.
            ii) Theory: Used for tests that take parameters and can run multiple times with different sets of data.
                It’s useful when you want to test the same logic with various inputs.
            iii) InlineData: Provides the test data to the Theory method. [InlineData(1)] means you’re running the test with the id value set to 1. 
                 If you had more InlineData attributes with different values, the test would run multiple times with those values.
         */

        [Theory]
        [InlineData(1)]
        public async Task Test_DeleteAsync_ShouldReturnDeleted_WhenCustomerIsDeleted(int id)
        {
            //1)Arrange--> This is where you set up everything your test needs.

            //You create a Customer instance with a specific id. This simulates the customer you expect to be deleted.
            var customer = new Customer { Id = id };

            var customerListAfterDeletion = new List<Customer>(); // Assuming no customers are left after deletion

            // This tells the mock service that when GetByIdDataAsync(id) is called with the id, it should return the customer object you just created.
            CustomerServiceMock.Setup(service => service.GetByIdDataAsync(id)).ReturnsAsync(customer);


            // This tells the mock service that when DeleteDataAsync is called with a Customer object that has the matching id
            // it should return the string "deleted". This simulates the deletion process.
            CustomerServiceMock.Setup(service => service.DeleteDataAsync(It.Is<Customer>(c => c.Id == id)))
                               .ReturnsAsync("deleted");

            var customerController = new CustomerAPIController(CustomerServiceMock.Object);




            // 2.Act--> This is where you execute the code you want to test.

            /*You call the DeleteEmployee method on your controller, passing in the id.
            This method should handle the deletion of the customer and return the result.*/
            var result = (OkObjectResult)await customerController.DeleteEmployee(id);


            // 3. Assert ---> This is where you check if the result is what you expected.
            Assert.NotNull(result); // You ensure that the result of calling DeleteEmployee is not null. If it was null, something went wrong.
            Assert.IsType<Customer[]>(result.Value); // You verify that the result is of type Customer[]. This checks that the result is an array of customers
        }


        

        [Theory]
        [InlineData(1, true)]  // Customer found
        [InlineData(2, false)] // Customer not found
        public async Task Test_GetSingleCustomer(int id, bool customerExists)
        {
            // Arrange
            Customer? customer = customerExists ? new Customer { Id = id } : null;
            CustomerServiceMock.Setup(service => service.GetByIdDataAsync(id)).ReturnsAsync(customer);
            var customerController = new CustomerAPIController(CustomerServiceMock.Object);

            // Act
            var result = await customerController.GetSingleCustomer(id);

            // Assert
            if (customerExists)
            {
                // when customerExists is false, the controller returns a NotFoundResult,
                // but your test is attempting to cast it to an OkObjectResult, which causes the InvalidCastException.(if done like previous way)
                //To fix this, you should only cast the result to OkObjectResult when you expect it to be of that type.

                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Equal(200, okResult.StatusCode);
                Assert.IsType<Customer>(okResult.Value);
            }
            else
            {
                Assert.IsType<NotFoundResult>(result);
            }
        }



        [Fact]
        public async Task Test_AddCustomer()
        {
            //Arrange
            var customer = new Customer
            {
                Id = 1,
                Name = "Sudip",
                Email = "sudippaudel944@gmail.com",
                Phone = "9868207566",
                Address = "Shankhamul"
            };
            CustomerServiceMock.Setup(service => service.AddDataAsync(customer)).ReturnsAsync("added");
            var customerController = new CustomerAPIController(CustomerServiceMock.Object);


            //Act
            //here, since the controller is of type Ok() and doesnt return any object or values, this is of (OkResult) type only
            var result= (OkResult)await customerController.AddCustomer(customer);

            //assert
            Assert.Equal(200, result.StatusCode);
            Assert.IsType<OkResult>(result);
        }



        [Fact]
        public async Task Test_UpdateCustomer_ReturnsUpdatedCustomer()
        {
            //Arrange
            var customer = new Customer
            {
                Id = 1,
                Name = "Sudip Paudel",
                Email = "sudippaudel944@gmail.com",
                Phone = "9868207566",
                Address = "Shankhamul"
            };

            // Setup the mock to simply complete the task when UpdateDataAsync is called
            CustomerServiceMock.Setup(service => service.UpdateDataAsync(customer)).Returns(Task.CompletedTask);
            var customerController = new CustomerAPIController(CustomerServiceMock.Object);

            // Act
            var result = (OkObjectResult)await customerController.UpdateEmployee(customer);

            //Assert
            //checking for generic return pattern
            Assert.Equal(200,result.StatusCode);
            Assert.IsType<Customer>(result.Value);

            //now checking if it returns updated values
            var returnedCustomer = result.Value as Customer;
            Assert.Equal(customer.Id, returnedCustomer?.Id);
            Assert.Equal(customer.Name, returnedCustomer?.Name);
            Assert.Equal(customer.Email, returnedCustomer?.Email);
            Assert.Equal(customer.Phone, returnedCustomer?.Phone);
            Assert.Equal(customer.Address, returnedCustomer?.Address);
        }
    }
}

