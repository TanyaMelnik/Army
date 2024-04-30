
namespace Magic
{
    class ProxyDie:Dead
    {
        Dead unit;
        public ProxyDie(Dead unit)
        {
            this.unit = unit;
        }

        public void DeleteUnit(List<IUnit> army, int numberUnit)
        {
            // Если в настройках указан звук => включаем его
            if (Settings.GetInstance(0, 0).Sound){
                Console.Beep(300, 500);
                //Thread.Sleep(1000);
                /*Console.Beep(300, 500);
                Console.Beep(300, 500);
                Console.Beep(250, 500);
                Console.Beep(350, 250);*/
            }
            unit.DeleteUnit(army, numberUnit); 
        }
    }
}