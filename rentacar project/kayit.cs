using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace rentacar_project
{
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }

        rentacarEntities con = new rentacarEntities();

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (radioButton1.Checked == true)
                {
                    YoneticiKayitPanel.Show();
                    MusteriKayitPanel.Hide();


                }
                else if (radioButton1.Checked == false)
                {
                    YoneticiKayitPanel.Hide();
                    MusteriKayitPanel.Show();
                }


            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                if (radioButton2.Checked == true)
                {

                    YoneticiKayitPanel.Hide();
                    MusteriKayitPanel.Show();
                }
                else if (radioButton2.Checked == false)
                {

                    YoneticiKayitPanel.Show();
                    MusteriKayitPanel.Hide();
                }

            }
        }


        private void kayit2_Click(object sender, EventArgs e)
        {

           

            customer cust = new customer();
            cust.customerNameSurname = MusteriKadi.Text;
            cust.customerPW = MusteriSifre.Text;
            con.customers.Add(cust);
            con.SaveChanges();
            MessageBox.Show("Kayıt Başarılı");

        }

        private void kayit1_Click(object sender, EventArgs e)
        {
            employee emp = new employee();
            emp.employeeNameSurname = textBox1.Text;
            emp.empoloyeePw = yoneticiSifre.Text;
            con.employees.Add(emp);
            con.SaveChanges();
            MessageBox.Show("Kayıt Başarılı");
        }

        private void kayit_Load(object sender, EventArgs e)
        {

        }
    }
}
