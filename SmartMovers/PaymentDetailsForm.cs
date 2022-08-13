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
    public partial class PaymentDetailsForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RODO9FP\SQLEXPRESS;Initial Catalog=SmartMovers;Integrated Security=True");
        string g;
        public PaymentDetailsForm()
        {
            InitializeComponent();
            fillcomboboxLoadID();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                g = "Category1";
            }
            else if(radioButton2.Checked==true)
            {
                g = "Category2";
            }
            else
            {
                g = "Category3";
            }
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Payment values ('" + txtPaymentID.Text + "','" + txtCustomerID.Text + "','" + g + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Inserted Successfully", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void fillcomboboxLoadID()
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
            if (radioButton1.Checked == true)
            {
                g = "Category1";
            }
            else if (radioButton2.Checked == true)
            {
                g = "Category2";
            }
            else
            {
                g = "Category3";
            }

            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Payment set CustomerID = '" + txtCustomerID.Text + "', Customer_Category = '" + g + "' where PaymentID = '" + txtPaymentID.Text + "'";
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
                cmd.CommandText = "delete from Payment where PaymentID = '" + txtPaymentID.Text + "'";
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
                SqlCommand cmd = new SqlCommand("Select * from Payment where PaymentID = @parm1", conn);
                cmd.Parameters.AddWithValue("@parm1", txtPaymentID.Text);
                SqlDataReader reader1;
                reader1 = cmd.ExecuteReader();
                if (reader1.Read())
                {
                    MessageBox.Show("Payment ID = " + reader1.GetValue(0).ToString() + "\n" + "Customer  ID = " + reader1.GetValue(1).ToString() + "\n" + "Customer Category = " + reader1.GetValue(2).ToString(), "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void PaymentDetailsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
