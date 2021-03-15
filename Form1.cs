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
            //Esto devuelve una lista que en cada posición contiene una sublista
            // con todas las propiedades que tienen el mismo dpi
            var repetidos = reportes.GroupBy(r => r.Dpi);

            //se supone un cantidad de 0 propiedades
            int max = 0;
            //en la posición 0
            int pos = 0;

            //se recorren los datos agrupados
            for (int i = 0; i < repetidos.Count(); i++)            
            {
                //si la cantidad de datos que tiene es mayor al mayor 
                //esa cantidad se considera la nueva mayor y se guarda
                //la posición en la que se encontró
                if (repetidos.ToList()[i].Count() > max)
                {
                    max = repetidos.ToList()[i].Count();
                    pos = i;
                }
            }

            //en Key queda guardado el dato por el cual se agrupo
            //en este caso agrupamos por DPI
            labelPropietario.Text = "El DPI: " + repetidos.ToList()[pos].Key;
            //En max se guardó el número de propiedades que tenía cada DPI
            labelPropiedades.Text = "Tiene " + max.ToString() + " Propiedades";

        }

        private void buttonCuotas_Click(object sender, EventArgs e)
        {
            //aseguramos que la lista este ordenada
            MostrarReporte(true);

            int cuantos = reportes.Count();

            //como esta ordenada de menor a mayor están en la posición 0,1,2
            labelBajas.Text = "Más Bajas: " + reportes[0].Cuota.ToString() + "," + reportes[1].Cuota.ToString() + "," + reportes[2].Cuota.ToString();
            //como estan ordenada de menor a mayor las ultimas 3 son las cuotas mayores 
            labelAltas.Text = "Más Altas: " + reportes[cuantos -1 ].Cuota.ToString() + "," + reportes[cuantos - 2].Cuota.ToString() + "," + reportes[cuantos - 3].Cuota.ToString();
        }

        private void buttonCuota_Click(object sender, EventArgs e)
        {

            //Se agrupan los datos del reporte por DPI:
            //Esto devuelve una lista que en cada posición contiene una sublista
            //con todas las propiedades que tienen el mismo dpi
            var agrupado = reportes.GroupBy(r => r.Dpi);

            //inciar con una cuota mayor de 0 y un dpi vacio
            double maxCuota = 0;
            string maxDpi = "";
           

            //Recorrer cada dato agrupado
            foreach (var grupo in agrupado)
            {
                
                double sumaCuota = 0;
                string dpi = "";

                //se recorren cada propiedad que hay en el grupo con el mismo dpi
                //y se va sumando el total de cuotas de cada una de esas propiedades
                //y se guarda el dpi de ese grupo
                foreach (var p in grupo)
                {
                    sumaCuota += p.Cuota;
                    dpi = p.Dpi;
                }                

                //si la suma de las cuotas del dpi actual es mayor que la cuota mayor
                //la suma de la cuota se convirte en la cuota mayor
                //y se guarda el dpi de esa suma de cuotas
                if (sumaCuota > maxCuota)
                {
                    maxCuota = sumaCuota;
                    maxDpi = dpi;
                }
            }


            labelPropietarioMax.Text = maxDpi;
            labelCuotaMax.Text = maxCuota.ToString();



        }

       
    }
}
