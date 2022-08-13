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
    public partial class ProductForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RODO9FP\SQLEXPRESS;Initial Catalog=SmartMovers;Integrated Security=True");

        public ProductForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                cmd.CommandText = "insert into Product values ('" + txtProductID.Text + "','" + txtProductName.Text + "','" + cmbProductType.Text + "')";
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
                cmd.CommandText = "update Product set Product_Name = '" + txtProductName.Text + "', Product_Type = '" + cmbProductType.Text + "' where ProductID = '" + txtProductID.Text + "'";
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
                cmd.CommandText = "delete from Product where ProductID = '" + txtProductID.Text + "'";
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
                SqlCommand cmd = new SqlCommand("Select * from Product where ProductID = @parm1", conn);
                cmd.Parameters.AddWithValue("@parm1", txtProductID.Text);
                SqlDataReader reader1;
                reader1 = cmd.ExecuteReader();
                if (reader1.Read())
                {
                    MessageBox.Show("Product ID = " + reader1.GetValue(0).ToString() + "\n" + "Product_Name = " + reader1.GetValue(1).ToString() + "\n" + "Product_Type = " + reader1.GetValue(2).ToString() , "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
    }

