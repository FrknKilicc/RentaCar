using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rentacar_project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new yoneticiKadi());


            //rentacar proje

            //musteri,araç,personel,şube
            //personel girişi ve müşteri girişi olacak
            //personel tüm sayfada işlem yapacak
            //müşteri sadece araçlar ve şubeler sayfasına erişim sağlayabilecek birde ektrapaket özelliği isterse müşteri baska form sayfasına yönlendirip ekstra tablosunnda veriler tutulacak

            //müşteriler
            //müşteriNo
            //müşteriAdSoyad
            //
        }
    }
}
