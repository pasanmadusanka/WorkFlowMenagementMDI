using FuelApp.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace FuelApp.Views
{
    public partial class SMS_Sender : Form
    {
        string lastUser=Properties.Settings.Default.LastUser;
        string[] ports = SerialPort.GetPortNames();
        SMS_DbAccess dba = new SMS_DbAccess();

        public void GetDeptCat()
        {
            DataTable dt = dba.FillEmpCat();
            CmbDeptCat.DisplayMember = "catagory";
            CmbDeptCat.DataSource = dt;
        }
        public SMS_Sender()
        {
            InitializeComponent();
            LblUser.Text = lastUser.ToUpper();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            DataTable dt = dba.FillEmployeeNumbers(CmbDeptCat.Text);
            //1
            //string[] array = dt
            //     .AsEnumerable()
            //     .Select(row => row.Field<string>("Number"))
            //     .ToArray();
            //2
            //List<string> list = new List<string>();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    string rowAsString = string.Join(", ", dt.Rows[i].ItemArray);
            //    list.Add(rowAsString);
            //}
            //string[] array = list.ToArray();
            
            //3
            string[] array = new string[dt.Columns.Count];
            DataRow dr = dt.Rows[0];
            for (int i = 0; i < dr.ItemArray.Length; i++)
            {
                array[i] = dr[i].ToString();
            }

            Console.WriteLine("The following serial ports were found:");
            try
            {
                // Display each port name to the console. 
                foreach (string port in ports)
                {
                    try
                    {
                        foreach (string numbers in array)
                        {
                            try
                            {
                                if (sendSMS(port, numbers, TxtSubject.Text + "-" + TxtMessage.Text.ToString()))
                                {
                                    //MessageBox.Show("Message Send Sucessfully to "+ num + "....!");
                                    Console.WriteLine("Message Send Sucessfully to " + numbers + "....!");
                                }
                                else
                                {
                                    MessageBox.Show("Problem With Senind Message to " + numbers + "....!");
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show("Problem With Numbers!. " + ex.ToString()); }
                        }
                        MessageBox.Show("Message Send Sucessfully....!");
                    }
                    catch
                    { MessageBox.Show("Problem"); }
                    Console.WriteLine(port);
                }
            }
            catch
            {
                MessageBox.Show("Sending");
            }
            try
            {
                foreach (string numbers in array)
                {
                    if (dba.SaveMessageDetails(dba.GetLastIndex(), TxtSubject.Text, numbers, TxtMessage.Text))
                    {
                        Console.WriteLine("Record " + numbers + " Sucessfully Added...!");
                    }

                    else
                    {
                        MessageBox.Show("Sorry Somthing is Wrong!");
                    }
                }
                MessageBox.Show("Record Saved Sucessfully....!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool sendSMS(string port, string phoneno, string msg)
        {
            bool status = false;
            try
            {
                System.IO.Ports.SerialPort sport = new System.IO.Ports.SerialPort();
                sport.PortName = port;
                sport.BaudRate = 9600;
                sport.DataBits = 8;
                sport.StopBits = StopBits.One;
                sport.Parity = Parity.None;
                sport.Open();
                sport.Write(@"AT+CMGF=1" + (char)(13));
                sport.Write(@"AT+CMGS=" + (char)(34) + phoneno + (char)(34) + (char)(13));
                sport.Write(@msg + (char)(13) + (char)(26));
                sport.Close();
                status = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return status;
        }

        private void GetComPort()
        {
            foreach (string port in ports)
            {
                try
                {
                    CmbNumberList.Items.Add(port);
                }
                catch (Exception ex)
                { MessageBox.Show(port + " has a issue " + ex.ToString()); }
            }
        }

        
        private void CmbDeptCat_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataTable dt = dba.FillEmployeeNumbers(CmbDeptCat.Text);
            CmbNumberList.DisplayMember = "Number";
            CmbNumberList.DataSource = dt;
        }

        private void SMS_Sender_Load_1(object sender, EventArgs e)
        {
            //GetComPort();

            GetDeptCat();
            TxtNumber.Text = CmbDeptCat.Text.ToString();
        }
    }
}
