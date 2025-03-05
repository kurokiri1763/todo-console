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
                