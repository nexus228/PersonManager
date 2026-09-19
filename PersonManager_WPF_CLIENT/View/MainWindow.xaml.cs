using PersonManager_WPF_CLIENT.Model;
using PersonManager_WPF_CLIENT.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PersonManager_WPF_CLIENT.View
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


        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is MainWindowViewModel viewModel && ((DataGrid)sender).SelectedItem is Person person)
            {
                if (viewModel.ShowPersonDetailsCommand.CanExecute(person))
                {
                    viewModel.ShowPersonDetailsCommand.Execute(person);
                }
            }
        }
    }
}