<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="AplicacionesUDEO.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>MJBR UDEO</title>
        <link href="css/Style.css" rel="stylesheet" type="text/css"/>
        <link rel="icon" href="img/MAJOcctrcs.png" />
        <style type="text/css">
            .auto-style4 {
                width: 619px;
                color:white;
                -webkit-text-stroke: 2px black;
                font-size: 30px;
            }
        </style>
    
    </head>





    <body>
        <form id="form1" runat="server">
        

        <table class="estiloTabla alineaCentro">
            <tr>
                <td class="auto-style4">  <h1 >PROJECT&lt; / &gt;U</h1>  </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Button ID="RediCalc" CssClass="botonMenu" runat="server" Text="CALCULADORA" OnClick="RediCalc_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Button ID="RediProduct" CssClass="botonMenu" runat="server" Text="PRODUCTOS" OnClick="RediProduct_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Button ID="RediElect" CssClass="botonMenu" runat="server" Text="IE1" OnClick="RediElect_Click" />
                </td>
            </tr>
        </table>
        

        </form>
    </body>



</html>
