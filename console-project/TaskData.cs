// データベースの管理クラス
using System;
using System.Configuration;
using System.Data.SQLite;



public class Database
{
    private string connectionString = "Data Source=data.db;Version=3;";

    // データベースを初期化（テーブル作成）
    public void InitializeDatabase()
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Task(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT
                    Taskname TEXT NOT NULL
                    Register DATETIME DEFAULT CURRENT_TIMESTAMP 
                );";
            using (var command = new SQLiteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    // タスクを追加
    public void AddTask(string taskname)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string insertQuery = "INSERT INTO Task (Taskname) VALUES (@taskname)";
            using (var command = new SQLiteCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@taskname", taskname);
                command.ExecuteNonQuery();
            }
        }
    }

    // タスク一覧を取得
    public List<TaskObj> GetTasks()
    {
        
        List<TaskObj> tasks = new List<TaskObj>();
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string selectQuery = "SELECT * FROM Task";
            using (var command = new SQLiteCommand(selectQuery,connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    
                    tasks.Add(new TaskObj
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Taskname = reader["Taskname"].ToString(),
                        Register = DateTime.Parse(reader["Register"].ToString())
                    });
                }
            }
        }
        return tasks;
    }

    // タスクの編集
    public void EditTask(int id, string taskname)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string updateQuery = "UPDATE Task SET Taskname = @taskname WHERE Id = @id";
            using (var command = new SQLiteCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@taskname", taskname);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }

    // タスクの削除
    public void DeleteTask(int id)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string deleteQuery = "DELETE FROM Task WHERE Id = @id";
            using (var command = new SQLiteCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}