﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO.Ports;

namespace Mess_Bar_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            String[] strPortName = SerialPort.GetPortNames();
            foreach (string n in strPortName) 
            serialPort1.BaudRate = 9600;
            serialPort1.PortName = "COM3";
            serialPort1.Open();

        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
           
            cmd_ex();
            serialPort1.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {

            Close();
        }
      

        private void cmd_ex()
        {
            if (serialPort1.ReadExisting() == "133 6 56 187 0")
            {
               
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }
            else
            {
                MessageBox.Show(serialPort1.ReadExisting(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
