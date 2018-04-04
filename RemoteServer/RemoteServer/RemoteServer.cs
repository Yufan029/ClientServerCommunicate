using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace RemoteServer
{
    class RemoteServer
    {
        static void Main(string[] args)
        {
            // https://support.microsoft.com/en-us/help/307600/how-to-marshal-an-object-to-a-remote-server-by-reference-by-using-visu
            TcpChannel chan = new TcpChannel(8085);
            ChannelServices.RegisterChannel(chan);

            RemotingConfiguration.RegisterWellKnownServiceType(
                Type.GetType("ServerClass.myRemoteClass, ServerClass") ?? throw new InvalidOperationException(),
                "RemoteTest",
                WellKnownObjectMode.SingleCall);

            Console.WriteLine("Hit <enter> to exit...");
            Console.ReadLine();
        }
    }
}
