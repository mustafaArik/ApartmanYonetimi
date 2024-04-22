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
    public partial class Form2 : Form
    {
        string u_id; // Veritabanındaki kimlik sütunu
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Apartman.mdb;");

        public Form2(string kimlik)
        {
            InitializeComponent();
            u_id = kimlik;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                string sorgu = "SELECT * FROM users WHERE kimlik = " + u_id;

                OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
                baglanti.Open();

                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();

                if (oku.GetValue(2).ToString() == textBox1.Text)
                {
                    string sql = "UPDATE users SET u_pass = '"+textBox3.Text+"' WHERE Kimlik = "+u_id;
                    
                    OleDbCommand kmt = new OleDbCommand(sql, baglanti);
                    kmt.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show(" paroal değişti..");

                }
                else
                {
                    MessageBox.Show("Mevcut paroal yanlış..");
                }



            }
        }
    }
}
