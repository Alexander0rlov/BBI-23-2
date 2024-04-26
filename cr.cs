using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

abstract class Task
{
    protected string _text;
    public string Text()
    {
        return _text;
    }

    public Task(string text) { _text = text;  }

    public virtual void ParseText(string text) { }
}

class Task1: Task
{
    [JsonConstructor]
    public Task1(string text) : base(text) { ParseText(text); }
    private string removed;

    public override void ParseText(string text)
    {
        string pattern = @"[.,!?;:-]";
        removed = Regex.Replace(text, pattern,""); //заменяет перечисленные в pattern знанки препинания на "".
    }

    public override string ToString()
    {
        return removed;
    }
}
class Task2: Task
{
    [JsonConstructor]   
    public Task2(string text) : base(text) { ParseText(text); }
    private string result = "";

    public override void ParseText(string text)
    {
        string[] words = text.Split('.');

        foreach (string word in words) { result += word + "\n"; } // для вывода информации, т.к. не сделал номер
    }
    public override string ToString()
    {
        return result;
    }
}
class Json
{
    public static void Write<T>(T text, string file) //запись
    {
        using (FileStream filestream = new FileStream(file, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(filestream, text);
        }
    }
    public static T Read<T>(string file) //чтение
    {
        using (FileStream filestream = new FileStream(file, FileMode.OpenOrCreate))
        {
            return JsonSerializer.Deserialize<T>(filestream);
        }
        return default(T);
    }
}

class Program
{
    static void Main()
    {
        Task1 task1 = new Task1("Ночь, улица, фонарь, аптека. Бессмысленный и тусклый свет. Живи еще хоть четверть века — Всё будет так. Исхода нет.");
        Task2 task2 = new Task2("Ночь, улица, фонарь, аптека. Бессмысленный и тусклый свет. Живи еще хоть четверть века — Всё будет так. Исхода нет.");


        Task[] task =
        {
            new Task1(task1.ToString()),
            new Task2(task2.ToString())
        };
        Console.WriteLine(task[0]);
        Console.WriteLine(task[1]);

        // создание папки
        string path = "C:\\Users\\m2310883\\Documents";
        string folder = "Answer";

        path = Path.Combine(path, folder);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        string File1 = "cw2_1.json";
        string File2 = "cw2_2.json";

        File1 = Path.Combine(path, File1);
        File2 = Path.Combine(path, File2);

        /*if (!File.Exists(File1)) для записи пустых файлов (на всякий случай)
        {
            var f = File.Create(File1);
            f.Close();
        }

        if (!File.Exists(File2))
        {
            var f = File.Create(File2);
            f.Close();
        }*/

        if (!File.Exists(File1))
        {
            Json.Write<Task1>((Task1)task[0], File1);
        }
        else
        {
            var read = Json.Read<Task1>(File1);
            Console.WriteLine(read);
        }

        if (!File.Exists(File2))
        {
            Json.Write<Task2>((Task2)task[1], File2);
        }
        else
        {
            var read = Json.Read<Task1>(File2);
            Console.WriteLine(read);
        }
    }
}
