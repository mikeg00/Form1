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
    }
}