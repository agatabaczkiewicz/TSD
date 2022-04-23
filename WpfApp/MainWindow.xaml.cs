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


        private void Button_Click_Delete(object sender, RoutedEventArgs e)
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
        

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            if (this.BookList.SelectedIndex != -1)
            {
                this.BookList.UnselectAll();
                this.Selected.Visibility = Visibility.Hidden;
                this.Empty.Visibility = Visibility.Visible;
            }
            else if (this.Empty.Visibility == Visibility.Visible)
            {
                bool Readed = false;
                if (this.IsRead.IsChecked == true)
                    Readed = true;

                bookList.Add(new Book(1)
                {
                    Author = this.Author.Text,
                    Format = BookFormat.EBook,
                    IsRead = Readed,
                    Title = this.Title.Text,
                    Year = int.Parse(this.Year.Text)
                }); 
              
                    this.Author.Clear();
                    this.Format.Clear();
                this.IsRead.IsChecked = false;
                    this.Title.Clear();
                    this.Year.Clear();
                    this.BookList.Items.Refresh();
                
            }
        }

        public void SelectBook(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1 && Keyboard.Modifiers == ModifierKeys.Control)
            {
                this.Selected.Visibility = Visibility.Hidden;
                this.Empty.Visibility = Visibility.Visible;
            }
            if (e.ClickCount == 1 && (Keyboard.Modifiers & ModifierKeys.Control) == 0)
            {
                this.Empty.Visibility = Visibility.Hidden;
                this.Selected.Visibility = Visibility.Visible;
            }
        }

    }
}
