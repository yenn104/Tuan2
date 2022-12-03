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
  public partial class Products : System.Web.UI.Page
  {
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
      GetDS();
    }

    private void GetDS()
    {
      try
      {
        DataTable dataTable = new DataTable();
        string sql = "Select Mahh as N'Mã hàng hóa', Tenhh as N'Tên hàng hóa', Madvt as N'Đơn vị tính', SL as N'Số lượng', Mancc as N'Mã nhà cung cấp' From Hanghoa;";

        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        conn.Open();
        da.Fill(dataTable);
        //dataTable.Rows.Add("Xoa");
        conn.Close();
        if (dataTable.Rows.Count > 0)
        {
          gvProduct.Visible = true;
          gvProduct.Enabled = true;
         // gvProduct.Rows.i
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
  }
}