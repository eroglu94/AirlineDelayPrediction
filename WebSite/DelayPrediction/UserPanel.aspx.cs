using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class UserPanel : System.Web.UI.Page
{
    //Global Variables
    string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;


    protected void Page_Load(object sender, EventArgs e)
    {
        lblUsername.Text = SessionUsername();
        FillUsersFlightStorage();


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

    protected void FillUsersFlightStorage()
    {
        if (lblUsername.Text == "Login / Register")
        {
            return;
        }

        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter("SELECT [source],[destination],[flightnumber],[tailnum],[uniquecarrier],[date],[time],[distance],[arrdelay],[depdelay] FROM UsersFlightStorage WHERE username = @username", conn);
        da.SelectCommand.Parameters.AddWithValue("@username", lblUsername.Text);
        DataTable dt = new DataTable();

        da.Fill(dt);

        GridViewUserFlightData.DataSource = dt;
        GridViewUserFlightData.DataBind();

       
        GridViewUserFlightData.HeaderRow.Cells[0].Text = "Source";
        GridViewUserFlightData.HeaderRow.Cells[1].Text = "Destination";
        GridViewUserFlightData.HeaderRow.Cells[2].Text = "Flight Num";
        GridViewUserFlightData.HeaderRow.Cells[3].Text = "Tail Number";
        GridViewUserFlightData.HeaderRow.Cells[4].Text = "Carrier";
        GridViewUserFlightData.HeaderRow.Cells[5].Text = "Date";
        GridViewUserFlightData.HeaderRow.Cells[6].Text = "Time";
        GridViewUserFlightData.HeaderRow.Cells[7].Text = "Distance";
        GridViewUserFlightData.HeaderRow.Cells[8].Text = "Arr Delay";
        GridViewUserFlightData.HeaderRow.Cells[9].Text = "Dep Delay";

    }




    protected void GridViewUserFlightData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //FillUsersFlightStorage();
        GridViewUserFlightData.PageIndex = e.NewPageIndex;
        GridViewUserFlightData.DataBind();
        GridViewUserFlightData.HeaderRow.Cells[0].Text = "Source";
        GridViewUserFlightData.HeaderRow.Cells[1].Text = "Destination";
        GridViewUserFlightData.HeaderRow.Cells[2].Text = "Flight Num";
        GridViewUserFlightData.HeaderRow.Cells[3].Text = "Tail Number";
        GridViewUserFlightData.HeaderRow.Cells[4].Text = "Carrier";
        GridViewUserFlightData.HeaderRow.Cells[5].Text = "Date";
        GridViewUserFlightData.HeaderRow.Cells[6].Text = "Time";
        GridViewUserFlightData.HeaderRow.Cells[7].Text = "Distance";
        GridViewUserFlightData.HeaderRow.Cells[8].Text = "Arr Delay";
        GridViewUserFlightData.HeaderRow.Cells[9].Text = "Dep Delay";
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

