using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms1.Algoritmos
{
    public class AlgoritmoSimulacion
    {
        public AlgoritmoSimulacion() { }
        public List<int> GenerarValores(int n)
        {
            List<int> listaSalida = new List<int>();
            for (int i = 0; i < n; i++)
            {
                listaSalida.Add(5 * (i + 1));
            }

            return listaSalida;
        }
        public List<int> GeneradorCongruencial(int a, int c, int m, int x0)
        {
            List<int> listaSalida = new List<int>();
            bool entra = true;
            int xi = x0;
            while (entra)
            {
                xi = (a * xi + c) % m;
                if (!listaSalida.Contains(xi))
                {
                    listaSalida.Add((xi + 1) % m);
                }
                else
                {
                    entra = false;
                }
            }
            
            return listaSalida;
        }

        public List<int> GeneradorNoLineal(int a, int c, int m, int X0)
        {
            List<int> listaSalida = new List<int>();
            bool entra = true;
            int xi = X0;
            while (entra)
            {
                xi = (xi ^ a + c) % m;
                if (!listaSalida.Contains(xi))
                {
                    listaSalida.Add((xi + 1) % m);
                }
                else
                {
                    entra = false;
                }
            }
            return listaSalida;
        }

        public List<int> GeneradorCuadradoMedio(int semilla, int noDigitos)
        {
            List<int> listaSalida = new List<int>();
            bool entra = true;
            int xi = 0;

            while (entra)
            {
                // Cuadrar la semilla
                long cuadrado = (long)semilla * semilla;
                string cuadradoStr = cuadrado.ToString();

                // Asegurarse de que el número cuadrado tenga suficientes dígitos
                while (cuadradoStr.Length < noDigitos + 2)
                {
                    cuadradoStr = "0" + cuadradoStr;
                }

                // Extraer el medio del cuadrado
                int inicio = (cuadradoStr.Length - noDigitos) / 2;
                string medioStr = cuadradoStr.Substring(inicio, noDigitos);

                // Intentar convertir el valor medio extraído a entero
                if (int.TryParse(medioStr, out semilla))
                {
                    xi = semilla;

                    // Verificar si el valor ya existe en la lista
                    if (!listaSalida.Contains(xi))
                    {
                        listaSalida.Add(xi);
                    }
                    else
                    {
                        entra = false; // Terminar el bucle si se repite un valor
                    }
                }
                else
                {
                    // Terminar el bucle en caso de un error en la conversión
                    entra = false;
                }
            }

            return listaSalida;
        }

        public List<int> GeneradorProductoMedio(int semilla, int noDigitos, int k)
        {
            List<int> listaSalida = new List<int>();
            bool entra = true;
            int xi = 0;

            while (entra)
            {
                // Cuadrar la semilla
                long cuadrado = (long)semilla * k;
                string cuadradoStr = cuadrado.ToString();

                // Asegurarse de que el número cuadrado tenga suficientes dígitos
                while (cuadradoStr.Length < noDigitos + 2)
                {
                    cuadradoStr = "0" + cuadradoStr;
                }

                // Extraer el medio del cuadrado
                int inicio = (cuadradoStr.Length - noDigitos) / 2;
                string medioStr = cuadradoStr.Substring(inicio, noDigitos);

                // Intentar convertir el valor medio extraído a entero
                if (int.TryParse(medioStr, out semilla))
                {
                    xi = semilla;

                    // Verificar si el valor ya existe en la lista
                    if (!listaSalida.Contains(xi))
                    {
                        listaSalida.Add(xi);
                    }
                    else
                    {
                        entra = false; // Terminar el bucle si se repite un valor
                    }
                }
                else
                {
                    // Terminar el bucle en caso de un error en la conversión
                    entra = false;
                }
            }

            return listaSalida;
        }


    }
}