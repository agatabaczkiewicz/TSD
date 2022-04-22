using HomeLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Book> bookList;
        public MainWindow()
        {
            InitializeComponent();
            bookList = MyBookCollection.GetMyCollection();
            BookList.ItemsSource = bookList;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var button = sender as Button;
                var book = button.DataContext as Book;
                //Book itemToRemove = (Book)((ListBox)sender).SelectedItem;
                ((ObservableCollection<Book>)bookList).Remove(BookList.SelectedItem as Book);

              //  BookList.ItemsSource = bookList;
                // remove from list
               // (this.BookList.ItemsSource).RemoveAt(BookList.Items.IndexOf(BookList.SelectedItem as Book));
            }
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Book book = BookList.SelectedItem as Book;
            bookList.Add(new Book(1){
                Title = book.Title,
                Author = book.Author,
                Year = 555,
                IsRead = true,
                Format = BookFormat.PaperBack });
        }
    }
}
