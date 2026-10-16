using PersonManager_WPF_CLIENT.Model;
using PersonManager_WPF_CLIENT.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

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

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("MainWindow_Loaded");
            if (DataContext != null && DataContext is MainWindowViewModel vm)
            {
                vm.NewPersonAdded += MainViewModel_NewPersonAdded;
            }
        }

        private void MainViewModel_NewPersonAdded(object? sender, Person person)
        {
            Dispatcher.BeginInvoke(() =>
            {
                PersonsDataGrid.ScrollIntoView(person);
                PersonsDataGrid.UpdateLayout();

                if (PersonsDataGrid.ItemContainerGenerator
                    .ContainerFromItem(person) is DataGridRow row)
                {
                   
                    var brush = (SolidColorBrush)FindResource("BtnBackgroundColor");
                   
                    row.Background = brush.Clone();

                    var animation = new ColorAnimation
                    {
                        To = Colors.White,
                        Duration = TimeSpan.FromSeconds(1.5)
                    };

                    animation.Completed += (_, _) =>
                    {
                        row.ClearValue(DataGridRow.BackgroundProperty);
                    };

                    brush = (SolidColorBrush)row.Background;
                    brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                }
            }, DispatcherPriority.Loaded);
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