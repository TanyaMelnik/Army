﻿using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    // Стенка на стенку
    class WallToWall : ITypeConstruction,Dead
    {
        public void CheckDecorator(List<IUnit> army1, List<IUnit> army2)
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

        public void DeleteUnit(List<IUnit> army, int numberUnit)
        {
            // Смещение юнита справа
            army.RemoveAt(numberUnit);
        }
        // Т.К. стенка на стенку, то спец свойства будут применяться только у одной армии
        public void DoSpecialProperties(List<IUnit> army1, List<IUnit> army2)
        {
            // Защищающаяся армия ( с меньшим количеством)
            List<IUnit> defender = army1.Count < army2.Count ? army1 : army2;
            // Атакующая армия ( с большим количеством)
            List<IUnit> attacker = army1.Count > army2.Count ? army1 : army2;
            // Применения спец свойств
            for (int i = defender.Count; i < attacker.Count; i++)
            {
                // Проверка на спец свойство 
                if (attacker[i] is LogGetAttack unitTemp1 && unitTemp1.unit is ISpecialProperty unit1)
                {
                    // Обёртка для логирования 
                    var proxy = new ProxyLogSpecial(unit1);
                    IUnit newUnit = proxy.DoSpecialProperty(attacker, defender, i);
                    // Если генетик склонировал солдата
                    if (newUnit != null)
                    {
                        // Вставляем нового солдата перед ним
                        army1.Insert(i, newUnit);
                        // Т.к появился новый солдат, то делаем переход через генетика
                        i++;
                    }
                }
            }
            // Обновляем вторую армию после лучников
            Update(defender);
        }

        public void MakeMeleeFight(List<IUnit> army1, List<IUnit> army2)
        {
            ProxyDie proxy = new(new Сolumn());
            // Количество совпадающих армий.
            int minCountArmy = army1.Count < army2.Count ? army1.Count : army2.Count;
            // Сначала сражения 
            for (int i = 0;i < minCountArmy; i++)
            {
                // Если произошли сдвиги и солдат остался без противника
                if (i >= army1.Count || i >= army2.Count)
                { 
                    break;
                }
                // Если противник есть 
                army2[0].GetHit(army1[0].Attack());
                if (army2[0].Health() < 0) proxy.DeleteUnit(army2, 0);
                if (army2.Count > 0)
                {
                    army1[0].GetHit(army2[0].Attack());
                    if (army1[0].Health() < 0) proxy.DeleteUnit(army1, 0);
                }
            }
        }

        public string Show(List<IUnit> army1, List<IUnit> army2)
        {
            // Защищающаяся армия ( с меньшим количеством)
            List<IUnit> defender = army1.Count < army2.Count ? army1 : army2;
            // Атакующая армия ( с большим количеством)
            List<IUnit> attacker = army1.Count > army2.Count ? army1 : army2;
            StringBuilder s= new ();
            s.Append("Армия 1: \t Армия 2: \n");
            for (int i = 0; i < defender.Count; i++)
            {
                s.Append(defender[i].ToString()+ "\t" + attacker[i].ToString()+"\n");
            }
            // Если разное количество в армиях
            for (int i = defender.Count; i<attacker.Count; i++)
            {
                if (attacker.Count== army1.Count){
                    s.Append(army1[i].ToString() + "\n" );
                }
                else
                {
                    s.Append("\t" + army2[i].ToString() + "\n");
                }
            }
            return s.ToString();
        }

        public void Update(List<IUnit> army)
        {
            for (int i = 0; i < army.Count; i++)
            {
                // Если нашли мертвого юнита - удаляем его из армии.
                if (army[i].Health() <= 0)
                {
                    ProxyDie proxy = new(new Сolumn());
                    proxy.DeleteUnit(army, i);
                }
            }
        }
    }
}
