using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Globalization;
using SCE_Updater;
using System.Reflection;

namespace SpellforceCharacterEditor
{
    public partial class Form1 : Form, Updatable
    {
        static int ds = 0;
        const int PROCESS_WM_READ = 0x0010;
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess,
        int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        static extern int GetProcessId(IntPtr handle);


        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, 
          byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

        static Process process = Process.GetProcessesByName("Spellforce")[0];
        static IntPtr processHandle = OpenProcess(PROCESS_WM_READ, false, process.Id);
        static  int bytesRead = 0;
        static byte[] buffer = new byte[4];
        static byte[] buff2 = new byte[64];

        static int baseAddr = 0x00D644D0; //gold :)
        static int[] offsets = new int[5] { 0x10, 0x34, 0x8, 0xc, 0xbd };
        static int Address = baseAddr;

        public string ApplicationName
        {
            get
            {
                return "Spellforce Character Editor";
            }
        }

        public string ApplicationId
        {
            get
            {
                return "Spellforce Character Editor";
            }
        }

        public Assembly ApplicationAssembly
        {
            get
            {
                return Assembly.GetExecutingAssembly();
            }
        }

        public Icon ApplicationIcon
        {
            get
            {
                return this.Icon;
            }
        }

        public Uri UpdateXmlLocation
        {
            get
            {
                return new Uri("");
            }
        }

        public Form Context
        {
            get
            {
                return this;
            }
        }

        public Form1()
        {
            
            InitializeComponent();
          
            ReadProcessMemory((int)processHandle, Address, buffer, buffer.Length, ref bytesRead);

            for( int a=0; a< offsets.Length; a++) {

                Address = offsets[a] + BitConverter.ToInt32(buffer, 0);
                ReadProcessMemory((int)processHandle, Address, buffer, buffer.Length, ref bytesRead);
            }
            textBox_gold.Text = BitConverter.ToInt32(buffer, 0).ToString();


            Console.ReadLine();
            this.label2.Text = this.ApplicationAssembly.GetName().Version.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
            //int x = 0;
            //Int32.TryParse(textBox_gold.Text, out x);
            buff2 = System.Text.Encoding.ASCII.GetBytes(textBox_gold.Text);
            WriteProcessMemory((int)processHandle, Address, buff2, buff2.Length, ref ds);
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            //textBox1.Text = BitConverter.ToInt32(buff2, 0).ToString();
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            //textBox1.Text = BitConverter.ToInt32(buff2, 0).ToString();
        }
    }
}
