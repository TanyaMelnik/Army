
namespace Magic
{
    interface Dead
    {
        public void DeleteUnit(List<IUnit> army, int numberUnit);
    }
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
            if (Settings.sound){
                Console.Beep(300, 500);
            }
            unit.DeleteUnit(army, numberUnit); 
        }
    }
}