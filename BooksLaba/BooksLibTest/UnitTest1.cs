using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BooksLaba //BooksLibTest
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
                book.Name = "����";
                book.Price = 500;
                book.Author = "��� �.�.";
                book.Category = "����������";

                //Act
                context.Books.Add(book);

                //Assert
                Assert.IsTrue(book.Price == 500);


                //context.Books.Add(book);
                //context.SaveChanges();
            }
        }

        //[TestMethod]
        //public void RemoveBookTest()
        //{
        //    using (var context = new MyDbContext())
        //    {
        //        //Arrange
        //        var book = new Book();
        //        book.Name = "����";
        //        book.Price = 500;
        //        book.Author = "��� �.�.";
        //        book.Category = "����������";

        //        //Act
        //        var result = context.Books.Add(book);
                
        //        //Assert
        //        Assert.IsTrue(result.Price == 500);


        //        //context.Books.Add(book);
        //        //context.SaveChanges();
        //    }
        //}
    }
}
