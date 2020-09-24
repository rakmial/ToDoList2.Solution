using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class CategoriesControllers : Controller
  {
    [HttpGet("/categories")]
    public ActionResult Index()
    {
      List<Category> allCategories = Category.GetAll();
      return View(allCategories);
    }

    [HttpPost("/categories")]
    public ActionResult Create(string categoryName)
    {
      Category newCat = new Category(categoryName);
      return RedirectToAction("Index");
    }

    [HttpGet("/categories/new")]
    public ActionResult New()
    {
      return View();
    }
  

    [HttpGet("/categories/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category selectCat = Category.Find(id);
      List<Item> categoryItems = selectCat.Items;
      model.Add("category", selectCat);
      model.Add("items", categoryItems);
      return View(model);
    }
  }
}