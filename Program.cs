

namespace Magic
{
    internal class Program
    {
        static void Main()
        {
            User.UserGame();
            Settings settings = Settings.GetInstance(4, 5);
            HeavyWarrior a = new(settings,(1,1));
            a.Print();
            HeavyWarrior b = new(settings, (2, 2));
            b.Print();
            Console.WriteLine(b.Attack);
            a.GetHit(b.Attack);
/*            a.Attack(b);
            a.Attack(b);*/
            a.Print();
            b.Print();


        }
    }
}
