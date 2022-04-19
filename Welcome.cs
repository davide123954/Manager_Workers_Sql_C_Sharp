using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Managar_Work
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }
        private void txtUser_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void Welcome_Load(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ((txtUser.Text == "Igor" && txtPassword.Text == "12543IgorPS") ||(txtUser.Text=="Stav" && txtPassword.Text=="12354StavPs"||(txtUser.Text=="Davide"&& txtPassword.Text=="123458DavidePs")))
            {
                MessageBox.Show("WELCOME BACK MANAGER :)");
                Form1 f1 = new Form1();
                f1.Closed += (s, args) => this.Close();
                f1.Show();
            }
            else if(txtUser.Text=="@WorkerIntel770" && txtPassword.Text == "@WorkerIntel770")
            {
                MessageBox.Show("WELCOME BACK Worker :)");
                WorkerTurn w1 = new WorkerTurn();
                w1.Closed += (s, args) => this.Close();
                w1.Show();
            }
            else
                MessageBox.Show("ERROR!!!!!!!PLEASE INSERT YOUR CORRECT ID AND NAME");
        }
        private void Check()
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-LQU6CS6\\SQLEXPRESS;database=Workers;Integrated security=sspi");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from table_Workers where Name=@Name", con);
            cmd.Parameters.AddWithValue("@Name", txtUser.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
