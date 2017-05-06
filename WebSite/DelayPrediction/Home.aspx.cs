using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;
using System.Configuration;
using System.Data.SqlClient;

public partial class Home : System.Web.UI.Page
{
    //MultipleActiveResultSets=true
    //Globals
    static List<string> Values = new List<string>();


    static double _arrDelay;
    static double _depDelay;

    string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {
                if (Request.UrlReferrer.LocalPath.ToString() != "/UserPanel.aspx")
                {
                    if (Request.UrlReferrer.LocalPath.ToString() != "/Statistics.aspx")
                    {
                        Session.Clear();
                    }
                }
            }

        }
        catch (Exception)
        {

            Session.Clear();
        }

        lblUsername.Text = SessionUsername();

        //sourceInput.Text = "Johnson County";
        //destinationInput.Text = "John F Kennedy Intl";
        //flightnumInput.Text = "8721";
        //tailnumInput.Text = "N672BR";
        //datepicker.Text = "05/10/2017";
        //deperatureInput.Text = "1500";
        //arrivalInput.Text = "1800";
        TransparentWindow.Visible = false;


        //Disable Post Back
        //accountName.Attributes.Add("onclick", "return false;");
    }

    protected string GetArrivalPredictionResult()
    {
        //string[] Values = new string[15];


        var client = new RestClient("https://ussouthcentral.services.azureml.net/workspaces/f6e359556dc542d1bf38920922d6bcf5/services/a581a6ef66b14d85b3f7ffe02cfcfca7/execute?api-version=2.0&format=swagger");
        var request = new RestRequest(Method.POST);
        request.AddHeader("postman-token", "38ae9266-460c-bbc0-5131-cf1928fa29e8");
        request.AddHeader("cache-control", "no-cache");
        request.AddHeader("content-type", "application/json");
        request.AddHeader("authorization", "Bearer ZLsjuUJHfuTq/3AHcS6S6yZoC4ZdGVtTDw2IlLVqllCYweEthPn6l7kHCx2PcG4ooDkixsmLjbHSZ0mJFaqJTg==");
        request.AddParameter("application/json", "{\r\n        \"Inputs\": {\r\n                \"input1\":\r\n                [\r\n                    {\r\n                            'Year': \"" + Values[0] + "\",   \r\n                             'Month': \"" + Values[1] + "\",   \r\n                            'DayofMonth': \"" + Values[2] + "\",   \r\n                            'DayOfWeek': \"" + Values[3] + "\",   \r\n                                                        'CRSDepTime': \"" + Values[4] + "\",   \r\n                                                        'CRSArrTime': \"" + Values[5] + "\",   \r\n                            'UniqueCarrier': \"" + Values[6] + "\",   \r\n                            'FlightNum': \"" + Values[7] + "\",   \r\n                            'TailNum': \"" + Values[8] + "\",   \r\n                                                        'CRSElapsedTime': \"" + Values[9] + "\",   \r\n                                                        'ArrDelay': \"" + Values[10] + "\",   \r\n                                                        'Origin': \"" + Values[11] + "\",   \r\n                            'Dest': \"" + Values[12] + "\",   \r\n                            'Distance': \"" + Values[13] + "\",   \r\n                                                                                                                                            'Diverted': \"" + Values[14] + "\",   \r\n                                                                                                                                                                }\r\n                ],\r\n        },\r\n    \"GlobalParameters\":  {\r\n    }\r\n}\r\n", ParameterType.RequestBody);

        IRestResponse response = client.Execute(request);

        string resp = response.Content.ToString().Remove(0, 41);
        var Doubleresult = resp.Remove(resp.Length - 6, 6).Substring(0, 7).Replace('.', ',').ToDouble();
        Doubleresult = Math.Round(Doubleresult, 1);
        _arrDelay = Doubleresult;
        return Doubleresult.ToString();
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
                LoginLink.Disabled = true;
                //label.Text = Session["Username"].ToString();
                return Session["Username"].ToString();

            }
        }
        catch (Exception)
        {

            return "Login / Register";
        }
    }

    protected string GetDeparturePredictionResult()
    {
        var client = new RestClient("https://ussouthcentral.services.azureml.net/workspaces/f6e359556dc542d1bf38920922d6bcf5/services/342e53436c8d42679546f7765459afb9/execute?api-version=2.0&format=swagger");
        var request = new RestRequest(Method.POST);
        request.AddHeader("postman-token", "d91b8a63-98fe-83c4-7b5f-8522252eb7e5");
        request.AddHeader("cache-control", "no-cache");
        request.AddHeader("content-type", "application/json");
        request.AddHeader("authorization", "Bearer 5GpzHuX5fUgQn+LvovqbJu1o0DdO9f8JVmTJ2mSeIFFZkN+q4dPtTJaEskJGlJ4fStJJG9I47zJ3jf40y6JnMw==");
        request.AddParameter("application/json", "{\r\n        \"Inputs\": {\r\n                \"input1\":\r\n                [\r\n                    {\r\n                            'Year': \"" + Values[0] + "\",   \r\n                            'Month': \"" + Values[1] + "\",   \r\n                            'DayofMonth': \"" + Values[2] + "\",   \r\n                            'DayOfWeek': \"" + Values[3] + "\",   \r\n                            'CRSDepTime': \"" + Values[4] + "\",   \r\n                            'CRSArrTime': \"" + Values[5] + "\",   \r\n                            'UniqueCarrier': \"" + Values[6] + "\",   \r\n                            'FlightNum': \"" + Values[7] + "\",   \r\n                            'TailNum': \"" + Values[8] + "\",   \r\n                            'CRSElapsedTime': \"" + Values[9] + "\",   \r\n                            'DepDelay': \"" + Values[10] + "\",   \r\n                            'Origin': \"" + Values[11] + "\",   \r\n                            'Dest': \"" + Values[12] + "\",   \r\n                            'Distance': \"" + Values[13] + "\",   \r\n                            'Diverted': \"" + Values[14] + "\",   \r\n                    }\r\n                ],\r\n        },\r\n    \"GlobalParameters\":  {\r\n    }\r\n}", ParameterType.RequestBody);

        IRestResponse response = client.Execute(request);

        string resp = response.Content.ToString().Remove(0, 41);
        var Doubleresult = resp.Remove(resp.Length - 6, 6).Substring(0, 7).Replace('.', ',').ToDouble();
        Doubleresult = Math.Round(Doubleresult, 1);
        _depDelay = Doubleresult;
        return Doubleresult.ToString();



    }

    protected double GreatDistanceCalculation(double lat1, double lon1, double lat2, double lon2)
    {
        var R = 6371e3;
        var omega1 = lat1 * Math.PI / 180.0; // convert to radyan
        var omega2 = lat2 * Math.PI / 180.0;
        var deltaOmega = (lat2 - lat1) * Math.PI / 180.0;
        var deltaLambda = (lon2 - lon1) * Math.PI / 180.0;
        var a = Math.Sin(deltaOmega / 2) * Math.Sin(deltaOmega / 2) + Math.Cos(omega1) * Math.Cos(omega2) * Math.Sin(deltaLambda / 2) * Math.Sin(deltaLambda / 2);
        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        var d = R * c / 1000;
        return d;


    }

    protected void btnPredict_Click(object sender, EventArgs e)
    {

        GetPredictionInputs();

        lbldeppredictionResult.Text = GetDeparturePredictionResult() + " Min";
        lblarrpredictionResult.Text = GetArrivalPredictionResult() + " Min";
        lbldistance.Text = Convert.ToInt32((Values[13].ToDouble() / 0.621371192)).ToString() + " Km";

        TransparentWindow.Visible = true;

        //lblpredictionResult.Text = GetArrivalPredictionResult(GetPredictionInputs());
        //lblpredictionResult.Text = GetDeparturePredictionResult(GetPredictionInputs());
    }

    protected List<string> GetPredictionInputs()
    {
        var source = sourceInput.Text;
        var dest = destinationInput.Text;

        sqlDB helperDB = new sqlDB();
        Data helperData = new Data();
        string strLat1, strLat2, strLon1, strLon2;

        //Distance
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM airports WHERE airport = @airport", conn);
        cmd.Parameters.AddWithValue("@airport", source);
        helperDB.DataReader(cmd, "lat", "long", out strLat1, out strLon1);


        cmd = new SqlCommand("SELECT * FROM airports WHERE airport = @airport", conn);
        cmd.Parameters.AddWithValue("@airport", dest);
        helperDB.DataReader(cmd, "lat", "long", out strLat2, out strLon2);

        var tempDistance = GreatDistanceCalculation(strLat1.Replace('.', ',').ToDouble(), strLon1.Replace('.', ',').ToDouble(), strLat2.Replace('.', ',').ToDouble(), strLon2.Replace('.', ',').ToDouble());

        tempDistance = tempDistance * 0.621371192; //Mile türünden lazım, databasemizde öyle çünkü
        int distance = Convert.ToInt32(tempDistance);

        //End Distance


        //Origin And Destination
        source = helperData.airportNames.FindIndexOf(source).ToString();
        dest = helperData.airportNames.FindIndexOf(dest).ToString();
        //End Origin and Destination


        //Deperature Time and Arrival Time
        var deptime = deperatureInput.Text;
        var arrtime = arrivalInput.Text;
        //End Deperature Time and Arrival Time


        //ElapsedTime
        TimeSpan tsDeptime = new TimeSpan(deptime.Substring(0, 2).ToInt32(), deptime.Substring(2, 2).ToInt32(), 0);
        TimeSpan tsArrtime = new TimeSpan(arrtime.Substring(0, 2).ToInt32(), arrtime.Substring(2, 2).ToInt32(), 0);
        TimeSpan tsElapsedTime = new TimeSpan();
        tsElapsedTime = tsArrtime.Subtract(tsDeptime);
        var ElapsedTime = tsElapsedTime.TotalMinutes.ToString();
        //End ElapsedTime


        //TailNumber And UniqeCarrier
        var tailNum = tailnumInput.Text;
        cmd = new SqlCommand("SELECT * FROM finalDataSet WHERE Tailnum = @Tailnum", conn);
        cmd.Parameters.AddWithValue("@Tailnum", tailNum);
        var uniqeCarrierID = helperDB.DataReader(cmd, "UniqueCarrier")[0]; //ID sini aldık
        //End TailNumber And UniqeCarrier


        //Flight Number
        var flightnumber = flightnumInput.Text;
        //End FlightNumber


        //Date
        var tempdate = datepicker.Text.Split('/').ToArray(); //       04/23/2017    year month day
        var date = new DateTime(int.Parse(tempdate[2]), int.Parse(tempdate[0]), int.Parse(tempdate[1]));
        //End Date

        Values = new List<string>();
        Values.Add(date.Year.ToString());
        Values.Add(date.Month.ToString());
        Values.Add(date.Day.ToString());
        int dayofWeek = ((int)date.DayOfWeek == 0) ? 7 : (int)date.DayOfWeek;
        Values.Add(dayofWeek.ToString());
        Values.Add(deptime);
        Values.Add(arrtime);
        Values.Add(uniqeCarrierID);
        Values.Add(flightnumber);
        Values.Add(tailNum);
        Values.Add(ElapsedTime);
        Values.Add("0"); //ARRIVAL DELAY
        Values.Add(source);
        Values.Add(dest);
        Values.Add(distance.ToString()); //In miles
        Values.Add("0"); //DIVERTED


        return Values;
    }

    protected void Login()
    {
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE username = @username AND password=@password", conn);
        cmd.Parameters.AddWithValue("@username", tbxLoginID.Text);
        cmd.Parameters.AddWithValue("@password", tbxPassword.Text);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            //Response.Write("<script>alert('Giriş Başarılı');</script>");
            lblUsername.Text = dr["username"].ToString();
        }
        else
        {
            JSMessage("Wrong Username or Password !!");

        }
        conn.Close();
    }

    protected void JSMessage(string message)
    {
        Response.Write("<script>alert('" + message + "');</script>");
    }

    protected void Register()
    {

        sqlDB sqlhelper = new sqlDB();
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE username = @username", conn);
        cmd.Parameters.AddWithValue("@username", tbxRegisterUsername.Text);
        var data = sqlhelper.DataReader(cmd, "username");
        if (data.Count() == 0)
        {
            cmd = new SqlCommand("INSERT INTO users(username,password,email,country) VALUES(@username,@password,@email,@country)", conn);
            cmd.Parameters.AddWithValue("@username", tbxRegisterUsername.Text);
            cmd.Parameters.AddWithValue("@password", tbxRegisterPassword.Text);
            cmd.Parameters.AddWithValue("@email", tbxRegisterEmail.Text);
            cmd.Parameters.AddWithValue("@country", tbxRegisterCountry.Text);
            int control = cmd.ExecuteNonQuery();
            if (control > 0)
            {
                JSMessage("You Have Succesfully Registered.");
            }
            else
            {
                JSMessage("Error while registering, try again");
            }

        }
        else
        {
            JSMessage("Username already exists, Pick another one :( ");
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (tbxLoginID.Text == "" || tbxPassword.Text == "")
        {
            JSMessage("Please fill all fields");
            return;
        }

        Login();

        Session["Username"] = lblUsername.Text;
        SessionUsername();

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (tbxRegisterUsername.Text == "" || tbxRegisterPassword.Text == "" || tbxRegisterEmail.Text == "" || tbxRegisterCountry.Text == "")
        {
            JSMessage("Please fill all fields");
            return;
        }

        Register();

    }

    protected void saveData_Click(object sender, EventArgs e)
    {
        if (lblUsername.Text == "Login / Register")
        {
            JSMessage("You Must Login to the Website!!");
            return;
        }

        Data helperData = new Data();

        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO UsersFlightStorage (source,destination,flightnumber,tailnum,uniquecarrier,date,time,distance,arrdelay,depdelay,username) VALUES (@source,@destination,@flightnumber,@tailnum,@uniquecarrier,@date,@time,@distance,@arrdelay,@depdelay,@username)", conn);

        cmd.Parameters.AddWithValue("@source", sourceInput.Text);
        cmd.Parameters.AddWithValue("@destination", destinationInput.Text);
        cmd.Parameters.AddWithValue("@flightnumber", flightnumInput.Text);
        cmd.Parameters.AddWithValue("@tailnum", tailnumInput.Text);
        cmd.Parameters.AddWithValue("@uniquecarrier", helperData.carrierName[(Values[6]).ToInt32()].ToString());
        cmd.Parameters.AddWithValue("@date", datepicker.Text);

        var deptime = deperatureInput.Text.Substring(0, 2).ToInt32() + ":" + deperatureInput.Text.Substring(2, 2);
        var arrtime = arrivalInput.Text.Substring(0, 2).ToInt32() + ":" + arrivalInput.Text.Substring(2, 2);
        var time = deptime + "-" + arrtime;
        cmd.Parameters.AddWithValue("@time", time);
        cmd.Parameters.AddWithValue("@distance", Values[13]);
        cmd.Parameters.AddWithValue("@arrdelay", _arrDelay.ToString());
        cmd.Parameters.AddWithValue("@depdelay", _depDelay.ToString());
        cmd.Parameters.AddWithValue("@username", lblUsername.Text);

        int control = cmd.ExecuteNonQuery();
        if (control > 0)
        {
            JSMessage("Data Saved Succesfully!");
        }
        else
        {
            JSMessage("Problem Occured While Saving Data, Try Again :( ");
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
}

