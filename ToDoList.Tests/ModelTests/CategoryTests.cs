using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System.Collections.Generic;
using System;

namespace ToDoList.Test
{
  [TestClass]
  public class CategoryTest
  {
    [TestMethod]
    public void CategoryConstructor_CreatesCategoryInstance_Category()
    {
      Category newCat = new Category("test");
      Assert.AreEqual(typeof(Category), newCat.GetType());
    }
  }
}