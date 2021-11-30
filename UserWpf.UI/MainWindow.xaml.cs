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
using UserWpf.ViewModel;

namespace UserWpf.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void newBtn_Click(object sender, RoutedEventArgs e)
        {
            NewEditWindow newWindow = new NewEditWindow();
            newWindow.DataContext = new NewEditWindowViewModel();
            newWindow.ShowDialog();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel viewModel = (MainWindowViewModel)DataContext;
            NewEditWindow editWindow = new NewEditWindow();
            editWindow.DataContext = new NewEditWindowViewModel(viewModel.CurrentUser);
            editWindow.ShowDialog();
        }


        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
