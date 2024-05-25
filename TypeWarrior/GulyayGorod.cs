
using Magic;

namespace Magic
{
    class GulyayGorod
    {
        public string type = "Щит гуляй город";
        // Здоровье.
        public int strength = 200;
        // Сила атаки.
        public int power = 0;
        // Стоимость.
        public int cost =2;
        public void GetDemage(int strengthAttack)
        {
            strength-=strengthAttack;
        }
    }

    /// <summary>
    /// Адаптер AdapterGulyayGorod реализует интерфейс IUnit и использует GulyayGorod.
    /// </summary>
    /// <param name="percentAttackAndDodge">Процент атаки и уклонения.</param>
    class AdapterGulyayGorod((int percentAttack, double percentDodge) percentAttackAndDodge) : IUnit(percentAttackAndDodge)
    {
        private readonly GulyayGorod gulyayGorod = new();

        public override string Name() => gulyayGorod.type;
        public override int Health()
        {
            return gulyayGorod.strength;
        }
        public override int Attack()
        {
            return gulyayGorod.power;
        }
        public override int Defense()
        {
            return 0;
        }
        public override double Dodge()
        {
            return 0;
        }
        public override string ToString()
        {
            return string.Format($"{Name()}. Здоровье: {Health()} Сила: {attack} Стоимость: {cost} Броня {defense} Уклонение {dodge}");
        }

        public override void GetHit(int strengthAttack)
        {
            gulyayGorod.GetDemage(strengthAttack);
        }

        public override IUnit MakeClone()
        {
            var a = new AdapterGulyayGorod((0, 0));
            a.gulyayGorod.strength = gulyayGorod.strength;
            return new LogGetAttack(a, (0, 0));
        }

        public override int Cost()
        {
            return gulyayGorod.cost;
        }
    }
}