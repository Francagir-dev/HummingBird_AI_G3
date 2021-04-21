using System;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using NUnit.Framework;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    public static DataBaseManager dbManager;
    string connectionString;
    string sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;

    string DATABASE_NAME = "/HummingBird.db; PRAGMA foreign_keys = ON;";

    #region InfoFromDB

    #region Lists of classes

    private List<GameSession> _allGameSessions = new List<GameSession>();
    private List<Patient> _allPatients = new List<Patient>();
    private List<App> _allAppInfo = new List<App>();
    private List<Model> _allModelInfo = new List<Model>();

    #endregion

    #region Last item of DB

    private GameSession _lastGs;
    private Patient _lastPatient;
    private App _lastAppInfo;
    private Model _lastModelInfo;
    private Patient _specificPatient;

    #endregion

    #region Getters & Setters

    public List<GameSession> AllGameSessions
    {
        get => _allGameSessions;
        set => _allGameSessions = value;
    }

    public List<Patient> AllPatients
    {
        get => _allPatients;
        set => _allPatients = value;
    }

    public List<App> AllAppInfo
    {
        get => _allAppInfo;
        set => _allAppInfo = value;
    }

    public List<Model> AllModelInfo
    {
        get => _allModelInfo;
        set => _allModelInfo = value;
    }

    public GameSession LastGs
    {
        get => _lastGs;
        set => _lastGs = value;
    }

    public Patient LastPatient
    {
        get => _lastPatient;
        set => _lastPatient = value;
    }

    public App LastAppInfo
    {
        get => _lastAppInfo;
        set => _lastAppInfo = value;
    }

    public Model LastModelInfo
    {
        get => _lastModelInfo;
        set => _lastModelInfo = value;
    }

    #endregion

    #endregion


    private void Awake()
    {
        string filepath = Application.dataPath + DATABASE_NAME;
        connectionString = "URI=file:" + filepath;
        dbconn = new SqliteConnection(connectionString);
        CreateTable();
        CreateGameSession();
    }

    private void Start()
    {
        dbManager = this;
        GetLastApp();
        InsertAppInfo(20f, 20f, 20);
        InsertAppInfo(30f, 40f, 20);
        InsertAppInfo(59f, 100f, 20);
    }

    /* A SIMPLE BASIC QUERY With different tables:
    * SELECT GameSession.username as 'player',AVG(accuracyScore) AS 'Average of Accuracy' FROM Accuracy INNER JOIN GameSession ON  Accuracy.gs_id=GameSession.id order by(SELECT AVG(Accuracy.accuracyScore)FROM Accuracy INNER JOIN GameSession ON  Accuracy.gs_id=GameSession.id);
    */

    #region Create DB

    /// <summary>
    /// Create the tables in the Database
    /// </summary>
    private void CreateTable()
    {
        // VARCHAR => STRING
        // BLOB => FLOAT (OR DECIMAL NUMBERS)
        using (dbconn = new SqliteConnection(connectionString))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "CREATE TABLE IF NOT EXISTS [GameSession] (" +
                       "[gs_id] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT," +
                       "[username] VARCHAR(255)  NOT NULL," +
                       "[actualDate] VARCHAR(255)  NOT NULL," +
                       "[timeMovingAround] BLOB NOT NULL)";
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            sqlQuery = "CREATE TABLE IF NOT EXISTS [Patient] (" +
                       "[patient_id] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT," +
                       "[name] VARCHAR(255)  NOT NULL)";
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            sqlQuery = "CREATE TABLE IF NOT EXISTS [Model] (" +
                       "[model_id] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT," +
                       "[patient_id] INTEGER NOT NULL," +
                       "[name] VARCHAR(255)  NOT NULL," +
                       "[timeBeingWatched] BLOB  NOT NULL," +
                       "FOREIGN KEY (patient_id) REFERENCES Patient(patient_id))";
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            sqlQuery = "CREATE TABLE IF NOT EXISTS [App] (" +
                       "[app_id] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT," +
                       "[gs_id] INTEGER NOT NULL," +
                       "[patient_id] INTEGER NOT NULL," +
                       "[timeSpentOnPatient] BLOB NOT NULL," +
                       "[timeInfoToPatient] BLOB NOT NULL," +
                       "[timesClickedPatient] INTEGER  NOT NULL," +
                       "FOREIGN KEY (patient_id) REFERENCES Patient(patient_id)," +
                       "FOREIGN KEY (gs_id) REFERENCES GameSession(gs_id))";
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }

    #endregion


    #region Get Info From DB

    /// <summary>
    /// Get all GameSessions
    /// </summary>
    public void GetAllGameSessions()
    {
        //Clear prev list
        _allGameSessions.Clear();
        using (dbconn = new SqliteConnection(connectionString))
        {
            dbconn.Open();
            using (dbcmd = dbconn.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM GameSession";
                dbcmd.CommandText = sqlQuery;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _allGameSessions.Add(new GameSession(reader.GetInt32(0), reader.GetString(1),
                            reader.GetString(2),
                            reader.GetFloat(3)));
                    }

                    dbconn.Close();
                    reader.Close();
                }
            }
        }
    }

    /// <summary>
    /// Get last GameSession
    /// </summary>
    public void GetLastGameSession()
    {
        using (dbconn = new SqliteConnection(connectionString))
        {
            dbconn.Open();
            using (dbcmd = dbconn.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM GameSession ORDER BY gs_id DESC LIMIT 1";
                dbcmd.CommandText = sqlQuery;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            _lastGs = new GameSession(reader.GetInt32(0), reader.GetString(1),
                                reader.GetString(2),
                                reader.GetFloat(3));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }

                    dbconn.Close();
                    reader.Close();
                }
            }
        }
    }

    /// <summary>
    /// Get all Patients
    /// </summary>
    public void GetAllPatients()
    {
        //Clearing prev List
        _allPatients.Clear();
        //Open Conn
        using (dbconn = new SqliteConnection(connectionString))
        {
            dbconn.Open();
            using (dbcmd = dbconn.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM Patient";
                dbcmd.CommandText = sqlQuery;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _allPatients.Add(new Patient(reader.GetInt32(0), reader.GetString(1)));
                    }

                    dbconn.Close();
                    reader.Close();
                }
            }
        }
    }

    /// <summary>
    /// Get last Patient
    /// </summary>
    public void GetLastPatient()
    {
        using (dbconn = new SqliteConnection(connectionString))
        {
            dbconn.Open();
            using (dbcmd = dbconn.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM Patient ORDER BY patient_id DESC LIMIT 1";
                dbcmd.CommandText = sqlQuery;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _lastPatient = new Patient(reader.GetInt32(0), reader.GetString(1));
                        Debug.LogWarning(_lastPatient.ToString());
                    }

                    dbconn.Close();
                    reader.Close();
                }
            }
        }
    }

    /// <summary>
    /// Get an specific Patient
    /// </summary>
    public void GetSpecificPatient(string name)
    {
        using (dbconn = new SqliteConnection(connectionString))
        {
            dbconn.Open();
            using (dbcmd = dbconn.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM Patient WHERE name = " + name + "ORDER BY gs_id DESC LIMIT 1";
                dbcmd.CommandText = sqlQuery;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            _specificPatient = new Patient(reader.GetInt32(0), reader.GetString(1));
                            Debug.Log(_lastGs.ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }

                    dbconn.Close();
                    reader.Close();
                }
            }
        }
    }

    /// <summary>
    /// Get all Apps
    /// </summary>
    public void GetAllApps()
    {
        _allAppInfo.Clear();
        using (dbconn = new SqliteConnection(connectionString))
        {
            dbconn.Open();
            using (dbcmd = dbconn.CreateCommand())
            {
                string sqlQuery =
                    "SELECT  App.app_id, App.timeSpentOnPatient,App.timeInfoToPatient App.timesClickedPatient, GameSession.gs_id, GameSession.username, GameSession.actualDate, GameSession.timeMovingAround, Patient.patient_id, Patient.name FROM App INNER JOIN GameSession ON App.gs_id=GameSession.gs_id INNER JOIN Patient ON App.patient_id=Patient.patient_id order by App.app_id";
                dbcmd.CommandText = sqlQuery;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            _allAppInfo.Add(new App(reader.GetInt32(0),
                                new GameSession(reader.GetInt32(4), reader.GetString(5),
                                    reader.GetString(6),
                                    reader.GetFloat(7)),
                                new Patient(reader.GetInt32(8), reader.GetString(9)),
                                reader.GetFloat(1),
                                reader.GetFloat(2),
                                reader.GetInt32(3)));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }

                    dbconn.Close();
                    reader.Close();
                }
            }
        }
    }

    /// <summary>
    /// Get last App
    /// </summary>
    public void GetLastApp()
    {
        using (dbconn = new SqliteConnection(connectionString))
        {
            dbconn.Open();
            using (dbcmd = dbconn.CreateCommand())
            {
                string sqlQuery =
                    "SELECT App.app_id, App.timeSpentOnPatient,App.timeInfoToPatient, App.timesClickedPatient, GameSession.gs_id, GameSession.username, GameSession.actualDate, GameSession.timeMovingAround, Patient.patient_id, Patient.name FROM App INNER JOIN GameSession ON App.gs_id=GameSession.gs_id INNER JOIN Patient ON App.patient_id=Patient.patient_id order by App.app_id";
                dbcmd.CommandText = sqlQuery;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            _lastAppInfo = new App(reader.GetInt32(0),
                                new GameSession(reader.GetInt32(4), reader.GetString(5),
                                    reader.GetString(6),
                                    reader.GetFloat(7)),
                                new Patient(reader.GetInt32(8), reader.GetString(9)),
                                reader.GetFloat(1),
                                reader.GetFloat(2),
                                reader.GetInt32(3));

                            Debug.LogWarning(_lastAppInfo.ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }

                    dbconn.Close();
                    reader.Close();
                }
            }
        }
    }

    /// <summary>
    /// Get all Models
    /// </summary>
    public void GetAllModels()
    {
        _allModelInfo.Clear();
        using (dbconn = new SqliteConnection(connectionString))
        {
            dbconn.Open();
            using (dbcmd = dbconn.CreateCommand())
            {
                string sqlQuery =
                    "SELECT Patient.patient_id, Patient.name,Model.model_id, Model.name, Model.timeBeingWatched FROM Patient INNER JOIN GameSession ON  Model.patient_id=Patient.patient_id order by Model.model_id";
                dbcmd.CommandText = sqlQuery;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            _allModelInfo.Add(new Model(reader.GetInt32(2),
                                new Patient(reader.GetInt32(0), reader.GetString(1)), reader.GetString(3),
                                reader.GetFloat(4)));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }

                    dbconn.Close();
                    reader.Close();
                }
            }
        }
    }

    /// <summary>
    /// Get last Model
    /// </summary>
    public void GetLastModel()
    {
        using (dbconn = new SqliteConnection(connectionString))
        {
            dbconn.Open();
            using (dbcmd = dbconn.CreateCommand())
            {
                string sqlQuery =
                    "SELECT Patient.patient_id, Patient.name,Model.model_id, Model.name, Model.timeBeingWatched FROM Patient INNER JOIN GameSession ON  Model.patient_id=Patient.patient_id order by Model.model_id";
                dbcmd.CommandText = sqlQuery;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            _lastModelInfo = new Model(reader.GetInt32(2),
                                new Patient(reader.GetInt32(0), reader.GetString(1)), reader.GetString(3),
                                reader.GetFloat(4));

                            Debug.Log(_lastModelInfo.ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }

                    dbconn.Close();
                    reader.Close();
                }
            }
        }
    }

    #endregion

    #region C => Create (Add to DB, POST)

    //POST => Add to DB
    public void InsertAppInfo(
        float timeSpentOnPatient,
        float timeInfoToPatient,
        int timesClickedPatient) // add the variables needed
    {
        GetLastGameSession();
        GetLastPatient();
        string sqlQuery;
        using (dbconn = new SqliteConnection(connectionString))
        {
            Debug.Log(_lastGs.GsID);
            Debug.Log(_lastPatient);
            dbconn.Open();
            using (dbcmd = dbconn.CreateCommand())
            {
                /*
                 * You'll need all colums (see Create DB function), if there is an "object" as GameSession, you'll need to add just its id (Variable from its class)
                 * Those objects should not be null (So call those Insert Queries first)
                 */
                sqlQuery = String.Format(
                    "INSERT INTO App(gs_id,patient_id,timeSpentOnPatient,timeInfoToPatient,timesClickedPatient) VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\")",
                    _lastGs.GsID, _lastPatient.PatientID, timeSpentOnPatient, timeInfoToPatient, timesClickedPatient);
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }
    }

    public void CreateGameSession()
    {
        string sqlQuery;
        using (dbconn = new SqliteConnection(connectionString))
        {
            dbconn.Open();
            using (dbcmd = dbconn.CreateCommand())
            {
                /*
                 * You'll need all colums (see Create DB function), if there is an "object" as GameSession, you'll need to add just its id (Variable from its class)
                 * Those objects should not be null (So call those Insert Queries first)
                 */
                string username = "Mob";
                string actualDate = "17/7/2021";
                float timeMovingAround = 83.3f;

                sqlQuery = String.Format(
                    "INSERT INTO GameSession(username, actualDate, timeMovingAround) VALUES(\"{0}\",\"{1}\",\"{2}\")",
                    username, actualDate, timeMovingAround);
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }
    }

    #endregion
}