using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak2;

namespace Zadatak3
{
    /// <summary>
    /// Summary description for TodoRepositoryTests
    /// </summary>
    [TestClass]
    public class TodoRepositoryTests
    {
        [TestMethod]
        public void TestGet()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item1 = new TodoItem("prvi");
            TodoItem item2 = new TodoItem("drugi");
            
            repo.Add(item1);
            
            Assert.AreEqual(item1, repo.Get(item1.Id));
            Assert.IsNull(repo.Get(item2.Id));
        }

        [TestMethod]
        public void TestAdd()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item1 = new TodoItem("prvi");

            Assert.AreEqual(item1, repo.Add(item1));
            
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        public void TestAddException()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item1 = new TodoItem("prvi");

            repo.Add(item1);
            repo.Add(item1);
        }

        [TestMethod]
        public void TestRemove()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item1 = new TodoItem("prvi");
            TodoItem item2 = new TodoItem("drugi");

            repo.Add(item1);
            repo.Add(item2);

            Assert.AreEqual(item1, repo.Get(item1.Id));
            Assert.IsTrue(repo.Remove(item1.Id));
            Assert.IsFalse(repo.Remove(item1.Id));

        }

        [TestMethod]
        public void TestUpdate()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item1 = new TodoItem("prvi");
            TodoItem item2 = new TodoItem("drugi");

            repo.Add(item1);
            Assert.IsNull(repo.Get(item2.Id));
            repo.Update(item2);
            Assert.IsNotNull(repo.Get(item2.Id));

            repo.Update(item2);
            Assert.AreEqual(item2, repo.Get(item2.Id));

        }

        [TestMethod]
        public void TestMarkAsCompleted()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item1 = new TodoItem("prvi");

            Assert.IsFalse(repo.MarkAsCompleted(item1.Id));
            repo.Add(item1);
            Assert.IsTrue(repo.MarkAsCompleted(item1.Id));
        }

        [TestMethod]
        public void TestGetAll()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item1 = new TodoItem("prvi");
            TodoItem item2 = new TodoItem("drugi");
            TodoItem item3 = new TodoItem("treci");

            List<TodoItem> list = new List<TodoItem>();
            list = repo.GetAll();

            Assert.AreEqual(0, list.Count);

            repo.Add(item1);
            repo.Add(item2);
            repo.Add(item3);
            list = repo.GetAll();

            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void TestGetActive()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item1 = new TodoItem("prvi");
            TodoItem item2 = new TodoItem("drugi");
            TodoItem item3 = new TodoItem("treci");

            List<TodoItem> list = new List<TodoItem>();
            list = repo.GetActive();

            Assert.AreEqual(0, list.Count);

            repo.Add(item1);
            repo.Add(item2);
            repo.Add(item3);
            list = repo.GetActive();
            Assert.AreEqual(3, list.Count);

            repo.MarkAsCompleted(item2.Id);
            list = repo.GetActive();
            Assert.AreEqual(2, list.Count);

            repo.MarkAsCompleted(item3.Id);
            list = repo.GetActive();
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void TestGetCompleted()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item1 = new TodoItem("prvi");
            TodoItem item2 = new TodoItem("drugi");
            TodoItem item3 = new TodoItem("treci");

            List<TodoItem> list = new List<TodoItem>();
            list = repo.GetCompleted();

            Assert.AreEqual(0, list.Count);

            repo.Add(item1);
            repo.Add(item2);
            repo.Add(item3);
            list = repo.GetCompleted();
            Assert.AreEqual(0, list.Count);

            repo.MarkAsCompleted(item2.Id);
            list = repo.GetCompleted();
            Assert.AreEqual(1, list.Count);

            repo.MarkAsCompleted(item3.Id);
            list = repo.GetCompleted();
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void TestGetFiltered()
        {
            TodoRepository repo = new TodoRepository();

            TodoItem item1 = new TodoItem("prvi");
            TodoItem item2 = new TodoItem("drugi");
            TodoItem item3 = new TodoItem("treci");

            List<TodoItem> list = new List<TodoItem>();

            repo.Add(item1);
            repo.Add(item2);
            repo.Add(item3);

            list = repo.GetFiltered(t => t.Text.StartsWith("p"));
            Assert.AreEqual(1, list.Count);

            TodoItem item4 = new TodoItem("ppp");
            repo.Add(item4);

            list = repo.GetFiltered(t => t.Text.StartsWith("p"));
            Assert.AreEqual(2, list.Count);
        }
    }
}
