<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RPSale.aspx.cs" Inherits="Tuan2.Views.RPHangHoa" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
  
  <asp:Button ID="btnTao" runat="server" Height="40px" OnClick="btnTao_Click" Text="Tạo report" Width="100px" style="margin-top: 40px" TabIndex="1"/>
  <asp:Button ID="btnPDF" runat="server" Height="40px" OnClick="btnPDF_Click" Text="Xuất PDF" Width="100px" />
  <asp:Button ID="btnExcel" runat="server" Height="40px" TabIndex="2" Text="Xuất Excel" Width="100px" style="margin: 40px 0px" OnClick="btnExcel_Click" />
  <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
  <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="400px" style="margin-top: 60px; border:0.5px solid #ccc" Width="100%" DocumentMapWidth="50%">
  </rsweb:ReportViewer>

  </asp:Content>


