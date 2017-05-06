using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for sqlDB
/// </summary>
public class sqlDB
{
    string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

    public sqlDB()
    {
        //constructor
    }

    public List<string> DataReader(SqlCommand cmd, string ColumnName)
    {

        SqlDataReader dr = cmd.ExecuteReader();
        List<string> Data = new List<string>();
        while (dr.Read())
        {
            Data.Add(dr[ColumnName].ToString());
        }

        return Data;
    }

    public void DataReader(SqlCommand cmd, string ColumnName_1, string ColumnName_2, out string data1, out string data2)
    {
        data1 = "";
        data2 = "";
        SqlDataReader dr = cmd.ExecuteReader();
         
        if (dr.Read())
        {
            data1 = (dr[ColumnName_1].ToString());
            data2 = (dr[ColumnName_2].ToString());
        }


    }

}