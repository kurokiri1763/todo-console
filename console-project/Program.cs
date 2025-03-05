List<string> tasks = [];

void Display()
{
    // タスクを表示
    foreach(string task in tasks)
    {
        Console.WriteLine(task);
    }
}

void Add()
{
    // タスクを追加
    Console.Write("Type your newtask: ");
    String newTask = Console.ReadLine();
    tasks.Add(newTask);
}

void Edit()
{
// タスクを更新
    Console.Write("Type your edittask: ");
    String editTask = Console.ReadLine();
    // 既存のタスクを参照する
    int indexNum = tasks.IndexOf(editTask);

    if (indexNum == -1)
    {
        Console.WriteLine("Please enter a valid task");
    }

    else
    {
    Console.Write
    ("Type your newtext: ");
    String newText = Console.ReadLine();
    
    // 参照した値を変更する
    tasks[indexNum] = newText;
    }
}

void Remove()
{
    // タスクを削除
    Console.Write("Type your removetask: ");
    String removeTask = Console.ReadLine();
    tasks.Remove(removeTask);
}

static void CommandError()
{
    Console.WriteLine("error");
    Console.WriteLine("This command does not exist.");
    Console.WriteLine("Please type a valid command.");
}


while(true)
{
       // タスク表示コマンドを読み取る
    Console.Write("Type command: ");
    string command = Console.ReadLine();
    // コマンドによって動作切り替え
    // 表示コマンド
    if (command == "display")
    {
        Display();
    }
    // 追加コマンド
    else if (command == "add")
    {
        Add();
    }
    // 更新コマンド
    else if (command == "edit")
    {
        Edit();
    }
    // 削除コマンド
    else if (command == "remove")
    {
        Remove();
    }

    else
    {
        CommandError();
    }
}