<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Page_Novo_Usuario.aspx.cs" Inherits="CadastroUsuario" EnableViewstate="true" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="divcadastro" >
        </br>
                <asp:Label ID="lblExcecao" runat="server" CssClass="lblsCadastro"></asp:Label>
           </br>
           </br>
                <span class="cadastrotitle">Cadastro de Usuario:</span>
                </br>           
               <span class="lblsCadastro">Nome:</span>
               </br>
                <asp:TextBox ID="txtNome" runat="server" CssClass="txtscadastro" 
            Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="*Nome é necessário" ControlToValidate="txtNome" 
            CssClass="lblResponse"></asp:RequiredFieldValidator>        
              </br>
               <span class="lblsCadastro">Login:</span>
               </br>
                <asp:TextBox ID="txtlogin" runat="server" CssClass="txtscadastro"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtlogin" ErrorMessage="*Login é necessário" 
            CssClass="lblResponse"></asp:RequiredFieldValidator>
        </br>
               <span class="lblsCadastro">Senha:</span>
               </br>
                <asp:TextBox ID="txtSenha" runat="server" CssClass="txtscadastro" 
            TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtSenha" ErrorMessage="*Senha é necessária" 
            CssClass="lblResponse"></asp:RequiredFieldValidator>
        </br>
                <span class="lblsCadastro">Confirmar Senha: </span>
               </br>
               <asp:TextBox ID="txtconfirmarsenha" 
                    runat="server" CssClass="txtscadastro" TextMode="Password"></asp:TextBox>
     </br>
               
               <span class="lblsCadastro">RG:</span>
               </br>
                <asp:TextBox ID="txtRg" runat="server" ValidationGroup="CPFouRG" 
                    CssClass="txtscadastro"></asp:TextBox>
                    </br>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtRg" ErrorMessage="*RG ou CPF são nescessários" 
                    ValidationGroup="CPFouRG" CssClass="lblsCadastro"></asp:RequiredFieldValidator>
      </br>
                <span class="lblsCadastro">CPF:</span>
                </br>
                <asp:TextBox ID="txtCPF" runat="server" ValidationGroup="CPFouRG" 
                    CssClass="txtscadastro"></asp:TextBox>
       </br>
               <span class="lblsCadastro">Data de Nascimento:</span>
               </br> 
                <span class="lblData">Dia:</span><asp:DropDownList ID="DropDia" 
            runat="server" >                  
                </asp:DropDownList>
                <span class="lblResponse">Mês:</span>
                <asp:DropDownList ID="DropMes" runat="server" style="margin-bottom: 0px" 
                    Width="88px">
                </asp:DropDownList>
                <span class="lblResponse">Ano:</span>
                <asp:DropDownList ID="DropAno" runat="server">
                </asp:DropDownList>
       </br>
               <span class="lblsCadastro"> E-mail: </span>
               </br>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="txtscadastro"></asp:TextBox>
        </br>
              <span class="lblsCadastro"> Interesses:</span>
               </br>              
                
                <asp:TextBox ID="txtInteresses" runat="server" Height="52px" Width="350px" 
                    CssClass="txtscadastro" TextMode="MultiLine"></asp:TextBox>
       </br>
       </br>
                <span class="lblsCadastro">Imagem:</span>
                </br>        
                <asp:FileUpload ID="CaminhoImagem" runat="server" 
            CssClass="txtscadastro" />
        </br>
        </br>
                <asp:Button ID="BtnCadastrar" runat="server" Text="Cadastrar" 
                    onclick="BtnCadastrar_Click" style="text-align: center" 
                    CssClass="btncadastro" />
        </p>
        </div>
        
</asp:Content>

