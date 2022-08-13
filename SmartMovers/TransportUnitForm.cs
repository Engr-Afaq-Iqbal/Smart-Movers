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
    public partial class TransportUnitForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RODO9FP\SQLEXPRESS;Initial Catalog=SmartMovers;Integrated Security=True");

        public TransportUnitForm()
        {
            InitializeComponent();
            fillcomboboxDepotID();
            fillcomboboxLoadID();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenuForm mmf = new MainMenuForm();
            mmf.Show();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into TransportUnit values ('" + txtDriverID.Text + "','" + txtAssisstantID.Text + "','" + cmbLocationID.Text + "','" + txtDepotID.Text + "','"+txtLoadID.Text+"')";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Inserted Successfully", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update TransportUnit set AssisstenetID = '" + txtAssisstantID.Text + "', Location = '" + cmbLocationID.Text + "', DepotID = '" + txtDepotID.Text + "', LoadID = '" + txtLoadID.Text + "' where DriverID = '" + txtDriverID.Text + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Updated Successfully", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from TransportUnit where DriverID = '" + txtDriverID.Text + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Deleted Successfully", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from TransportUnit where DriverID = @parm1", conn);
                cmd.Parameters.AddWithValue("@parm1", txtDriverID.Text);
                SqlDataReader reader1;
                reader1 = cmd.ExecuteReader();
                if (reader1.Read())
                {
                    MessageBox.Show("Driver ID = " + reader1.GetValue(0).ToString() + "\n" + "Assisstenet ID = " + reader1.GetValue(1).ToString() + "\n" + "Location = " + reader1.GetValue(2).ToString() + "\n" + "Depot ID = " + reader1.GetValue(3).ToString() + "\n" + "Load ID = " + reader1.GetValue(4).ToString(), "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    MessageBox.Show("Record Not Found...", "Search Results", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
        public void fillcomboboxDepotID()
        {
            string sql = "Select * from Depot";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader myreader;
            try
            {
                conn.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string sname = myreader.GetString(0);
                    txtDepotID.Items.Add(sname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
        public void fillcomboboxLoadID()
        {
            string sql = "Select * from Load";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader myreader;
            try
            {
                conn.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string sname = myreader.GetString(0);
                    txtLoadID.Items.Add(sname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
    }
}
