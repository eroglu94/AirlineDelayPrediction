using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

public partial class Statistics : System.Web.UI.Page
{
    //Global Variables
    string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;


    protected void Page_Load(object sender, EventArgs e)
    {
        lblUsername.Text = SessionUsername();
        FillCharts();
    }

    protected void FillCharts()
    {
        DataTable dt = GetData("select * from dbo.top10_Origin");



        Chart1.Series[0].ChartType = SeriesChartType.Pie;
        Chart1.DataSource = dt;
        Chart1.Series.First().XValueMember = "Origin";
        Chart1.Series.First().YValueMembers = "Count";
        Chart1.DataBind();
        Chart1.ChartAreas["ChartArea1"].BackColor = System.Drawing.Color.Transparent;



        dt.Clear();
        dt = GetData("select * from dbo.flightCount");

        Chart2.Series[0].ChartType = SeriesChartType.Pie;
        Chart2.DataSource = dt;
        Chart2.Series.First().XValueMember = "Code";
        Chart2.Series.First().YValueMembers = "Flight Count";
        Chart2.DataBind();
        Chart2.ChartAreas["ChartArea1"].BackColor = System.Drawing.Color.Transparent;


        dt.Clear();
        dt = GetData("select * from dbo.avgDelay");

        Chart3.Series[0].ChartType = SeriesChartType.Column;
        Chart3.DataSource = dt;
        Chart3.Series.First().XValueMember = "Code";
        Chart3.Series.First().YValueMembers = "Average Delay";
        Chart3.DataBind();
        Chart3.ChartAreas["ChartArea1"].BackColor = System.Drawing.Color.Transparent;

    }

    private static DataTable GetData(string query)
    {
        DataTable dt = new DataTable();
        string constr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
            return dt;
        }
    }
    protected string SessionUsername()
    {
        try
        {
            if (Session["Username"].ToString() == "")
            {
                return "Login / Register";
            }
            else
            {
                return Session["Username"].ToString();
            }
        }
        catch (Exception)
        {

            return "Login / Register";
        }
    }

    protected void accountLink_ServerClick(object sender, EventArgs e)
    {
        if (lblUsername.Text != "Login / Register")
        {
            Response.Redirect("UserPanel.aspx");
        }
        else
        {
            JSMessage("You Must Login First!");
        }
    }

    protected void JSMessage(string message)
    {
        Response.Write("<script>alert('" + message + "');</script>");
    }
}