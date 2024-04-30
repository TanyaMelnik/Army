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
            /*int i = 1;
            if (army2.Count<1 || army1.Count < 1){
                return;
            }
            // Добавить проверки + генетик !!!
            while (i< Math.Max(army2.Count, army1.Count))
            {
                LogGetAttack unitTemp1 = (LogGetAttack)army1[i];
                if (unitTemp1.unit is ISpecialProperty unit1)
                {
                    Console.WriteLine($"Special Удар от {unitTemp1.unit} ");
                    var proxy = new ProxyLogSpecial(unit1);
                    // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial
                    if (army1.Count > 0 && army2.Count > 0) proxy.DoSpecialProperty(army1, army2, i);
                }
                LogGetAttack unitTemp2 = (LogGetAttack)army2[i];
                if (unitTemp2.unit is ISpecialProperty unit2)
                {
                    Console.WriteLine($"Special Удар от {unitTemp2.unit} ");
                    var proxy = new ProxyLogSpecial(unit2);
                    // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial
                    if (army1.Count > 0 && army2.Count > 0) proxy.DoSpecialProperty(army1, army2, i);
                }
            }
*/




            for (int i = 1; i < Math.Min(army2.Count, army1.Count); i++)
            {
                LogGetAttack unitTemp1 = (LogGetAttack)army1[i];
                if (unitTemp1.unit is ISpecialProperty unit1)
                {
                    Console.WriteLine($"Special Удар от {unitTemp1.unit} ");
                    var proxy = new ProxyLogSpecial(unit1);
                    // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial
                    if (army1.Count > 0 && army2.Count > 0) proxy.DoSpecialProperty(army1, army2, i);
                }
                LogGetAttack unitTemp2 = (LogGetAttack)army2[i];
                if (unitTemp2.unit is ISpecialProperty unit2)
                {
                    Console.WriteLine($"Special Удар от {unitTemp2.unit} ");
                    var proxy = new ProxyLogSpecial(unit2);
                    // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial
                    if (army1.Count > 0 && army2.Count > 0) proxy.DoSpecialProperty(army1, army2, i);
                }
            }
            // Если армии разных размеров, то продолжают спец атаки.
            if (army1.Count > army2.Count)
            {
                for (int i = army2.Count; i < army1.Count; i++)
                {
                    LogGetAttack unitTemp1 = (LogGetAttack)army1[i];
                    if (unitTemp1.unit is ISpecialProperty unit1)
                    {
                        Console.WriteLine($"Special Удар от {unitTemp1.unit} ");
                        var proxy = new ProxyLogSpecial(unit1);
                        // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial
                        if (army1.Count > 0 && army2.Count > 0) proxy.DoSpecialProperty(army1, army2, i);
                    }
                }
            }
            else
            {
                for (int i = army1.Count; i < army2.Count; i++)
                {
                    LogGetAttack unitTemp2 = (LogGetAttack)army2[i];
                    if (unitTemp2.unit is ISpecialProperty unit2)
                    {
                        Console.WriteLine($"Special Удар от {unitTemp2.unit} ");
                        var proxy = new ProxyLogSpecial(unit2);
                        // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial
                        if (army1.Count > 0 && army2.Count > 0) proxy.DoSpecialProperty(army1, army2, i);
                    }
                }
            }

        }
    }
}
