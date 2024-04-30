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
            army2[0].GetHit(army1[0].Attack);
            if (army2[0].Health < 0) army2.RemoveAt(0); // ЗДЕСЬ ВЫЗЫВАТЬ ПРОКСИ
            army1[0].GetHit(army2[0].Attack);
            if (army1[0].Health < 0) army1.RemoveAt(0); // ЗДЕСЬ ВЫЗЫВАТЬ ПРОКСИ
        }
    }
}
