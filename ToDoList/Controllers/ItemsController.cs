using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {

    [HttpGet("categories/{categoryId}/items/new")]
    public ActionResult New(int catId)
    {
      Category cat = Category.Find(catId);
      return View(cat);
    }

    [HttpPost("/items/delete")]
    public ActionResult DeleteAll()
    {
      Item.ClearAll();
      return View();
    }

    [HttpGet("categories/{categoryId}/items/{id}")]
    public ActionResult Show(int categoryId, int itemId)
    {
      Category foundCategory = Category.Find(categoryId);
      Item foundItem = Item.Find(itemId);
      Dictionary<string, object> model = new Dictionary<string, object> ();
      model.Add("item", foundItem);
      model.Add("category", foundCategory);
      return View(model);
    }
  }
}