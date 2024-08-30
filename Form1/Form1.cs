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

        public static bool EsPrimo(int numero)
        {
            if (numero <= 1) return false;
            if (numero == 2) return true;
            if (numero % 2 == 0) return false;

            int limite = (int)Math.Floor(Math.Sqrt(numero));

            for (int i = 3; i <= limite; i += 2)
            {
                if (numero % i == 0)
                    return false;
            }
            return true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Paso 0: Condicion de vacio
            if (textBox5.Text.Equals("") ||
                textBox6.Text.Equals("") ||
                textBox7.Text.Equals("") ||
                textBox8.Text.Equals(""))
            {
                MessageBox.Show("Los numeros tienen que ser MAYOR que cero, NO VACIOS");
                return;
            }
            //Paso 1: Inicializacion de parametros
            int a = Convert.ToInt32(textBox5.Text);
            int c = Convert.ToInt32(textBox6.Text);
            int x0 = Convert.ToInt32(textBox7.Text);
            int m = Convert.ToInt32(textBox8.Text);
            //Paso 1.2: Condiciones

            if (a<=0 || c<=0 || x0<=0)
            {
                MessageBox.Show("Valores 'a', 'c', 'x0' tienen que ser mayores que cero");
                return;
            }
            if (m<=x0 || m<=c || m <= a)
            {
                MessageBox.Show("El valor de 'm' tiene que ser mayor que los demas parametros");
                return;
            }

            if (!EsPrimo(a))
            {
                MessageBox.Show("El Valor de 'a' tiene que ser un numero primo");
                return;
            }
            if (!EsPrimo(c))
            {
                MessageBox.Show("El Valor de 'c' tiene que ser un numero primo");
                return;
            }
            if (!EsPrimo(m))
            {
                MessageBox.Show("El Valor de 'm' tiene que ser un numero primo");
                return;
            }
            if (!EsPrimo(x0))
            {
                MessageBox.Show("El Valor de 'x0' tiene que ser un numero primo");
                return;
            }
            //Paso 2: Declarar clase algoritmo genetico
            AlgoritmoSimulacion algoritmo = new AlgoritmoSimulacion();
            //Paso 3: Llamar metodo principal
            List<int> listaEnteros = algoritmo.GeneradorCongruencial(a,c,m,x0);
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Equals("") || textBox8.Text.Equals("") || textBox6.Text.Equals(""))
            {
                MessageBox.Show("Tiene que darle valores a la semilla 'a', a los dígitos 'm' y a la constante 'c' para este método");
                return;
            }

            // Convertir los valores de los TextBox
            int a = Convert.ToInt32(textBox5.Text);
            int m = Convert.ToInt32(textBox8.Text);
            int c = Convert.ToInt32(textBox6.Text);

            // Verificar si los valores son mayores que cero
            if (a <= 0 || m <= 0 || c <= 0)
            {
                MessageBox.Show("Valores 'a', 'm' y 'c' tienen que ser mayores que cero");
                return;
            }

            // Verificar si el cuadrado de la semilla tiene suficientes dígitos
            long cuadrado = (long)a * a;
            string cuadradoStr = cuadrado.ToString();

            if (cuadradoStr.Length < m + 2)
            {
                MessageBox.Show("El cuadrado de la semilla no tiene suficientes dígitos para extraer el número deseado.");
                return;
            }

            // Llamar al método principal del AlgoritmoSimulacion
            AlgoritmoSimulacion algoritmo = new AlgoritmoSimulacion();
            List<int> listaEnteros = algoritmo.GeneradorProductoMedio(a, m, c);

            // Llenar el grid con los resultados
            llenarGrid(listaEnteros);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Paso 0: Condicion de vacio
            if (textBox5.Text.Equals("") ||
                textBox6.Text.Equals("") ||
                textBox7.Text.Equals("") ||
                textBox8.Text.Equals(""))
            {
                MessageBox.Show("Los numeros tienen que ser MAYOR que cero, NO VACIOS");
                return;
            }
            //Paso 1: Inicializacion de parametros
            int a = Convert.ToInt32(textBox5.Text);
            int c = Convert.ToInt32(textBox6.Text);
            int x0 = Convert.ToInt32(textBox7.Text);
            int m = Convert.ToInt32(textBox8.Text);
            //Paso 1.2: Condiciones

            if (a <= 0 || c <= 0 || x0 <= 0)
            {
                MessageBox.Show("Valores 'a', 'c', 'x0' tienen que ser mayores que cero");
                return;
            }
            if (m <= x0 || m <= c || m <= a)
            {
                MessageBox.Show("El valor de 'm' tiene que ser mayor que los demas parametros");
                return;
            }

            if (!EsPrimo(a))
            {
                MessageBox.Show("El Valor de 'a' tiene que ser un numero primo");
                return;
            }
            if (!EsPrimo(c))
            {
                MessageBox.Show("El Valor de 'c' tiene que ser un numero primo");
                return;
            }
            if (!EsPrimo(m))
            {
                MessageBox.Show("El Valor de 'm' tiene que ser un numero primo");
                return;
            }
            if (!EsPrimo(x0))
            {
                MessageBox.Show("El Valor de 'x0' tiene que ser un numero primo");
                return;
            }
            //Paso 2: Declarar clase algoritmo genetico
            AlgoritmoSimulacion algoritmo = new AlgoritmoSimulacion();
            //Paso 3: Llamar metodo principal
            List<int> listaEnteros = algoritmo.GeneradorNoLineal(a, c, m, x0);
            //Paso 4: Llenar el grid
            llenarGrid(listaEnteros);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Equals("") || textBox8.Text.Equals(""))
            {
                MessageBox.Show("Tiene que darle valores a la semilla 'a' y a los dígitos 'm' para este método");
                return;
            }

            // Convertir los valores de los TextBox
            int a = Convert.ToInt32(textBox5.Text);
            int m = Convert.ToInt32(textBox8.Text);

            // Verificar si los valores son mayores que cero
            if (a <= 0 || m <= 0)
            {
                MessageBox.Show("Valores 'a' y 'm' tienen que ser mayores que cero");
                return;
            }

            // Verificar si el cuadrado de la semilla tiene suficientes dígitos
            long cuadrado = (long)a * a;
            string cuadradoStr = cuadrado.ToString();

            if (cuadradoStr.Length < m + 2)
            {
                MessageBox.Show("El cuadrado de la semilla no tiene suficientes dígitos para extraer el número deseado.");
                return;
            }

            // Llamar al método principal del AlgoritmoSimulacion
            AlgoritmoSimulacion algoritmo = new AlgoritmoSimulacion();
            List<int> listaEnteros = algoritmo.GeneradorCuadradoMedio(a, m);

            // Llenar el grid con los resultados
            llenarGrid(listaEnteros);
        }
    }
}
