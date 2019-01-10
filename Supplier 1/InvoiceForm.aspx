<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="InvoiceForm.aspx.cs" Inherits="Supplier_1.InvoiceForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container white z-depth-2">
        <ul class="tabs teal center">
            <li class="tab col s6"><a class="white-text">Invoice</a></li>
        </ul>
        <div class="col s12">
            <div class="form-container">
                <h3 class="teal-text">
                    <asp:Label ID="month_lbl" runat="server" Text="Label"></asp:Label>
                </h3>
                <div class="row">
                    <div class="input-field col s12">
                        <table>
                            <tr>
                                <td><b>Bill To</b></td>
                                <td><b>Month Of Invoice</b></td>
                                <td><b>Invoice Number #</b></td>
                                <td><b>Invoice Date</b></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_billing" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_invMonth" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_invoiceNo" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_invoicedate" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <br />
                <div class="col s12">
                    <div class="form-container">
                        <asp:GridView ID="gv_invoice" CssClass="striped" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField HeaderText="Date Of Delivery" ReadOnly="True" DataField="startDate" />
                                <asp:BoundField HeaderText="Description" ReadOnly="True" DataField="aID" />
                                <asp:BoundField HeaderText="Total Amount" DataField="finalPrice" />
                            </Columns>

                        </asp:GridView>
                        <div class="input-field col s12">
                            <asp:Label ID="lbl_subtotal" CssClass="right" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lbl_shippfee" CssClass="right" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lbl_finalprice" CssClass="right" runat="server"></asp:Label>
                            <br />
                            <br />
                            <asp:LinkButton ID="btn_close" CssClass="btn waves-effect waves-light right" runat="server" OnClick="btn_close_Click">Proceed</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
