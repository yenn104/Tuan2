using ClosedXML.Excel;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tuan2.Views
{
  public partial class RPHangHoa : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
     
    }

    protected void GenerateReport()
    {
      SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

      conn.Open();
      SqlCommand comd;
      comd = new SqlCommand();
      comd.Connection = conn;


      comd.CommandType = CommandType.StoredProcedure;
      comd.CommandText = "Sto_Banhang02";
      comd.Parameters.Add("@Ngay", SqlDbType.Date);
      comd.Parameters[0].Value = "03/02/2022";


      SqlDataAdapter sqlAdapter = new SqlDataAdapter();
      sqlAdapter.SelectCommand = comd;

      DataSet Dset = new DataSet();

      sqlAdapter.Fill(Dset, "Dset");

      ReportDataSource MyDs = new ReportDataSource();
      MyDs.Name = "DataSetHangHoa";
      MyDs.Value = Dset.Tables[0];

      ReportViewer1.ProcessingMode = ProcessingMode.Local;
      ReportViewer1.LocalReport.ReportPath = Server.MapPath("/Reports/RPSale.rdlc");

      ReportViewer1.LocalReport.DataSources.Clear();
      ReportViewer1.LocalReport.DataSources.Add(MyDs);
      conn.Close();

    }


    protected void ExportToExcel()
    {
      DataTable dataTable = GetDatafromDatabase();
      using (XLWorkbook xlwb = new XLWorkbook())
      {
        xlwb.Worksheets.Add(dataTable, "ThongKe");
        string myName = Server.UrlEncode("lby.xlsx");
        MemoryStream ms = GetStream(xlwb);
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment; filename=" + myName);
        Response.ContentType = "application/vnd.ms-excel";
        Response.BinaryWrite(ms.ToArray());
        Response.End();
      }
    }

    protected DataTable GetDatafromDatabase()
    {
      SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
      DataTable dataTable = new DataTable();
      conn.Open();
      SqlCommand comd = new SqlCommand("Sto_Banhang02 '" + "03/02/2022" + "' ", conn);
      SqlDataAdapter sqlAdapter = new SqlDataAdapter(comd);
      sqlAdapter.Fill(dataTable);
      conn.Close();
      return dataTable;
    }

    protected MemoryStream GetStream(XLWorkbook xlwb)
    {
      MemoryStream ms = new MemoryStream();
      xlwb.SaveAs(ms);
      ms.Position = 0;
      return ms;
    }

    protected void GeneratePDF()
    {
      SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
      conn.Open();
      SqlCommand comd = new SqlCommand();
      comd.Connection = conn;

      comd.CommandType = CommandType.StoredProcedure;
      comd.CommandText = "Sto_Banhang02";
      comd.Parameters.Add("@Ngay", SqlDbType.Date);
      comd.Parameters[0].Value = "03/02/2022";

      SqlDataAdapter sqlAdapter = new SqlDataAdapter();
      sqlAdapter.SelectCommand = comd;

      DataSet Dset = new DataSet();
      sqlAdapter.Fill(Dset, "Dset");

      ReportDataSource MyDs = new ReportDataSource();
      MyDs.Name = "DataSetHangHoa";
      MyDs.Value = Dset.Tables[0];


      ReportViewer1.ProcessingMode = ProcessingMode.Local;
      ReportViewer1.LocalReport.ReportPath = Server.MapPath("/Reports/RPSale.rdlc");

      ReportViewer1.LocalReport.DataSources.Clear();
      ReportViewer1.LocalReport.DataSources.Add(MyDs);
      conn.Close();


      Warning[] warnings;
      string[] streamIds;
      string mimeType = string.Empty;
      string encoding = string.Empty;
      //string encoding = "";
      string extension = string.Empty;
      string filename = "lby";
      var deviceInfo = @"<DeviceInfo> <EmbedFonts>None</EmbedFonts> </DeviceInfo>";

      byte[] bytes = ReportViewer1.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out extension, out streamIds, out warnings);

      Response.Buffer = true;
      Response.Clear();
      Response.ContentType = mimeType;
      Response.AddHeader("content-disposition", "attachment; filename=" + filename + "." + extension);
      Response.BinaryWrite(bytes);           
      Response.Flush();
    }

    protected void btnTao_Click(object sender, EventArgs e)
    {
      GenerateReport();
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
      ExportToExcel();
    }

    protected void btnPDF_Click(object sender, EventArgs e)
    {
      GeneratePDF();
    }

  }
}