using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArşivOtomasyonProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string connectionString = "Server=172.21.54.148;Port=3306;Database=NYP23-19;User=NYP23-19;Password=Uludag9512357.;";
        MySqlConnection connection = new MySqlConnection(connectionString);

        void EmanetTablosu()
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from TabloEmanet", connection);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    EmanetTablosu();
                }
                connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Tabloyu çekerken hata oluştu!", "Hata!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
