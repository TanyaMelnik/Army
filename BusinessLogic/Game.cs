using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
            IUnit unitTemp = null;
            int i = 1;
            int j = 1;
            while (i < army1.Count && j < army2.Count)
            {
                Console.WriteLine("i; "+ i);
                Console.WriteLine(army1[i].ToString());
                LogGetAttack unitTemp1 = (LogGetAttack)army1[i];
                if (unitTemp1.unit is ISpecialProperty unit1)
                {
                    Console.WriteLine($"Special Удар от {unitTemp1.unit} ");
                    var proxy = new ProxyLogSpecial(unit1);
                    // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial
                    if (army1.Count > 0 && army2.Count > 0) unitTemp = proxy.DoSpecialProperty(army1, army2, i);
                    if (unitTemp != null)
                    {
                        army1.Insert(i, unitTemp);
                        Console.WriteLine("В список добавлен элемент " + unitTemp.ToString());
                        i++;
                    }
                }
                i++;

                Console.WriteLine("j; " + j);
                Console.WriteLine(army2[j].ToString());
                LogGetAttack unitTemp2 = (LogGetAttack)army2[j];
                if (unitTemp2.unit is ISpecialProperty unit2)
                {
                    Console.WriteLine($"Special Удар от {unitTemp2.unit} ");
                    var proxy = new ProxyLogSpecial(unit2);
                    // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial
                    if (army1.Count > 0 && army2.Count > 0) unitTemp = proxy.DoSpecialProperty(army1, army2, j);
                    if (unitTemp != null)
                    {
                        army2.Insert(j, unitTemp);
                        Console.WriteLine("В список добавлен элемент " + unitTemp.ToString());
                        j++;
                    }
                }
                j++;
            }
            List<IUnit> ownArmy;
            List<IUnit> enemyArmy;
            int x;
            // Если армии разных размеров, то продолжают спец атаки.
            if (army1.Count > army2.Count)
            {
                ownArmy = new(army1);
                enemyArmy = new(army2);
                x = i;
            }
            else
            {
                ownArmy = new(army2);
                enemyArmy = new(army1);
                x = j;

            }
            while (x < ownArmy.Count())
            {
                Console.WriteLine("x; " + x);
                Console.WriteLine(ownArmy[i].ToString());
                LogGetAttack unitTemp1 = (LogGetAttack)ownArmy[x];
                if (unitTemp1.unit is ISpecialProperty unit1)
                {
                    Console.WriteLine($"Special Удар от {unitTemp1.unit} ");
                    var proxy = new ProxyLogSpecial(unit1);
                    // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial
                    if (ownArmy.Count > 0 && enemyArmy.Count > 0) unitTemp = proxy.DoSpecialProperty(ownArmy, enemyArmy, x);
                    if (unitTemp != null)
                    {
                        ownArmy.Insert(x, unitTemp);
                        Console.WriteLine("В список добавлен элемент " + unitTemp.ToString());
                        x++;
                    }
                }
                x++;
            }
            /*if (army1.Count > army2.Count)
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
            }*/

        }
    }
}
