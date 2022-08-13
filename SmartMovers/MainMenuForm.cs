using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartMovers
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm lf = new LoginForm();
            lf.Show();
            
        }

        private void btnDepots_Click(object sender, EventArgs e)
        {
            this.Close();
            DepotsForm dpf = new DepotsForm();
            dpf.Show();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            this.Close();
            CustomersForm ctf = new CustomersForm();
            ctf.Show();
        }

        private void btnJob_Click(object sender, EventArgs e)
        {
            this.Close();
            JobForm jbf = new JobForm();
            jbf.Show();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            this.Close();
            PaymentDetailsForm pdf = new PaymentDetailsForm();
            pdf.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            this.Close();
            Job_Load jbl = new Job_Load();
            jbl.Show();
        }

        private void btnTransport_Click(object sender, EventArgs e)
        {
            this.Close();
            TransportUnitForm tpf = new TransportUnitForm();
            tpf.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            this.Close();
            ProductForm pf = new ProductForm();
            pf.Show();
        }
    }
}
