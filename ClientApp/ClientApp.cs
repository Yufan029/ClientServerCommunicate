using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using ServerClass;

namespace ClientApp
{
    class ClientApp
    {
        static void Main(string[] args)
        {
            TcpChannel chan = new TcpChannel();
            ChannelServices.RegisterChannel(chan);

            myRemoteClass obj = (myRemoteClass) Activator.GetObject(typeof(myRemoteClass), "tcp://localhost:8085/RemoteTest");

            if (obj == null)
            {
                Console.WriteLine("Could not locate server");
            }
            else if (obj.SetString("Sending String to Server"))
            {
                System.Console.WriteLine("Success: Check the other console to verify.");
            }
            else
            {
                System.Console.WriteLine("Sending the test string has failed.");
            }

            Console.WriteLine("Hit <enter> to exit...");
            Console.ReadLine();
        }
    }
}
