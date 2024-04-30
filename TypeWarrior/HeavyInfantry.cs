namespace Magic
{
    class HeavyWarrior : IUnit,IHealtheble
    {
        public HeavyWarrior((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 50;
            cost = 2;
            dodge += 0.05;
            defense = 100;
        }
        public void Heal(int arrowDamage)
        {
            // Нельзя лечить больше, чем максимальное здоровье
            health = (health + arrowDamage) < Settings.GetInstance(0, 0).Health ? (health + arrowDamage) : Settings.GetInstance(0, 0).Health;
        }

        public override string ToString()
        {
            return string.Format($"Тяжёлый Солдат. Здоровье: {health} Сила: {attack} Стоимость: {cost} Броня {defense} Уклонение {dodge} ");
        }

    }
}