
namespace Magic
{
    internal class Program
    {
        static void Main()
        {
            /* AbstractArmyFactory abstractArmyFactory1 = new AttackArmy();
             ArmyCreatedFactories armyCreatedFactories1 = new BalanceArmy(abstractArmyFactory1);
             List<IUnit> army1 = armyCreatedFactories1.CreateArmy();

             // Создание второй армии.
             AbstractArmyFactory abstractArmyFactory2 = new AttackArmy();
             ArmyCreatedFactories armyCreatedFactories2 = new BalanceArmy(abstractArmyFactory2);
             List<IUnit> army2 = armyCreatedFactories2.CreateArmy();
             // Паттерн Singleton. 
             Settings.GetInstance(100, 20);
             //User.UserGame();
             Invoker invoker = new Invoker();
             ICommand StartMakeMove = new MakeMove(new Сolumn(army1, army2));
             *//*invoker.AddCommand(StartMakeMove);
             _ = invoker.ExecuteCommand();*//*
             Console.WriteLine("hello");

             foreach(IUnit unit in StartMakeMove._TypeConstruction.Army1) 
             {
                 Console.WriteLine(unit.ToString());
             }
             foreach (IUnit unit in StartMakeMove._TypeConstruction.Army2)
             {
                 Console.WriteLine(unit.ToString());
             }
             //invoker.GetStategy().Show();*/
            User.UserGame();
        }
    }
}
