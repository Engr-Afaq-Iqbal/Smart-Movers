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
    public partial class DepotsForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RODO9FP\SQLEXPRESS;Initial Catalog=SmartMovers;Integrated Security=True");
        public DepotsForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenuForm mmf = new MainMenuForm();
            mmf.Show();
            
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Depot values ('" + txtDepotNumber.Text + "','" + comboLocation.Text + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Entered Successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboLocation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
