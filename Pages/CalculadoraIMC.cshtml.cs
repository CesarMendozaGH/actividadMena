using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace introduccionRazor_ASPNet.Pages
{
    public class CalculadoraIMCModel : PageModel
    {
         [BindProperty]
        public double Peso { get; set; }

        [BindProperty]
        public double Altura { get; set; }

        public ResultadoIMC? Resultado { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (Peso > 0 && Altura > 0)
            {
                Resultado = new ResultadoIMC(Peso, Altura);
            }
        }
    }

    public class ResultadoIMC
    {
        public double Peso { get; }
        public double Altura { get; }

        public ResultadoIMC(double peso, double altura)
        {
            Peso = peso;
            Altura = altura;
        }

        public double CalcularIMC()
        {
            return Math.Round(Peso / (Altura*Altura)*100);
        }
        public string ObtenerClasificacion()
        {
            var imc = CalcularIMC();
            if (imc < 18) return "Peso Bajo";
            if (imc < 25) return "Peso Normal";
            if (imc < 27) return "Sobrepeso";
            if (imc < 30) return "Obesidad grado 1";
            if (imc < 40) return "Obesidad grado 2";
            return "Obesidad grado 3";
        }

        public string ObtenerRecomendacion()
        {
            var imc = CalcularIMC();
            if (imc < 18) return "Come mas pa y consulta a un especialista.";
            if (imc >= 18 && imc < 25) return "Peso normal";
            if (imc >= 25 && imc < 27) return "Cuida tu alimentación y ve a un gym";
            if (imc >= 27 && imc < 30) return "Consulta a un especialista para empezar a bajar de peso";
            if (imc >= 30 && imc < 40) return "Es importante buscar ayuda médica para aumentar tu calidad de vida ";
            return "Riesgo muy alto, puedes sufrir un infarto o diferentes padecimientos, busca a un especialista urgentemente";
        }

        public string ObtenerImagen()
        {
            var imc = CalcularIMC();
            if (imc < 18) return "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR12YxubOhtGtleKpSXILv-vB_RO4TkSJ-0tg&s";
            if (imc >= 18 && imc < 25) return "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTPMIFJEkgkNEvaE9qukE7_QDFaZKw9ypaLzw&";
            if (imc >= 25 && imc < 27) return "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRSL-E_R4QRxsDhEPevkSQaBXEFa2iw-G1Vyg&s";
            if (imc >= 27 && imc < 30) return "https://lh3.googleusercontent.com/proxy/B9LvS3hOw-S0_7fqNM-hkCzZjff_BOb5XilCgawiW2WFnGIIEhfLMv1WdKPd3YbifSMOJTtrICvmjRtyTsV0zOmNEBxmrIMxYAFINbppDu8iICtAmfzVq2GDaMJ53xNBgrF9U75xSASBi2fJ7oYiGRNTl1MMQlj30n7xAOJHPsCb4nG_bk6jHsbGw_2j4WC95HhBBeTNoJ-zi72K2Eq535iDLGrhzg";
            if (imc >= 30 && imc < 40) return "https://refaccionariamario.info/147204/12482.jpg";
            return "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1dFYWeVxLAWSMzmnRhqQlRHBsxL5EwQ0Tsg&s";
        }
    }
}
