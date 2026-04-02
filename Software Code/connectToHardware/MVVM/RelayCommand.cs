using connectToHardware.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

// RelayCommand utilises the command design pattern 
// Essentially it turns a command into an object 
// This way you can pass the command around, stored, queued, logged, or undone.

// The GoF Command pattern encapsulates a request as an object, allowing requests to be parameterized, queued, logged, and undone, 
// while decoupling the sender of the request from the receiver that performs it.

namespace connectToHardware.MVVM
{
    // RelayCommand is essentially just a generic wrapper around a method 
    public class RelayCommand : ICommand 
    // create a class RelayCommand that implements the interface ICommand 
    // the interface consists of three method 
    // Execute 
    // CanExecute
    // CanExecuteChanged 

    // all three must be implemented for it to works 
    {
       
        private readonly Action _execute;

        public RelayCommand(Action execute) // when you call this method with new RelayCommand(LedOn) the LedOn is the execute 
        {
            _execute = execute;
        }

        public void Execute(object? parameter) // when the user press the button this section will be executed 
        {
            _execute();
        }

        public bool CanExecute(object parameter)
        {
            // will need to update it to cant press it when its already on 
            return true;
        }

        public event EventHandler? CanExecuteChanged;

    }
}
