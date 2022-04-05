using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItTool
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            label1.Text = "IP";
            label2.Text = nameip();
            label3.Text = "MAC";
            label4.Text = namemac();
            label5.Text = "USER";
            label6.Text = nameuser();
            label7.Text = "COMP.";
            label8.Text = namehost();
            label9.Text = "Ping";
            label10.Text =  updown();
       

        }

        public static string nameip()
        {
            var host = System.Net.Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public static String namehost()
        {
            //strComputerName = Environment.MachineName.ToString();
            string name ="";
            name = Environment.MachineName.ToString();
            return name;
        }
        public static String nameuser()
        {
            string domain = "";
            domain = Environment.UserName.ToString();
            return domain;
        }
        public static string namemac()
        {

            String mac = "";
             mac = NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString();    
          


            return mac;


        }
 


        private void Form1_Load(object sender, EventArgs e)
        {


        }

        public static string updown()
        {
            string updown = "";
            Ping ping = new Ping();
            PingReply cevap = ping.Send("www.google.com");
            if(cevap.Status==IPStatus.Success)
            {
                updown = "Success";
                return updown;
            }
            else {

                updown = "Fail";
                return updown;

            }


            return updown;
        
        }
 
    }
}
