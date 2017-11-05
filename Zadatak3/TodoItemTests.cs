using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak2;

namespace Zadatak3
{
    [TestClass]
    public class TodoItemTests
    {
        //todoItem method tests
        [TestMethod]
        public void TestMarkAsCompleted()
        {
            TodoItem item = new TodoItem("napravi");

            Assert.IsTrue(item.MarkAsCompleted()); //oznaci kao zavrsen
            Assert.IsFalse(item.MarkAsCompleted()); //ako je vec zavrsen, vrati false
        }

        [TestMethod]
        public void TestEquals()
        {
            TodoItem item1 = new TodoItem("napravi");
            TodoItem item2 = new TodoItem("napravi2");

            Assert.AreNotEqual(item1, item2); //nisu jednaki

            item2.Id = item1.Id;

            Assert.AreEqual(item1, item2); //sad jesu
        }
    }
}
