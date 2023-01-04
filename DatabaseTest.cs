`C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.SceneManagement;

public class DatabaseTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        //InsertDatabase();
        ReadDatabase();
        Debug.Log("End");
    }

    public void ReadDatabase()
    {
        string conn = "URI=file:" + Application.dataPath + "/UserDB.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT ID, Username, Password, Age, Gender " + "FROM Users";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int ID = reader.GetInt32(0);
            string Username = reader.GetString(1);
            string Password = reader.GetString(2);
            int Age = reader.GetInt32(3);
            int Gender = reader.GetInt32(4);

          
            StartMenu.instance.CreateHashNode(Username, Password, Age, Gender);
            StartMenu.instance.HashAdd(StartMenu.instance.RetrieveHashNode());

            Debug.Log("ID: " + ID + "  Username: " + Username + "  Password: " + Password);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public void InsertDatabase()
    {
        if (StartMenu.instance.CheckUsername() && StartMenu.instance.CheckPassword())
        {
            Debug.Log("reached");
            string[] temp = StartMenu.instance.GetDetails();
            string username = temp[0];
            string password = temp[1];
            Debug.Log(username + "  " + password);
            string conn = "URI=file:" + Application.dataPath + "/UserDB.db"; //Path to database.
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "INSERT INTO Users(Username, Password, Age, Gender) VALUES ('" + username + "', '" + password + "', 1, 1)";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            StartMenu.instance.CreateHashNode(username, password, 1, 1);
            StartMenu.instance.HashAdd(StartMenu.instance.RetrieveHashNode());
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
            RegisterManager.instance.ChangeTextColour(true);
            RegisterManager.instance.RegisterSuccess();
        }
        
        else
        {
            Debug.Log("test Empty field or username taken");
            RegisterManager.instance.ChangeTextColour(false);
            if (StartMenu.instance.GetEmptyStatus())
            {
                RegisterManager.instance.RegisterFailure(false);
            }
            else
            {
                RegisterManager.instance.RegisterFailure(true);
            }
        }
    }

    public void LoginChecksum()
    {
        Debug.Log("reached");
        string[] temp = StartMenu.instance.GetDetails();
        string username = temp[0];
        string password = temp[1];
        Debug.Log(username + "  " + password);
        if (StartMenu.instance.CheckLoginHashNode(username))
        {
            if(password == StartMenu.instance.GetUserPassword())
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Debug.Log("Wrong Username or Password");
            }
        }
        else
        {
            Debug.Log("Wrong Username or Password");
        }

    }
}
