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
        
    }

    //skriv om
    void Load()
    {
        var list = SqliteDataAccess.LoadPeople();
        foreach (EleverModel p in list)
            Console.WriteLine($"id: {p.Elev_Personnummer}, name: {p.Namn} {p.Adress}");
    }

    //skriv om
    void Save()
    {
        Console.WriteLine("First name or quit: \n>>");
        string name = Console.ReadLine();
        if (name == "quit")
            return;

        Console.WriteLine("Last name: \n>>");
        string lastName = Console.ReadLine();

        SqliteDataAccess.SavePerson(new EleverModel() { Namn = name, Adress = lastName });
    }
}

class SqliteDataAccess
{
    public static void AddElev(EleverModel elev)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        cnn.Execute($"INSERT INTO Elever VALUES (@Elev_Personnummer, @Namn, @Adress, @Epost, @Telefonnummer, @Klass_Namn)", elev);
    }

    public static List<EleverModel> LoadElever()
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        var output = cnn.Query<EleverModel>("SELECT * FROM Elever", new DynamicParameters());
        return output.ToList();
    }
    public static EleverModel LoadElev(string ElevPersonnummer)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        var output = cnn.Query<EleverModel>("SELECT * FROM Elever WHERE Elev_Personnummer ='" + ElevPersonnummer + "'", new DynamicParameters());
        return output.ToList()[0];
    }
    public static void SaveElev(EleverModel person)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        cnn.Execute("INSERT INTO people (first_name, last_name) VALUES (@FirstName, @LastName)", person);
    }

    //viktig rör ej
    private static string LoadConnectionString(string id = "Default")
    {
        //gå in i App.config och ge vår ConnectionString till oss!
        return ConfigurationManager.ConnectionStrings[id].ConnectionString;
    }
}

public class EleverModel
{
    public int Elev_Personnummer { get; set; }
    public string Namn { get; set; }
    public string Adress { get; set; }
    public string Epost { get; set; }
    public int Telefonnummer { get; set; }
    public string Klass_Namn { get; set; }
}
public class HushållModel
{
    public int ID { get; set; }
    public int Elev_Personnummer { get; set; }
    public int Vårdnadshavare_Personnummer { get; set; }
}
public class KlasserModel
{
    public string Klass_Namn { get; set; }
}
 public class KurserModel
{
    public int KursID { get; set; }
    public string Kurs_Namn { get; set; }
    public int Lärare_Personnummer { get; set; }
}
public class KursregisteringModel
{
    public int ID { get; set; }
    public int KursID { get; set; }
    public int Elev_Personnummer { get; set; }
}
public class LärareModel
{
    public int Lärare_Personnummer { get; set; }
    public string Namn { get; set; }
    public string Adress { get; set; }
    public string Epost { get; set; }
    public int Telefonnummer { get; set; }
}
public class VårdnadshavareModel
{
    public int Vårdnadshavare_Personnummer { get; set; }
    public string Namn { get; set; }
    public string Adress { get; set; }
    public string Epost { get; set; }
    public int Telefonnummer { get; set; }
}