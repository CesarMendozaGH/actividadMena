using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace introduccionRazor_ASPNet.Pages
{
    public class ArreglosModelModel : PageModel
    {
        public double A { get; set; } 
        public double B { get; set; } 
        public double X { get; set; } 
        public double Y { get; set; } 
        public int N { get; set; } 
        public string Resultado { get; set; }


        public void OnGet()
        {
            
        }
        public void OnPost()
        {
            if (N < 0)
            {
                Resultado = "El exponente n debe ser positivo";
                return;
            }

            Resultado = "";

            for (int k = 0; k <= N; k++)
            {
                // Calcular coeficiente binomial
                double coef = CoeficienteBinomial(N, k);

                // Calcular (ax)^(n-k)
                double terminoAX = Math.Pow(A * X, N - k);

                // Calcular (by)^k
                double terminoBY = Math.Pow(B * Y, k);

                // Calcular término completo
                double termino = coef * terminoAX * terminoBY;

                // Formatear el signo
                if (k > 0 && termino >= 0)
                    Resultado += " + ";
                else if (termino < 0)
                    Resultado += " - ";

                // Agregar valor absoluto del término
                Resultado += Math.Abs(termino).ToString("0.##");

                // Agregar variables
                if (N - k > 0)
                    Resultado += $"a^{N - k}x^{N - k}";

                if (k > 0)
                    Resultado += $"b^{k}y^{k}";
            }
        }

        private double CoeficienteBinomial(int n, int k)
        {
            if (k == 0 || k == n) return 1;

            double resultado = 1;
            for (int i = 1; i <= k; i++)
            {
                resultado = resultado * (n - k + i) / i;
            }
            return resultado;
        }
    }
}
