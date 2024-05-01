
using System.ComponentModel.DataAnnotations;

namespace Magic
{
    class Doctor : IUnit, ISpecialProperty, IHealtheble
    {
        public override string Name() => name;
        // Уникальные характеристики доктора.
        int radiusAttack = 2;
        int powerTreatment = 40;
        public Doctor((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 10;
            cost = 4;
            dodge += 0.1;
            defense = 0;
            name = "Доктор";
        }
        // Специальное свойство - лечить 
        public IUnit DoSpecialProperty(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            for (int i = 0;i<= radiusAttack; i++)
            {
                // Если впереди стоящий существует 
                if (number + i < ownArmy.Count)
                { 
                    // Если его можно вылечить 
                    if (ownArmy[number + i] is IHealtheble patient)
                    {
                        patient.Heal(powerTreatment);
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
                            patient.Heal(powerTreatment);
                            return null;
                        }
                    }
                }
            }
            return null;
        }

       

        public override string ToString()
        {
            return string.Format($"{Name()}. Здоровье: {health} Сила: {attack} Стоимость: {cost} Броня {defense}  Уклонение {dodge} ");
        }
        public void Heal(int powerTreatment)
        {
            // Нельзя лечить больше, чем максимальное здоровье
            health = (health + powerTreatment) < Settings.GetInstance(0, 0).Health ? (health + powerTreatment) : Settings.GetInstance(0, 0).Health;
        }
        public override void GetHit(int strengthAttack)
        {
            Random random = new Random();
            double randomNumber = random.NextDouble();
            //Если уклонение не произошло => unit получает урон 
            if (dodge < randomNumber)
            {
                if (defense >= strengthAttack) defense -= strengthAttack;
                else if (defense < strengthAttack && defense > 0)
                {
                    int x = strengthAttack - defense;
                    defense = 0;
                    health -= x;
                }
                else health -= strengthAttack;
            }
            else Console.WriteLine("Произошло уклонение от атаки");
        }
        public override int Health()
        {
            return health;
        }
        public override int Attack()
        {
            return attack;
        }
        public override int Defense()
        {
            return defense;
        }
        public override double Dodge()
        {
            return dodge;
        }
        public override int Cost()
        {
            return cost;
        }
    }
}