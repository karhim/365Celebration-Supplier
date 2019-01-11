<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Supplier_1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

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
    </form>
</body>
</html>
