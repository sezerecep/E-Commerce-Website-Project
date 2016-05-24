<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="siparislerim.aspx.cs" Inherits="RSezer_ETicaret.siparislerim" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Siparişleriniz </title>
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
            <div class="orders">
                <asp:DataList ID="DataList1" runat="server" Height="100%" Width="100%" RepeatLayout="Flow"  RepeatDirection="Horizontal" >
                    <ItemTemplate>
                        <div id="dvUrun" style="margin-left:15%; margin-top:5%">
                
                            Sipariş No:<%#Eval("O_ID") %>,&nbsp&nbsp
                            Sipariş Durumu:<%#Eval("O_Status") %>,&nbsp&nbsp
                            Ödeme Türü:<%#Eval("O_PaymentType") %>&nbsp&nbsp<br />

                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <footer>
                Recep Sezer - 2016
            </footer>

        </div>

    </form>
</body>
</html>
