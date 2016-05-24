<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sepetim.aspx.cs" Inherits="RSezer_ETicaret.sepetim" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Sepetiniz </title>
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
            <div class="cart" >
                <div style="overflow-x: hidden; overflow: scroll; width: 100%; height:90%;">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" Height="100%" Width="100%" RepeatLayout="Table" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" >
                    <ItemTemplate>
                        <div id="dvUrun" style="margin-left:15%;">
                
                            <%#Eval("P_Name") %><br /> 
                            <%#Eval("P_Price") %> TL<br />
                            <%#Eval("CP_Count") %><br />
                             <a href="sepetim.aspx?P_Name=<%#Eval("P_Name") %>"><img src="del.png" /></a><br />

                        </div>

                    </ItemTemplate>


                </asp:DataList>
                    </div>
                <div style="width: 100%; height:10%; margin:0 auto; text-align:center; line-height:50%;">
                    <asp:Button ID="BTsepetionayla" runat="server" Text="Sepeti Onayla" Font-Size="Large" Height="45px" OnClick="BTsepetionayla_Click" Width="160px" BackColor="#F2C35B" />
                </div>
            </div>
            <footer>
                Recep Sezer - 2016
            </footer>

        </div>

    </form>
</body>
</html>
