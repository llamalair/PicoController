using connectToHardware.ViewModel;
using System.IO.Ports;
using System.Windows;

namespace connectToHardware

{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            // so everytime our main window is constructed , a view model is constructed for it
            var vm = new MainWindowViewModel();
            DataContext = vm; // essentially what is it saying is that when the .xaml file ask for any commands or properties create a viewmodel
            // delegate all task to MainWindowViewModel 
        }


    }
}