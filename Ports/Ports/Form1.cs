using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ports
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();

            // Retrieve the list of active TCP connections
            TcpConnectionInformation[] tcpConnections = ipGlobalProperties.GetActiveTcpConnections();

            // Retrieve the list of active TCP listeners
            //TcpListener[] tcpListeners = ipGlobalProperties.GetActiveTcpListeners();
            IPEndPoint[] tcpListeners = ipGlobalProperties.GetActiveTcpListeners();

            for (int i = 0; i < tcpListeners.Length; i++)
            {
                int portNumber = tcpListeners[i].Port;
                listBox1.Items.Add($"TCP Port {portNumber}");
            }

            // Retrieve the list of active UDP listeners
            IPEndPoint[] udpListeners = ipGlobalProperties.GetActiveUdpListeners();

            // Create a list to store the open port information
            List<string> openPorts = new List<string>();

            // Add the TCP connections to the list
            foreach (TcpConnectionInformation tcpConnection in tcpConnections)
            {
                openPorts.Add($"TCP {tcpConnection.LocalEndPoint.Port}: {tcpConnection.State}");
            }

            // Add the TCP listeners to the list
           /* foreach (TcpListener tcpListener in tcpListeners)
            {

                openPorts.Add($"TCP {tcpListener.Server.LocalEndPoint.Port}: Listening");
            }*/

            // Add the UDP listeners to the list
            foreach (IPEndPoint udpListener in udpListeners)
            {
                openPorts.Add($"UDP {udpListener.Port}: Listening");
            }

            // Display the list of open ports in a ListBox
            listBox1.DataSource = openPorts;
        }

        


    }
}
