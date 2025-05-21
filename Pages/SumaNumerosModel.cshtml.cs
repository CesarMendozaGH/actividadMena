using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace introduccionRazor_ASPNet.Pages
{
    public class SumaNumerosModelModel : PageModel
    {
        //Definimos los atributos del modelo

        //para asociar los campos del html con esta parte se hace lo siguiente
        [BindProperty]
        public string num1 { get; set; } = "";
        [BindProperty]
        public string num2 { get; set; }
        public string resultado { get; set; }

        public int suma = 0;
        public void OnGet() //por delfault nos pone un onGet
        {
        }

        //pero nosotros haremos un metodo para trabajar con post
        public void OnPost(){ 
                //recibir los datos (que llegan por default como String los convertimos)
                int numero1 = Convert.ToInt32(num1);
                int numero2 = Convert.ToInt32(num2);
            suma = numero1 + numero2;

            ModelState.Clear(); //Investigar para que esto
        }
    }
}
