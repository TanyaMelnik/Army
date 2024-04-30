using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Magic
{
    public class Game
    {
        public static void Fight(List<IUnit> army1, List<IUnit> army2)
        {
            /*Console.WriteLine("//////");
            Console.WriteLine(army2[0].Health);
            army2[0].GetHit(army1[0].Attack);
            Console.WriteLine(army2[0].Health);
            Console.WriteLine("//////");*/
            ProxyDie proxy = new(new DeadUnit());
            army2[0].GetHit(army1[0].Attack());
            if (army2[0].Health() < 0) proxy.DeleteUnit(army2,0); // ЗДЕСЬ ВЫЗЫВАТЬ ПРОКСИ
            if (army2.Count > 0 ) 
            {
                army1[0].GetHit(army2[0].Attack());
                if (army1[0].Health() < 0) proxy.DeleteUnit(army1, 0);
            }
        }
        public static void DoSpecial(List<IUnit> army1, List<IUnit> army2)
        {
            for (int i = 0; i < army1.Count; i++)
            {

            }
        }
    }
}
