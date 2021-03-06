using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ToDoList.Models;
using System;
using MySql.Data.MySqlClient;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTest : IDisposable
  {

    public void Dispose()
    {
      Item.ClearAll();
    }

    public ItemTest()
    {
      DBConfiguration.ConnectionString = 
      "server=localhost;"+
      "user id=root;"+
      "password=crabcake;"+
      "port=3306;"+
      "database=to_do_list_test;";
    }

    [TestMethod]
    public void ItemConstructor_CreatesInstanceOfItem_Item()
    {
      Item newItem = new Item("test");
      Assert.AreEqual(typeof(Item), newItem.GetType());
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreSame_Bool()
    {
      Item first = new Item("pet Ludwig");
      Item second = new Item("pet Ludwig");

      Assert.AreEqual(first, second);
    }

    [TestMethod]
    public void Save_SavesObjectDataToDB_Void()
    {
      //Arrange
      Item newItem = new Item("Pet Ludwig");
      List<Item> returnList = new List<Item> {newItem};
      //Act
      newItem.Save();
      //Assert
      CollectionAssert.AreEqual(returnList, Item.GetAll());
    }
//
//    [TestMethod]
//    public void GetDescription_ReturnsDescription_String()
//    {
//      //Arrange
//      string description = "Walk the dog.";
//
//      //Act
//      Item newItem = new Item(description);
//      string result = newItem.Description;
//
//      //Assert
//      Assert.AreEqual(description, result);
//    }
//
//    [TestMethod]
//    public void SetDescription_SetDescription_String()
//    {
//      //Arrange
//      string description = "Walk the dog.";
//      Item newItem = new Item(description);
//
//      //Act
//      string updatedDescription = "Do the dishes";
//      newItem.Description = updatedDescription;
//      string result = newItem.Description;
//
//      //Assert
//      Assert.AreEqual(updatedDescription, result);
//    }
//
    [TestMethod]
    public void GetAll_ReturnsEmptyListfromDB_ItemList()
    {
      // Arrange
      List<Item> newList = new List<Item> { };

      // Act
      List<Item> result = Item.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01);
      newItem1.Save();
      Item newItem2 = new Item(description02);
      newItem2.Save();
      List<Item> newList = new List<Item> { newItem1, newItem2 };

      //Act
      List<Item> result = Item.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

//    [TestMethod]
//    public void GetId_IdPropertyWithGetter_Int()
//    {
//      //Arrange
//      string description = "Pet Ludwig.";
//      Item newItem = new Item(description);
//
//      //Act
//      int result = newItem.Id;
//
//      //Assert
//      Assert.AreEqual(1, result);
//    }
//
    [TestMethod]
    public void Find_FindByIdReturnsItem_Item()
    {
      //Arrange
      string description = "Pet Ludwig.";
      Item item = new Item(description);
      item.Save();

      //Act
      Item found = Item.Find(item.Id);

      //Assert
      Assert.AreEqual(item, found);
    }
  }
}