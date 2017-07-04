using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WuuGames.Modelo;
using WuuGames.Business;


public partial class Anuncios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Tipo"] != "")
        {
            if (Request.QueryString["Tipo"] == "Todos")
            {
               
                AnuncioLogica anuncios = new AnuncioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
                List<AnuncioModelo> listaanuncios = anuncios.RecuperarTodos();
              //  GridView1.DataSource = listaanuncios;                
                //GridView1.DataBind();                
            }
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Response.Redirect("Anuncio.aspx?AnuncioId=" +  GridView1.SelectedRow.Cells(1).Text);
    }
    protected void GridView1_SelectedIndexChanged(object sender, GridViewSelectEventArgs e)
    {
       // Response.Redirect("Anuncio.aspx?AnuncioId" + GridView1.SelectedRow.Cells[1].Text);
        
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       int currentRowIndex = Convert.ToInt32(e.CommandArgument);
     //  Response.Redirect("Anuncio.aspx?AnuncioId=" + GridView1.DataKeys[1].Value.ToString());
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Response.Redirect("Anuncio.aspx?AnuncioId" + GridView1.SelectedRow.Cells[1].Text);
    }
}