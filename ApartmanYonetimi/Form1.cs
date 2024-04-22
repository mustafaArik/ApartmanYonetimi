using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApartmanYonetimi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Apartman.mdb;");

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM users";

            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();

            OleDbDataReader oku = komut.ExecuteReader();


            while (oku.Read())
            {
                if (textBox1.Text == oku.GetValue(1).ToString() && textBox2.Text == oku.GetValue(2).ToString())
                {
                    Form2 frm = new Form2(oku.GetValue(0).ToString());
                    baglanti.Close();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya Parola Yanlış");
                }
            }

            baglanti.Close();
        }
    }
}
