namespace Magic
{
    class Genetic : IUnit
    {
        public Genetic()
        {
            
        }
        public void GetHit(int strength)
        {
            // Удар по броне 
            defense = defense - strength >= 0 ? defense - strength : 0;
            // Удар по здоровью 
            health = defense - strength < 0 ? health + (defense - strength) : health;
            // Проверка и действия, если смерть ..... 
        }

        public int DoAttack()
        {
            return attack;
        }

        public void Clone()
        {

        }

        public override string ToString()
        {
            return string.Format($"Тяжёлый Солдат. Здоровье: {health} Сила: {health} Стоимость: {cost} Броня {defense} ");
        }

        public override void Attack(IUnit two)
        {

        }
    }
}