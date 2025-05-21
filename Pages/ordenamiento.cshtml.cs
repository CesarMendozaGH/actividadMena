using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace introduccionRazor_ASPNet.Pages
{
    public class odernamientoModel : PageModel
    {
        public required int[] numerosAleatorios { get; set; } 
        public required int[] numerosOrdenados { get; set; }
        public int suma { get; set; }
        public double promedio { get; set; }
        public List<int>? moda { get; private set; }
        public double mediana { get; private set; }
        public void OnGet()
        {
            
            GenerarNumerosAleatorios();

            
            CalcularEstadisticas();
        }

        private void GenerarNumerosAleatorios()
        {

            numerosAleatorios = new int[20];
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                numerosAleatorios[i] = random.Next(0, 101);
            }            
            numerosOrdenados = (int[])numerosAleatorios.Clone();
            Array.Sort(numerosOrdenados);
        }

        private void CalcularEstadisticas()
        {
            suma = 0;
            foreach (int numero in numerosAleatorios)
            {
                suma += numero;
            }

            promedio = (double)suma / numerosAleatorios.Length;            
            moda = CalcularModa(numerosAleatorios);
            mediana = CalcularMediana(numerosOrdenados);
        }

        private List<int> CalcularModa(int[] numeros)
        {
            
            int[] frecuencias = new int[101]; 

           
            foreach (int numero in numeros)
            {
                frecuencias[numero]++;
            }

           
            int maxFrecuencia = 0;
            for (int i = 0; i < frecuencias.Length; i++)
            {
                if (frecuencias[i] > maxFrecuencia)
                {
                    maxFrecuencia = frecuencias[i];
                }
            }

           
            if (maxFrecuencia == 1)
            {
                return new List<int>();
            }

           
            List<int> modas = new List<int>();
            for (int i = 0; i < frecuencias.Length; i++)
            {
                if (frecuencias[i] == maxFrecuencia)
                {
                    modas.Add(i);
                }
            }

            return modas;
        }

        private double CalcularMediana(int[] numerosOrdenados)
        {
            int n = numerosOrdenados.Length;

          
            if (n % 2 == 0)
            {
                return (numerosOrdenados[(n / 2) - 1] + numerosOrdenados[n / 2]) / 2.0;
            }
            
            else
            {
                return numerosOrdenados[n / 2];
            }
        }
    }
}
