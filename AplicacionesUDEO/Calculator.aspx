<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="AplicacionesUDEO.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CALCULADORA</title>
    <link rel="icon" href="img/calculadora.png" />
    <link href="css/CalcStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">

    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div>

            <table class="estiloTabla ">
                <tr>
                    <td class=" txtCalc">☰ Estándar</td>
                </tr>

                <tr class="D_line alinD ">
                    <td class=" txtCalc alinD">
                        <asp:TextBox class="txtBox" ID="txtRESULTADO" runat="server" ReadOnly="True" TextMode="MultiLine" MaxLength="16" ></asp:TextBox>
                        <asp:TextBox class="txtBox" ID="txtOPERACION" runat="server" ReadOnly="True" TextMode="MultiLine" MaxLength="16"></asp:TextBox>
                    </td>
                </tr>

                <!--  <tr class="D_line alinC">
                    <td class="auto-style4 ">
                        
                        <asp:Button ID="btn_MC" class="M_boton" runat="server" Text="MC" />
                        <asp:Button ID="btn_MC0" class="M_boton" runat="server" Text="MR" />
                        <asp:Button ID="btn_MC1" class="M_boton" runat="server" Text="M+" />
                        <asp:Button ID="btn_MC3" class="M_boton" runat="server" Text="MS" />
                        <asp:Button ID="btn_MC2" class="M_boton" runat="server" Text="M-" />
                        <asp:Button ID="btn_MC4" class="M_boton" runat="server" Text="M v" /> 
                    </td>
                </tr>-->

                    
                <tr class="D_line alinC">
                    <td class="auto-style4">
                        <asp:Button ID="ButtonMod" class="teclaOscura" runat="server" Text="%" OnClick="Operador_Click" />
                        <asp:Button ID="ButtonCE" class="teclaOscura" runat="server" Text="E" OnClick="ButtonCE_Click" />
                        <asp:Button ID="ButtonC" class="teclaOscura" runat="server" Text="C" OnClick="ButtonC_Click" />
                        <asp:Button ID="ButtonDelete" class="teclaOscura" runat="server" Text="D" OnClick="ButtonDelete_Click" />
                    </td>
                </tr>


                <tr class="D_line alinC">
                    <td class="auto-style4">
                        <asp:Button ID="ButtonFraccion" class="teclaOscura" runat="server" Text="F" OnClick="Operador_Click" />
                        <asp:Button ID="ButtonCuadrado" class="teclaOscura" runat="server" Text="^" OnClick="Operador_Click" />
                        <asp:Button ID="ButtonRaiz" class="teclaOscura" runat="server" Text="√" OnClick="Operador_Click"/>
                        <asp:Button ID="ButtonDivision" class="teclaOscura" runat="server" Text="÷" OnClick="Operador_Click"/>
                    </td>
                </tr>

                <tr class="D_line alinC ">
                    <td class="auto-style4">
                        <asp:Button ID="Button7" class="teclaClara" runat="server" Text="7" OnClick="ButtonNumber_Click" />
                        <asp:Button ID="Button8" class="teclaClara" runat="server" Text="8" OnClick="ButtonNumber_Click" />
                        <asp:Button ID="Button9" class="teclaClara" runat="server" Text="9" OnClick="ButtonNumber_Click"/>
                        <asp:Button ID="ButtonMult" class="teclaOscura" runat="server" Text="x" OnClick="Operador_Click"/>
                    </td>
                </tr>

                <tr class="D_line alinC">
                    <td class="auto-style4">
                        <asp:Button ID="Button4" class="teclaClara" runat="server" Text="4" OnClick="ButtonNumber_Click"/>
                        <asp:Button ID="Button5" class="teclaClara" runat="server" Text="5" OnClick="ButtonNumber_Click"/>
                        <asp:Button ID="Button6" class="teclaClara" runat="server" Text="6" OnClick="ButtonNumber_Click"/>
                        <asp:Button ID="ButtonResta" class="teclaOscura" runat="server" Text="-" OnClick="Operador_Click" />
                    </td>
                </tr>

                <tr class="D_line alinC">
                    <td class="auto-style4">
                        <asp:Button ID="Button1" class="teclaClara" runat="server" Text="1" OnClick="ButtonNumber_Click"/>
                        <asp:Button ID="Button2" class="teclaClara" runat="server" Text="2" OnClick="ButtonNumber_Click"/>
                        <asp:Button ID="Button3" class="teclaClara" runat="server" Text="3" OnClick="ButtonNumber_Click"/>
                        <asp:Button ID="ButtonSuma" class="teclaOscura" runat="server" Text="+" OnClick="Operador_Click" />
                    </td>
                </tr>

                <tr class="D_line alinC">
                    <td class="auto-style4">
                        <asp:Button ID="ButtonMasMenos" class="teclaClara" runat="server" Text="±" OnClick="ButtonMasMenos_Click" />
                        <asp:Button ID="Button0" class="teclaClara" runat="server" Text="0"  OnClick="ButtonNumber_Click"/>
                        <asp:Button ID="ButtonComa" class="teclaClara" runat="server" Text="," OnClick="ButtonComa_Click" />
                        <asp:Button ID="ButtonIgual" class="teclaResalta" runat="server" Text="=" OnClick="ButtonIgual_Click" />
                    </td>
                </tr>
                </table>
        </div>
    </form>
</body>
</html>
