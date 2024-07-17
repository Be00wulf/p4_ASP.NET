<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="AplicacionesUDEO.CRUD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CONTROL DE INGRESO</title>
    <link href="css/ClientStyle.css" rel="stylesheet" type="text/css";
    <link rel="icon" href="img/CLIENTE.png" />
        <style type="text/css">
            .auto-style1 {
                width: 100%;
            }

            .auto-style1 {
                width: 79%;
                border-radius: 30px;
                background-color: aqua;
                margin: auto;
            }

            .auto-style2 {
                width: 18%;
                text-align: right;
            }

            .auto-style3 {
                width: 18%;
                border-radius: 30px;
                /*background-color: aqua;*/
                margin: auto;
                text-align: right;
            }

            .auto-style4 {
                width: 335px;
            }
        </style>
</head>

<body>
    <form id="form1" runat="server">
        <h1>CONTROL DE INGRESO</h1>
        <div>
            <table class="estiloTabla" >
                <tr>
                    <td class="auto-style3" >Codigo</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="estilotxtBox" ></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">Precio</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="estilotxtBox"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">Existencia</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="estilotxtBox"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">Precioventa</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="estilotxtBox"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">Producto</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="estilotxtBox"></asp:TextBox>
                    </td>
                </tr>
            </table>



            <table class="estiloTabla">
                <tr>
                    <td class="alineaCentro"   ><asp:Button ID="GUARDAR" CssClass="boton botonGuardar" runat="server" Text="GUARDAR" OnClick="GUARDAR_Click" />
                    </td>
                    <td>
                        <asp:Button ID="EDITAR" CssClass="boton botonEditar" runat="server" Text="EDITAR" OnClick="EDITAR_Click" />
                    </td>
                    <td>
                        <asp:Button ID="ELIMINAR" CssClass="boton botonEliminar" runat="server" Text="ELIMINAR" OnClick="ELIMINAR_Click" />
                    </td>
                </tr>
            </table>



            <table class="estiloTabla">
                <tr>
                    <asp:GridView ID="GridView1" class="estiloGrid" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                        
                    </asp:GridView>
                </tr>
            </table>


        </div>
    </form>
</body>
</html>
