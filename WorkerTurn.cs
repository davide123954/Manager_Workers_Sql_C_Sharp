using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Managar_Work
{
    public partial class WorkerTurn : Form
    {
        System.Timers.Timer t;
        int hour, minute, second;
        public WorkerTurn()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            t.Start();
        }
        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(()=>
            {
                second += 1;
                if (second == 60)
                {
                    minute += 1;
                    second = 0;
                }
                if (minute == 60)
                {
                    hour += 1;
                    minute = 0;
                }
                txtShowTimer.Text = string.Format("{0}:{1}:{2}",hour.ToString().PadLeft(2,'0'),minute.ToString().PadLeft(2,'0'),second.ToString().PadLeft(2,'0'));   
            }));
            //throw new NotImplementedException();
        }
        private void label2_Click(object sender, EventArgs e) { }
        private void WorkerTurn_Load(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
            t.Start();
            //t.Stop();
           // Application.DoEvents();
        }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void txtID_TextChanged(object sender, EventArgs e) { }
        private void btnSure_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-LQU6CS6\\SQLEXPRESS;database=Workers;Integrated security=sspi");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Hour_Worker values(@ID,@Year,@Month,@Day,@TimeWorked)", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            cmd.Parameters.AddWithValue("@Year",comboBoxYear.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@Month", comboBoxMonth.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@Day", comboBoxDay.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@TimeWorked", txtShowTimer.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("ALL DETAILS OF YOUR TURN HAS BEEN SAVED WITH SUCCESS!!!");
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Welcome w1 = new Welcome();
            w1.Show();
        }
        private void label1_Click(object sender, EventArgs e) { }
        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            t.Stop();
        }
    }
}
