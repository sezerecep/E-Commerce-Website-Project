<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="urundetay.aspx.cs" Inherits="RSezer_ETicaret.urundetay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> E-Ticaret Sitem </title>
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
                      <li>
                          <a href="default.aspx">Ürünler</a>
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
            <div class="productdetail">
                
              <div class="tableholder">
                  <ul>

                      <li>
                          <asp:Label ID="Label2" runat="server" Text="Kategori:" Font-Size="Large"></asp:Label>
                      </li>
                      <li>
                           <asp:Label ID="Label3" runat="server" Text="Ürün Adı:" Font-Size="Large"></asp:Label>
                      </li>
                      <li>
                          <asp:Label ID="Label4" runat="server" Text="Fiyat:" Font-Size="Large"></asp:Label>
                      </li>
                      <li>
                           <asp:Label ID="Label5" runat="server" Text="Açıklama:" Font-Size="Large"></asp:Label>
                      </li>
                      <li>
                          <asp:Label ID="Label6" runat="server" Text="Stok Adedi:" Font-Size="Large"></asp:Label>
                      </li>

                  </ul>

              </div>
                <div class="buttonholder">

                    <asp:Label ID="Label1" runat="server" Text="Adet:" Font-Size="Large"></asp:Label>
                    <asp:TextBox ID="TBurunadedi" runat="server" type="number" Font-Size="Large" Height="43px" Width="55px" Padding="10px"></asp:TextBox>
                    <asp:Button ID="BTsepeteekle" runat="server" Text="Sepete Ekle" Font-Size="Large" Height="42px" Padding="10px" OnClick="BTsepeteekle_Click" BackColor="#F2C35B" />

              </div>
                
            </div>
            <footer>
                Recep Sezer - 2016
            </footer>

                  

        </div>
 
    </form>
</body>
</html>
