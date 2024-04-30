
namespace Magic
{
    internal class Program
    {
        static void Main()
        {
            /*Console.Beep(300, 500);
            Console.Beep(300, 500);
            Console.Beep(300, 500);
            Console.Beep(250, 500);
            Console.Beep(350, 250);
            Console.Beep(300, 500);
            Console.Beep(250, 500);*/
            /*IUnit a = new LogGetAttack(new Bowman((1,1.0)), (1,1.0));
            LogGetAttack b = (LogGetAttack)a;
            if (b.unit is ISpecialProperty unit2)
            {
                Console.WriteLine($"Special Удар от {a} ");
            }*/
            User.UserGame();
            //LogGetAttack a=new()
            //Settings settings = Settings.GetInstance(100, 5);
            /* HeavyWarrior a = new(settings, (1, 1));
             a.Print();
             HeavyWarrior b = new(settings, (2, 2));
             b.Print();
             Console.WriteLine(b.Attack);
             a.GetHit(b.Attack);
             a.Attack(b);
             a.Attack(b);
             a.Print();
             b.Print();*/
            /* AbstractArmyFactory aA = new AttackArmy(); //с атакой
             ArmyCreatedFactories bB = new BalanceArmy(aA); // балансированно (в параментрах передаём абстрактну фабрику!)
             List<IUnit> army = bB.CreateArmy();
             foreach (IUnit unit in army)
             {
                 Console.WriteLine(unit.ToString());
             }*/

        }
    }
}
