
using System.ComponentModel.DataAnnotations;

namespace Magic
{
    class Doctor : IUnit, ISpecialProperty, IHealtheble
    {
        // Уникальные характеристики доктора.
        int radiusAttack = 2;
        int arrowDamage = 40;
        public Doctor((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 10;
            cost = 4;
            dodge += 0.1;
            defense = 0;
        }
        // Специальное свойство - лечить 
        public IUnit DoSpecialProperty(List<IUnit> ownArmy, int number)
        {
            for (int i = 0;i<= radiusAttack; i++)
            {
                // Если впереди стоящий существует 
                if (number + i < ownArmy.Count)
                { 
                    // Если его можно вылечить 
                    if (ownArmy[number + i] is IHealtheble patient)
                    {
                        patient.Heal(arrowDamage);
                        return null;
                    }
                }
                else
                {
                    // Если сзади стоящий существует 
                    if (number - i >= 0)
                    {
                        // Если его можно вылечить 
                        if (ownArmy[number - i] is IHealtheble patient)
                        {
                            patient.Heal(arrowDamage);
                            return null;
                        }
                    }
                }
            }
            return null;
        }

        public void Heal(int arrowDamage)
        {
            // Нельзя лечить больше, чем максимальное здоровье
            health = (health + arrowDamage) < Settings.GetInstance(0, 0).Health ? (health + arrowDamage) : Settings.GetInstance(0, 0).Health;
        }

        public override string ToString()
        {
            return string.Format($"Доктор. Здоровье: {health} Сила: {attack} Стоимость: {cost} Броня {defense}  Уклонение {dodge} ");
        }

    }
}