
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestePost.aspx.cs" Inherits="TestePost" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    protected void CheckBox17_CheckedChanged(object sender, EventArgs e)
    {

    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .txttitulo
        {
            margin-right: 20px;
        }
        .cbCategorias
        {
            margin-left: 30px;
            margin-top: 5px;
            padding-top: 10px;
            top: 20px;
        }
    
        .Corpopost
        {
            margin-left: 60px;
            height: 300px;
            width: 400px;
        }
        .MaxCharacter
        {
            margin-left: 100px;
        }
        .btnpost
        {
            margin-left: 450px;
        }
        .btncancel
        {
            margin-left: 20px;
        }
        .divNewPost
        {
            width: 650px;
            height: 600px;
            top: 400px;
            left: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="divNewPost" style="width: 654px; height: 532px">
    
       <a> Título:<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 15px" 
            Width="400px" CssClass="txttitulo"></asp:TextBox></a>

        
        <br />
        Genero(s) :&nbsp;&nbsp;
        <asp:CheckBox ID="CheckBox1" runat="server" CssClass="cbCategorias" 
            Text="Ação" />
        <asp:CheckBox ID="CheckBox2" runat="server" CssClass="cbCategorias" 
            Text="Aventura" />
        <asp:CheckBox ID="CheckBox3" runat="server" CssClass="cbCategorias" 
            Text="Terror" />
        <asp:CheckBox ID="CheckBox4" runat="server" CssClass="cbCategorias" 
            Text="Ficção Cientifica" />
        <asp:CheckBox ID="CheckBox5" runat="server" CssClass="cbCategorias" 
            Text="Arcade" />
        <br />
        <asp:CheckBox ID="CheckBox6" runat="server" CssClass="cbCategorias" 
            Text="Corrida" />
        <asp:CheckBox ID="CheckBox7" runat="server" CssClass="cbCategorias" 
            Text="Estratégia" />
&nbsp;<asp:CheckBox ID="CheckBox8" runat="server" CssClass="cbCategorias" 
            Text="Esportes" />
        <asp:CheckBox ID="CheckBox9" runat="server" CssClass="cbCategorias" 
            Text="Luta" />
        <asp:CheckBox ID="CheckBox10" runat="server" CssClass="cbCategorias" 
            Text=" MMORPG" />
        <asp:CheckBox ID="CheckBox11" runat="server" CssClass="cbCategorias" 
            Text="Multi Player" />
        <br />
        <asp:CheckBox ID="CheckBox12" runat="server" CssClass="cbCategorias" 
            Text="Raciocínio e Lógica" />
        <asp:CheckBox ID="CheckBox13" runat="server" CssClass="cbCategorias" 
            Text="RPG" />
        <asp:CheckBox ID="CheckBox14" runat="server" CssClass="cbCategorias" 
            Text="Simuladores" />
        <asp:CheckBox ID="CheckBox15" runat="server" CssClass="cbCategorias" 
            Text="Infantil" />
        <asp:CheckBox ID="CheckBox16" runat="server" CssClass="cbCategorias" 
            Text="Adulto" />
        <br />
        <br />
        Assunto:
        <asp:CheckBox ID="CheckBox17" runat="server" CssClass="cbCategorias" 
            oncheckedchanged="CheckBox17_CheckedChanged" Text="Novidades" />
        <asp:CheckBox ID="CheckBox18" runat="server" Text="Dicas" />
        <asp:CheckBox ID="CheckBox19" runat="server" Text="Downloads" />
        <asp:CheckBox ID="CheckBox20" runat="server" Text="Forum" />
        <asp:CheckBox ID="CheckBox21" runat="server" Text="Outros" />

        
            <p>
                Corpo:</p>
        <p>
                <asp:TextBox ID="TextBox4" runat="server" CssClass="Corpopost" Height="151px" 
                    style="top: 195px" Width="508px"></asp:TextBox>
        </p>
        <p>
                <asp:Label ID="Label1" runat="server" CssClass="MaxCharacter" Text="Max. 10000"></asp:Label>
        </p>
        <p>
                &nbsp;</p>
        <p>
                <asp:Button ID="Button1" runat="server" BackColor="Transparent" 
                    CssClass="btnpost" Text="Postar" />
                <asp:Button ID="Button2" runat="server" BackColor="Transparent" 
                    CssClass="btncancel" Text="Cancelar" />
        </p>

        
    </div>
    
    </div>
    </form>
</body>
</html>
