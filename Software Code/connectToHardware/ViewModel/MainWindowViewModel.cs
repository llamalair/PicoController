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

        private Service service; // essentially create a new service 
        private PicoState pico = new PicoState();// create the state object 
        public ICommand OnCommand { get;} // create the command that run on command 
        public ICommand OffCommand { get;} // create the commadn that run off command 

        public event PropertyChangedEventHandler? PropertyChanged; // this is an event ( an event is something that people can subscribe to and it will notify PropertyChanged when something change 

        // you want it to be already there so you get it at the start 
        public string Status
        {
            get => pico.Status; // this runs when someone read the property , it will get the current status 
            set
            {
                //if (value != status)
                //{
                //    this.status = value;
                //    NotifyPropertyChanged();
                //}

                // is essentially the same thing as below if you create a helper method NotifyPropertyChanged() which implemenet PropertyChanged?.Invoke(this.new PropertyChange....)


                pico.Status = value; // then it will set the current status as this 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status))); // then notify the ui that the status is changed ( by raising PropertyChanged ) 
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


        

        // two private method 
        private void TurnOn() 
        {
            
            Status = "ON"; // update the model to run on 
            RealStatus = service.LedOn(); // tell the service to run Led.On 
        }

        private void TurnOff()
        {
            RealStatus = service.LedOff();
            Status = "OFF";
        }

        //private string ReadMeFast()
        //{
        //    RealStatus = service.readMe();

        //}
    }
}
