using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        if(args.Length<3)
        {
            Console.WriteLine("usage:dotnet run<csvFilePath><columnindex><searchkey>");
            return;
        } 
        string csvFilePath = args[0];
        int columnindex = int.Parse(args[1]);
        string searchkey = args[2];

        if(!File.Exists(csvFilePath))
        {
            Console.WriteLine("csv file not found.");
            return;
        }
        if (!int.TryParse(args[1],out int columnNumber) || columnNumber<=0)
        {
            Console.WriteLine("Invalid column number,please provide a positive integer.");
            return;
        }
           string Searchkey = args[2];

        try
        {
            var lines=File.ReadAllLines(csvFilePath);

            foreach(var line in lines)
            {
                var columns=line.Split(',');
                if(columns.Length>=columnNumber) { 
                string valueToSearch=columns [columnNumber -1].Trim();
                    if (valueToSearch.Equals(searchkey,StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(line);
                    }
                        }
            }
        }
        catch(IOException ex)
        {
            Console.WriteLine("Error reading CSV file:" + ex.Message);
        }
    }
}
