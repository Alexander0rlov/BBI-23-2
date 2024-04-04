﻿public struct Jumper
{
    private string _name;
    private int _lengthrate;
    private int _rate;
    private int _score;

    public Jumper(string name, int length, int rate1, int rate2, int rate3, int rate4, int rate5)
    {
        _name = name;
        _lengthrate = (length - 120) * 2 + 60; 
        int[] rate = new int[] { rate1, rate2, rate3, rate4, rate5 };
        Array.Sort(rate);
        _rate = rate[1] + rate[2] + rate[3];
        _score = _lengthrate + _rate; 
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

public abstract class SkiJumping
{
    private string _discipline;
    protected Jumper[] Jumpers;

    public SkiJumping(Jumper[] jumpers, string discipline)
    {
        _discipline = discipline;
        Jumpers = jumpers;
    }

    public virtual Jumper Jump() { return Jumpers[0]; }

    public virtual void Write()
    {
        foreach (var jumper in Jumpers)
        {
            Console.WriteLine("{0}\t   {1}", jumper.GetName(), jumper.GetScore());
        }
    }

    public virtual void WriteDis()
    {
        Console.WriteLine(_discipline);
    }
}

public class J120m : SkiJumping
{
    public J120m(Jumper[] jumpers) : base(jumpers, "120 метров")
    {
    }
    public override Jumper Jump()
    {
        return base.Jump();
    }
}

public class J180m : SkiJumping
{
    public J180m(Jumper[] jumpers) : base(jumpers, "180 метров")
    {
    }

    public override Jumper Jump()
    {
        return base.Jump();
    }
}

class Program
{
    static void Main()
    {
        Jumper[] jumpers = new Jumper[10];

        jumpers[0] = new Jumper("Конов", 115, 15, 17, 11, 10, 12);
        jumpers[1] = new Jumper("Петров", 120, 11, 15, 12, 14, 13);
        jumpers[2] = new Jumper("Иванов", 129, 20, 19, 17, 18, 16);
        jumpers[3] = new Jumper("Смирнов", 125, 17, 17, 16, 18, 19);
        jumpers[4] = new Jumper("Козлов", 128, 20, 18, 18, 15, 14);


        jumpers[5] = new Jumper("Орлов", 175, 15, 17, 11, 10, 12);
        jumpers[6] = new Jumper("Негров", 180, 11, 15, 12, 14, 13);
        jumpers[7] = new Jumper("Соколов", 179, 20, 19, 17, 18, 16);
        jumpers[8] = new Jumper("Дуров", 176, 17, 17, 16, 18, 19);
        jumpers[9] = new Jumper("Попов", 168, 20, 18, 18, 15, 14);

        J120m[] j120 = new J120m[5];
        J180m[] j180 = new J180m[5];

        for (int i = 0; i < 5; i++)
        {
            j120[i] = new J120m([jumpers[i]]);
        }

        for (int i = 5; i < 10; i++)
        {
            j180[i - 5] = new J180m([jumpers[i]]);
        }

        Sort(j120);
        Sort(j180);
        Print(j120);
        Print(j180);

    }

    static void Sort(SkiJumping[] jumper)
    {
        for (int i = 0; i < jumper.Length - 1; i++)
        {
            for (int j = i + 1; j < jumper.Length; j++)
            {
                if (jumper[i].Jump().GetScore() < jumper[j].Jump().GetScore())
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