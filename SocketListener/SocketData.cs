using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketListener
{
    public class SocketData
    {
        public string Data { get; set; }
    }

    public class SensorData
    {
        public int Temperature { get; set; }
        public int Speed { get; set; }
        public string State { get; set; }
    }
}
