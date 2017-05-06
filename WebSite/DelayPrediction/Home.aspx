<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delay Prediction</title>

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link href="Css/awesomplete.css" rel="stylesheet" />
    <link href="Css/StyleSheet.css" rel="stylesheet" />
    <link href="Css/font-awesome.min.css" rel="stylesheet" />
    <link href="//netdna.bootstrapcdn.com/font-awesome/3.2.1/css/font-awesome.css" rel="stylesheet" />
    <link href="Css/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css" />
    <link href="Css/login.css" rel="stylesheet" />

    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="Js/awesomplete.js"></script>

    <style type="text/css">
        .auto-style1 {
            width: 253px;
            height: 63px;
        }
    </style>

</head>
<body id="HomePage">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="bgmask hidden"></div>
        <div id="header">
            <div id="logo">
                <img alt="" src="img/logo2.png" class="auto-style1" />
            </div>
            <div class="topnav" id="myTopnav">
                <a href="Home.aspx" class="activePage">Home</a>
                <a href="Statistics.aspx">Statistics</a>
                <a href="#database">Database</a>
                <a href="#about">About</a>
                <a href="#Account" runat="server" id="accountLink" onserverclick="accountLink_ServerClick">Account</a>
                <a class="accountIcon fa fa-user-circle-o fa-fw" runat="server" id="LoginLink"></a>
                <a href="#account" class="account">
                    <asp:Label ID="lblUsername" runat="server" Text="Login / Register"></asp:Label></a>
            </div>
        </div>


        <div id="contents">

            <%--<div class="div1 hidden"></div>
            <div class="div2"></div>--%>


            <div class="loginFloatDiv hidden">

                <div class="module form-module">
                    <div class="toggle">
                        <i class="fa fa-times fa-pencil"></i>
                        <%--<div class="tooltip">Register</div>--%>
                    </div>
                    <div class="form">
                        <h2>Login to your account</h2>

                        <asp:TextBox ID="tbxLoginID" runat="server" placeholder="Username"></asp:TextBox>
                        <asp:TextBox ID="tbxPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        <button type="submit" name="btnSubmit" id="btnSubmit" value="Login" runat="server" onserverclick="btnLogin_Click">Login</button>
                        <%--<input type="submit"   value="Login" runat="server" onserverclick="Submit_Click"/>--%>
                    </div>
                    <div class="form">
                        <h2>Create an account</h2>


                        <asp:TextBox ID="tbxRegisterUsername" placeholder="Username" runat="server"></asp:TextBox>
                        <asp:TextBox ID="tbxRegisterPassword" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:TextBox ID="tbxRegisterEmail" placeholder="Email Address" runat="server"></asp:TextBox>
                        <asp:TextBox ID="tbxRegisterCountry" placeholder="Country" runat="server"></asp:TextBox>
                        <button type="submit" name="btnRegister" id="btnRegister" value="Register" runat="server" onserverclick="btnRegister_Click">Register</button>

                    </div>
                    <%--<div class="cta"><a href="#">Forgot your password?</a></div>--%>
                </div>









            </div>

            <div id="description">
                <h1 class="h1">You Can Predict&nbsp The Airlines Delay Here!</h1>

            </div>
            <div id="SearchField">
                <div id="prediction">
                    <ajaxToolkit:MaskedEditExtender ID="mexArrTime" runat="server" TargetControlID="arrivalInput" Mask="99:99"></ajaxToolkit:MaskedEditExtender>
                    <ajaxToolkit:MaskedEditExtender ID="mexDeptime" runat="server" TargetControlID="deperatureInput" Mask="99:99"></ajaxToolkit:MaskedEditExtender>

                    <asp:TextBox ID="sourceInput" runat="server" CssClass="textboxSearch sourceIcon" placeholder="Source" TextMode="Search" Width="250px"></asp:TextBox><asp:TextBox ID="destinationInput" runat="server" CssClass="textboxSearch destinationIcon" placeholder="Destination" TextMode="Search" Width="250px"></asp:TextBox><asp:TextBox ID="flightnumInput" CssClass="textboxSearch flightnumberIcon" placeholder="Flight Number" Width="230px" runat="server" TextMode="Search"></asp:TextBox><asp:TextBox ID="tailnumInput" CssClass="textboxSearch tailnumIcon" placeholder="Tail Number" Width="220px" runat="server" TextMode="Search"></asp:TextBox><asp:TextBox ID="datepicker" runat="server" placeholder="Date" CssClass="textboxSearch dateIcon" TextMode="Search" Width="200px"></asp:TextBox><asp:TextBox ID="deperatureInput" CssClass="textboxSearch" Width="145px" placeholder="DepTime" runat="server" TextMode="Search"></asp:TextBox><asp:TextBox ID="arrivalInput" CssClass="textboxSearch" placeholder="ArrTime" Width="145px" runat="server" TextMode="Search"></asp:TextBox>
                    <asp:Button ID="btnPredict" runat="server" CssClass="predictButton" Text="Calculate" OnClick="btnPredict_Click" />
                </div>

                <div id="predictionResult">
                    <div id="TransparentWindow" runat="server">
                        Distance:
                        <asp:Label ID="lbldistance" runat="server" Text="" CssClass="labelpredictionResult"></asp:Label>
                        <br />
                        Deperature Delay:
                        <asp:Label ID="lbldeppredictionResult" runat="server" Text="" CssClass="labelpredictionResult"></asp:Label>
                        <br />
                        Arrival Delay:
                        <asp:Label ID="lblarrpredictionResult" runat="server" Text="" CssClass="labelpredictionResult"></asp:Label>
                        <br />
                        <asp:Button ID="saveData" runat="server" Text="Save" CssClass="saveButton" OnClick="saveData_Click" />
                        <%--<div style="clear: both;"></div>--%>
                    </div>


                    <%--                    <div class="button-row">
                        <div><a title="Button"></a></div>
                    </div>--%>
                </div>
            </div>

        </div>







        <div id="footer">IKU Airlines Delay Prediction</div>
    </form>


    <%--<script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>--%>

    <script src="Js/login.js"></script>
    <script src="Js/LoginHide.js"></script>
    <script src="Js/Date.js"></script>
</body>
<script src="Js/AutoComplete.js"></script>
</html>
