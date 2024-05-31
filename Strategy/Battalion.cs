using System.Text;

namespace Magic
{
    /// <summary>
    ///  Класс батальона.
    ///  Строка идентификатора "T:Magic.Battalion".
    /// </summary> 
    class Battalion : ITypeConstruction, IDead
    {
        /// <summary>
        /// Поле первой армии.
        /// Строка идентификатора "F:Magic.Battalion.army1".
        /// </summary>
        private List<IUnit> army1;

        /// <summary>
        /// Поле второй армии.
        /// Строка идентификатора "F:Magic.Battalion.army2".
        /// </summary>
        private List<IUnit> army2;

        /// <summary>
        /// Список первой армии.
        /// Строка идентификатора "F:Magic.Battalion.Army1".
        /// </summary>
        public List<IUnit> Army1 { get => army1; set => army1 = value; }

        /// <summary>
        /// Поле второй армии.
        /// Строка идентификатора "F:Magic.Battalion.Army2".
        /// </summary>
        public List<IUnit> Army2 { get => army2; set => army2 = value; }
        public Battalion(List<IUnit> _army1, List<IUnit> _army2)
        {
            (army1, army2) = (_army1, _army2);
        }

        /// <summary>
        /// Метод, проверяющий декоратоор. 
        /// Строка идентификатора "M:Magic.Battalion.CheckDecorator".
        /// </summary>
        public void CheckDecorator()
        {
            for (int i = 1; i < army1.Count - 1; i++)
            {
                // Если нашли легкого солдата.
                if (army1[i] is LogGetAttack lightUnit && lightUnit.unit is LightWarrior)
                {
                    // А рядом с ним тяжелые солдаты => легкий солдат становится оруженосцем. 
                    if (i % 3 != 2 && i + 1 <= army1.Count - 1 && army1[i + 1] is LogGetAttack 
                        heavyUnit1 && heavyUnit1.unit is HeavyWarrior)
                    {
                        army1[i + 1] = new HelmDecorator(new ShieldDecorator(new PikeDecorator(new 
                            HorseDecorator(army1[i + 1], (0, 0)), (0, 0)), (0, 0)), (0, 0));
                    }
                    if (i % 3 != 0 && i - 1 >= 0 && army1[i - 1] is LogGetAttack heavyUnit2 && 
                        heavyUnit2.unit is HeavyWarrior)
                    {
                        army1[i - 1] = new HelmDecorator(new ShieldDecorator(new PikeDecorator(new 
                            HorseDecorator(army1[i - 1], (0, 0)), (0, 0)), (0, 0)), (0, 0));
                    }
                }
            }

            for (int i = 1; i < army2.Count - 1; i++)
            {
                // Если нашли легкого солдата.
                if (army2[i] is LogGetAttack lightUnit && lightUnit.unit is LightWarrior)
                {
                    // А рядом с ним тяжелые солдаты => легкий солдат становится оруженосцем. 
                    if (i % 3 != 2 && i + 1 <= army2.Count - 1 && army2[i + 1] is LogGetAttack 
                        heavyUnit1 && heavyUnit1.unit is HeavyWarrior)
                    {
                        army2[i + 1] = new HelmDecorator(new ShieldDecorator(new PikeDecorator(new 
                            HorseDecorator(army1[i + 1], (0, 0)), (0, 0)), (0, 0)), (0, 0));
                    }
                    if (i % 3 != 0 && i - 1 >= 0 && army2[i - 1] is LogGetAttack heavyUnit2 && 
                        heavyUnit2.unit is HeavyWarrior)
                    {
                        army2[i - 1] = new HelmDecorator(new ShieldDecorator(new PikeDecorator(new 
                            HorseDecorator(army1[i - 1], (0, 0)), (0, 0)), (0, 0)), (0, 0));
                    }
                }
            }
        }

        /// <summary>
        /// Метод, удаляющий юнит. 
        /// Строка идентификатора "M:Magic.Battalion.DeleteUnit".
        /// </summary>
        public void DeleteUnit(List<IUnit> army, int numberUnit)
        {
            int i;
            for (i = numberUnit; i < army.Count-3; i+=3)
            {
                army[i] = army[i+3];
            }
            if (i<army.Count) army.RemoveAt(i);
        }

