namespace Magic
{
    /// <summary>
    ///  Класс логирования атаки.
    ///  Строка идентификатора "T:Magic.LogGetAttack".
    /// </summary>  
    class LogGetAttack(IUnit unit, (int percentAttack, double percentDodge) percentAttackAndDodge) : 
        IUnit(percentAttackAndDodge)
    {
        /// <summary>
        /// Поле юнита.
        /// Строка идентификатора "F:Magic.LogGetAttack.unit".
        /// </summary>
        public IUnit unit = unit;

        /// <summary>
        /// Поле файла логирования.
        /// Строка идентификатора "F:Magic.LogGetAttack.logFilePath".
        /// </summary>
        const string logFilePath = "logHitUnit.txt";

        /// <summary>
        /// Метод здоровья юнита. 
        /// Строка идентификатора "M:Magic.LogGetAttack.Health".
        /// </summary>
        /// <returns>Здоровье.</returns>     
        public override int Health()
        {
            return unit.Health();
        }

        /// <summary>
        /// Метод атаки. 
        /// Строка идентификатора "M:Magic.LogGetAttack.Attack".
        /// </summary>
        /// <returns>Атака.</returns>  
        public override int Attack()
        {
            return unit.Attack();
        }

        /// <summary>
        /// Метод преображения в строку. 
        /// Строка идентификатора "M:Magic.LogGetAttack.ToString".
        /// </summary>
        /// <returns>Строка.</returns>  
        public override string ToString()
        {
            return unit.ToString();
        }

        /// <summary>
        /// Метод получения удара. 
        /// Строка идентификатора "M:Magic.LogGetAttack.GetHit(Magic.int)".
        /// </summary>
        public override void GetHit(int strengthAttack)
        {
            string text = $"[{DateTime.Now}] Удар по {unit.GetType()} уроном " +
                $"{strengthAttack} ";
            Data.WriteInFile(logFilePath, text);
            unit.GetHit(strengthAttack);
        }

        /// <summary>
        /// Метод названия юнита. 
        /// Строка идентификатора "M:Magic.LogGetAttack.Name".
        /// </summary>
        /// <returns>Название.</returns>  
        public override string Name()
        {
            return unit.Name();
        }

        /// <summary>
        /// Метод урона. 
        /// Строка идентификатора "M:Magic.LogGetAttack.Dodge".
        /// </summary>
        /// <returns>Урон.</returns> 
        public override double Dodge()
        {
            return unit.Dodge();
        }

        /// <summary>
        /// Метод защиты. 
        /// Строка идентификатора "M:Magic.LogGetAttack.Defense".
        /// </summary>
        /// <returns>Защита.</returns> 
        public override int Defense()
        {
            return unit.Defense();
        }

        /// <summary>
        /// Метод стоимости. 
        /// Строка идентификатора "M:Magic.LogGetAttack.Cost".
        /// </summary>
        /// <returns>Стоимость.</returns> 
        public override int Cost()
        {
            return unit.Cost();
        }

        /// <summary>
        /// Метод клонирования. 
        /// Строка идентификатора "M:Magic.LogGetAttack.MakeClone".
        /// </summary>
        /// <returns>Клон.</returns> 
        public override IUnit MakeClone()
        {
            return unit.MakeClone();
        }
    }    
}