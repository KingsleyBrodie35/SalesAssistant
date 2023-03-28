using System;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;
using ConsoleTables;

namespace SalesAssistant
{
    public class RetainingWallCommand : Command, QueryCmds
    {
        //Fields
        private bool _curve;
        private string _colour;
        private int _height;
        private string _baseQuery;
        private string _whereClause;
        private Products _queryResults;
        //Constructor
        public RetainingWallCommand() : base(new string[] { "retaining walls", "retaining wall", "retainingwall", "retainingwalls" })
        {
            _baseQuery = "select ProductID, Name, Supplier, MaxHeight, CanCurve, colour_name, colourCat, size, price from Product NATURAL JOIN retainingwall NATURAL JOIN colour natural join type;";
            _queryResults = new Products();
        }
        //Methods
        public override Products Execute()
        {
            AskCurve();
            AskColour();
            AskHeight();
            QueryDB();
            return _queryResults;
        }
        private void AskCurve()
        {
            Console.Write("Does your wall require curviture?: ");
            string reply = Console.ReadLine();
            reply = reply.ToLower();
            if (reply == "yes" || reply == "y")
            {
                _curve = true;
            } else
            {
                _curve = false;
            }
        }
        private void AskColour()
        {
            Console.Write("Would you like to search for a colour?: ");
            string result = Console.ReadLine();
            if (result == "yes" || result == "y")
            {
                Console.Write("Please select a colour to search for: Ex. Grey: ");
                _colour = Console.ReadLine();
            }
        }
        private void AskHeight()
        {
            Console.Write("What is the approximate height of the wall?\nPlease write in millimetres excluding description of measurement ex. 600mm = 600: ");
            //convert readline to int
            try
            {
                _height = Int32.Parse(Console.ReadLine());
            } catch (FormatException)
            {
                Console.WriteLine($"unable to parse string {_height}");
            }
        }
        public void QueryDB()
        {
            //connect to MySql db
            using MySqlConnection con = new MySqlConnection(ConnString);
            con.Open();
            //creating where clause
            CreateClause();
            //adding where clause to base query
            if (_whereClause != null)
            {
                _baseQuery = _baseQuery.Replace(";", " ");
                _baseQuery += _whereClause;
            }
            //Writing query
            try
            {
                MySqlCommand cmd = new MySqlCommand(_baseQuery, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    Console.WriteLine("Sorry there are no products that match your query.");
                }
                var table = new ConsoleTable("ID",  "Name", "Supplier", "Maximum Height", "colour", "size", "price");
                while (reader.Read())
                {
                    //create new rw object here.
                    table.AddRow($"{reader[0]}", $"{reader[1]}", $"{reader[2]}", $"{reader[3]}mm", $"{reader[5]}", $"{reader[7]}", $"{reader[8]}");
                    _queryResults.Add(new RetainingWall((uint)reader[0], (string)reader[1], (string)reader[2], (int)reader[3], (bool)reader[4], (string)reader[5], (string)reader[7], (float) reader[8]));
                }
                //write table to console
                table.Write();
                Console.WriteLine();
                //close sql reader
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void CreateClause()
        {
            if (_colour != null && !_curve && _height == 0)
            {
                _whereClause = $"WHERE ColourCat = \"{_colour}\";";
            }
            if (_colour == null && _curve && _height == 0) 
            {
            
                _whereClause = $"WHERE canCurve = 1;";
            }
            if (_colour == null && !_curve && _height != 0)
            {
                _whereClause = $"WHERE maxHeight >= \"{_height}\";";
            }
            if (_colour != null && _curve && _height == 0)
            {
                _whereClause = $"WHERE ColourCat = \"{_colour}\" and canCurve = 1;";
            }
            if (_colour != null && !_curve && _height != 0)
            {
                _whereClause = $"WHERE ColourCat = \"{_colour}\" and maxHeight >= {_height};";
            }
            if (_colour == null && _curve == true && _height != 0)
            {
                _whereClause = $"WHERE maxHeight >= \"{_height}\" and canCurve = 1;";
            }
            if (_colour != null && _curve && _height != 0)
            {
                _whereClause = $"WHERE maxHeight >= \"{_height}\" and canCurve = 1 and ColourCat = \"{_colour}\";";
            }
        }
    }
}
