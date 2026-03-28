using System.ComponentModel;

namespace connectToHardware.Model
{
    // model only holds the status
    // so if its turn on it will be "ON"
    public class PicoState 
    {
        public string Status { get; set; } = "OFF";
        public string RealStatus {  get; set; } = string.Empty;



        // 
    }
}
