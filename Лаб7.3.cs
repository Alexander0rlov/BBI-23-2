abstract class FootballTeam
{
    protected string _name;
    protected int _points;
    protected int _group;
    protected string _gender;

    public FootballTeam(string name, int points, int group)
    {
        _name = name;
        _points = points;
        _group = group;
        _gender = "";
    }

    public virtual int GetPoints() { return _points; }
    public virtual void Write()
    {
        Console.WriteLine($"Название {_name} Пол {_gender} Баллы {_points} ");
    }
}

class MaleTeam: FootballTeam
{
    public MaleTeam(string name, int points, int group): base(name, points, group) { _gender = "Мужская команда"; }
    public override int GetPoints()
    {
        return base.GetPoints();
    }
    public override void Write()
    {
        base.Write();
    }
}

class FemaleTeam: FootballTeam
{
    public FemaleTeam(string name, int points, int group) : base(name, points, group) { _gender = "Женская команда"; }
    public override int GetPoints()
    {
        return base.GetPoints();
    }
    public override void Write()
    {
        base.Write();
    }
}

class Program
{
    static void Main(string[] args)
    {
        FemaleTeam[] FTeam1 = new FemaleTeam[12];
        for (int i = 0; i < 12; i++)
        {
            FTeam1[i] = new FemaleTeam($"Team {i + 1}", new Random().Next(0, 50), 1);

        }

        FemaleTeam[] FTeam2 = new FemaleTeam[12];
        for (int i = 0; i < 12; i++)
        {
            FTeam2[i] = new FemaleTeam($"Team {i + 1}", new Random().Next(0, 50), 2);

        }

        MaleTeam[] MTeam1 = new MaleTeam[12];
        for (int i = 0; i < 12; i++)
        {
            MTeam1[i] = new MaleTeam($"Team {i + 1}", new Random().Next(0, 50), 1);

        }

        MaleTeam[] MTeam2 = new MaleTeam[12];
        for (int i = 0; i < 12; i++)
        {
            MTeam2[i] = new MaleTeam($"Team {i + 1}", new Random().Next(0, 50), 2);

        }


        Sort(MTeam1);
        Sort(MTeam2);
        Sort(FTeam1);
        Sort(FTeam2);


        FootballTeam[] Mstage2 = MergeArrays(MTeam1, MTeam2);//все мужские команды по убыванию
        FootballTeam[] Fstage2 = MergeArrays(FTeam1, FTeam2);//все женские команды по убыванию
        FootballTeam[] Finals = MergeArrays(Mstage2 , Fstage2);//все команды по убыванию


        for(int i = 0;i < 6; i++)//вывод 6 лучших команд среди всех 
        {
            Finals[i].Write();
        }


        static FootballTeam[] MergeArrays(FootballTeam[] team1, FootballTeam[] team2)
        {
            FootballTeam[] merged = new FootballTeam[team1.Length + team2.Length];
            int i = 0, j = 0, k = 0;

            while (i < team1.Length && j < team2.Length)
            {
                if (team1[i].GetPoints() >= team2[j].GetPoints())
                {
                    merged[k] = team1[i];
                    i++;
                }
                else
                {
                    merged[k] = team2[j];
                    j++;
                }
                k++;
            }

            while (i < team1.Length)
            {
                merged[k] = team1[i];
                i++;
                k++;
            }

            while (j < team2.Length)
            {
                merged[k] = team2[j];
                j++;
                k++;
            }

            return merged;
        }


        static void Sort(FootballTeam[] team)
        {
            for (int i = 1; i < team.Length; i++)
            {
                FootballTeam temp = team[i];
                int j = i - 1;

                while (j >= 0 && team[j].GetPoints() < temp.GetPoints())
                {
                    team[j + 1] = team[j];
                    j--;
                }

                team[j + 1] = temp;
            }
        }
    } 
}
