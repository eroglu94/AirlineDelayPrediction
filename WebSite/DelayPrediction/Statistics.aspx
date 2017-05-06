<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Statistics.aspx.cs" Inherits="Statistics" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Statistics</title>

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
<body id="Statistics">
    <form id="form1" runat="server">

        <div class="bgmask hidden"></div>
        <div id="header">
            <div id="logo">
                <img alt="" src="img/logo2.png" class="auto-style1" />
            </div>
            <div class="topnav" id="myTopnav">
                <a href="Home.aspx" >Home</a>
                <a href="Statistics.aspx" class="activePage">Statistics</a>
                <a href="#database">Database</a>
                <a href="#about">About</a>
                <a href="#Account" runat="server" id="accountLink">Account</a>
                <a class="accountIcon fa fa-user-circle-o fa-fw" runat="server" id="LoginLink"></a>
                <a href="#account" class="account">
                    <asp:Label ID="lblUsername" runat="server" Text="Login / Register"></asp:Label></a>
            </div>
        </div>


        <div id="contents">






            <div id="description">
                <h1 class="h1">You Can Predict&nbsp The Airlines Delay Here!</h1>

            </div>



            <div id="chartContainer">
                <asp:Chart ID="Chart1" runat="server" BackColor="Transparent" Width="350px" Height="350px" IsSoftShadows="False">
                    <Titles>
                        <asp:Title Font="Helvetica Nue, 12pt" Name="Title1"
                            Text="Most Frequent Airlines" />
                    </Titles>
                    <Series>
                        <asp:Series Name="Series1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>


                <asp:Chart ID="Chart2" runat="server" BackColor="Transparent" Width="350px" Height="350px" IsSoftShadows="False">
                    <Titles>
                        <asp:Title Font="Helvetica Nue, 12pt" Name="Title1"
                            Text="Top 10 Flight Count" />
                    </Titles>
                    <Series>
                        <asp:Series Name="Series1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>



                <asp:Chart ID="Chart3" runat="server" BackColor="Transparent" Width="350px" Height="350px" IsSoftShadows="False">
                    <Titles>
                        <asp:Title Font="Helvetica Nue, 12pt" Name="Title1"
                            Text="Average Delay of Big Airline Compaines" />
                    </Titles>
                    <Series>
                        <asp:Series Name="Series1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>


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







