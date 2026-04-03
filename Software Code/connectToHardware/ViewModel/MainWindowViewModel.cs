using connectToHardware.Model;
using connectToHardware.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

// essentially replacing the code behind ( the MainWindow.xaml.cs file ) 
// must use data binding 

namespace connectToHardware.ViewModel
{
    
    public class MainWindowViewModel : INotifyPropertyChanged // this class requrie that we implement a PropertyChanged event 

    {

        private Service service; // declares a variable 
        private PicoState pico = new PicoState();// create the state object 
        public ICommand BOnCommand { get;} // create the command that run on command 
        public ICommand BOffCommand { get;} // create the commadn that run off command 
        public ICommand ROnCommand { get; } // create the command that run on command 
        public ICommand ROffCommand { get; } // create the commadn that run off command 
        public ICommand YOnCommand { get; } // create the command that run on command 
        public ICommand YOffCommand { get; } // create the commadn that run off command 

        public event PropertyChangedEventHandler? PropertyChanged; // this is an event ( an event is something that people can subscribe to and it will notify PropertyChanged when something change 

        public MainWindowViewModel()
        {
            BOnCommand = new RelayCommand(BTurnOn);
            BOffCommand = new RelayCommand(BTurnOff);
            ROnCommand = new RelayCommand(RTurnOn);
            ROffCommand = new RelayCommand(RTurnOff);
            YOnCommand = new RelayCommand(YTurnOn);
            YOffCommand = new RelayCommand(YTurnOff);
            service = new Service();
        }
        
        private int count = 0;

        // two private method 
        private void BTurnOn() 
        {
            
            if (RealStatus == "BlueLedIsOn")
            {
                count++;
                ErrorMessage = "ALREADY ON ( NO MESSAGE SEND ) spam count =  " + count;
                return;
            }

            // always use .Trim() for seriel replies 

            RealStatus = service.BLedOn().Trim(); // tell the service to run Led.On 
            ErrorMessage = "";
            count = 0;
                      
            
        }

        private void BTurnOff()
        {
            if (RealStatus == "BlueLedIsOff")
            {
                count++;
                ErrorMessage = "ALREADY OFF ( NO MESSAGE SENT ) spam count = " + count ;
                return;
            }

            RealStatus = service.BLedOff().Trim(); // tell the service to run Led.On 
            ErrorMessage = "";
            count = 0;


        }

        private void RTurnOn()
        {

            if (RealStatus == "RedLedIsOn")
            {
                count++;
                ErrorMessage = "ALREADY ON ( NO MESSAGE SEND ) spam count =  " + count;
                return;
            }

            // always use .Trim() for seriel replies 

            RealStatus = service.RLedOn().Trim(); // tell the service to run Led.On 
            ErrorMessage = "";
            count = 0;


        }

        private void RTurnOff()
        {
            if (RealStatus == "RedLedIsOff")
            {
                count++;
                ErrorMessage = "ALREADY OFF ( NO MESSAGE SENT ) spam count = " + count;
                return;
            }

            RealStatus = service.RLedOff().Trim(); // tell the service to run Led.On 
            ErrorMessage = "";
            count = 0;


        }

        private void YTurnOn()
        {

            if (RealStatus == "YellowLedIsOn")
            {
                count++;
                ErrorMessage = "ALREADY ON ( NO MESSAGE SEND ) spam count =  " + count;
                return;
            }

            // always use .Trim() for seriel replies 

            RealStatus = service.YLedOn().Trim(); // tell the service to run Led.On 
            ErrorMessage = "";
            count = 0;


        }

        private void YTurnOff()
        {
            if (RealStatus == "YellowLedIsOff")
            {
                count++;
                ErrorMessage = "ALREADY OFF ( NO MESSAGE SENT ) spam count = " + count;
                return;
            }

            RealStatus = service.YLedOff().Trim(); // tell the service to run Led.On 
            ErrorMessage = "";
            count = 0;


        }

        //private string ReadMeFast()
        //{
        //    RealStatus = service.readMe();
        //}

        public string ErrorMessage // this is just a variable call error message its so complicated cause you set it with property 
        {
            get => pico.ErrorMessage; // this runs when someone read the property , it will get the current status 
            set
            {
                //if (value != status)
                //{
                //    this.status = value;
                //    NotifyPropertyChanged();
                //}

                // is essentially the same thing as below if you create a helper method NotifyPropertyChanged() which implemenet PropertyChanged?.Invoke(this.new PropertyChange....)


                pico.ErrorMessage = value; // then it will set the current status as this 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ErrorMessage))); // then notify the ui that the status is changed ( by raising PropertyChanged ) 
            }
        }

        public string RealStatus
        {
            get => pico.RealStatus; //y you read the real result from there 
            set
            {
                //if (value != status)
                //{
                //    this.status = value;
                //    NotifyPropertyChanged();
                //}

                // is essentially the same thing as below if you create a helper method NotifyPropertyChanged() which implemenet PropertyChanged?.Invoke(this.new PropertyChange....)


                pico.RealStatus = value; // then it will set the current status as this 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RealStatus))); // then notify the ui that the status is changed ( by raising PropertyChanged ) 
            }
        }

    }
}
