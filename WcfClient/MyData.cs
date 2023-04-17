using System;
using System.Linq;
using System.Net;

class MyData
{
    public static void MyInfo()
    {
        Console.WriteLine("Jakub Czerwiński, 260335");
        Console.WriteLine("Paulina Drzazga, 260370");
        DateTime now = DateTime.Now;
        Console.WriteLine(now.Day + "-" + now.ToString("MMMM") + " " + now.Hour + ":" + now.Minute + ":" + now.Second);
        Console.WriteLine(Environment.Version);
        Console.WriteLine(Environment.UserName);
        Console.WriteLine(Environment.OSVersion.Platform);
        try
        {
            Console.WriteLine("IP: " + Dns.GetHostAddresses(Dns.GetHostName()).First().MapToIPv4());
        }
        catch
        {
            // do nothing
        }
        Console.WriteLine("Witaj w świecie C# 😃");
    }
}