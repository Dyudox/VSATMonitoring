<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="editfoto.aspx.vb" Inherits="editfoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li class="active">Edit Foto</li>
        </ul>
    </div>
    <br />
    <div class="col-md-6">
        <label>Judul Baru</label>
        <asp:TextBox ID="txtjudul" runat="server" CssClass="form-control"></asp:TextBox>
        <br />       
        <label for="exampleInputEmail1">Keterangan Images</label>
        <textarea maxlength="100" class="form-control input-sm bounceIn animation-delay2" rows="4" id="txtketgambar" placeholder="Keterangan" runat="server" required="required"></textarea>
         <br />
        <label>Gambar Baru</label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="btn btn-success" />
    </div>
</asp:Content>

