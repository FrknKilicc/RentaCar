using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace rentacar_project
{
    public partial class yoneticiKadi : Form
    {
        public yoneticiKadi()
        {
            InitializeComponent();
        }
        rentacarEntities con = new rentacarEntities();

        private void yoneticiKadi_Load(object sender, EventArgs e)
        {
           
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (radioButton1.Checked == true)
                {
                    YoneticiGirisPanel.Show();
                    MusteriGirisPanel.Hide();


                }
                else if (radioButton1.Checked == false)
                {
                    YoneticiGirisPanel.Hide();
                    MusteriGirisPanel.Show();
                }


            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                if (radioButton2.Checked == true)
                {

                    YoneticiGirisPanel.Hide();
                    MusteriGirisPanel.Show();
                }
                else if (radioButton2.Checked == false)
                {

                    YoneticiGirisPanel.Show();
                    MusteriGirisPanel.Hide();
                }

            }
        }
        public bool LoginYonetici(string userr, string pw)
        {
            var query = from user in con.employees where user.employeeNameSurname == userr && user.empoloyeePw == pw select user;
            if (query.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool LoginCustomer(string userr, string pw)
        {
            var query = from user in con.customers where user.customerNameSurname == userr && user.customerPW == pw select user;
            if (query.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Giris_Click(object sender, EventArgs e)
        {
            if (LoginYonetici(textBox1.Text, yoneticiSifre.Text))
            {
                Calisan cal = new Calisan();
                cal.Show();
                MessageBox.Show("Giriş Başarılı ");

            }
            else
            {
                MessageBox.Show("Giriş Başarısız ");
            }
        }
        public static string kad;
        public static int ıd;
        private void Giris2_Click(object sender, EventArgs e)
        {
            if (LoginCustomer(MusteriKadi.Text, MusteriSifre.Text))
            {
                
               
                yoneticiKadi check = new yoneticiKadi();
                musteriPage musteri = new musteriPage();
                customer cust = new customer();
                
                var query = from user in con.customers where user.customerNameSurname == MusteriKadi.Text && user.customerPW == MusteriSifre.Text select user.customerNo;


                if (query.Any())
                {
                    foreach (var item in query)
                    {
                        ıd = Convert.ToInt32(item);
                    }
                   
                   kad = MusteriKadi.Text;

                }
                else
                {
                    musteri.textBox1.Text = MusteriKadi.Text;
                }
                


                ///////

                musteriPage cal1 = new musteriPage();
                cal1.Show();
                MessageBox.Show("Giriş Başarılı ");
            }
            else
            {
                MessageBox.Show("Giriş Başarısız ");
            }
        }
    }
}
