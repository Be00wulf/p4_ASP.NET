using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace AplicacionesUDEO
{
    public partial class CRUD : System.Web.UI.Page
    {
        DataTable tablaProducto = new DataTable();
        //ViewState     Session

        DataTable tablaDepa = new DataTable();
        DataTable tablaMUnic = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Definiendo la tabla
            tablaProducto.Columns.Add("NIT");
            tablaProducto.Columns.Add("NOMBRES");
            tablaProducto.Columns.Add("APELLIDOS");
            tablaProducto.Columns.Add("DIRECCIÓN");
            tablaProducto.Columns.Add("TELÉFONO");
            tablaProducto.Columns.Add("FECHA DE NACIMIENTO");
            tablaProducto.Columns.Add("DEPARTAMENTO");
            tablaProducto.Columns.Add("MUNICIPIO");

            //CargarDepa();
            //CargarMunic();
            if (!IsPostBack)
            {
                CargarDepa();
                ELIMINAR.Enabled = false;
                EDITAR.Enabled = false;
            }

            StreamReader leer = new StreamReader(Server.MapPath("archivos/datos4.txt"));

            //definiendo columnas de separacion de TIPOS DE datos ingresados
            while (!leer.EndOfStream) {
                string linea = leer.ReadLine();
                string[] aux = linea.Split(',');
                tablaProducto.Rows.Add(aux);
            }
            leer.Close();
            GridView1.DataSource = tablaProducto;
            GridView1.DataBind();
            //GUARDAR.Enabled = true;
            //ELIMINAR.Enabled = true;

        }

        public void deshabilitarBoton()
        {
            ELIMINAR.Enabled = false;
            EDITAR.Enabled = false;
        }

        public void CargarDepa()
        {
            tablaDepa.Columns.Add("Codigo");
            tablaDepa.Columns.Add("Depa");
            StreamReader leer = new StreamReader(Server.MapPath("archivos/Departamento.txt"));

            while (!leer.EndOfStream)
            {
                string linea = leer.ReadLine();
                string[] aux = linea.Split(',');
                tablaDepa.Rows.Add(aux);
            }
            leer.Close() ;
            DropDownList1Depa.DataSource = tablaDepa;
            DropDownList1Depa.DataTextField = "Depa";
            DropDownList1Depa.DataValueField = "Codigo";
            DropDownList1Depa.DataBind();
        }

        public void CargarMunic()
        {
            tablaMUnic.Columns.Clear();
            tablaMUnic.Rows.Clear();
            tablaMUnic.Columns.Add("CodMuni");
            tablaMUnic.Columns.Add("Munic");
            tablaMUnic.Columns.Add("CodDepa");

            StreamReader leer = new StreamReader(Server.MapPath("archivos/Municipio.txt"));

            while (!leer.EndOfStream)
            {
                string linea = leer.ReadLine();
                string[] aux = linea.Split(',');
                if (DropDownList1Depa.SelectedValue == aux[2])
                {
                    tablaMUnic.Rows.Add(aux);
                }

                //tablaDepa.Rows.Add(aux);
            }
            leer.Close();
            DropDownList2Munic.DataSource = tablaMUnic;
            DropDownList2Munic.DataTextField = "Munic";
            DropDownList2Munic.DataValueField = "CodMuni";
            DropDownList2Munic.DataBind();
        }

        //Limpiando los campos al terminar de arreglar
        public void limpiar()
        {
            TextBoxNit.Text = string.Empty;
            TextBoxNombres.Text = "";
            TextBoxApellidos.Text = string.Empty;
            TextBoxDireccion.Text = string.Empty;
            TextBoxTelefono.Text = string.Empty;
            TextBoxFechaNacimiento.Text = string.Empty;
            TextBoxDepartamento.Text = string.Empty;
            TextBoxMunicipio.Text = string.Empty;
            TextBoxBuscar.Text = string.Empty;
            EDITAR.Enabled = true;
            //ELIMINAR.Enabled = true;
            //GUARDAR.Enabled = true;
            deshabilitarBoton();
        }

        //agregando la info     DATOS AGREGADOS = SOLUCIONADO
        protected void GUARDAR_Click(object sender, EventArgs e)
        {
            //**********revisar mnicipio y depto vacios         CAMPOS LLENOS
            if ((TextBoxNit.Text != "") && (TextBoxNombres.Text != "") && (TextBoxApellidos.Text != "") && (TextBoxDireccion.Text != "") && (TextBoxTelefono.Text != "") && (TextBoxFechaNacimiento.Text != "") && (TextBoxDepartamento.Text != "") && (TextBoxMunicipio.Text != ""))
            {
                //rectificando si no hay nits repetidos
                bool nitDuplicado = false;
                foreach (DataRow fila in tablaProducto.Rows)
                {
                    if (fila[0].ToString() == TextBoxNit.Text)
                    {
                        nitDuplicado = true;
                        break;
                    }
                }

                if (nitDuplicado)
                {
                    Response.Write("<script language=javascript>alert('Un usuario con este NIT ya ha sido registrado. Intente con otro NIT.')</script>");
                    limpiar();
                }

                else
                { 
                    tablaProducto.Rows.Add(TextBoxNit.Text, TextBoxNombres.Text, TextBoxApellidos.Text, TextBoxDireccion.Text, TextBoxTelefono.Text, TextBoxFechaNacimiento.Text, TextBoxDepartamento.Text, TextBoxMunicipio.Text);
                    //agrega los datos al grid
                    GridView1.DataBind();

                    //agregar datos al archivo txt
                    string linea = TextBoxNit.Text + "," + TextBoxNombres.Text + "," + TextBoxApellidos.Text + "," + TextBoxDireccion.Text + "," + TextBoxTelefono.Text + "," + TextBoxFechaNacimiento.Text + "," + TextBoxDepartamento.Text + "," + TextBoxMunicipio.Text;
                    StreamWriter escribir = new StreamWriter(Server.MapPath("archivos/datos4.txt"), true);
                    escribir.WriteLine(linea);
                    escribir.Close();
                    Response.Write("<script language=javascript>alert('Se ha ingresado el cliente exitosamente')</script>");
                    limpiar();
                }
            }

            else
            {
                Response.Write("<script language=javascript>alert('Algunos campos están vacíos')</script>");
            }
        }

        //SOBREESCRITURA ARREGLADA
        protected void EDITAR_Click(object sender, EventArgs e)
        {
            if ((TextBoxNit.Text == "") || (TextBoxNombres.Text == "") || (TextBoxApellidos.Text == "") || (TextBoxDireccion.Text == "") || (TextBoxTelefono.Text == "") || (TextBoxFechaNacimiento.Text == "") || (TextBoxDepartamento.Text == "") || (TextBoxMunicipio.Text == ""))
            {
                Response.Write("<script language=javascript>alert('Todos los campos deben estar llenos')</script>");
                return; // Salir del método si algún campo está vacío
            }

            string codClient = TextBoxNit.Text;
            bool clienteEncontrado = false;

            foreach (DataRow fila in tablaProducto.Rows)
            {
                if (fila[0].ToString() == codClient)
                {
                    fila[0] = TextBoxNit.Text;
                    fila[1] = TextBoxNombres.Text;
                    fila[2] = TextBoxApellidos.Text;
                    fila[3] = TextBoxDireccion.Text;
                    fila[4] = TextBoxTelefono.Text;
                    fila[5] = TextBoxFechaNacimiento.Text;
                    fila[6] = TextBoxDepartamento.Text;
                    fila[7] = TextBoxMunicipio.Text;
                    clienteEncontrado = true;
                    Response.Write("<script language=javascript>alert('Informacion actualizada exitosamente')</script>");
                    GridView1.DataBind();
                    limpiar();
                    break;
                }

            }
            //actualizando datos en el txt              //FALSE PARA no REESCRIBIR     
            //new StreamWriter(Server.MapPath("archivos/datos1.txt"), true);
            StreamWriter escribir = new StreamWriter(Server.MapPath("archivos/datos4.txt"), false);

            foreach (DataRow fila in tablaProducto.Rows)
            {
                string linea = fila[0].ToString() + "," + fila[1].ToString() + "," + fila[2].ToString() + "," + fila[3].ToString() + "," + fila[4].ToString() + "," + fila[5].ToString() + "," + fila[6].ToString() + "," + fila[7].ToString();
                escribir.WriteLine(linea);
            }
            escribir.Close();
        }

        protected void ELIMINAR_Click(object sender, EventArgs e)
        {
            string codClient = TextBoxNit.Text;
            foreach (DataRow fila in tablaProducto.Rows)
            {
                if (fila[0].ToString() == codClient)
                {

                    fila[0] = "";
                    fila[1] = "";
                    fila[2] = "";
                    fila[3] = "";
                    fila[4] = "";
                    fila[5] = "";
                    fila[6] = "";
                    fila[7] = "";
                    Response.Write("<script language=javascript>alert('Dato eliminado exitosamente')</script>");
                    GridView1.DataBind();
                    limpiar();
                    break;
                }
            }
            //actualizando datos en el txt
            //new StreamWriter(Server.MapPath("archivos/datos1.txt"), true);        //false para no reescribir
            StreamWriter escribir = new StreamWriter(Server.MapPath("archivos/datos4.txt"), false);

            foreach (DataRow fila in tablaProducto.Rows)
            {
                string linea = fila[0].ToString() + "," + fila[1].ToString() + "," + fila[2].ToString() + "," + fila[3].ToString() + "," + fila[4].ToString() + "," + fila[5].ToString() + "," + fila[6].ToString() + "," + fila[7].ToString();
                
                escribir.WriteLine(linea);
            }
            escribir.Close();
        }

        //revisar si no hay coincidencias   = solucionado
        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            //al presionar buscar, debe 1. buscar coincidencias y 2. limpiar la caja de busquda
            //TextBoxBuscar.Text = string.Empty;
            string codClient = TextBoxBuscar.Text;
            bool encontrado = false;
            foreach (DataRow fila in tablaProducto.Rows)
            {
                if (fila[0].ToString() == codClient)
                {
                    TextBoxNit.Text = fila[0].ToString();
                    TextBoxNombres.Text = fila[1].ToString();
                    TextBoxApellidos.Text = fila[2].ToString();
                    TextBoxDireccion.Text = fila[3].ToString();
                    TextBoxTelefono.Text = fila[4].ToString();
                    TextBoxFechaNacimiento.Text = fila[5].ToString();
                    TextBoxDepartamento.Text = fila[6].ToString();
                    TextBoxMunicipio.Text = fila[7].ToString();

                    encontrado = true;
                    break;
                    
                }
            }

            //habilitar editar y eliminar
            if (encontrado)
            {
                EDITAR.Enabled = true;
                ELIMINAR.Enabled = true;
            }

            if (!encontrado)
            {
                Response.Write("<script language=javascript>alert('No existen clientes con el NIT ingresado')</script>");
                EDITAR.Enabled = false;
                ELIMINAR.Enabled = false;
            }

            TextBoxBuscar.Text = "";
        }

        protected void DropDownList1Depa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMunic();

            //mostrando el texto de la selección en el text box
            TextBoxDepartamento.Text = DropDownList1Depa.SelectedItem.Text;
        }

        protected void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        protected void DropDownList2Munic_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxMunicipio.Text = DropDownList2Munic.SelectedItem.Text;
        }

    }
}