using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using TMPro;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    string connectionString;
    string sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;

    string DATABASE_NAME = "/HummingBird.db; PRAGMA foreign_keys = ON;";

    private void Awake()
    {
        string filepath = Application.dataPath + DATABASE_NAME;
        connectionString = "URI=file:" + filepath;
        dbconn = new SqliteConnection(connectionString);
        CreateTable();
    }

    //SELECT GameSession.username as 'player',AVG(accuracyScore) AS 'Average of Accuracy' FROM Accuracy INNER JOIN GameSession ON  Accuracy.gs_id=GameSession.id order by(SELECT AVG(Accuracy.accuracyScore)FROM Accuracy INNER JOIN GameSession ON  Accuracy.gs_id=GameSession.id);

    #region Create DB

    /// <summary>
    /// Create the tables in the Database
    /// </summary>
    private void CreateTable()
    {
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
                       "[timeBeingWatched] BLOB  NOT NULL,"+
                       "FOREIGN KEY (patient_id) REFERENCES GameSession(patient_id))";
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            sqlQuery = "CREATE TABLE IF NOT EXISTS [App] (" +
                       "[app_id] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT," +
                       "[gs_id] INTEGER NOT NULL," +
                       "[patient_id] INTEGER NOT NULL," +
                       "[timeSpentOnPatient] BLOB NOT NULL," +
                       "[timeInfoToPatient] BLOB NOT NULL," +
                       "[timesClickedPatient] INTEGER  NOT NULL," +
                       "FOREIGN KEY (patient_id) REFERENCES GameSession(patient_id),"+
                       "FOREIGN KEY (gs_id) REFERENCES GameSession(gs_id))";
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }

    #endregion


    #region GET METHODS (DATABASE)

    /// <summary>
    /// Get all GameSessions
    /// </summary>
    public void GetInfo()
    {
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
                        // GameSession gs = new GameSession(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
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
    public void GetLastGameSessionID()
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
                    }

                    dbconn.Close();
                    reader.Close();
                }
            }
        }
    }

    #endregion


    #region POST INFO INTO DB

    /// <summary>
    /// Add all info to the Database
    /// </summary>
    public void PostInfo(float[] accuracyPoints, float[] timeSeen, float[] timeHit)
    {
    }

    #endregion
}