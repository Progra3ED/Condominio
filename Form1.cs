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
        List<Reporte> reportes = new List<Reporte>();

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

        private void MostrarReporte(bool ordenada = false)
        {
            //por si se presiona varias veces el boton de cargar o de ordenar
            //cada vez borramos la lista
            reportes.Clear();
            
            foreach (var propiedad in propiedades)
            {
                Reporte reporte = new Reporte();

                Propietario propietario = propietarios.Find(p => p.Dpi == propiedad.Dpi);

                reporte.Dpi = propietario.Dpi;
                reporte.Nombre = propietario.Nombre;
                reporte.Apellido = propietario.Apellido;
                reporte.NoCasa = propiedad.NoCasa;
                reporte.Cuota = propiedad.Cuota;

                reportes.Add(reporte);
            }


            if (ordenada)
                reportes = reportes.OrderBy(r => r.Cuota).ToList();

            dataGridViewReporte.DataSource = null;
            dataGridViewReporte.DataSource = reportes;
            //por si no queremos mostrar el dpi
            dataGridViewReporte.Columns[0].Visible = false;
            dataGridViewReporte.Refresh();            

        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {

            MostrarReporte();

        }

        private void buttonOrdenar_Click(object sender, EventArgs e)
        {
            MostrarReporte(true);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();
        }

       

        private void buttonMasPropiedades_Click(object sender, EventArgs e)
        {
            //a la clase Reporte se le incluyo el DPI para poder
            //ver cuantas propiedades tiene un dueño sin depender 
            //de su nombre y apellido

            //Se agrupan los datos del reporte por DPI
            var repetidos = reportes.GroupBy(r => r.Dpi);

            int max = 0;
            int pos = 0;

            for (int i = 0; i < repetidos.Count(); i++)            
            {
                if (repetidos.ToList()[i].Count() > max)
                {
                    max = repetidos.ToList()[i].Count();
                    pos = i;
                }
            }

            labelPropietario.Text = "El DPI: " + repetidos.ToList()[pos].Key;
            labelPropiedades.Text = "Tiene " + max.ToString() + " Propiedades";




        }
    }
}
