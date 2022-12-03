<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Collection.aspx.cs" Inherits="Tuan2.Views.Collection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="tab">
    <button class="tablinks" onclick="openMenu(event, 'Home')">Home</button>
    <button class="tablinks" onclick="openMenu(event, 'Contact')">Contact</button>
    <button class="tablinks" onclick="openMenu(event, 'About')">About</button>
  </div>

  <div id="Home" class="tabcontent">
    <h3>Home</h3>
    <p>Homeeeeeeeeeeeeeeeeeeee</p>
  </div>

  <div id="Contact" class="tabcontent">
    <h3>Contact</h3>
    <p>Contacttttttttttttttttt</p> 
  </div>

  <div id="About" class="tabcontent">
    <h3>About</h3>
    <p>Abouttttttttttttttttttt</p>
  </div>
  
  <div style="margin:150px 20px">
    <a runat="server" href="~/" style="text-decoration: none; padding:10px; border:1px solid antiquewhite">Quay Lại</a>
  </div>

  <script>
    function openMenu(evt, item) {
      var i, tabcontent, tablinks;
      tabcontent = document.getElementsByClassName("tabcontent");
      for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
      }
      tablinks = document.getElementsByClassName("tablinks");
      for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
      }
      document.getElementById(item).style.display = "block";
      evt.currentTarget.className += " active";
    }
  </script>

</asp:Content>
