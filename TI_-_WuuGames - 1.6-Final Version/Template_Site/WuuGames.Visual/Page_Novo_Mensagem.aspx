<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Page_Novo_Mensagem.aspx.cs" Inherits="NovaMensagem" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <div id=nova_Mensagem class="divNweMensagem">
    

    <span><strong class="Msglbl">Nova Mensagem:</strong></span>
    </br>
    </br>
    <span class="msgspans">Para:</span>
        <asp:Label ID="lblUsuario" runat="server"></asp:Label>
    </br>    
    <span class="msgspans">Assunto:</span>
    </br>
    </br>
        <asp:TextBox ID="txtAssunto" runat="server" CssClass="txtsMsg" ></asp:TextBox>
        </br>
    <span class="msgspans">Mensagem:</span>
    </br>
        <asp:TextBox ID="txtMensagem" runat="server" CssClass="txtsMsg" Height="104px" 
            TextMode="MultiLine"></asp:TextBox>

            </br>
            </br>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Tipo:<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="1">Privada</asp:ListItem>
            <asp:ListItem Value="2">Negociacao</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Enviar" CssClass="btnMensagem" 
            onclick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" style="margin-left: 48px" 
            Text="Cancelar" Width="97px" onclick="Button2_Click" />
    </div>
</asp:Content>


