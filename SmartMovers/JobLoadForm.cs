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
    public partial class Job_Load : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RODO9FP\SQLEXPRESS;Initial Catalog=SmartMovers;Integrated Security=True");

        public Job_Load()
        {
            InitializeComponent();
            fillcomboboxProductID();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Load values ('" + txtLoadID.Text + "','" + cmbLoadType.Text + "','" + txtProductID.Text + "','" + txtJobID.Text + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Inserted Successfully","Confirmation Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenuForm mmf = new MainMenuForm();
            mmf.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Load set Load_Type = '" + cmbLoadType.Text + "', ProductID = '" + txtProductID.Text + "',JobID = '"+txtJobID.Text+"' where LoadID = '" + txtLoadID.Text + "'";
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
                cmd.CommandText = "delete from Load where LoadID = '" + txtLoadID.Text + "'";
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
                SqlCommand cmd = new SqlCommand("Select * from Load where LoadID = @parm1", conn);
                cmd.Parameters.AddWithValue("@parm1", txtLoadID.Text);
                SqlDataReader reader1;
                reader1 = cmd.ExecuteReader();
                if (reader1.Read())
                {
                    MessageBox.Show("Load ID = " + reader1.GetValue(0).ToString() + "\n" + "Load Type = " + reader1.GetValue(1).ToString() + "\n" + "Product ID = " + reader1.GetValue(2).ToString()+"\n"+ "Load ID = " + reader1.GetValue(3).ToString(), "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void fillcomboboxProductID()
        {
            string sql = "Select * from Product";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader myreader;
            try
            {
                conn.Open();
                myreader = cmd.ExecuteReader();
                while(myreader.Read())
                {
                    string sname = myreader.GetString(0);
                    txtProductID.Items.Add(sname);
                }
            }
            catch(Exception ex)
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
                    txtJobID.Items.Add(sname);
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
