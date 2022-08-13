using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace SmartMovers
{
    public partial class LoginForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RODO9FP\SQLEXPRESS;Initial Catalog=SmartMovers;Integrated Security=True");
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlogging_Click(object sender, EventArgs e)
        {
            try
                {
                string query = "Select * from Logging Where Username = '" + txtUsername.Text.Trim() + "'and Password = '" + txtPassword.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query,conn);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if(dtbl.Rows.Count == 1)
                {
                    MainMenuForm mmf = new MainMenuForm();
                    this.Hide();
                    mmf.Show();
               
                }
                else
                {
                    MessageBox.Show("Enter correct Username or Password");

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
