<%@ Page Title="" Language="VB" MasterPageFile="~/site.master" AutoEventWireup="false" CodeFile="ChangePassword.aspx.vb" Inherits="ChangePassword" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script>
        function ValidationAdd() {
            var PassOld = document.getElementById("ctl00_MainContent_txtPassword");
            var PassNew = document.getElementById("ctl00_MainContent_TxtPasswordNew");
            var PassConf = document.getElementById("ctl00_MainContent_TxtPasswordConfirm");

            var SLow = /[a-z]/g;
            var SUper = /[A-Z]/g;
            var Snum = /\d/;
            var SKar = /[!#$%&"'()*+,./:;<=>?@\^_`{|}~-]/g;

            if (PassOld.value.length < 8 && PassNew.value.length < 8 && PassConf.value.length < 8) {
                alert("Password kurang panjang");
                return false
            };
            if (PassOld.value.match(SLow) && PassNew.value.match(SLow) && PassConf.value.match(SLow)) {

            } else {
                alert("Password tidak lower case");
                return false;
            }
            if (PassOld.value.match(SUper) && PassNew.value.match(SUper) && PassConf.value.match(SUper)) {

            } else {
                alert("Password tidak Upper case");
                return false;
            }
            if (PassOld.value.match(Snum) && PassNew.value.match(Snum) && PassConf.value.match(Snum)) {

            } else {
                alert("Password tidak number");
                return false
            }
            if (PassOld.value.match(SKar) && PassNew.value.match(SKar) && PassConf.value.match(SKar)) {

            } else {
                alert("Password tidak karakter");
                return false
            }
        };
    </script>
    <div class="row">
	
        <div class="col-lg-6">
            <div class="row">
                <div class="col-lg-12 bounceIn animation-delay1">
                    <label>Old Password</label>
                    <input type="password" placeholder="Old Password" class="form-control input-sm bounceIn animation-delay4" id="txtPassword" runat="server"/>
                </div>                
                <div class="col-lg-12 bounceIn animation-delay3">
                    <div class="seperator"></div>
                    <label>New Password</label>
                    <dx:ASPxTextBox ID="TxtPasswordNew" runat="server" ToolTip=" New Password " Password="true" CssClass="form-control input-sm bounceIn animation-delay5" Width="100%"> 
                        <validationsettings ValidationGroup="CekPassword" RequiredField-IsRequired="true" ErrorTextPosition="Bottom" ErrorDisplayMode="ImageWithText" Display="Dynamic">
                            <regularexpression  ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!#$%&'()*+,./:;<=>?@\^_`{|}~-])[A-Za-z\d!#$%&'()*+,./:;<=>?@\^_`{|}~-]{8,}" 
                            ErrorText="Valid Password Examples: PaSs@123 Or PaSs123!" />
                        </validationsettings>
                    </dx:ASPxTextBox>
                </div>                
                <div class="col-lg-12 bounceIn animation-delay4">
                    <div class="seperator"></div>
                    <label>Confirm New Password</label>
                    <dx:ASPxTextBox ID="TxtPasswordConfirm" runat="server" ToolTip=" Confirm Password" Password="true" CssClass="form-control input-sm bounceIn animation-delay6" Width="100%"> 
                        <validationsettings ValidationGroup="CekPassword" RequiredField-IsRequired="true" ErrorTextPosition="Bottom" ErrorDisplayMode="ImageWithText" Display="Dynamic">
                            <regularexpression  ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!#$%&'()*+,./:;<=>?@\^_`{|}~-])[A-Za-z\d!#$%&'()*+,./:;<=>?@\^_`{|}~-]{8,}" 
                            ErrorText="Valid Password Examples: PaSs@123 Or PaSs123!" />
                        </validationsettings>
                    </dx:ASPxTextBox>
                </div>                
                <div class="col-lg-12 bounceIn animation-delay7 text-right">
                    <div class="seperator"></div>
                    <asp:button id="Btn_update" runat="server" class="btn btn-success btn-sm bounceIn animation-delay8 " Text="Update" OnClientClick="return ValidationAdd()"></asp:button>
                    <asp:button id="btn_batal" runat="server" class="btn btn-success btn-sm bounceIn animation-delay10 " Text="Cancel"></asp:button>                   
                    
                </div>
            </div>            
        </div>
        <div class="col-lg-6">
            <div class="col-md-12">
                <label id="lblChange" runat="server" class="text-danger text-uppercase" visible="false">Confirm New Password</label>
            </div>
        </div>
    </div>

</asp:Content>

