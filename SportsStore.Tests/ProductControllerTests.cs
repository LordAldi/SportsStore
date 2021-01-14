using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using Xunit;
namespace SportsStore.Tests
{
    
        public class ProductControllerTests
        {
            [Fact]
            public void Can_Use_Repository()
            {
            // Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
             new Product {ProductID = 1, Name = "P1"},
             new Product {ProductID = 2, Name = "P2"}
             }).AsQueryable<Product>());
            HomeController controller = new HomeController(mock.Object);
            // Act
            ProductsListViewModel result = controller.Index().ViewData.Model as ProductsListViewModel;
            // Assert
            Product[] prodArray = result.Products.ToArray();
            Console.WriteLine(prodArray);
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P1", prodArray[0].Name);
            Assert.Equal("P2", prodArray[1].Name);
        }

            [Fact]
            public void Can_Paginate()
            {
            // Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
 new Product {ProductID = 1, Name = "P1"},
 new Product {ProductID = 2, Name = "P2"},
 new Product {ProductID = 3, Name = "P3"},
 new Product {ProductID = 4, Name = "P4"},
 new Product {ProductID = 5, Name = "P5"}
 }).AsQueryable<Product>());
            HomeController controller = new HomeController(mock.Object);
            controller.PageSize = 3;
            // Act
            ProductsListViewModel result =
            controller.Index(2).ViewData.Model as ProductsListViewModel;
            // Assert
            Product[] prodArray = result.Products.ToArray();
            /*Assert.True(prodArray.Length == 2)*/;
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);
        }
        }
    
}
