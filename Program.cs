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

    //Fix at some point
    /*
    void Load()
    {
        var list = SqliteDataAccess.LoadElever();
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

        SqliteDataAccess.AddElev(new EleverModel() { Namn = name, Adress = lastName });
    }
    */
}

class SqliteDataAccess
{
    //Untested should work, might not
    //Fix "intermidiary" table generation (kursregistrering etc.)

    /// <summary>
    /// Finished with the exception of this tying in with other tables and intermidiary table generation
    /// </summary>
    /// <param name="Elever"></param>
    #region Elever
    public static void AddElev(EleverModel Elev)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        cnn.Execute($"INSERT INTO Elever VALUES (@Elev_Personnummer, @Namn, @Adress, @Epost, @Telefonnummer, @Klass_Namn)", Elev);
    }
    public static List<EleverModel> LoadEleverList()
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        var output = cnn.Query<EleverModel>("SELECT * FROM Elever", new DynamicParameters());
        return output.ToList();
    }
    public static EleverModel LoadElev(string ElevPersonnummer)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        var output = cnn.Query<EleverModel>("SELECT * FROM Elever WHERE Elev_Personnummer='" + ElevPersonnummer + "'", new DynamicParameters());
        return output.ToList()[0];
    }
    public static void RemoveElev(string ElevPersonnummer)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        cnn.Query<EleverModel>("DELETE FROM Elever WHERE Elev_Personnummer='" + ElevPersonnummer + "'");
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Vårdnadshavare"></param>
    #region Vårdnadshavare
    public static void AddVårdnadshavare(VårdnadshavareModel Vårdnadshavare)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        cnn.Execute($"INSERT INTO Vårdnadshavare VALUES (@Vårdnadshavare_Personnummer, @Namn, @Adress, @Epost, @Telefonnummer)", Vårdnadshavare);
    }
    public static List<VårdnadshavareModel> LoadVårdnadshavareList()
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        var output = cnn.Query<VårdnadshavareModel>("SELECT * FROM Vårdnadshavare", new DynamicParameters());
        return output.ToList();
    }
    public static VårdnadshavareModel LoadVårdnadshavare(string VårdnadshavarePersonnummer)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        var output = cnn.Query<VårdnadshavareModel>("SELECT * FROM Vårdnadshavare WHERE Vårdnadshavare_Personnummer='" + VårdnadshavarePersonnummer + "'", new DynamicParameters());
        return output.ToList()[0];
    }
    public static void RemoveVårdnadshavare(string VårdnadshavarePersonnummer)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        cnn.Query<VårdnadshavareModel>("DELETE FROM Vårdnadshavare WHERE Vårdnadshavare_Personnummer='" + VårdnadshavarePersonnummer + "'");
    }
    #endregion

    #region Lärare
    public static void AddLärare(LärareModel lärare)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        cnn.Execute($"INSERT INTO Lärare VALUES (@Lärare_Personnummer, @Namn, @Adress, @Telefonnummer, @Epost)", lärare);
    }
    public static List<LärareModel> LoadLärareList()
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        var output = cnn.Query<LärareModel>("SELECT * FROM Lärare", new DynamicParameters());
        return output.ToList();
    }
    public static LärareModel LoadLärare(string LärarePersonnummer)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        var output = cnn.Query<LärareModel>("SELECT * FROM Lärare WHERE Lärare_Personnummer='" + LärarePersonnummer + "'", new DynamicParameters());
        return output.ToList()[0];
    }
    public static void RemoveLärare(string LärarePersonnummer)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        cnn.Query<LärareModel>("DELETE FROM Lärare WHERE Lärare_Personnummer='" + LärarePersonnummer + "'");
    }
    #endregion

    #region Kurser
    public static void AddKurs(EleverModel elev)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        cnn.Execute($"INSERT INTO Elever VALUES (@Elev_Personnummer, @Namn, @Adress, @Epost, @Telefonnummer, @Klass_Namn)", elev);
    }
    public static List<EleverModel> LoadKurserList()
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        var output = cnn.Query<EleverModel>("SELECT * FROM Elever", new DynamicParameters());
        return output.ToList();
    }
    public static EleverModel LoadKurs(string ElevPersonnummer)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        var output = cnn.Query<EleverModel>("SELECT * FROM Elever WHERE Elev_Personnummer='" + ElevPersonnummer + "'", new DynamicParameters());
        return output.ToList()[0];
    }
    public static void RemoveKurs(string ElevPersonnummer)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        cnn.Query<EleverModel>("DELETE FROM Elever WHERE Elev_Personnummer='" + ElevPersonnummer + "'");
    }
    #endregion

    #region Klasser
    public static void AddKlass(EleverModel elev)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        cnn.Execute($"INSERT INTO Elever VALUES (@Elev_Personnummer, @Namn, @Adress, @Epost, @Telefonnummer, @Klass_Namn)", elev);
    }
    public static List<EleverModel> LoadKlasserList()
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        var output = cnn.Query<EleverModel>("SELECT * FROM Elever", new DynamicParameters());
        return output.ToList();
    }
    public static EleverModel LoadKlass(string ElevPersonnummer)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        var output = cnn.Query<EleverModel>("SELECT * FROM Elever WHERE Elev_Personnummer='" + ElevPersonnummer + "'", new DynamicParameters());
        return output.ToList()[0];
    }
    public static void RemoveKlass(string ElevPersonnummer)
    {
        using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());
        cnn.Query<EleverModel>("DELETE FROM Elever WHERE Elev_Personnummer='" + ElevPersonnummer + "'");
    }
    #endregion

    //viktig rör ej
    private static string LoadConnectionString(string id = "Default")
    {
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