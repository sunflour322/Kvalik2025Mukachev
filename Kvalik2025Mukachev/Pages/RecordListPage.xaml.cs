using System;
using System.Collections.Generic;
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
using Kvalik2025Mukachev.Database;

namespace Kvalik2025Mukachev.Pages
{
    /// <summary>
    /// Логика взаимодействия для RecordListPage.xaml
    /// </summary>
    public partial class RecordListPage : Page
    {
        private int _pageNumber = 1;
        private int _countPages = 0;
        private int _result;
        private Service _product;
        public RecordListPage()
        {
            InitializeComponent();
            RecordLv.ItemsSource = App.db.Service.ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TypeCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RecordLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
        private void LeftClick(object sender, RoutedEventArgs e)
        {
            _pageNumber--;
            if (_pageNumber < 1)
            {
                MessageBox.Show("Начало списка");
                _pageNumber++;
                return;
            }
            pageNumberTb.Text = _pageNumber.ToString();
            _result -= 20;
        }
        private void RightClick(object sender, RoutedEventArgs e)
        {
            _pageNumber++;
            if (_pageNumber > _countPages)
            {
                MessageBox.Show("Конец списка");
                _pageNumber--;
                return;
            }
            pageNumberTb.Text = _pageNumber.ToString();
            _result += 20;
        }


        
    }
}
