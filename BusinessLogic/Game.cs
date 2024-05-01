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
            ProxyDie proxy = new(new DeadUnit());
            army2[0].GetHit(army1[0].Attack());
            if (army2[0].Health() < 0) proxy.DeleteUnit(army2,0);
            if (army2.Count > 0 ) 
            {
                army1[0].GetHit(army2[0].Attack());
                if (army1[0].Health() < 0) proxy.DeleteUnit(army1, 0);
            }
        }
        // Метод который обновляет армии.
        public static void Update(List<IUnit> army)
        {
            for (int i=0; i<army.Count; i++)
            {
                // Если нашли мертвого юнита - удаляем его из армии.
                if (army[i].Health() <= 0)
                {
                    ProxyDie proxy = new(new DeadUnit());
                    proxy.DeleteUnit(army, i);
                }
            }
        }
        public static void DoSpecial(List<IUnit> army1, List<IUnit> army2)
        {
            // Счётчик для army1
            int i = 1;
            // Счётчик для army2
            int j = 1;
            if (army2.Count < 2 && army1.Count < 2)
            {
                return;
            }
            // Величина армий для проверки 
            int army1Count = army1.Count;
            int army2Count = army2.Count;
            // Добавить проверки + генетик !!!
            while (i < Math.Max(army1Count, army2Count) && j < Math.Max(army1Count, army2Count))
            {
                // Величина армий для проверки 
                army1Count = army1.Count;
                army2Count = army2.Count;
                // Применяем специальное свойство из первой армии 
                if (i < army1.Count)
                {
                    if (army1[i] is LogGetAttack unitTemp1 && unitTemp1.unit is ISpecialProperty unit1)
                    {
                        var proxy = new ProxyLogSpecial(unit1);
                        // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial
                        if (army1.Count > 0 && army2.Count > 0)
                        {
                            IUnit newUnit = proxy.DoSpecialProperty(army1, army2, i);
                            // Если генетик склонировал солдата
                            if (newUnit != null)
                            {
                                // Вставляем нового солдата перед ним
                                army1.Insert(i, newUnit);
                                i++;
                            }
                            // Если был не генетик => проверяем число второй армии.
                            else
                            {
                                Update(army2);
                                // Если во второй армии убили 
                                if (army2.Count != army2Count)
                                {
                                    j--;
                                }
                            }
                        }
                    }
                    i++;
                }
                // Применяем специальное свойство из второй армии 
                if (j < army2.Count)
                {
                    if (army2[j] is LogGetAttack unitTemp2 && unitTemp2.unit is ISpecialProperty unit2)
                    {
                        var proxy = new ProxyLogSpecial(unit2);
                        if (army1.Count > 0 && army2.Count > 0)
                        {
                            // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial
                            IUnit newUnit2 = proxy.DoSpecialProperty(army2, army1, j);
                            // Если генетик склонировал солдата
                            if (newUnit2 != null)
                            {
                                // Вставляем нового солдата перед ним
                                army2.Insert(j, newUnit2);
                                j++;
                            }
                            // Если был не генетик => проверяем число второй армии.
                            else
                            {
                                Update(army1);
                                // Если во второй армии убили 
                                if (army1.Count != army1Count)
                                {
                                    i--;
                                }
                            }
                        }
                    }
                    j++;
                }
            }
        }
        public static void CheckDecorator(List<IUnit> army)
        {
            for (int i = 1; i < army.Count - 1; i++)
            {
                // Если нашли легкого солдата
                if (army[i] is LogGetAttack lightUnit && lightUnit.unit is LightWarrior)
                {
                    // А рядом с ним тяжелые солдаты => легкий солдат становится оруженосцем 
                    if (army[i + 1] is LogGetAttack heavyUnit1 && heavyUnit1.unit is HeavyWarrior)
                    {
                        army[i + 1] = new HelmDecorator(new ShieldDecorator(new PikeDecorator(new HourseDecorator(army[i + 1], (0, 0)), (0, 0)), (0, 0)), (0, 0));
                    }
                    if (army[i - 1] is LogGetAttack heavyUnit2 && heavyUnit2.unit is HeavyWarrior)
                    {
                        army[i - 1] = new HelmDecorator(new ShieldDecorator(new PikeDecorator(new HourseDecorator(army[i + 1], (0, 0)), (0, 0)), (0, 0)), (0, 0));
                    }
                }
            }

        }
    }
}
