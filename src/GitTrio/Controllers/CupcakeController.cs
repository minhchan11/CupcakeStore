using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GitTrio.Models;
using Microsoft.EntityFrameworkCore;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GitTrio.Controllers
{
    public class CupcakeController : Controller
    {
        private ICupcakeRepository cupcakeRepo;

        public CupcakeController(ICupcakeRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.cupcakeRepo = new EFCupcakeRepository();
            }
            else
            {
                this.cupcakeRepo = thisRepo;
            }
        }


        public ViewResult Index()
        {
            return View(cupcakeRepo.Cupcakes.ToList());
        }

        public IActionResult Details(int id)
        {
            Cupcake thisCupcake = cupcakeRepo.Details(id);
            return View(thisCupcake);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string newName, string newDescription, int newPrice, string newCake, string newFrosting, string newTopping, int newInventory, string newImage)
        {
            Cupcake newCupcake = new Cupcake(newName, newDescription, newPrice, newCake, newFrosting, newTopping, newInventory, newImage);
            cupcakeRepo.Save(newCupcake);
            return Json(newCupcake);
        }

        public IActionResult Edit(int id)
        {
            Cupcake thisCupcake = cupcakeRepo.Cupcakes.FirstOrDefault(x => x.Id == id);
            return View(thisCupcake);
        }

        [HttpPost]
        public IActionResult Edit(Cupcake cupcake)
        {
            cupcakeRepo.Edit(cupcake);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Cupcake thisCupcake = cupcakeRepo.Cupcakes.FirstOrDefault(x => x.Id == id);
            return View(thisCupcake);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Cupcake thisCupcake = cupcakeRepo.Cupcakes.FirstOrDefault(x => x.Id == id);
            cupcakeRepo.Remove(thisCupcake);
            return RedirectToAction("Index");
        }
    }
}