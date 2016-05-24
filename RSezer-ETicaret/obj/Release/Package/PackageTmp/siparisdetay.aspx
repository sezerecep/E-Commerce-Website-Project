<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="siparisdetay.aspx.cs" Inherits="RSezer_ETicaret.siparisdetay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title> Sipariş İçin Detay </title>
        <link href="style.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">

        <div id="wrapper">
            <header>
                <div class="logo">
                    <img src="logo.jpg" style="width:100%; height:100%;" />
                </div>
              <nav>
                  <ul>
                      <li class="cat-wrap">
                          <a href="Default.aspx">Ürünler</a>
                      </li>
                  </ul>
                  <ul>
                      <li>
                           <a href="sepetim.aspx">Sepetim</a>
                      </li>
                  </ul>
                   <ul>
                      <li>
                          <a href="siparislerim.aspx">Siparişlerim</a>
                      </li>
                  </ul>
              </nav>
                
            </header>
            <div class="cart" style="margin:0 auto;" > 
                 <ul style="list-style:none;">
                      <li style="margin:40px;">
                          <asp:Label ID="Label1" runat="server" Text="Posta Kodu:" Font-Size="Large" Height="20px"></asp:Label><asp:TextBox ID="TBpostcode" runat="server" Height="20px" Font-Size="Large" Width="100%"></asp:TextBox>
                      </li>
                  </ul>
                  <ul style="list-style:none;">
                      <li style="margin:40px;">
                          <asp:Label ID="Label2" runat="server" Text="Adres:" Font-Size="Large"></asp:Label><asp:TextBox ID="TBaddress" runat="server" Height="20px" Font-Size="Large" Width="100%"></asp:TextBox>
                      </li>
                  </ul>
                 <ul style="list-style:none;">
                      <li style="margin:40px;">
                         <asp:Label ID="Label3" runat="server" Text="Şehir:" Font-Size="Large"></asp:Label><asp:TextBox ID="TBcity" runat="server" Height="20px" Font-Size="Large" Width="100%"></asp:TextBox>
                      </li>
                  </ul>
                 <ul style="list-style:none;">
                      <li style="margin:40px;">
                          <asp:Label ID="Label4" runat="server" Text="Bölge:" Font-Size="Large"></asp:Label><asp:TextBox ID="TBregion" runat="server" Height="20px" Font-Size="Large" Width="100%"></asp:TextBox>
                      </li>
                  </ul>
                 <ul style="list-style:none;">
                     <li style="margin:40px;">
                          <asp:Label ID="Label5" runat="server" Text="Ülke:" Font-Size="Large"></asp:Label><asp:TextBox ID="TBcountry" runat="server" Height="20px" Font-Size="Large" Width="100%"></asp:TextBox>
                      </li>
                  </ul>
                 <ul style="list-style:none;">
                      <li style="margin:40px;">
                         <asp:Label ID="Label6" runat="server" Text="Ödeme Tipi:" Font-Size="Large"></asp:Label>
                         <asp:DropDownList ID="DDLpayment" runat="server" Font-Size="Large" Height="35px" Width="20%">
                              <asp:ListItem>Kredi Kartı</asp:ListItem>
                              <asp:ListItem>EFT</asp:ListItem>
                              <asp:ListItem>Kapıda Ödeme</asp:ListItem>
                          </asp:DropDownList>
                      </li>
                  </ul>
                <ul style="list-style:none;">
                      <li style="margin:40px;">
                          <asp:Button ID="BTonay" runat="server" Text="Siparişi Onayla" Font-Size="Large" Height="30px" OnClick="BTonay_Click" Width="20%" BackColor="#F2C35B" />
                      </li>
                  </ul>
            </div>
            <footer>
                Recep Sezer - 2016
            </footer>

        </div>

    </form>
</body>
</html>

