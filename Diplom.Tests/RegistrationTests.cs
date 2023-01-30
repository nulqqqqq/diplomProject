using Xunit;
using Moq;
using System.Collections.Generic;
using DiplomServer.Interfaces;
using DiplomServer.Services;
using WpfApp1.Windows;
using Diplom.Domain.Core;
using DiplomServer.Controllers;

namespace Diplom.Tests
{
    public class AdminMenuTests
    {
       /* [Fact]
        public void MenuTest()
        {
            //Arrange
            var mock = new Mock<IAdminMenu>();
            mock.Setup(_adminMenu => _adminMenu.GetMenu()).Returns(GetAll());
            var controller = new AdminMenuController(mock.Object);

            //Act
            var result = controller.GetMenu();

            //Assert
            var viewResult = Assert.IsType<MenuModel>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<MenuModel>>(viewResult.GetType());
            Assert.Equal(GetAll(),model);

        }
        private async Task<List<MenuModel>> GetAll()
        {
            var menus = new List<MenuModel>
            {
                new MenuModel{FoodId = 1,FoodCount = 10,FoodName = "a",Price = 1,RestId = 1 },
                new MenuModel{FoodId = 2,FoodCount = 11,FoodName = "b" ,Price = 2,RestId = 2},
                new MenuModel{FoodId = 3,FoodCount = 10,FoodName = "c" ,Price = 3,RestId = 3},

            };
            return menus;*/
        /*}*/
    }
}
