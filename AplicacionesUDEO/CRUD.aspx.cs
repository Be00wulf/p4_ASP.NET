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

            StreamReader leer = new StreamReader(Server.MapPath("archivos/datos1.txt"));

            //definiendo columnas de separacion de TIPOS DE datos 
            while (!leer.EndOfStream) { 
                string linea = leer.ReadLine();
                string[] aux = linea.Split(',');
                tablaProducto.Rows.Add(aux);
            }
            leer.Close();
            GridView1.DataSource = tablaProducto;
            GridView1.DataBind();
            GUARDAR.Enabled = true;
            ELIMINAR.Enabled = false;

        }

        //Limpiando los campos al terminar de arreglar
        public void limpiar()
        {

        }

        protected void GUARDAR_Click(object sender, EventArgs e)
        {

        }

        protected void EDITAR_Click(object sender, EventArgs e)
        {

        }

        protected void ELIMINAR_Click(object sender, EventArgs e)
        {

        }
    }
}