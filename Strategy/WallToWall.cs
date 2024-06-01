using System.Text;

namespace Magic
{
    /// <summary>
    ///  Класс стенки на стенку.
    ///  Строка идентификатора "T:Magic.WallToWall".
    /// </summary> 
    class WallToWall : ITypeConstruction,IDead
    {
        /// <summary>
        /// Поле первой армии.
        /// Строка идентификатора "F:Magic.WallToWall.army1".
        /// </summary>
        private List<IUnit> army1;

        /// <summary>
        /// Поле второй армии.
        /// Строка идентификатора "F:Magic.WallToWall.army".
        /// </summary>
        private List<IUnit> army2;

        /// <summary>
        /// Список первой армии.
        /// Строка идентификатора "M:Magic.WallToWall.Army1".
        /// </summary>
        public List<IUnit> Army1 { get => army1; set => army1 = value; }

        /// <summary>
        /// Список второй армии.
        /// Строка идентификатора "M:Magic.WallToWall.Army2".
        /// </summary>
        public List<IUnit> Army2 { get => army2; set => army2 = value; }

        /// <summary>
        /// Метод стенки на стенку.
        /// Строка идентификатора "M:Magic.WallToWall.WallToWall".
        /// </summary>
        public WallToWall(List<IUnit> _army1, List<IUnit> _army2)
        {
            (army1, army2) = (_army1, _army2);
        }

        /// <summary>
        /// Метод проверки декоратора.
        /// Строка идентификатора "M:Magic.WallToWall.CheckDecorator".
        /// </summary>
        public void CheckDecorator()
        {
            // Защищающаяся армия ( с меньшим количеством).
            List<IUnit> defender = army1.Count < army2.Count ? army1 : army2;

            // Атакующая армия ( с большим количеством).
            List<IUnit> attacker = army1.Count > army2.Count ? army1 : army2;

            for (int i = defender.Count; i < attacker.Count - 1; i++)
            {
                // Если нашли легкого солдата.
                if (attacker[i] is LogGetAttack lightUnit && lightUnit.unit is LightWarrior)
                {
                    // А рядом с ним тяжелые солдаты => легкий солдат становится оруженосцем. 
                    if (attacker[i + 1] is LogGetAttack heavyUnit1 && heavyUnit1.unit is HeavyWarrior)
                    {
                        attacker[i + 1] = new HelmDecorator(new ShieldDecorator(new PikeDecorator(new HorseDecorator(attacker[i + 1], (0, 0)), (0, 0)), (0, 0)), (0, 0));
                    }

                    if (attacker[i - 1] is LogGetAttack heavyUnit2 && heavyUnit2.unit is HeavyWarrior)
                    {
                        attacker[i - 1] = new HelmDecorator(new ShieldDecorator(new PikeDecorator(new HorseDecorator(attacker[i - 1], (0, 0)), (0, 0)), (0, 0)), (0, 0));
                    }
                }
            }
        }

        /// <summary>
        /// Метод удаления юнита.
        /// Строка идентификатора "M:Magic.WallToWall.DeleteUnit(Magic.IUnit, Magic.int)".
        /// </summary>
        public void DeleteUnit(List<IUnit> army, int numberUnit)
        {
            // Смещение юнита справа.
            army.RemoveAt(numberUnit);
        }

        /// <summary>
        /// Метод специальных свойств.
        /// Строка идентификатора "M:Magic.WallToWall.DoSpecialProperties".
        /// </summary>
        public void DoSpecialProperties()
        {
            // Защищающаяся армия с меньшим количеством.
            List<IUnit> defender = army1.Count < army2.Count ? army1 : army2;

            // Атакующая армия с большим количеством.
            List<IUnit> attacker = army1.Count > army2.Count ? army1 : army2;

            // Применения спецтальных свойств.
            for (int i = defender.Count; i < attacker.Count; i++)
            {
                // Проверка на специальное свойство.
                if (attacker[i] is LogGetAttack unitTemp1 && unitTemp1.unit is ISpecialProperty unit1)
                {
                    // Обёртка для логирования.
                    var proxy = new ProxyLogSpecial(unit1);
                    IUnit? newUnit = proxy.DoSpecialPropertyWallToWall(attacker, defender, i);

                    // Если генетик склонировал солдата.
                    if (newUnit != null)
                    {
                        // Вставляем нового солдата перед ним.
                        army1.Insert(i, newUnit);
                        // Т.к появился новый солдат, то делаем переход через генетика.
                        i++;
                    }
                }
            }

            // Обновляем вторую армию после лучников.
            Update(defender);
        }

        /// <summary>
        /// Метод атаки.
        /// Строка идентификатора "M:Magic.WallToWall.MakeMeleeFight".
        /// </summary>
        public void MakeMeleeFight()
        {
            ProxyDie proxy = new(new Сolumn(army1, army2));

            // Количество совпадающих армий.
            int minCountArmy = army1.Count < army2.Count ? army1.Count : army2.Count;

            // Сначала сражения. 
            for (int i = 0;i < minCountArmy; i++)
            {
                // Если произошли сдвиги и солдат остался без противника.
                if (i >= army1.Count || i >= army2.Count)
                { 
                    break;
                }

                // Если противник есть. 
                army2[i].GetHit(army1[i].Attack());

                if (army2[i].Health() < 0) proxy.DeleteUnit(army2, i);

                if (i<army2.Count)
                {
                    army1[i].GetHit(army2[i].Attack());

                    if (army1[i].Health() < 0) proxy.DeleteUnit(army1, i);
                }
            }
        }

        /// <summary>
        /// Метод показа армии.
        /// Строка идентификатора "M:Magic.WallToWall.Show".
        /// </summary>
        /// <returns>Строка.</returns> 
        public string Show()
        {
            // Защищающаяся армия ( с меньшим количеством).
            List<IUnit> defender = army1.Count < army2.Count ? army1 : army2;

            StringBuilder s= new ();

            s.Append("Армия 1: \t Армия 2: \n");

            for (int i = 0; i < defender.Count; i++)
            {
                s.Append(army1[i] + "\t" + army2[i]+"\n");
            }

            for (int i = defender.Count; i < army1.Count; i++)
            {
                s.Append(army1[i] +"    нет воина\n");
            }

            for (int i = defender.Count; i < army2.Count; i++)
            {
                s.Append("нет воина\t" + army2[i] + "\n");
            }

            return s.ToString();
        }

        /// <summary>
        /// Метод обновления армии.
        /// Строка идентификатора "M:Magic.WallToWall.Update(Magic.IUnit)".
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