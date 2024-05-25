
namespace Magic
{
    interface IDead
    {
        public void DeleteUnit(List<IUnit> army, int numberUnit);
    }
    class ProxyDie(IDead unit) : IDead
    {
        readonly IDead unit = unit;

        public void DeleteUnit(List<IUnit> army, int numberUnit)
        {
            // Если в настройках указан звук => включаем его.
            if (Settings.sound){
                Console.Beep(300, 500);
            }
            unit.DeleteUnit(army, numberUnit); 
        }
    }
}