        /// <summary>
        /// Метод, делающий спец.. 
        /// Строка идентификатора "M:Magic.Battalion.DoSpecialProperties".
        /// </summary>
        public void DoSpecialProperties()
        {
            // Счётчик для army1.
            int i = 1;
            // Счётчик для army2.
            int j = 1;
            while (i < Math.Max(army1.Count, army2.Count) && i < 3 && j < 
                Math.Max(army1.Count, army2.Count) && j < 3)
            {
                // Применяем специальное свойство из первой армии. 
                if (i < army1.Count && i > army2.Count-1)
                {
                    if (army1[i] is LogGetAttack unitTemp1 && unitTemp1.unit is 
                        ISpecialProperty unit1)
                    {
                        var proxy = new ProxyLogSpecial(unit1);
                        // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial.
                        if (army1.Count > 0 && army2.Count > 0)
                        {
                            IUnit? newUnit = proxy.DoSpecialPropertyBattalion(army1, 
                                army2, i);

                            // Если генетик склонировал солдата
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
                    
                }

                i++;

                // Применяем специальное свойство из второй армии. 
                if (j < army2.Count && j > army1.Count - 1)
                {
                    if (army2[j] is LogGetAttack unitTemp2 && unitTemp2.unit is 
                        ISpecialProperty unit2)
                    {
                        var proxy = new ProxyLogSpecial(unit2);
                        if (army1.Count > 0 && army2.Count > 0)
                        {
                            // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial.
                            IUnit? newUnit2 = proxy.DoSpecialPropertyBattalion(army2, army1, j);

                            // Если генетик склонировал солдата
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
                }

                j++;
            }

            // Счётчик для army1.
            i = 3;
            // Счётчик для army2.
            j = 3;

            while (i < Math.Max(army1.Count, army2.Count) && j < Math.Max(army1.Count, army2.Count))
            {
                // Применяем специальное свойство из первой армии. 
                if (i < army1.Count)
                {
                    if (army1[i] is LogGetAttack unitTemp1 && unitTemp1.unit is ISpecialProperty unit1)
                    {
                        var proxy = new ProxyLogSpecial(unit1);
                        // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial.
                        if (army1.Count > 0 && army2.Count > 0)
                        {
                            IUnit? newUnit = proxy.DoSpecialPropertyBattalion(army1, army2, i);
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
                    
                }

                i++;

                // Применяем специальное свойство из второй армии. 
                if (j < army2.Count)
                {
                    if (army2[j] is LogGetAttack unitTemp2 && unitTemp2.unit is ISpecialProperty unit2)
                    {
                        var proxy = new ProxyLogSpecial(unit2);
                        if (army1.Count > 0)
                        {
                            // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial.
                            IUnit? newUnit2 = proxy.DoSpecialPropertyBattalion(army2, army1, j);
                            // Если генетик склонировал солдата
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
                }

                j++;
            }
        }

        /// <summary>
        /// Метод, начинающий драку. 
        /// Строка идентификатора "M:Magic.Battalion.MakeMeleeFight".
        /// </summary>
        public void MakeMeleeFight()
        {
            ProxyDie proxy = new(new Battalion(army1,army2));
            for (int i = 0; i < 3; i++) 
            {
                if (i < army1.Count && i < army2.Count)
                {
                    army2[i].GetHit(army1[i].Attack());

                    if (army2[i].Health() < 0) proxy.DeleteUnit(army2, i);
                }

                if (i < army1.Count && i < army2.Count)
                {
                    army1[i].GetHit(army2[i].Attack());

                    if (army1[i].Health() < 0) proxy.DeleteUnit(army1, i);
                }
            }
        }

        /// <summary>
        /// Метод показа. 
        /// Строка идентификатора "M:Magic.Battalion.Show".
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
        /// Метод обновления. 
        /// Строка идентификатора "M:Magic.Battalion.Update".
        /// </summary>
        public void Update(List<IUnit> army)
        {
            for (int i = 0; i < army.Count; i++)
            {
                // Если нашли мертвого юнита - удаляем его из армии.
                if (army[i].Health() <= 0)
                {
                    ProxyDie proxy = new(new Сolumn(army1, army2));
                    proxy.DeleteUnit(army, i);
                }
            }
        }
    }
}