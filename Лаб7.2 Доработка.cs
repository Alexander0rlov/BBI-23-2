
public struct Jumper
{
    private string _name;
    private int _lengthrate;
    private int _rate;
    private int _score;

    public Jumper(string name, int length, int rate1, int rate2, int rate3, int rate4, int rate5)
    {
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
}

abstract class SkiJumping
{
    protected string _discipline;
    protected string _name; 
    protected int _score;
    public SkiJumping (Jumper jumper)
    {
        _discipline = "";
        _name = jumper.GetName();
        _score = jumper.GetScore();
    }

    public virtual int GetPoints()
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

class J120m : SkiJumping
{
    public J120m (Jumper jumper) : base (jumper) { _discipline = "120 метров"; _name = jumper.GetName(); _score = jumper.GetScore(); }

    public override void Write()
    {
        base.Write();
    }

    public override void WriteDis()
    {
        base.WriteDis();
    }

    public override int GetPoints()
    {
        return base.GetPoints();
    }

}

class J180m : SkiJumping
{
    public J180m(Jumper jumper) : base (jumper) { _discipline = "180 метров"; _name = jumper.GetName(); _score = jumper.GetScore(); }

    public override void Write()
    {
        base.Write();
    }

    public override void WriteDis()
    {
        base.WriteDis();
    }

    public override int GetPoints()
    {
        return base.GetPoints();
    }
}


class Program
{
    static void Main()
    {
        Jumper[] jumper = new Jumper[10];

        // 120 метров
        jumper[0] = new Jumper("Конов", 115, 15, 17, 11, 10, 12);
        jumper[1] = new Jumper("Петров", 120, 11, 15, 12, 14, 13);
        jumper[2] = new Jumper("Иванов", 129, 20, 19, 17, 18, 16);
        jumper[3] = new Jumper("Смирнов", 125, 17, 17, 16, 18, 19);
        jumper[4] = new Jumper("Козлов", 128, 20, 18, 18, 15, 14);

        // 180 метров

        jumper[5] = new Jumper("Орлов", 175, 15, 17, 11, 10, 12);
        jumper[6] = new Jumper("Негров", 180, 11, 15, 12, 14, 13);
        jumper[7] = new Jumper("Соколов", 179, 20, 19, 17, 18, 16);
        jumper[8] = new Jumper("Дуров", 176, 17, 17, 16, 18, 19);
        jumper[9] = new Jumper("Попов", 168, 20, 18, 18, 15, 14);

        J120m[] j120 = new J120m[5];
        J180m[] j180 = new J180m[5];

        for (int i = 0; i < 5; i++)
        {
            j120[i] = new J120m(jumper[i]);
        }

        for (int i = 5; i < 10; i++)
        {
            j180[i-5] = new J180m(jumper[i]);
        }

        Sort(j120);
        Sort(j180);
        Print(j120);
        Print(j180);

        static void Sort(SkiJumping[] jumper)
        {
            for (int i = 0; i < jumper.Length - 1; i++)
            {
                for (int j = i; j < jumper.Length; j++)
                {
                    if (jumper[i].GetPoints() < jumper[j].GetPoints())
                    {
                        SkiJumping temp = jumper[i];
                        jumper[i] = jumper[j];
                        jumper[j] = temp;
                    }
                }
            }
        }

        static void Print(SkiJumping[] jumper)
        {
            jumper[0].WriteDis();
            foreach (SkiJumping jump in jumper)
            {
                jump.Write();
            }
        }

    }
}