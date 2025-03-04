List<string> tasks = [];

while(true)
{
// タスク表示コマンドを読み取る
    Console.Write("Type command: ");
    string command = Console.ReadLine();
    // コマンドによって動作切り替え
    // 表示コマンド
    if (command == "display")
    {
        // タスクを表示
        foreach(string task in tasks)
        {
            Console.WriteLine(task);
        }
    }

    // 追加コマンド
    else if (command == "add")
    {
        // タスクを追加
        Console.Write("Type your newtask: ");
        String newTask = Console.ReadLine();
        tasks.Add(newTask);
    }

    // 更新コマンド
    else if (command == "edit")
    {
        // タスクを更新
        Console.Write("Type your edittask: ");
        String editTask = Console.ReadLine();

        if (editTask == editTask)
        {
        // 既存のタスクを参照する
        int indexNum = tasks.IndexOf(editTask);
        Console.Write("Type your newtext: ");
        String newText = Console.ReadLine();
        
        // 参照した値を変更する
        tasks[indexNum] = newText;
        }

        else
        {
            Console.Write("The information entered does not match the task");
        }

    }
    // 削除コマンド
    else if (command == "remove")
    {
        // タスクを削除
        Console.Write("Type your removetask: ");
        String removeTask = Console.ReadLine();
        tasks.Remove(removeTask);

    }

    else
    {
        Console.WriteLine("error");
        Console.WriteLine("This command does not exist.");
        Console.WriteLine("Please type a valid command.");
    }

}