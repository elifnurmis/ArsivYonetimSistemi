using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ArşivOtomasyonProjesi
{
    public partial class EmanetEkranı : Form
    {
        public EmanetEkranı()
        {
            InitializeComponent();
        }
        static string connectionString = "Server=172.21.54.148;Port=3306;Database=NYP23-19;User=NYP23-19;Password=Uludag9512357.;";
        MySqlConnection connection = new MySqlConnection(connectionString);


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("Bağlantı başarılı.");
                    // Bağlantı açık olduğunda yapılacak işlemler buraya yazılabilir.

                    MySqlCommand cmd = new MySqlCommand("insert into TabloEmanet(TC,Telefon,AlınanRaf,TeslimEdilenRaf) Values(@p1,@p2,@p3,@p4)");
                    cmd.Parameters.AddWithValue("@p1", textBoxTC.Text);
                    cmd.Parameters.AddWithValue("@p2", textBoxTelefon.Text);
                    cmd.Parameters.AddWithValue("@p3", textBoxAlınanRaf.Text);
                    cmd.Parameters.AddWithValue("@p4", textBoxTeslimRaf.Text);
                }
                connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Veriler kaydedilemedi!", "Hata!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
