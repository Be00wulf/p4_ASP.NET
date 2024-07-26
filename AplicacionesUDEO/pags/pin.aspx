<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pin.aspx.cs" Inherits="AplicacionesUDEO.pags.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <%-- METADATOS --%>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>FORMULARIO</title>
    <link rel="icon" href="../img/FORMULARIOicono.png" />
    <link href="../css/FormStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /*ESPACIO PARA LOS ESTILOS*/
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>

    <%-- CONTENIDO --%>
<body>
    <form id="form1" runat="server">
        <div>

            <%-- tabla encabezado --%>
            <table class="auto-style1">
                <tr class="encabezado">
                    <td>
                        <img class="imgEncabezado" src="../img/MAJOcctrcs.png"/>
                    </td>
                </tr>
            </table>

            <%-- tabla titulo subtitulo texto --%>
            <table>
                <tr>
                    <td>
                        <h1 class="textoSimple">Título 
                            <strong class="textoResaltado">uno</strong> 
                        </h1>
                    </td>
                </tr>

                <tr>
                    <td>
                        <h3 class="textoResaltado">Subítulo texto
                            <strong class="textoSimple">uno</strong> 
                        </h3>
                    </td>
                </tr>

            </table>

            <%-- tabla img form --%>


            <table>

            </table>

        </div>
    </form>
</body>
</html>
