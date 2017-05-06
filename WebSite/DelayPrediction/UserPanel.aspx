<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserPanel.aspx.cs" Inherits="UserPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Panel</title>

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link href="Css/awesomplete.css" rel="stylesheet" />
    <link href="Css/StyleSheet.css" rel="stylesheet" />
    <link href="Css/font-awesome.min.css" rel="stylesheet" />
    <link href="//netdna.bootstrapcdn.com/font-awesome/3.2.1/css/font-awesome.css" rel="stylesheet" />
    <link href="Css/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css" />
    <link href="Css/login.css" rel="stylesheet" />
    <link href="Css/gridview.css" rel="stylesheet" />

    <style type="text/css">
        .auto-style1 {
            width: 253px;
            height: 63px;
        }
    </style>

    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="Js/awesomplete.js"></script>
</head>
<body id="UserPanel">
    <form id="form1" runat="server">

        <div id="header">
            <div id="logo">
                <img alt="" src="img/logo2.png" class="auto-style1" />
            </div>
            <div class="topnav" id="myTopnav">
                <a href="Home.aspx">Home</a>
                <a href="Statistics.aspx">Statistics</a>
                <a href="#database">Database</a>
                <a href="#about">About</a>
                <a href="#Account" runat="server" id="accountLink" class="activePage">Account</a>
                <a class="accountIcon fa fa-user-circle-o fa-fw"></a>
                <a href="#account" class="account">
                    <asp:Label ID="lblUsername" runat="server" Text="Login / Register"></asp:Label></a>
            </div>
        </div>


        <div id="contents">
            <div id="description">
                <h1 class="h1">You Can Predict&nbsp The Airlines Delay Here!</h1>

            </div>

            <div id="userdata">
                <div id="gridLocation">
                    <asp:GridView ID="GridViewUserFlightData" SelectedRowStyle-CssClass="gridselectedrow" CssClass="mydatagrid" runat="server" PagerStyle-CssClass="gridpager" HeaderStyle-CssClass="gridheader" RowStyle-CssClass="gridrows" AllowPaging="true" OnPageIndexChanging="GridViewUserFlightData_PageIndexChanging" ></asp:GridView>

                </div>

            </div>






        </div>











        <div id="footer">IKU Airlines Delay Prediction</div>

    </form>



    <script src="Js/login.js"></script>
    <script src="Js/LoginHide.js"></script>
    <script src="Js/Date.js"></script>
</body>
<script src="Js/AutoComplete.js"></script>
</html>
