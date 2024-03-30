abstract class Jumper
{
    protected string _discipline;
    protected string _name;
    protected int _lengthrate;
    protected int _rate;
    protected int _score;

    public Jumper(string name, int length, int rate1, int rate2, int rate3, int rate4, int rate5)
    {
        _discipline = "Прыжки на лыжах";
        _name = name;
        _lengthrate = (length - 120) * 2 + 60; // очки за длину прыжка
        int[] rate = new int[5]; // отсеивание наибольшего и наименьшего результата
        rate[0] = rate1;
        rate[1] = rate2;
        rate[2] = rate3;
        rate[3] = rate4;
        rate[4] = rate5;
        for (int i = 0; i < rate.Length - 1; i++)
        {
            for (int j = i; j < rate.Length; j++)
            {
                if (rate[i] < rate[j])
                {
                    int temp = rate[i];
                    rate[i] = rate[j];
                    rate[j] = temp;
                }
            }
        }
        _rate = rate[1] + rate[2] + rate[3];
        _score = _lengthrate + _rate; // финальные очки спортсмена
    }
    

    public string GetName()
    {
        return _name;
    }

    public int GetScore()
    {
        return _score;
    }

    public virtual void Write()
    {
        Console.WriteLine("{0}\t   {1}", _name, _score);
    }

    public virtual void WriteDis()
    {
        Console.WriteLine(_discipline);
    }
}
class Jumper120: Jumper
{
    public Jumper120(string name, int length, int rate1, int rate2, int rate3, int rate4, int rate5) : base(name, length, rate1, rate2, rate3, rate4, rate5)
    {

        _discipline = "120 метров";
    }

    public override void Write()
    {
        Console.WriteLine("{0}\t   {1}", _name, _score);
    }

    public override void WriteDis()
    {
        base.WriteDis();
    }
}

class Jumper180 : Jumper
{
    public Jumper180(string name, int length, int rate1, int rate2, int rate3, int rate4, int rate5) : base(name, length, rate1, rate2, rate3, rate4, rate5)
    {
        _discipline = "180 метров";
    }

    public override void Write()
    {
        Console.WriteLine("{0}\t   {1}", _name, _score);
    }

    public override void WriteDis()
    {
        base.WriteDis();
    }

}

class Program
{
    static void Main()
    {
        Jumper180[] jumper180 = new Jumper180[5];

        jumper180[0] = new Jumper180("Орлов", 175, 15, 17, 11, 10, 12);
        jumper180[1] = new Jumper180("Негров", 180, 11, 15, 12, 14, 13);
        jumper180[2] = new Jumper180("Соколов", 179, 20, 19, 17, 18, 16);
        jumper180[3] = new Jumper180("Дуров", 176, 17, 17, 16, 18, 19);
        jumper180[4] = new Jumper180("Попов", 168, 20, 18, 18, 15, 14);

        Jumper120[] jumper120 = new Jumper120[5];

        jumper120[0] = new Jumper120("Конов", 115, 15, 17, 11, 10, 12);
        jumper120[1] = new Jumper120("Петров", 120, 11, 15, 12, 14, 13);
        jumper120[2] = new Jumper120("Иванов", 129, 20, 19, 17, 18, 16);
        jumper120[3] = new Jumper120("Смирнов", 125, 17, 17, 16, 18, 19);
        jumper120[4] = new Jumper120("Козлов", 128, 20, 18, 18, 15, 14);

        Sort(jumper120);
        Print1(jumper120);
        Sort(jumper180);
        Print2(jumper180);    
    }

    static void Sort(Jumper[] jumper)
    {
        for (int i = 0; i < jumper.Length - 1; i++)
        {
            for (int j = i; j < jumper.Length; j++)
            {
                if (jumper[i].GetScore() < jumper[j].GetScore())
                {
                    Jumper temp = jumper[i];
                    jumper[i] = jumper[j];
                    jumper[j] = temp;
                }
            }
        }
    }

    static void Print1(Jumper120[] jumper)
    {
        jumper[0].WriteDis();
        foreach (Jumper120 jump in jumper)
        {
            jump.Write();
        }
    }
    static void Print2(Jumper180[] jumper)
    {
        jumper[0].WriteDis();
        foreach (Jumper180 jump in jumper)
        {
            jump.Write();
        }
    }

}
