using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace introduccionRazor_ASPNet.Pages
{
    public class CifradoCesarModel : PageModel
    {
        [BindProperty]
        public string Mensaje { get; set; }

        [BindProperty]
        public int Desplazamiento { get; set; }

        [BindProperty]
        public bool Accion { get; set; } = true;  // Default a cifrar

        public string Resultado { get; set; }

        private const string Alfabeto = "ABCDEFGHIJKLMNOPQRSTUVXYZ";

        public void OnGet() { }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(Mensaje) && Desplazamiento != 0)
            {
                Resultado = Transformar(Mensaje, Accion ? Desplazamiento : -Desplazamiento);
            }
        }

        private string Transformar(string texto, int desplazamiento)
        {
            desplazamiento = ((desplazamiento % Alfabeto.Length) + Alfabeto.Length) % Alfabeto.Length;

            var resultado = new StringBuilder(texto.Length);

            foreach (char c in texto.ToUpper())
            {
                int pos = Alfabeto.IndexOf(c);
                resultado.Append(pos >= 0 ? Alfabeto[(pos + desplazamiento) % Alfabeto.Length] : c);
            }

            return resultado.ToString();
        }
    }
}
