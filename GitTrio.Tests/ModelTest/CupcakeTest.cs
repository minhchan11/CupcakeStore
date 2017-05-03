using GitTrio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GitTrio.Tests
{
    public class CupcakeTest
    {
        [Fact]
        public void GetNameTest()
        {
            //Arrange
            var cupcake = new Cupcake("Rhubarb Almond Buckle", "Our vanilla cupcake filled with a tangy rhubarb compote, topped with fresh strawberry buttercream and almond streusel. Available May only!", 3, "Almond", "Rhubarb", "Almonds", 36, "http://www.cupcakeroyale.com/wp-content/uploads/2016/03/Rhubarb-Crisp-084.jpg");

            //Act
            var result = cupcake.Name;

            //Assert
            Assert.Equal("Rhubarb Almond Buckle", result);
        }
    }
}
