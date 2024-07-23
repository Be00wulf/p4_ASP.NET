<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="AplicacionesUDEO.CRUD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CONTROL DE INGRESO</title>
    <link href="css/CRUDStyle.css" rel="stylesheet" type="text/css" />
    <link rel="icon" href="img/CLIENTE.png" />
        <style type="text/css">
            
            .auto-style2 {
                width: 25%;
                text-align: right;
                font-size: 20px;
            }

            .auto-style3 {
                width: 25%;
                border-radius: 30px;
                /*background-color: aqua;*/
                margin: auto;
                text-align: right;
            }

            .auto-style4 {
                width: 335px;
            }
            .auto-style5 {
                width: 25%;
                text-align: right;
                height: 61px;
            }
            .auto-style6 {
                width: 335px;
                height: 61px;
            }
        </style>
</head>

<body>
    <form id="form1" runat="server" >
        <h1 class="alineaCentro">DATOS DEL CLIENTE</h1>
        <div>
            <table class="estiloTabla" >
                <tr>
                    <td class="auto-style3" >NIT </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBoxNit" runat="server" class="estilotxtBox" placeholder="Ej: 1725831-4"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">NOMBRES: </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBoxNombres" runat="server" CssClass="estilotxtBox" placeholder="Ej: Linda Rosa"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">APELLIDOS: </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBoxApellidos" runat="server" CssClass="estilotxtBox" placeholder="Ej: Ramos Flores"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style5">DIRECCIÓN: </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBoxDireccion" runat="server" CssClass="estilotxtBox" placeholder="Ej: 8va. calle 33-88 zona 1"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">TELÉFONO: </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBoxTelefono" runat="server" CssClass="estilotxtBox" placeholder="Ej: 77681213"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">FECHA DE NACIMIENTO: </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBoxFechaNacimiento" runat="server" CssClass="estilotxtBox" placeholder="Ej: 01/01/2000"></asp:TextBox>
                    </td>
                </tr>

                                <tr>
                <td class="auto-style2">DEPARTAMENTO: </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBoxDepartamento" runat="server" CssClass="estilotxtBox" Enabled="False"></asp:TextBox>
                    &nbsp;<asp:DropDownList ID="DropDownList1Depa" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1Depa_SelectedIndexChanged"  >
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">MUNICIPIO: </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBoxMunicipio" runat="server" CssClass="estilotxtBox" Enabled="False"></asp:TextBox>
          
                        
                        <asp:DropDownList ID="DropDownList2Munic" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2Munic_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>



            <table class="estiloTabla">
                <tr>
                    <td class="alineaCentro" ><asp:Button ID="GUARDAR" CssClass="boton botonGuardar" runat="server" Text="GUARDAR" OnClick="GUARDAR_Click" />
                    </td>
                    <td class="alineaCentro" >
                        <asp:Button ID="EDITAR" CssClass="boton botonEditar" runat="server" Text="EDITAR" OnClick="EDITAR_Click" Enabled="False" />
                    </td>
                    <td class="alinD" >
                        <asp:Button ID="ELIMINAR" CssClass="boton botonEliminar" runat="server" Text="ELIMINAR" OnClick="ELIMINAR_Click" Enabled="False" />
                    </td>
                </tr>
            </table>



            <table class="estiloTabla">
                <tr>
                    <td class="alineaCentro">
                        <asp:Button ID="ButtonBuscar" runat="server" CssClass="boton botonBuscar" Text="BUSCAR NIT" OnClick="ButtonBuscar_Click" />
                        &nbsp;<asp:TextBox ID="TextBoxBuscar" runat="server" CssClass="estilotxtBoxBuscar " placeholder="Ingresar NIT" ></asp:TextBox>

                    </td>
                </tr>

                <tr>
                    <td class="alinD">
                        &nbsp;<asp:Button ID="ButtonLimpiar" runat="server" CssClass="boton botonBuscar" Text="LIMPIAR CAMPOS" OnClick="ButtonLimpiar_Click"  />
                    </td>
                </tr>

                <tr>
                    <asp:GridView ID="GridView1" class="estiloGrid" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                        
                    
                </tr>
            </table>


        </div>
    </form>
</body>
</html>
