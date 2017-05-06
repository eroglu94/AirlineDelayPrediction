using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MyExtensions
/// </summary>
public static class MyExtensions
{
    public static double ToDouble(this string str)
    {
        return Convert.ToDouble(str);
    }

    public static int ToInt32(this string str)
    {
        return Convert.ToInt32(str);
    }

    public static int FindIndexOf(this string[] list, string value)
    {
        int i = 1;
        foreach (var item in list)
        {
            if (item == value)
            {
                return i;
            }
            i++;
        }
        return -1;
    }
}