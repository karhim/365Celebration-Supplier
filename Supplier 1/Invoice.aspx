<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="Supplier_1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6 "><a class="white-text">Generate Invoice</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container ">

                <div class="row">
                    <div class="input-field col s12">
                        &nbsp;Month of Invoice:
             <asp:DropDownList ID="DropDownList1" runat="server" CssClass="browser-default">
                      <asp:ListItem Text ="Select Month" Value="-1"></asp:ListItem>
                 <asp:ListItem Text ="Jan" Value="January"></asp:ListItem>
                 <asp:ListItem Text ="Feb" Value="February"></asp:ListItem>
                 <asp:ListItem Text ="Mar" Value="March"></asp:ListItem>
                 <asp:ListItem Text ="Apr" Value="April"></asp:ListItem>
                 <asp:ListItem Text ="May" Value="May"></asp:ListItem>
                 <asp:ListItem Text ="Jun" Value="June"></asp:ListItem>
                 <asp:ListItem Text ="Jul" Value="July"></asp:ListItem>
                 <asp:ListItem Text ="Aug" Value="August"></asp:ListItem>
                 <asp:ListItem Text ="Sep" Value="September"></asp:ListItem>
                 <asp:ListItem Text ="Oct" Value="October"></asp:ListItem>
                 <asp:ListItem Text ="Nov" Value="November"></asp:ListItem>
                 <asp:ListItem Text ="Dec" Value="December"></asp:ListItem>
                  </asp:DropDownList>
                        <br />
                        <br />
                        <div class="center">
                            <asp:Button ID="Invoice_btn" runat="server" Text="Generate Invoice" OnClick="Invoice_btn_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
