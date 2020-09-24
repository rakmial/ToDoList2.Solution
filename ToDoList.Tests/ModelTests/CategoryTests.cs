using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System.Collections.Generic;
using System;

namespace ToDoList.Test
{
  [TestClass]
  public class CategoryTest : IDisposable
  {

    public void Dispose()
    {
      Category.ClearAll();
    }

    [TestMethod]
    public void CategoryConstructor_CreatesCategoryInstance_Category()
    {
      Category newCat = new Category("test");
      Assert.AreEqual(typeof(Category), newCat.GetType());
    }

    [TestMethod]
    public void IdGetter_ReturnsIdOfCategory_Int()
    {
      Category test1 = new Category("test1");
      Category test2 = new Category("test2");
      Assert.AreEqual(test1.Id, 1);
      Assert.AreEqual(test2.Id, 2);
    }

    [TestMethod]
    public void GetAll_ReturnsListOfCategories_ListCategory()
    {
      Category test1 = new Category("test1");
      Category test2 = new Category("test2");
      List<Category> testList = new List<Category> {test1, test2};
      CollectionAssert.AreEqual(testList, Category.GetAll());
    }
  }
}