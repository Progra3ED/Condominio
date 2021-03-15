using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Condominio
{
    public partial class Form1 : Form
    {
        List<Propietario> propietarios = new List<Propietario>();
        List<Propiedad> propiedades = new List<Propiedad>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Cargar()
        {
            
            {
                FileStream stream = new FileStream(@"..\..\propietarios.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                while (reader.Peek() > -1)
                {
                    Propietario propietario = new Propietario();

                    propietario.Dpi = reader.ReadLine();
                    propietario.Nombre = reader.ReadLine();
                    propietario.Apellido = reader.ReadLine();

                    propietarios.Add(propietario);
                }

                reader.Close();
            }
            
            {
                FileStream stream = new FileStream(@"..\..\propiedades.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                while (reader.Peek() > -1)
                {
                    Propiedad propiedad = new Propiedad();

                    propiedad.NoCasa = reader.ReadLine();
                    propiedad.Dpi = reader.ReadLine();
                    propiedad.Cuota = Convert.ToDouble(reader.ReadLine());


                    propiedades.Add(propiedad);
                }

                reader.Close();
            }

        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {
            List<Reporte> reportes = new List<Reporte>();

            foreach (var propiedad in propiedades)
            {
                Reporte reporte = new Reporte();

                Propietario propietario = propietarios.Find(p => p.Dpi == propiedad.Dpi);

                reporte.Nombre = propietario.Nombre;
                reporte.Apellido = propietario.Apellido;
                reporte.NoCasa = propiedad.NoCasa;
                reporte.Cuota = propiedad.Cuota;

                reportes.Add(reporte);
            }

            dataGridViewReporte.DataSource = null;
            dataGridViewReporte.DataSource = reportes;
            dataGridViewReporte.Refresh();            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
