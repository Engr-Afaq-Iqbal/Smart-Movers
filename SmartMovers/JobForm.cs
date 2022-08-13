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
    public partial class JobForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RODO9FP\SQLEXPRESS;Initial Catalog=SmartMovers;Integrated Security=True");

        public JobForm()
        {
            InitializeComponent();
            fillcomboboxPaymentID();
            fillcomboboxCustomerID();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Job values ('" + txtJobID.Text + "','" + dateTimePicker1.Text + "','" + txtPaymentID.Text + "','" + txtCustomerID.Text + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Inserted Successfully", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void fillcomboboxPaymentID()
        {
            string sql = "Select * from Payment";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader myreader;
            try
            {
                conn.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string sname = myreader.GetString(0);
                    txtPaymentID.Items.Add(sname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        public void fillcomboboxCustomerID()
        {
            string sql = "Select * from Customer";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader myreader;
            try
            {
                conn.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string sname = myreader.GetString(0);
                    txtCustomerID.Items.Add(sname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Job set Job_Date = '" + dateTimePicker1.Text + "', ProductID = '" + txtPaymentID.Text + "',CustomerID = '" + txtCustomerID.Text + "' where JobID = '" + txtJobID.Text + "'";
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
                cmd.CommandText = "delete from Job where JobID = '" + txtJobID.Text + "'";
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
                SqlCommand cmd = new SqlCommand("Select * from Job where JobID = @parm1", conn);
                cmd.Parameters.AddWithValue("@parm1", txtJobID.Text);
                SqlDataReader reader1;
                reader1 = cmd.ExecuteReader();
                if (reader1.Read())
                {
                    MessageBox.Show("Job ID = " + reader1.GetValue(0).ToString() + "\n" + "Job Date = " + reader1.GetValue(1).ToString() + "\n" + "Payment ID = " + reader1.GetValue(2).ToString() + "\n" + "Customer ID = " + reader1.GetValue(3).ToString(), "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    MessageBox.Show("Record Not Found...", "Search Results", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
    }
}

