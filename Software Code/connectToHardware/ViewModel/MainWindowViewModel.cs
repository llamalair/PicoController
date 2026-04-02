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

// The ViewModel implements both the Mediator Design Pattern and the Observer Design Pattern 


// Mediator centralises communication between objects 
// So instead of View talking directly to Model , vice versa 
// Mediator acts as the middle man between them 
// Improve decoupling 
// Cause without a mediator, if the view talk to model there will be alot of dependency 

// Observable 


// essentially replacing the code behind ( the MainWindow.xaml.cs file ) 
// must use data binding 



namespace connectToHardware.ViewModel
{
    // the INotifyPropertyChanged is the IObservable Interface ( the interface that is being observe ) 
    // the ViewModel class acts like the concreateObservable which implements the IObservable interface 
    public class MainWindowViewModel : INotifyPropertyChanged // this class requrie that we implement a PropertyChanged event 

    {

        private Service service; // essentially create a new service 
        private PicoState pico = new PicoState();// create the state object 

        // command design pattern 
        
        public ICommand OnCommand { get;} // create the command that run on command 
        public ICommand OffCommand { get;} // create the commadn that run off command 

        // observe design pattern 
        public event PropertyChangedEventHandler? PropertyChanged; // this is an event ( an event is something that people can subscribe to and it will notify PropertyChanged when something change 

        // you want it to be already there so you get it at the start 
        public string ErrorMessage
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


        public MainWindowViewModel()
        {
            service = new Service();
            OnCommand = new RelayCommand(TurnOn);
            OffCommand = new RelayCommand(TurnOff);

        }


        private int count = 0;

        // two private method 
        private void TurnOn() 
        {
            
            if (RealStatus == "ON")
            {
                count++;
                ErrorMessage = "ALREADY ON ( NO MESSAGE SEND ) spam count =  " + count;
                return;
            }

            // always use .Trim() for seriel replies 

            RealStatus = service.LedOn().Trim(); // tell the service to run Led.On 
            ErrorMessage = "";
            count = 0;
            
            
            
            
        }

        private void TurnOff()
        {
            if (RealStatus == "OFF")
            {
                count++;
                ErrorMessage = "ALREADY OFF ( NO MESSAGE SENT ) spam count = " + count ;
                return;
            }

            RealStatus = service.LedOff().Trim(); // tell the service to run Led.On 
            ErrorMessage = "";
            count = 0;


        }

        //private string ReadMeFast()
        //{
        //    RealStatus = service.readMe();

        //}
    }
}
