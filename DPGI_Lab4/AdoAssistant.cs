using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows;

namespace DPGI_Lab4.Data;

public class AdoAssistant
{
    private static string? _connectionString;
    
    public AdoAssistant()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString_ADO"]
            .ConnectionString;
        _connectionString = connectionString;
        
        try
        {
            if (_connectionString is null)
                throw new SettingsPropertyNotFoundException();

            var connection = new SQLiteConnection(connectionString: _connectionString);
            
            connection.Open();
        }
        catch (SQLiteException)
        {
            MessageBox.Show(messageBoxText: "No connection with SQLte Database.",
                caption: "Error!",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error,
                defaultResult: MessageBoxResult.OK);
            
            Application.Current.Shutdown();
        }
    }
    
    public DataTable FillDT()
    {

        /*var Users = new List<int>();
        string sqlExpression = query;
        var command = new SQLiteCommand(sqlExpression, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                int prod = reader.GetInt32(0);
                Users.Add(prod);
            }
        }*/
        var connection = new SQLiteConnection(_connectionString);
        connection.Open();
        string query = "SELECT * FROM Users";
        var command = connection.CreateCommand(); // Создаем объект команды
        command.CommandText = query; // Устанавливаем текст команды
        var adapter = new SQLiteDataAdapter(command); // Создаем объект адаптера

        var table = new DataTable();
        adapter.Fill(table);

        return table;
    }

    public void ExecuteNonQuery(string query)
    {
        try
        {
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = connection.CreateCommand(); 
            command.CommandText = query;
            var rowsAffected = command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            MessageBox.Show("Bad data");
            throw;
        }

    }
    
}