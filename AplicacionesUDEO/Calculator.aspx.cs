using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionesUDEO
{
    public partial class Calculator : System.Web.UI.Page
    {
        //definiendo variables
        private double valor1;
        private double valor2;
        private string operador;
        private double resultado = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //probando 0 inicial, problema 1-> resuelto OnTextChanged
            //IsPostBack => si es una recargga
            //!IsPostBack => si se carga por primera vez


            if (!IsPostBack)
            {
                //MAXIMO DE CARACTERES EN EL TXT BOX
                txtOPERACION.Attributes.Add("maxlength", txtOPERACION.MaxLength.ToString());
                txtRESULTADO.Attributes.Add("maxlength", txtRESULTADO.MaxLength.ToString());

                //JS

                //txtOPERACION.Text = "0";
                //https://learn.microsoft.com/es-es/dotnet/api/system.web.ui.control.viewstate?view=netframework-4.8.1
                //https://stackoverflow.com/questions/2883149/viewstate-vs-session-maintaining-object-through-page-lifecycle
                //ViewState[] para datos dentro de una pagina y  Session[] para datos que necesitan ser accesibles para multiples paginas

                txtOPERACION.Text = "0";
                ViewState["valor1"] = 0.0;
                ViewState["valor2"] = 0;
                ViewState["operador"] = "";
            }
        }

        //definiendo la funcion general para el click en cada numero, donde se pueda 
        //reutilizar el OnClick para escribir el valor del text del boton en el textbox
        protected void ButtonNumber_Click(object sender, EventArgs e)
        {
            //vamos acumulando digitos
            Button button = (Button)sender;
            if (txtOPERACION.Text == "0")
            {
                txtOPERACION.Text = button.Text;
            }
            else
            {
                txtOPERACION.Text += button.Text;
            }
        }

        // limpiamdo campos
        protected void ButtonC_Click(object sender, EventArgs e)
        {
            txtOPERACION.Text = "0";
            txtRESULTADO.Text = "";           
            //valor1 = 0;
            //valor2 = 0;
            //operador = string.Empty;

            ViewState["valor1"] = 0.0;
            ViewState["valor2"] = 0;
            //ViewState["operador"] = "";
            ViewState["operador"] = string.Empty;
        }

        protected void ButtonCE_Click(object sender, EventArgs e)
        {
            txtOPERACION.Text = "0";
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (txtOPERACION.Text.Length > 0)
            {
                txtOPERACION.Text = txtOPERACION.Text.Substring(0, txtOPERACION.Text.Length - 1);
                if (txtOPERACION.Text.Length == 0)
                {
                    txtOPERACION.Text = "0"; //  regresadndo a "0"
                }
            }
        }


        //LA PAGINA SE RECONSTRUYE DESDE CERO CADA VEZ QYE SE H(ACE POSTB0ACK
        //postback se refiere al proceso en el cual el cliente (navegador) envía datos de vuelta al servidor para procesamiento
        protected void ButtonIgual_Click(object sender, EventArgs e)
        {

            //double tempoV1 = (double)ViewState["valor1"];
            double tempoV1;
            if (ViewState["valor1"] != null)
            {
                tempoV1 = (double)ViewState["valor1"];
            }
            else
            {
                tempoV1 = 0.0; // Asignar un valor por defecto si no está inicializado
            }



            string tempoV2 = txtOPERACION.Text;
            if (string.IsNullOrEmpty(tempoV2))
            {
                valor2 = tempoV1;
            }
            else
            {
                valor2 = Convert.ToDouble(txtOPERACION.Text);
            }



            //valor2 = Convert.ToDouble(txtOPERACION.Text);

            if (ViewState["operador"].Equals("ButtonSuma") || ViewState["operador"].Equals("ButtonResta") || ViewState["operador"].Equals("ButtonMult") || ViewState["operador"].Equals("ButtonDivision") || ViewState["operador"].Equals("ButtonMod"))
            {
                valor2 = Convert.ToDouble(txtOPERACION.Text);
            }
            else if (ViewState["operador"].Equals("ButtonRaiz") || ViewState["operador"].Equals("ButtonCuadrado") || ViewState["operador"].Equals("ButtonFraccion"))
            {
                valor2 = 0;
            }

            //operador determinando operacion 
            switch (ViewState["operador"])
            {

                case "ButtonSuma":
                    //txtRESULTADO.Text = tempoV1 + " S+ ";
                    //resultado = Math.Sqrt(tempoV1);
                    //txtRESULTADO.Text = "√" + tempoV1.ToString() + " = ";
                    resultado = tempoV1 + valor2;
                    txtRESULTADO.Text = tempoV1.ToString() + " + " + tempoV2 + " = ";
                    break;

                case "ButtonResta":
                    resultado = tempoV1 - valor2;
                    txtRESULTADO.Text = tempoV1.ToString() + " - " + tempoV2 + " = ";
                    break;

                case "ButtonMult":
                    resultado = tempoV1 * valor2;
                    txtRESULTADO.Text = tempoV1.ToString() + " * " + tempoV2 + " = ";
                    break;

                case "ButtonDivision":

                    if(valor2 != 0)
                    {
                        resultado = tempoV1 / valor2;
                        txtRESULTADO.Text = tempoV1.ToString() + " / " + tempoV2 + " = ";
                    }
                    else
                    {
                        txtRESULTADO.Text = "ERROR";
                    }
                    break;

                case "ButtonRaiz":
                    resultado = Math.Sqrt(tempoV1);
                    txtRESULTADO.Text = "√" + tempoV1.ToString() + " = ";
                    break;

                case "ButtonCuadrado":
                    resultado = tempoV1 * tempoV1;
                    txtRESULTADO.Text = tempoV1.ToString() + "² = ";
                    break;

                case "ButtonFraccion":
                    resultado = 1 / tempoV1;
                    txtRESULTADO.Text = "1/" + tempoV1.ToString() + " = ";
                    break;

                case "ButtonMod":
                    resultado = tempoV1 * (valor2 / 100);
                    txtRESULTADO.Text = tempoV1.ToString() + " * " + "( " + valor2.ToString() + " / 100 ) = ";
                    break;

                //case "ButtonIgual_Click":
                    //txtRESULTADO.Text = "ingrese una operacion";
                   // break;


                default:
                    txtRESULTADO.Text = "";
                    break;
            }

            txtOPERACION.Text = resultado.ToString();
            txtOPERACION.Text = resultado.ToString();           //SEGUIR CALCULANDO SIN ESCRIBIR A LA PAR
        }

        protected void ButtonSuma_Click(object sender, EventArgs e)
        {
            string tempoV1 = txtOPERACION.Text;
            //guardamos primer varlor y reiniciamos el txtbox para ingresar nuevo valor
            //valor1 = Convert.ToDouble(txtOPERACION.Text);
            ViewState["valor1"] = Convert.ToDouble(txtOPERACION.Text);
            txtRESULTADO.Text = tempoV1 + " + ";
            txtOPERACION.Text = "";
        }

        protected void Operador_Click(object sender, EventArgs e)
        {
            //para obtener el signo del operador
            Button btn = (Button)sender;
            //operador = btn.Text;
            //ViewState["operador"] = btn.Text;
            ViewState["operador"] = btn.ID;

            string tempoV1 = txtOPERACION.Text;
            //guardamos primer varlor y reiniciamos el txtbox para ingresar nuevo valor
            //valor1 = Convert.ToDouble(txtOPERACION.Text);
            ViewState["valor1"] = Convert.ToDouble(txtOPERACION.Text);
            //txtRESULTADO.Text = tempoV1 + " - ";
            switch (ViewState["operador"])
            {
                case "ButtonSuma":
                    txtRESULTADO.Text = tempoV1 + " + ";
                    break;

                case "ButtonResta":
                    txtRESULTADO.Text = tempoV1 + " - ";
                    break;

                case "ButtonMult":
                    txtRESULTADO.Text = tempoV1 + " * ";
                    break;

                case "ButtonDivision":
                    txtRESULTADO.Text = tempoV1 + " / ";
                    break;

                case "ButtonRaiz":
                    txtRESULTADO.Text = "√" + tempoV1;
                    break;

                case "ButtonCuadrado":
                    txtRESULTADO.Text = tempoV1 + "²";
                    break;

                case "ButtonFraccion":
                    txtRESULTADO.Text = "1/" + tempoV1;
                    break;

                case "ButtonMod":
                    txtRESULTADO.Text = tempoV1 + " %" ;
                    break;

                default:
                    txtRESULTADO.Text = "ERROOOOR";
                    break;
            }

            txtOPERACION.Text = "";
        }

        protected void ButtonComa_Click(object sender, EventArgs e)
        {
            //txtOPERACION.Text += ".";
            if (!txtOPERACION.Text.Contains(","))
            { 
                txtOPERACION.Text += ",";
            }

        }

        protected void ButtonMasMenos_Click(object sender, EventArgs e)
        {
            //cambiando valor, solo multiplicamos por -1
            double valorActual = Convert.ToDouble(txtOPERACION.Text);
            valorActual = valorActual * -1;
            txtOPERACION.Text = valorActual.ToString(); 
        }
    }
}
