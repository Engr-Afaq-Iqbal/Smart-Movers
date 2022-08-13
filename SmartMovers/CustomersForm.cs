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
    public partial class CustomersForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RODO9FP\SQLEXPRESS;Initial Catalog=SmartMovers;Integrated Security=True");

        public CustomersForm()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Customer set Customer_Name = '"+txtCustomerName.Text+"', Customer_Address = '"+txtCustomerAddress.Text+"' where CustomerID = '" + txtCustomerID.Text + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Updated Successfully", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Customer values ('" + txtCustomerID.Text + "','" + txtCustomerName.Text + "','"+txtCustomerAddress.Text+"')";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Customer where CustomerID = '" + txtCustomerID.Text + "'";
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
                SqlCommand cmd = new SqlCommand("Select * from Customer where CustomerID = @parm1", conn);
                cmd.Parameters.AddWithValue("@parm1", txtCustomerID.Text);
                SqlDataReader reader1;
                reader1 = cmd.ExecuteReader();
                if (reader1.Read())
                {
                    MessageBox.Show("Customer ID = " + reader1.GetValue(0).ToString() + "\n" + "Customer Name = " + reader1.GetValue(1).ToString() + "\n" + "Customer Address = " + reader1.GetValue(2).ToString(),"Search Results",MessageBoxButtons.OK,MessageBoxIcon.Information);


                }
                else
                {

                    MessageBox.Show("Record Not Found...","Search Results",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);

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
