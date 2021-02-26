using System;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        new Program().Run();
    }
    void Run()
    {
        while (true)
        {
            Console.WriteLine("save, load or quit \n>>");
            var input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "save":
                    Save();
                    break;
                case "load":
                    Load();
                    break;
                case "quit":
                    return;
                default:
                    var p = SqliteDataAccess.LoadPerson(input);
                    Console.WriteLine($"id: {p.id}, name: {p.first_name} {p.last_name}");
                    break;
            }
        }
    }

    void Load()
    {
        var list = SqliteDataAccess.LoadPeople();
        foreach (PersonModel p in list)
            Console.WriteLine($"id: {p.id}, name: {p.first_name} {p.last_name}");
    }

    void Save()
    {
        Console.WriteLine("First name or quit: \n>>");
        string name = Console.ReadLine();
        if (name == "quit")
            return;

        Console.WriteLine("Last name: \n>>");
        string lastName = Console.ReadLine();

        SqliteDataAccess.SavePerson(new PersonModel() { first_name = name, last_name = lastName });
    }


}

class SqliteDataAccess
{
    public static List<PersonModel> LoadPeople()
    {
        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        {
            var output = cnn.Query<PersonModel>("SELECT * FROM people", new DynamicParameters());
            return output.ToList();
        }
    }

    public static PersonModel LoadPerson(string firstName)
    {
        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        {
            var output = cnn.Query<PersonModel>("SELECT * FROM people WHERE first_name='" + firstName + "'", new DynamicParameters());
            return output.ToList()[0];
        }
    }

    public static void SavePerson(PersonModel person)
    {
        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        {
            cnn.Execute("INSERT INTO people (first_name, last_name) VALUES (@FirstName, @LastName)", person);
        }
    }

    private static string LoadConnectionString(string id = "Default")
    {
        //gå in i App.config och ge vår ConnectionString till oss!
        return ConfigurationManager.ConnectionStrings[id].ConnectionString;
    }
}

public class PersonModel
{
    public int id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
}

