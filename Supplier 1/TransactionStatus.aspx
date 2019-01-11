<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TransactionStatus.aspx.cs" Inherits="Supplier_1.TransactionStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container white z-depth-2">
        <ul class="tabs red lighten-2 center">
            <li class="tab col s6"><a class="white-text">Invoice manager</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" >
                <Columns>
                    <asp:BoundField DataField="invoiceID" HeaderText="Invoice ID" ReadOnly="True" />
                    <asp:BoundField DataField="invoiceDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Invoice Date" ReadOnly="True" />
                    <asp:BoundField DataField="InvoiceMonth" HeaderText="Invoice Month" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Payment Status">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("paymentStatus") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("paymentStatus") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="True" SelectText="Enter" />
                    <asp:CommandField ShowEditButton="True" />
                </Columns>
            </asp:GridView>

        </div>
            </div>
               </div>
</asp:Content>
