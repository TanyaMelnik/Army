using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class Battalion : ITypeConstruction, Dead
    {
        public void CheckDecorator(List<IUnit> army1, List<IUnit> army2)
        {
            throw new NotImplementedException();
        }

        public void DeleteUnit(List<IUnit> army, int numberUnit)
        {
            for (int i = numberUnit; i < army.Count()-3; i+=3)
            {
                army[i] = army[i+3];
            }
        }

        public void DoSpecialProperties(List<IUnit> army1, List<IUnit> army2)
        {
            // Счётчик для army1
            int i = 1;
            // Счётчик для army2
            int j = 1;

            while (i < Math.Max(army1.Count, army2.Count()) && i < 3 && j < Math.Max(army1.Count, army2.Count()) && j < 3)
            {
                // Применяем специальное свойство из первой армии 
                if (i < army1.Count && i > army2.Count()-1)
                {
                    if (army1[i] is LogGetAttack unitTemp1 && unitTemp1.unit is ISpecialProperty unit1)
                    {
                        var proxy = new ProxyLogSpecial(unit1);
                        // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial
                        if (army1.Count > 0 && army2.Count > 0)
                        {
                            IUnit newUnit = proxy.DoSpecialPropertyBattalion(army1, army2, i);
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
                            }
                        }
                    }
                    i++;
                }
                // Применяем специальное свойство из второй армии 
                if (j < army2.Count && j > army1.Count() - 1)
                {
                    if (army2[j] is LogGetAttack unitTemp2 && unitTemp2.unit is ISpecialProperty unit2)
                    {
                        var proxy = new ProxyLogSpecial(unit2);
                        if (army1.Count > 0 && army2.Count > 0)
                        {
                            // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial
                            IUnit newUnit2 = proxy.DoSpecialPropertyBattalion(army2, army1, j);
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
                            }
                        }
                    }
                    j++;
                }
            }

            // Счётчик для army1
            i = 3;
            // Счётчик для army2
            j = 3;

            while (i < Math.Max(army1.Count, army2.Count()) && j < Math.Max(army1.Count, army2.Count()))
            {
                // Применяем специальное свойство из первой армии 
                if (i < army1.Count)
                {
                    if (army1[i] is LogGetAttack unitTemp1 && unitTemp1.unit is ISpecialProperty unit1)
                    {
                        var proxy = new ProxyLogSpecial(unit1);
                        // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial
                        if (army1.Count > 0 && army2.Count > 0)
                        {
                            IUnit newUnit = proxy.DoSpecialPropertyBattalion(army1, army2, i);
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
                        if (army1.Count > 0)
                        {
                            // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial
                            IUnit newUnit2 = proxy.DoSpecialPropertyBattalion(army2, army1, j);
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
                            }
                        }
                    }
                    j++;
                }
            }
        }

        public void MakeMeleeFight(List<IUnit> army1, List<IUnit> army2)
        {
            ProxyDie proxy = new(new Battalion());
            for (int i = 0; i < 3; i++) 
            {
                if (i < army1.Count() && i < army2.Count())
                {
                    army2[i].GetHit(army1[i].Attack());
                    if (army2[i].Health() < 0) proxy.DeleteUnit(army2, i);
                }
                if (i < army1.Count() && i < army2.Count())
                {
                    army1[i].GetHit(army2[i].Attack());
                    if (army1[i].Health() < 0) proxy.DeleteUnit(army1, i);
                }
            }
        }

        // СДЕЛАТЬ
        public void Show(List<IUnit> army1, List<IUnit> army2)
        {
            throw new NotImplementedException();
        }

        //СДЕЛАТЬ
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

        string ITypeConstruction.Show(List<IUnit> army1, List<IUnit> army2)
        {
            throw new NotImplementedException();
        }
    }
}
