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
    public partial class Agregar : Form
    {
        public Agregar()
        {
            InitializeComponent();
        }

        private void Agregar1_Click(object sender, EventArgs e)
        {
            string conexionString = "datasource=127.0.0.1;port=3306;username=root;password=12345;database=leasein";
            string consulta = "INSERT INTO laptops(marca,codigo,procesador,ram,estado,ubicacion) VALUES('"+textMarca.Text+"','"+textCodigo.Text+ "','"+textProcesador.Text+ "','"+textRam.Text+ "','"+textEstado.Text+ "','"+textUbicacion.Text+"')";
            MySqlConnection databaseConexion = new MySqlConnection(conexionString);
            MySqlCommand comandoDatabase = new MySqlCommand(consulta, databaseConexion);

            try
            {
                databaseConexion.Open();
                MySqlDataReader lectura = comandoDatabase.ExecuteReader();
                databaseConexion.Close();

            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            this.Close();
        }
    }
}
