namespace Magic {
    class LightWarrior : IUnit, ICloneable,IHealtheble
    {
        public override string Name() => name ?? "";

        public LightWarrior((int , double ) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 40;
            cost = 1;
            dodge += 0.2;
            defense = 50;
            name = "Легкий солдат";
        }

        public IUnit Clone()
        {
            return new LogGetAttack(new LightWarrior((attack - 40, dodge - 0.2)), (attack-40, dodge-0.2));
        }


        public override string ToString()
        {
            return string.Format($"{Name()}. Здоровье: {health} Сила: {attack} Стоимость: {cost} Броня {defense} Уклонение {dodge}");
        }
        public void Heal(int powerTreatment)
        {
            // Нельзя лечить больше, чем максимальное здоровье.
            health = (health + powerTreatment) < Settings.GetInstance(0, 0).Health ? (health + powerTreatment) : Settings.GetInstance(0, 0).Health;
        }
        public override void GetHit(int strengthAttack)
        {
            Random random = new();
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
            var a = new LightWarrior((attack - 40, dodge - 0.2))
            {
                health = health,
                defense = defense
            };
            return new LogGetAttack(a, (attack - 40, dodge - 0.2));
        }
    } 
}