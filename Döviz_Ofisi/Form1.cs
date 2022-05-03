using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Döviz_Ofisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmdosya = new XmlDocument();
            xmdosya.Load(bugun);

            string dolaralis = xmdosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            LblDolarAlis.Text = dolaralis;
            string dolarsatis = xmdosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            LblDolarSatis.Text = dolarsatis;

            string euroalis = xmdosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            LblEuroAlis.Text = euroalis;

            string eurosatis = xmdosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            LblEuroSatis.Text = eurosatis;

        }

        private void BtnDolarAl_Click(object sender, EventArgs e)
        {
            Txtkur.Text = LblDolarAlis.Text;
            TxtMiktar.Text = "";
            TxtTutar.Text = "";
            TxtKalan.Text = "";
        }

        private void BtnDolarSat_Click(object sender, EventArgs e)
        {
            Txtkur.Text = LblDolarSatis.Text;
            TxtMiktar.Text = "";
            TxtTutar.Text = "";
            TxtKalan.Text = "";
        }

        private void BtnEuroAl_Click(object sender, EventArgs e)
        {
            Txtkur.Text = LblEuroAlis.Text;
            TxtMiktar.Text = "";
            TxtTutar.Text = "";
            TxtKalan.Text = "";
        }

        private void BtnEuroSat_Click(object sender, EventArgs e)
        {
            Txtkur.Text = LblEuroSatis.Text;
            TxtMiktar.Text = "";
            TxtTutar.Text = "";
            TxtKalan.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur = Convert.ToDouble(Txtkur.Text);
            miktar = Convert.ToDouble(TxtMiktar.Text);
            tutar = kur * miktar;
            TxtTutar.Text = tutar.ToString();
        }

        private void Txtkur_TextChanged(object sender, EventArgs e)
        {
            Txtkur.Text = Txtkur.Text.Replace(".", ",");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            double kur = Convert.ToDouble(Txtkur.Text);
            int miktar = Convert.ToInt32(TxtMiktar.Text);
            int tutar = Convert.ToInt32(miktar / kur);

            TxtTutar.Text = tutar.ToString();
            double kalan;
            kalan = miktar % kur;
            TxtKalan.Text = kalan.ToString();
        }
    }
}
