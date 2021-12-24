using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BooksLaba
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            using (var context = new MyDbContext())
            {
                BooksGrid.ItemsSource = context.Books.ToList();
            }
        }

        private void BooksGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var context = new MyDbContext())
            {
                if (BooksGrid.SelectedItem is Book selectedBook)
                {
                    TbName.Text = selectedBook.Name;
                    TbPrice.Text = selectedBook.Price.ToString();
                    TbAuthor.Text = selectedBook.Author;
                    TbCategory.Text = selectedBook.Category;
                }
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new MyDbContext())
            {
                if (BooksGrid.SelectedItem is Book selectedBook)
                {
                    context.Configuration.ValidateOnSaveEnabled = false;

                    context.Books.Attach(selectedBook);
                    context.Entry(selectedBook).State = EntityState.Deleted;
                    context.SaveChanges();
                    Load();
                }
            }
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new MyDbContext())
            {
                if (!decimal.TryParse(TbPrice.Text, out decimal price))
                {
                    return;
                }
                var book = new Book();
                book.Name = TbName.Text;
                book.Price = price;
                book.Author = TbAuthor.Text;
                book.Category = TbCategory.Text;

                context.Books.Add(book);
                context.SaveChanges();
                Load();
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new MyDbContext())
            {
                if (BooksGrid.SelectedItem is Book selectedBook)
                {
                    if (!decimal.TryParse(TbPrice.Text, out decimal price))
                    {
                        return;
                    }
                    context.Books.Attach(selectedBook);
                    selectedBook.Name = TbName.Text;
                    selectedBook.Price = price;
                    selectedBook.Author = TbAuthor.Text;
                    selectedBook.Category = TbCategory.Text;
                    context.SaveChanges();
                    Load();
                }
            }
        }
    }
}
