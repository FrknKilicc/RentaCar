using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rentacar_project
{
    public partial class musteriPage : Form
    {
        public musteriPage()
        {
            InitializeComponent();
        }
        rentacarEntities con = new rentacarEntities();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow column = dataGridView1.CurrentRow;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            subeDataGridView.Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.DataSource = con.cars.ToList();
        }

        private void SubeButton_Click(object sender, EventArgs e)
        {
            subeDataGridView.Visible = true;
            dataGridView1.Visible = false;
            subeDataGridView.DataSource = con.branches.ToList();
        }

        private void markaAraButton_Click(object sender, EventArgs e)
        {
            subeDataGridView.Visible = false;
            dataGridView1.Visible = true;

            dataGridView1.DataSource = con.cars.Where(x => x.carBrand.Contains(textBox6.Text)).ToList();
        }

        private void musteriPage_Load(object sender, EventArgs e)
        {
            yoneticiKadi yont = new yoneticiKadi();

            var query = from user in con.customers where user.customerNo == yoneticiKadi.ıd select user;
            foreach (var item in query)
            {
                textBox1.Tag = item.customerNo;
                textBox1.Text = item.customerNameSurname;
                textBox2.Text = item.customerPhone;
                textBox3.Text = item.customerAge.ToString();
                textBox4.Text = item.customerBalance.ToString();
                textBox5.Text = item.customerPayment.ToString();

                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                


            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 5)
            {

                dataGridView1.DataSource = con.cars.Where(x => x.carBrand.Contains(textBox6.Text)).ToList();
                //Şube Adına Göre 
            }

        }

        private void subeDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
