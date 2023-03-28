using System;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;
using ConsoleTables;

namespace SalesAssistant
{
    public class PaverCommand : Command, QueryCmds
    {
        //Fields
        private string _base;
        private string _colour;
        private string _size;
        private string _option;
        private string _baseQuery;
        private string _whereClause;
        private Products _queryResults;

        //constructor
        public PaverCommand() : base(new string[] { "paver", "paving", "pavers" })
        {
            _baseQuery = "select product.ProductID, Name, Supplier, canCrushRock, colour_name, ColourCat, size, Price FROM Product NATURAL JOIN Paver NATURAL JOIN colour NATURAL JOIN type;";
            _queryResults = new Products();
        }
        //Methods
        public override Products Execute()
        {
            AskBase();
            RefineSearch();
            QueryDB();
            return _queryResults;
        }
        //Ask for input on whether crush rock or concrete base
        private void AskBase()
        {
            do
            {
                Console.Write("Please select a base. Crush Rock or Concrete: ");
                string substrate = Console.ReadLine();
                substrate = substrate.ToLower();
                if (substrate == "concrete")
                {
                    _base = "concrete";
                }
                if (substrate == "crushed rock" || substrate == "crush rock")
                {
                    _base = "crushed rock";
                } 
            } while (_base == null);
        }
        //Ask the user to refine search by size, colour or both
        private void RefineSearch()
        {
            string searchParam;
            do
            {
                Console.Write("Please select a parameter to search by. 1:Size 2:Colour: ");
                searchParam = Console.ReadLine();
                searchParam = searchParam.ToLower();
                if (searchParam == "1" || searchParam == "size")
                {
                    SearchSize();
                } 
                if (searchParam == "2" || searchParam == "colour")
                {
                    SearchColour();
                }
            } while (searchParam == null);
            Console.Write($"Would you like to further reduce your search by {_option}?: ");
            string option = Console.ReadLine();
            option = option.ToLower();
            if (option == "yes" || option == "y" )
            {
                if (_size == null)
                {
                    SearchSize();
                }
                if (_colour == null)
                {
                    SearchColour();
                }
            }
        }
        private void SearchSize()
        {
            Console.Write("Please input a size in millimetre measurements. Ex. 400x400x40mm: ");
            _size = Console.ReadLine();
            _option = "colour";
        }
        private void SearchColour()
        {
            Console.Write("Please input a colour to search for. Ex. grey: ");
            _colour = Console.ReadLine();
            _option = "size";
        }
        //Connect to and query db creating paving objects
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
                var table = new ConsoleTable("ID", "Name", "Supplier", "Colour", "Size", "Price");
                while (reader.Read())
                {
                    //create new paving object here.
                    table.AddRow($"{reader[0]}", $"{reader[1]}", $"{reader[2]}", $"{reader[4]}", $"{reader[6]}", $"${reader[7]}ea");
                    _queryResults.Add(new Paver((uint) reader[0], (string) reader[1], (string) reader[2], (bool) reader[3], (string) reader[4], (string) reader[6], (float) reader[7]));
                }
                //print table to screen
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
        //Create where clause based on conditions
        public void CreateClause()
        {
            if (_colour != null && _size == null && _base != "crushed rock")
            {
                _whereClause = $"WHERE ColourCat = \"{_colour}\";";
            }
            if (_size != null && _colour == null && _base != "crushed rock")
            {
                _whereClause = $"WHERE size = \"{_size}\";";
            }
            if (_base == "crushed rock" && _colour == null && _size == null)
            {
                _whereClause = $"WHERE CanCrushRock = 1;";
            }
            if (_colour != null && _size != null && _base != "crushed rock")
            {
                _whereClause = $"WHERE ColourCat = \"{_colour}\" and size = \"{_size}\";";
            }
            if (_colour != null && _size == null && _base == "crushed rock")
            {
                _whereClause = $"WHERE ColourCat = \"{_colour}\" and CanCrushRock = 1;";
            }
            if (_colour == null && _size != null && _base == "crushed rock")
            {
                _whereClause = $"WHERE size = \"{_size}\" and CanCrushRock = 1;";
            }
            if (_colour != null && _size != null && _base == "crushed rock")
            {
                _whereClause = $"WHERE size = \"{_size}\" and CanCrushRock = 1 and ColourCat = \"{_colour}\";";
            }
        }
    }
}
