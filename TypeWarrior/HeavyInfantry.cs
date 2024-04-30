namespace Magic
{
    class HeavyWarrior : IUnit
    {
        public HeavyWarrior((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 50;
            cost = 2;
            dodge += 0.05;
            defense = 100;
        }
       /* public void GetHit(int strength)
        {
            // Удар по броне 
            defense = defense - strength >= 0 ? defense - strength : 0;
            // Удар по здоровью 
            health = defense - strength < 0 ? health + (defense - strength) : health;
            // Проверка и действия, если смерть ..... 
        }*/

        public int DoAttack()
        {
            return attack;
        }

        public void Clone()
        {

        }

        // Для проверки
        public void Print()
        {
            Console.WriteLine($"Тяжёлый Солдат. Здоровье: {health} Атака: {attack} Стоимость: {cost} Броня {defense} ");
        }

        // НЕ РАБОТАЕТ
        public override string ToString()
        {
            return string.Format($"Тяжёлый Солдат. Здоровье: {health} Сила: {attack} Стоимость: {cost} Броня {defense} Уклонение {dodge} ");
        }

    }
}