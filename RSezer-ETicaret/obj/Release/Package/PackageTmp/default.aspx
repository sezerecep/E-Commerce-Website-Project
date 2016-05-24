<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="RSezer_ETicaret._default" %>

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
                  <ul>
                      <li>
                          <asp:Button ID="BTlogout" runat="server" Text="Çıkış" Font-Size="Large" Height="45px" Width="80px" BackColor="#F2C35B" OnClick="BTlogout_Click" />
                      </li>
                  </ul>
              </nav>
                
            </header>
            <div class="middle">
                <div class="banner">
                    <img src="banner.png" style="height:100%; width:100%;"/>
                </div>
                <div class="login">
                    
                    <asp:Login ID="LGuser" runat="server" Height="360px"  PasswordLabelText="Şifre:" TitleText="Giriş Yap &amp; Hızlı Kayıt" UserNameLabelText="Kullanıcı Adı:" Width="360px">
                        <LayoutTemplate>
                            <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                                <tr>
                                    <td>
                                        <table cellpadding="0" style="height:360px;width:350px; padding-left: 15px;">
                                            <tr>
                                                <td align="center" colspan="2">Giriş Yap &amp; Hızlı Kayıt</td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Font-Size="Large">E-mail:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="UserName" runat="server" Font-Size="Large" Height="45px" Width="250px" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="LGuser">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Font-Size="Large">Şifre:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" Font-Size="Large" Height="45px" Width="250px" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="LGuser">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="color:Red;">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                                    <asp:Button ID="BTlogin" runat="server" CommandName="Login" Text="Giriş" ValidationGroup="LGuser" Font-Size="Large" Height="45px" Width="50px" OnClick="BTlogin_Click" />
                                                    <asp:Button ID="BTregister" runat="server" CommandName="Login" Text="Kayıt Ol" ValidationGroup="LGuser" Font-Size="Large" Height="45px" Width="80px" OnClick="BTregister_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                    </asp:Login>

                </div>
            </div>
            <div class="listing">
                <div class="categories">

                    <asp:Label ID="LBcategories" runat="server" CssClass="LBcategories" Font-Size="Large" Text="Kategoriler:"></asp:Label>
                    <asp:DropDownList ID="DDLcat" runat="server" CssClass="DDLcat" Font-Size="Large" Height="21px" Width="151px" AutoPostBack="True" OnSelectedIndexChanged="DDLcat_SelectedIndexChanged">
                    </asp:DropDownList>

                </div>
                <div class ="products">
                    <div style="overflow-x: hidden; overflow: scroll; width: 100%; height:100%;">
                    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" Height="100%" Width="100%" >
        <ItemTemplate>
            <div id="dvUrun" style="margin-left:15%;">
                
                <%#Eval("P_Name") %><br />
                <a href="urundetay.aspx?P_Name=<%#Eval("P_Name") %>"><img src="det.png" /></a>
                <br /> 
                <%#Eval("P_Price") %> TL<br />
                <%#Eval("CAT_Name") %><br />

            </div>

        </ItemTemplate>


    </asp:DataList>
                        </div>
                </div>
            </div>
            <footer>
                Recep Sezer - 2016
            </footer>

        </div>

    </form>
</body>
</html>
