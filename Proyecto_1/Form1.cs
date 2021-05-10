using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proyecto_1
{
    public partial class Inicio : Form
    {
        static string conexionString = "datasource=127.0.0.1;port=3306;username=root;password=12345;database=leasein";
        static string consulta = "SELECT * FROM laptops";
        public Inicio()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("id","id");
            dataGridView1.Columns.Add("marca", "marca");
            dataGridView1.Columns.Add("codigo", "codigo");
            dataGridView1.Columns.Add("procesador", "procesador");
            dataGridView1.Columns.Add("ram", "ram");
            dataGridView1.Columns.Add("estado", "estado");
            dataGridView1.Columns.Add("ubicacion", "ubicacion");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection databaseConexion = new MySqlConnection(conexionString);
            MySqlCommand comandoDatabase = new MySqlCommand(consulta, databaseConexion);

            try
            {
                databaseConexion.Open();
                MySqlDataReader lectura = comandoDatabase.ExecuteReader();
                dataGridView1.Rows.Clear();
                if (lectura.HasRows)
                {
                    while (lectura.Read())
                    {
                        dataGridView1.Rows.Add(lectura.GetString(0), lectura.GetString(1), lectura.GetString(2), lectura.GetString(3), lectura.GetString(4), lectura.GetString(5), lectura.GetString(6));
                    }
                }
                databaseConexion.Close();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Agregar agregar = new Agregar();
            agregar.Show();
        }
    }
}
