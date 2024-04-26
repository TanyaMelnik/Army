namespace Magic
{
    class Doctor : IUnit
    {
        public Doctor(Settings settings, (int , double) percentAttackAndDodge) : base(settings, percentAttackAndDodge)
        {
            attack += 10;
            cost = 4;
            dodge += 0.1;
            defense = 0;
        }
        /*public void GetHit(int strength)
        {
            // Удар по броне 
            defense = defense - strength >= 0 ? defense - strength : 0;
            // Удар по здоровью 
            health = defense - strength < 0 ? health + (defense - strength) : health;
            // Проверка и действия, если смерть ..... 
        }*/

        public override string ToString()
        {
            return string.Format($"Доктор. Здоровье: {health} Сила: {health} Стоимость: {cost} Броня {defense} ");
        }

    }
}