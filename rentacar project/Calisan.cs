using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rentacar_project
{
    public partial class Calisan : Form
    {
        public Calisan()
        {
            InitializeComponent();
        }
        rentacarEntities con = new rentacarEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            SubedataGridview.Visible = false;
            dataGridView1.Visible = true;
            AracdataGridview.Visible = false;
            dataGridView1.DataSource = con.customers.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow column = dataGridView1.CurrentRow;
            textBox1.Tag = column.Cells["customerNo"].Value.ToString();
            textBox1.Text = column.Cells["customerNameSurname"].Value.ToString();
            textBox2.Text = column.Cells["customerPhone"].Value.ToString();
            textBox3.Text = column.Cells["customerAge"].Value.ToString();
            textBox4.Text = column.Cells["customerBalance"].Value.ToString();
            textBox5.Text = column.Cells["customerPayment"].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customer cust = new customer();
            cust.customerNameSurname = textBox1.Text;
            cust.customerAge = Convert.ToInt32(textBox3.Text);
            cust.customerPhone = textBox2.Text;
            cust.customerBalance = Convert.ToInt32(textBox4.Text);
            cust.customerPayment = Convert.ToInt32(textBox5.Text);
            con.customers.Add(cust);
            con.SaveChanges();
            MessageBox.Show("kayıt Başarılı");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            var update = con.customers.Where(x => x.customerNo == id).FirstOrDefault();
            update.customerNameSurname = textBox1.Text;
            update.customerPhone = textBox2.Text;
            update.customerAge =Convert.ToInt32( textBox3.Text);
            update.customerBalance = Convert.ToDecimal(textBox4.Text);
            update.customerPayment = Convert.ToDecimal(textBox5.Text);
            con.SaveChanges();
            dataGridView1.DataSource = con.customers.ToList();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);

            var deleteCustomer = con.customers.Where(a => a.customerNo == id).FirstOrDefault();
            con.customers.Remove(deleteCustomer);
            con.SaveChanges();
            dataGridView1.DataSource = con.customers.ToList();
        }

        private void Calisan_Load(object sender, EventArgs e)
        {

        }

        private void SubedataGridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SubedataGridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SubedataGridview.Visible = true;
            dataGridView1.Visible = false;
            AracdataGridview.Visible = false;
            SubedataGridview.DataSource = con.branches.ToList();
        }

        private void AracdataGridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void aracButton_Click(object sender, EventArgs e)
        {
            SubedataGridview.Visible = false;
            dataGridView1.Visible = false;
            AracdataGridview.Visible = true;
            AracdataGridview.DataSource = con.cars.ToList();
        }

        private void MusteriAra_Click(object sender, EventArgs e)
        {
            SubedataGridview.Visible = false;
            dataGridView1.Visible = true;
            AracdataGridview.Visible = false;

            dataGridView1.DataSource = con.customers.Where(x => x.customerNameSurname.Contains(textBox6.Text)).ToList();
        }
    }
}
