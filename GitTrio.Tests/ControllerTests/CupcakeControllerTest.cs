using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GitTrio.Controllers;
using GitTrio.Models;
using Xunit;

namespace GitTrio.Tests.ControllerTest
{
    public class CupcakeControllerTest : IDisposable
    {
        EFCupcakeRepository db = new EFCupcakeRepository(new TestContext());

        int profit = 20;


        [Fact]
        public void Database_GetViewResultReturn_IsTypeViewResult()
        {
            CupcakeController controller = new CupcakeController(db);
            var result = controller.Index();
            var resultData = result.ViewData.Model;
            
            Assert.IsType<ViewResult>(result);
            Assert.IsType<List<Cupcake>>(resultData);
        }

        [Fact]
        public void Database_CreateNewCupcake_CupcakeIsReturned()
        {
            CupcakeController controller = new CupcakeController(db);
            var testCupcake = new Cupcake ("Limoncello Meringue", "Vanilla cake with marshmallow frosting, browned to perfection.", 2, "Vanilla", "Marshmallow", "None", 24, "http://www.cupcakeroyale.com/wp-content/uploads/2016/04/Limoncello.jpg");
            controller.Create(testCupcake);
            var collection = (controller.Index() as ViewResult).ViewData.Model as IEnumerable<Cupcake>;

            Assert.Contains(testCupcake,collection);
        }

        [Fact]
        public void Database_GetDetailsPage_SelectedCupcakeIsReturned()
        {
            CupcakeController controller = new CupcakeController(db);
            var testCupcake = new Cupcake("Limoncello Meringue", "Vanilla cake with marshmallow frosting, browned to perfection.", 2, "Vanilla", "Marshmallow", "None", 24, "http://www.cupcakeroyale.com/wp-content/uploads/2016/04/Limoncello.jpg");
            controller.Create(testCupcake);
            var model = (controller.Details(testCupcake.Id) as ViewResult).ViewData.Model as Cupcake;
            Assert.Equal(testCupcake, model);
        }

        [Fact]
        public void Database_UpdateDatabaseObject_SectedCupcakeIsUpdated()
        {
            CupcakeController controller = new CupcakeController(db);
            var testCupcake = new Cupcake("Limoncello Meringue", "Vanilla cake with marshmallow frosting, browned to perfection.", 2, "Vanilla", "Marshmallow", "None", 24, "http://www.cupcakeroyale.com/wp-content/uploads/2016/04/Limoncello.jpg");
            controller.Create(testCupcake);
            testCupcake.Name = "Lemon";
            controller.Edit(testCupcake);
            var model = (controller.Details(testCupcake.Id) as ViewResult).ViewData.Model as Cupcake;

            Assert.Equal("Lemon", model.Name);
        }

        [Fact]
        public void Database_DeleteDatabaseObject_SelectedCupcakeIsDeleted()
        {
            CupcakeController controller = new CupcakeController(db);

            var testCupcake = new Cupcake("Limoncello Meringue", "Vanilla cake with marshmallow frosting, browned to perfection.", 2, "Vanilla", "Marshmallow", "None", 24, "http://www.cupcakeroyale.com/wp-content/uploads/2016/04/Limoncello.jpg");
            controller.Create(testCupcake);

            var testCupcake2 = new Cupcake("Red Velvet", "Vanilla cake with marshmallow frosting, browned to perfection.", 2, "Chocolate", "Marshmallow", "None", 24, "http://www.cupcakeroyale.com/wp-content/uploads/2016/04/Limoncello.jpg");
            controller.Create(testCupcake2);
            controller.DeleteConfirmed(testCupcake2.Id);

            List<Cupcake> expected = new List<Cupcake> { testCupcake };

            var collection = (controller.Index() as ViewResult).ViewData.Model as IEnumerable<Cupcake>;

            Assert.Equal(expected, collection);
        }

        public void Dispose()
        {
            db.DeleteAll();
        }
    }
}
