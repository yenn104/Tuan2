<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HangHoa.aspx.cs" Inherits="Tuan2.Views.HangHoa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <asp:GridView ID="gvProduct" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"  Height="246px" Width="984px" 
    AutoGenerateColumns="False" AllowPaging="True" onpageindexchanging="gvProduct_PageIndexChanging"  PageSize="2" 
    OnRowEditing="gvProduct_RowEditing" OnRowUpdating="gvProduct_RowUpdating" OnRowDeleting="gvProduct_RowDeleting">
    <Columns>
      <asp:BoundField DataField="Mahh" HeaderText="Mã" Visible="true">
      <%--  <ItemTemplate>
            <asp:Label ID="MaHH" runat="server" Text='<%# Eval("Mahh") %>' ></asp:Label>
        </ItemTemplate>--%>
      </asp:BoundField>

      <asp:BoundField DataField="Tenhh" HeaderText="Tên">
      <%--  <ItemTemplate>
            <asp:Label ID="Tenhh" runat="server" Text='<%# Eval("Tenhh") %>' ></asp:Label>
        </ItemTemplate>--%>
      </asp:BoundField>
      <asp:BoundField DataField="Madvt" HeaderText="Đơn vị tính">
       <%-- <ItemTemplate>
            <asp:Label ID="Madvt" runat="server" Text='<%# Eval("Madvt") %>' ></asp:Label>
        </ItemTemplate>--%>
      </asp:BoundField>
      <asp:BoundField DataField="sl" HeaderText="Số lượng">
       <%-- <ItemTemplate>
            <asp:Label ID="Sl" runat="server" Text='<%# Eval("Sl") %>' ></asp:Label>
        </ItemTemplate>--%>
      </asp:BoundField>
      <asp:BoundField DataField="Mancc" HeaderText="Nhà cung cấp">
       <%-- <ItemTemplate>
            <asp:Label ID="Mancc" runat="server" Text='<%# Eval("Mancc") %>' ></asp:Label>
        </ItemTemplate>--%>
      </asp:BoundField>

      <asp:CommandField ShowEditButton="True" />
      <asp:CommandField ShowDeleteButton="True" />

    </Columns>
    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
    <RowStyle BackColor="White" ForeColor="#003399" />
    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
    <SortedAscendingCellStyle BackColor="#EDF6F6" />
    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
    <SortedDescendingCellStyle BackColor="#D6DFDF" />
    <SortedDescendingHeaderStyle BackColor="#002876" />
  </asp:GridView>

  <script type="text/javascript">
    function Confirm() {
      var confirm_value = document.createElement("INPUT");
      confirm_value.type = "hidden";
      confirm_value.name = "confirm_value";
      if (confirm("Bạn muốn thực thi hành động này không?")) {
        confirm_value.value = "Yes";
      }
      else {
        confirm_value.value = "No";
      }
      document.forms[0].appendChild(confirm_value);
    }
  </script>


  </asp:Content>
