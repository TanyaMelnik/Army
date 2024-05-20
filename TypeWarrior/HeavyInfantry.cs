namespace Magic
{
    class HeavyWarrior : IUnit,IHealtheble
    {
        public override string Name() => name;
        public HeavyWarrior((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 50;
            cost = 2;
            dodge += 0.05;
            defense = 100;
            name = "Тяжёлый Солдат";
        }

        public override string ToString()
        {
            return string.Format($"{Name()}. Здоровье: {health} Сила: {attack} Стоимость: {cost} Броня {defense} Уклонение {dodge} ");
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

        public override IUnit MakeClone()
        {
            var a = new HeavyWarrior((attack - 50, dodge - 0.05));
            a.health = health;
            a.defense = defense;
            return new LogGetAttack(a, (attack - 50, dodge - 0.05));
        }
    }
}