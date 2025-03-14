using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Database db = new Database();
        // データベースを初期化
        db.InitializeDatabase();

        Console.WriteLine("Welcome to the task manager📕");

        while(true)
        {
            // コマンドを表示
            Console.WriteLine("Please select a function");
            Console.WriteLine("1. 📜Display Tasks");
            Console.WriteLine("2. ▶️Add Task");
            Console.WriteLine("3. ✍️Edit Task");
            Console.WriteLine("4. 🗑️Remove Task");
            Console.WriteLine("5. 🏃‍♀️Exit");
            Console.Write("select command (1-5): ");

            string command = Console.ReadLine();

            if (command == "1")
            {
                DisplayTasks(db);
            }
            else if (command == "2")
            {
                AddTask(db);
            }
            else if (command == "3")
            {
                EditTask(db);
            }
            else if (command == "4")
            {
                RemoveTask(db);
            }
            else if (command == "5")
            {
                Console.WriteLine("👋じゃあな！");
                break;
            }
            else
            {
                Console.WriteLine("❌Invalid command. Please enter a valid command.");
            }
        }
    }

    // タスクを表示する
    static void DisplayTasks(Database db)
    {
        List<TaskObj> tasks = db.GetTasks();
        Console.WriteLine("Tasks:");
        if (tasks.Count == 0)
        {
            Console.WriteLine("⚠️No tasks found.");
        }
        else
        {
            Console.WriteLine("\n📜 Task List:");
            foreach (TaskObj task in tasks)
            {
                Console.WriteLine($"{task.Id}: {task.Taskname} ({task.Register})");
            }
        }
    }

    // タスクを追加する
    static void AddTask(Database db)
    {
        Console.Write("Enter new task name: ");
        string taskname = Console.ReadLine();
        db.AddTask(taskname);
        Console.WriteLine("✅Task added successfully.");
    }

    // タスクを編集する
    static void EditTask(Database db)
    {
        Console.Write("Enter task ID you want to edit: ");
        if (int.TryParse(Console.ReadLine(), out int taskid))
        {
            Console.Write("Enter new task description: ");
            string newText = Console.ReadLine();
            db.EditTask(taskid, newText);
            Console.WriteLine("✅Task edited successfully.");
        }

        else
        {
            Console.WriteLine("❌Invalid task ID. Please enter a valid task ID.");
        }
    }

    // タスクを削除する
    static void RemoveTask(Database db)
    {
        Console.Write("Enter task ID you want to remiove:");
        if (int.TryParse(Console.ReadLine(), out int taskid))
        {
            db.DeleteTask(taskid);
            Console.WriteLine("✅Task removed successfully.");
        }

        else
        {
            Console.WriteLine("❌Invalid task ID. Please enter a valid task ID.");
        }
    }
}