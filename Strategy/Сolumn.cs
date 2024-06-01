using System.Text;

namespace Magic
{
    /// <summary>
    ///  Класс колонны.
    ///  Строка идентификатора "T:Magic.Сolumn".
    /// </summary> 
    class Сolumn : ITypeConstruction, IDead
    {
        /// <summary>
        /// Поле первой армии.
        /// Строка идентификатора "F:Magic.Сolumn.army1".
        /// </summary>
        private List<IUnit> army1;

        /// <summary>
        /// Поле второй армии.
        /// Строка идентификатора "F:Magic.Сolumn.army".
        /// </summary>
        private List<IUnit> army2;

        /// <summary>
        /// Список первой армии.
        /// Строка идентификатора "M:Magic.Сolumn.Army1".
        /// </summary>
        public List<IUnit> Army1 { get => army1; set => army1 = value; }

        /// <summary>
        /// Список второй армии.
        /// Строка идентификатора "M:Magic.Сolumn.Army2".
        /// </summary>
        public List<IUnit> Army2 { get => army2; set => army2 = value; }

        /// <summary>
        /// Метод создания колонны.
        /// Строка идентификатора "M:Magic.Сolumn.Сolumn(Magic.IUnit, Magic.IUnit)".
        /// </summary>
        public Сolumn(List<IUnit> _army1, List<IUnit> _army2)
        {
            (army1, army2) = (_army1, _army2);
        }

        /// <summary>
        /// Метод создания колонны.
        /// Строка идентификатора "M:Magic.Сolumn.DeleteUnit(Magic.IUnit, Magic.int)".
        /// </summary>
        public void DeleteUnit(List<IUnit> army, int numberUnit)
        {
            // Смещение юнита вперёд.
            army.RemoveAt(numberUnit);
        }

        /// <summary>
        /// Метод специальных свойств.
        /// Строка идентификатора "M:Magic.Сolumn.DoSpecialProperties".
        /// </summary>
        public void DoSpecialProperties()
        {
            // Счётчик для army1.
            int i = 1;

            // Счётчик для army2.
            int j = 1;

            if (army2.Count < 2 && army1.Count < 2)
            {
                return;
            }

            // Величина армий для проверки. 
            int army1Count = army1.Count;
            int army2Count = army2.Count;

            while (i < Math.Max(army1Count, army2Count) && j < Math.Max(army1Count, army2Count))
            {
                army1Count = army1.Count;
                army2Count = army2.Count;
                // Применяем специальное свойство из первой армии. 
                if (i < army1.Count)
                {
                    if (army1[i] is LogGetAttack unitTemp1 && unitTemp1.unit is ISpecialProperty unit1)
                    {
                        var proxy = new ProxyLogSpecial(unit1);
                        if (army1.Count > 0 && army2.Count > 0)
                        {
                            IUnit? newUnit = proxy.DoSpecialPropertyСolumn(army1, army2, i);
                            // Если генетик склонировал солдата.
                            if (newUnit != null)
                            {
                                // Вставляем нового солдата перед ним.
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

                // Применяем специальное свойство из второй армии. 
                if (j < army2.Count)
                {
                    if (army2[j] is LogGetAttack unitTemp2 && unitTemp2.unit is ISpecialProperty unit2)
                    {
                        var proxy = new ProxyLogSpecial(unit2);
                        if (army1.Count > 0 && army2.Count > 0)
                        {
                            // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial.
                            IUnit? newUnit2 = proxy.DoSpecialPropertyСolumn(army2, army1, j);
                            // Если генетик склонировал солдата.
                            if (newUnit2 != null)
                            {
                                // Вставляем нового солдата перед ним.
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

        /// <summary>
        /// Метод обновления армии.
        /// Строка идентификатора "M:Magic.Сolumn.Update(Magic.IUnit)".
        /// </summary>
        public void Update(List<IUnit> army)
        {
            for (int i = 0; i < army.Count; i++)
            {
                // Если нашли мертвого юнита - удаляем его из армии.
                if (army[i].Health() <= 0)
                {
                    ProxyDie proxy = new(new Сolumn(army1,army2));
                    proxy.DeleteUnit(army, i);
                }
            }
        }

        /// <summary>
        /// Метод атаки.
        /// Строка идентификатора "M:Magic.Сolumn.MakeMeleeFight".
        /// </summary>
        public void MakeMeleeFight()
        {
            ProxyDie proxy = new(new Сolumn(army1, army2));
            army2[0].GetHit(army1[0].Attack());

            if (army2[0].Health() < 0) proxy.DeleteUnit(army2, 0);

            if (army2.Count > 0)
            {
                army1[0].GetHit(army2[0].Attack());

                if (army1[0].Health() < 0) proxy.DeleteUnit(army1, 0);
            }
        }

        /// <summary>
        /// Метод показа армии.
        /// Строка идентификатора "M:Magic.Сolumn.Show".
        /// </summary>
        /// <returns>Строка.</returns> 
        public string Show()
        {
            StringBuilder s = new();

            s.Append("Армия 1: \n");
            
            for (int i = 0; i < army1.Count; i++)
            {
                s.Append(army1[i]+"\n");
            }
            
            s.Append("Армия 2: \n");
            
            for (int i = 0; i < army2.Count; i++)
            {
                s.Append(army2[i] + "\n");
            }
            
            return s.ToString();
        }

        /// <summary>
        /// Метод проверки декоратора.
        /// Строка идентификатора "M:Magic.Сolumn.CheckDecorator".
        /// </summary>
        public void CheckDecorator()
        {
            for (int i = 1; i < army1.Count - 1; i++)
            {
                // Если нашли легкого солдата.
                if (army1[i] is LogGetAttack lightUnit && lightUnit.unit is LightWarrior)
                {
                    // А рядом с ним тяжелые солдаты => легкий солдат становится оруженосцем.
                    if (army1[i + 1] is LogGetAttack heavyUnit1 && heavyUnit1.unit is HeavyWarrior)
                    {
                        army1[i + 1] = new HelmDecorator(new ShieldDecorator
                            (new PikeDecorator(new HorseDecorator(army1[i + 1], (0, 0)), (0, 0)), (0, 0)), (0, 0));
                    }

                    if (army1[i - 1] is LogGetAttack heavyUnit2 && heavyUnit2.unit is HeavyWarrior)
                    {
                        army1[i - 1] = new HelmDecorator(new ShieldDecorator
                            (new PikeDecorator(new HorseDecorator(army1[i - 1], (0, 0)), (0, 0)), (0, 0)), (0, 0));
                    }
                }
            }

            for (int i = 1; i < army2.Count - 1; i++)
            {
                // Если нашли легкого солдата.
                if (army2[i] is LogGetAttack lightUnit && lightUnit.unit is LightWarrior)
                {
                    // А рядом с ним тяжелые солдаты => легкий солдат становится оруженосцем. 
                    if (army2[i + 1] is LogGetAttack heavyUnit1 && heavyUnit1.unit is HeavyWarrior)
                    {
                        army2[i + 1] = new HelmDecorator(new ShieldDecorator(new PikeDecorator
                            (new HorseDecorator(army1[i + 1], (0, 0)), (0, 0)), (0, 0)), (0, 0));
                    }
                    if (army2[i - 1] is LogGetAttack heavyUnit2 && heavyUnit2.unit is HeavyWarrior)
                    {
                        army2[i - 1] = new HelmDecorator(new ShieldDecorator(new PikeDecorator
                            (new HorseDecorator(army1[i - 1], (0, 0)), (0, 0)), (0, 0)), (0, 0));
                    }
                }
            }
        }
    }
}