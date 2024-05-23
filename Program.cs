
namespace Magic
{
    internal class Program
    {
        static void Main()
        {
            AbstractArmyFactory abstractArmyFactory1 = new AttackArmy();
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

            //invoker.GetStategy().Show();
        }
    }
}
