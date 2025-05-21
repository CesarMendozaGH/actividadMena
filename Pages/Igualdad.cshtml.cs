using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace introduccionRazor_ASPNet.Pages
{
    public class IgualdadModel : PageModel
    {
        [BindProperty]
        public double A { get; set; } = 1;
        [BindProperty]
        public double B { get; set; } = 1;
        [BindProperty]
        public double X { get; set; } = 1;
        [BindProperty]
        public double Y { get; set; } = 1;
        [BindProperty]
        public int N { get; set; } = 1;
        public required string Resultado { get; set; }
        public List<string> Iteraciones { get; set; } = new List<string>();
        public double SumaTotal { get; set; } 

        public void OnPost()
        {
            Iteraciones.Clear();
            SumaTotal = 0;

            if (N < 0)
            {
                Resultado = "El exponente n debe ser positivo";
                return;
            }

            Resultado = "";

            for (int k = 0; k <= N; k++)
            {
                double coef = CoeficienteBinomial(N, k);
                double terminoAX = Math.Pow(A * X, N - k);
                double terminoBY = Math.Pow(B * Y, k);
                double termino = coef * terminoAX * terminoBY;

                string iteracion = $"k={k}: coeficiente={coef}, (a·x)^{N - k}={terminoAX}, (b·y)^{k}={terminoBY}, término={termino}";
                Iteraciones.Add(iteracion);

                SumaTotal += termino;

                // Agregar el término al resultado
                if (k > 0 && termino >= 0)
                    Resultado += " + ";
                else if (termino < 0)
                    Resultado += " - ";
                //resultado redondeado con 
                Resultado += Math.Abs(termino).ToString("0.##");
            }
        }

        private double CoeficienteBinomial(int n, int k) // hacemos el metodo del coeficiente directamente
        {
            if (k == 0 || k == n)
                return 1;

            double resultado = 1;
            for (int i = 1; i <= k; i++)
            {
                resultado = resultado * (n - k + i) / i;
            }
            return resultado;
        }
    }
}
