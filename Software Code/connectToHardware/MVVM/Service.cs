
using System.IO.Ports;


namespace connectToHardware.MVVM
{
    class Service
    // responsible for actual hardware connection 
    {
        private SerialPort raspberryConnection; // like the attribute in OOP 
        public string result;

        public Service() {

            // SerialPort(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits) full constructor is this , but you only need the portName 
            // you can set it by _serialPort.PortName = COM6 also
            raspberryConnection = new SerialPort("COM6") // first one is port name
            {
                // these are the properties of type SerialPort https://learn.microsoft.com/en-us/dotnet/api/system.io.ports.serialport.dtrenable?view=net-10.0-pp
                // you only need DtrEnable set to True as the default properties all work 
                DtrEnable = true, // data terminal ready 
                RtsEnable = true,
                ReadTimeout = 2000
                // reason we need this to set to true instead of false is because if its false the data wont be sent 
                // do we need to set it to true for it to be able to send it 
            };
            raspberryConnection.Open();
        }

        public string LedOn() 
        {
            // writeline is one of SerialPort method 
            raspberryConnection.WriteLine("1"); // you write 1 into the connnection  https://learn.microsoft.com/en-us/dotnet/api/system.io.ports.serialport.writeline?view=net-10.0-pp&utm_
            result = raspberryConnection.ReadLine();
            return result;
        }

        public string LedOff()
        {
            raspberryConnection.WriteLine("0"); // vice versa 
            result = raspberryConnection.ReadLine();
            return result;
        }

        // to read the status of the raspberrypi 
        //

        // for model in the future 
        //public static void Read()

        //{
        //    raspberryConnection.ReadLine();

        //}

        // for in the future 
        public string readMe()
        {
            result = raspberryConnection.ReadLine();
            return result;
        }
    }

}
