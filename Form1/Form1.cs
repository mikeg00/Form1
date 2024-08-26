using Forms1.Algoritmos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Paso 0: Condicion de vacio
            if (textBox5.Text.Equals("") ||
                textBox6.Text.Equals(""))
            {
                MessageBox.Show("Los numeros tienen que ser MAYOR que cero, NO VACIOS");
                return;
            }
            //Paso 1: Inicializacion de parametros
            int totalValores = Convert.ToInt32(textBox5.Text);
            int valorMuestra = Convert.ToInt32(textBox6.Text);
            //Paso 2: Declarar clase algoritmo genetico
            AlgoritmoSimulacion algoritmo = new AlgoritmoSimulacion();
            //Paso 3: Llamar metodo principal
            List<int> listaEnteros = algoritmo.GenerarValores(totalValores);
            //Paso 4: Llenar el grid
            llenarGrid(listaEnteros);
        }

        public void llenarGrid(List<int> lista)
        {
            //Paso 0: Indicas el numero de columnas
            string numeroColumna1 = "1";
            string numeroColumna2 = "2";

            //Paso 1: Determinas la cantidad de columnas
            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add(numeroColumna1, "Id");
            dataGridView2.Columns.Add(numeroColumna2, "Valor");

            //Paso 2: Recorres el grid para cada fila llenas los valores aleatorios
            for (int i = 0; i < lista.Count; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[Int32.Parse(numeroColumna1) - 1].Value = (i + 1).ToString();
                dataGridView2.Rows[i].Cells[Int32.Parse(numeroColumna2) - 1].Value = lista[i].ToString();
            }
        }

        public void DescargaExcel(DataGridView data)
        {
            //Paso 0: Instalar complemento de Excel
            Microsoft.Office.Interop.Excel.Application exportarExcel = new Microsoft.Office.Interop.Excel.Application();
            exportarExcel.Application.Workbooks.Add(true);
            int indiceColumna = 0;

            //Paso 1: Construyes columnas y los nombres de las 'cabeceras'
            foreach (DataGridViewColumn columna in data.Columns)
            {
                indiceColumna++;
                exportarExcel.Cells[1, indiceColumna] = columna.HeaderText;
            }

            //Paso 2: Construyes filas y llenas valores
            int indiceFilas = 0;
            foreach (DataGridViewRow fila in data.Rows)
            {
                indiceFilas++;
                indiceColumna = 0;
                foreach (DataGridViewColumn columna in data.Columns)
                {
                    indiceColumna++;
                    exportarExcel.Cells[indiceFilas + 1, indiceColumna] = fila.Cells[columna.Name].Value;
                }
            }

            //Paso 3: Visibilidad
            exportarExcel.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DescargaExcel(dataGridView2);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
