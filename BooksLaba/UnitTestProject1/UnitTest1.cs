using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Data.Entity;

namespace BooksLaba
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddBookTest()
        {
            using (var context = new MyDbContext())
            {
                //Arrange
                var book = new Book();
                book.Name = "Альф";
                book.Price = 500;
                book.Author = "Бил А.В.";
                book.Category = "Фантастика";

                //Act
                var result = context.Books.Add(book);

                //Assert
                Assert.IsTrue(result.Name == "Альф");
                Assert.IsTrue(result.Price == 500);
                Assert.IsTrue(result.Author == "Бил А.В.");
                Assert.IsTrue(result.Category == "Фантастика");
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, book.GetType());
                Assert.IsFalse(result.Price == 250);
            }
        }
        [TestMethod]
        public void UpdateBookTest()
        {
            using (var context = new MyDbContext())
            {
                //Arrange
                var expectedPrice = 1000;
                var expectedName = "Том";
                var book = new Book();
                book.Name = "Альф";
                book.Price = 500;
                book.Author = "Бил А.В.";
                book.Category = "Фантастика";

                //Act
                var result = context.Books.Add(book);
                result.Price = expectedPrice;
                result.Name = expectedName;

                //Assert
                Assert.AreEqual(expectedPrice, result.Price);
                Assert.AreEqual(expectedName, result.Name);
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, book.GetType());
                Assert.IsFalse(result.Price == 500);
            }
        }
        [TestMethod]
        public void DeleteBookTest()
        {
            using (var context = new MyDbContext())
            {
                //Arrange
                var book = new Book();
                book.Name = "Альф";
                book.Price = 500;
                book.Author = "Бил А.В.";
                book.Category = "Фантастика";

                //Act
                var result = context.Books.Add(book);
                context.Entry(result).State = EntityState.Deleted;
                var isExists = context.Books.Any(p => p.Id == result.Id);

                //Assert
                Assert.IsFalse(isExists);
            }
        }
    }
}
