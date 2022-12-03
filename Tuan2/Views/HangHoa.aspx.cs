using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tuan2.Views
{
  public partial class HangHoa : System.Web.UI.Page
  {
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        GetDS();
      }
    }

    private void GetDS()
    {
      try
      {
        DataTable dataTable = new DataTable();
        string sql = "Select * From Hanghoa;";

        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        conn.Open();
        da.Fill(dataTable);
        conn.Close();
        if (dataTable.Rows.Count > 0)
        {
          gvProduct.DataSource = dataTable;
          gvProduct.DataBind();
        }
        else
        {
          gvProduct.DataSource = null;
          gvProduct.DataBind();
        }
        dataTable.Dispose();
      }
      catch
      {
        conn.Close();
      }

    }

    protected void gvProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      gvProduct.PageIndex = e.NewPageIndex;
      GetDS();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      GetDS();
    }


    protected void linkXoa_Click(object sender, EventArgs e)
    {
      LinkButton clickedbutton = (LinkButton)sender;
      GridViewRow row = (GridViewRow)clickedbutton.NamingContainer;

      string Mahh;
      //Mahh = row.Cells[0].Text;

      Label tx;
      tx = (Label)row.FindControl("lbMaHH");
      Mahh = tx.Text;

      string confirmValue = Request.Form["confirm_value"];
      if (confirmValue == "Yes")
      {
        conn.Open();
        string Stri = "delete from Hanghoa " +
         " where Mahh like N'" + Mahh + "'";
        SqlCommand Cmd = new SqlCommand(Stri, conn);
        Cmd.ExecuteNonQuery();
        Cmd.Dispose();
        conn.Close();
        Mahh = string.Empty;

        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Đã xoá thành công');", true);
        GetDS();
      }
    }

    protected void gvProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      var MaMH = gvProduct.Rows[e.RowIndex].Cells[0].Text;
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM HangHoa WHERE MaHH='" + MaMH + "'", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
      GetDS();
    }

    protected void gvProduct_RowEditing(object sender, GridViewEditEventArgs e)
    {
      gvProduct.EditIndex = e.NewEditIndex;
      GetDS();
    }



    protected void gvProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      gvProduct.EditIndex = -1;
      GridViewRow row = this.gvProduct.Rows[e.RowIndex];
      TextBox txtmahh = (TextBox)row.Cells[0].Controls[0];
      TextBox txttenhh = (TextBox)row.Cells[1].Controls[0];
      TextBox txtmadvt = (TextBox)row.Cells[2].Controls[0];
      TextBox txtsl = (TextBox)row.Cells[3].Controls[0];
      TextBox txtmancc = (TextBox)row.Cells[4].Controls[0];
      conn.Open();   
      string sql = "Update Hanghoa set Tenhh=N'" + txttenhh.Text + "',Madvt='" + txtmadvt.Text + "',SL='" + txtsl.Text + "',Mancc='" + txtmancc.Text + "'Where Mahh='" + txtmahh.Text + "'";
      SqlCommand updateCmd = new SqlCommand(sql, conn);
      updateCmd.ExecuteNonQuery();      
      conn.Close();  
      GetDS();
    }
  }

}