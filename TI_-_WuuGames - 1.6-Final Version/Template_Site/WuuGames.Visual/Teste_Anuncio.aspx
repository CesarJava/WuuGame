<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Teste_Anuncio.aspx.cs" Inherits="Teste_Anuncio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .img_Anuncio
        {
            float: left;
            margin-left: 0px;
            margin-top: 118px;
        }
        #Anuncio
        {
            height: 500px;
            width: 600px;
        }
        .txtsAnuncio
        {
            margin-left: 20px;
        }
        .lblDesc
        {
            width: 350px;
            height: 250px;
            margin-left: 25px;
        }
        .btnNegociar
        {
            border: 1px solid white;
            float: right;
            color: #0099FF;
            text-decoration: underline;
            background-color: transparent;
            margin-right: 20px;
        }
        .txtPreço
        {
            margin-left: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
    <div id="Anuncio">
        <asp:Image ID="Image1"  runat="server" CssClass="img_Anuncio" Height="232px" 
            Width="201px" />
        <br />
       <span class="txtsAnuncio">Anunciante: </span> <a href="Page_Usuario.aspx?<%=lblAnunciante.Text %>">    <asp:Label ID="lblAnunciante" runat="server" Text="Label"></asp:Label>  </a>
       <br />
       <br />
       <span class="txtsAnuncio">Nome do Anuncio:</span> <asp:Label ID="lblNomeAnuncio" runat="server" Text="Label"></asp:Label>
       <br />
       <br />
       <span class="txtsAnuncio">Descrição:</span>
       <br />
        <asp:TextBox ID="TextBox1" runat="server" CssClass="lblDesc" Height="250px" 
            Width="349px"></asp:TextBox>
            <br />
        <br />
        <span class="txtPreço">Preço:</span><asp:Label ID="lblPreco" runat="server" Text="Label"></asp:Label>
        <br />
        <span class="txtsAnuncio">Quantidade:</span> <asp:Label ID="lblQte" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Negociar " CssClass="btnNegociar" 
            Height="38px" Width="123px" />
    </div>


    
    </div>
    </form>
</body>
</html>
