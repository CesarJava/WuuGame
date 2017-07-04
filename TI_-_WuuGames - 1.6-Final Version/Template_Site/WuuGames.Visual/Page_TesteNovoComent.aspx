<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Page_TesteNovoComent.aspx.cs" Inherits="TesteNovoComent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Comment_Div
        {
            margin: 5px;
            border: thin solid white;
            width: 600px;
            background-color: transparent;
        }
        .Pnl_NovoComent
        {
            border: thin solid white;
            width: 600px;
            background-color: transparent;
        }
        .Title_NovoComment
        {
            margin-left: 250px;
            color: #0099FF;
            text-decoration: underline blink;
            background-color: transparent;
        }
        .Name_NewPost
        {
            margin-left: 20px;
            color: #0099FF;
            text-decoration: underline;
        }
        .txt_NewPost
        {
            width: 500px;
            margin-left: 50px;
            height: 250px;
        }
        .btn_NewPost
        {
            clear: both;
            float: right;
            width: 120px;
            height: 40px;
            color: #0099FF;
            text-decoration: underline;
            border: medium solid white;
            background-color: black;
        }
        #div_CorpoNewComent
        {
            width: 550px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" CssClass="Pnl_NovoComent">
        <div id="Comment_Div" >
                    <span class="Title_NovoComment">Deixe Seu Comentário:</span>
                    <br />   
                     <br />  
                                  
                        <div id="Novo_Coment">                         
                            <div id="div_CorpoNewComent">
                            <label class="Name_NewPost">Seu Comentário:</label>
                            <br />                           
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="txt_NewPost" 
                                    TextMode="MultiLine"></asp:TextBox>
                            </div>
                                                       
                            &nbsp;<asp:Button ID="Button1" runat="server" Text="Button" 
                                CssClass="btn_NewPost" />
                   </div>                      
                    
            </div>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
