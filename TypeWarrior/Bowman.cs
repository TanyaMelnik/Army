namespace Magic
{
    class Bowman : IUnit
    {
        public Bowman(Settings settings):base(settings)
        {
            attack = 30;
            cost = 3;
            dodge = 0.3;
            defense = 30;
    }
        public void GetHit(int strength)
        {
            // Удар по броне 
            defense = defense - strength >= 0 ? defense - strength : 0;
            // Удар по здоровью 
            health = defense - strength < 0 ? health + (defense - strength) : health;
            // Проверка и действия, если смерть ..... 
        }

        public override string ToString()
        {
            return string.Format($"Тяжёлый Солдат. Здоровье: {health} Сила: {health} Стоимость: {cost} Броня {defense} ");
        }

    }
}