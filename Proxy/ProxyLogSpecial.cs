namespace Magic
{
    /// <summary>
    ///  Класс логирования Прокси.
    ///  Строка идентификатора "T:Magic.ProxyLogSpecial(Magic.ISpecialProperty)".
    /// </summary>  
    class ProxyLogSpecial(ISpecialProperty unit) : ISpecialProperty
    {
        /// <summary>
        /// Поле юнита.
        /// Строка идентификатора "F:Magic.ProxyLogSpecial.unit".
        /// </summary>
        readonly ISpecialProperty unit = unit;

        /// <summary>
        /// Поле файла логирования.
        /// Строка идентификатора "F:Magic.ProxyLogSpecial.logFilePath".
        /// </summary>
        const string logFilePath = "logSpecial.txt";

        /// <summary>
        /// Метод,, логирующий удар. 
        /// Строка идентификатора "M:Magic.ProxyLogSpecial.DoSpecialPropertyСolumn".
        /// </summary>
        /// <returns>Удар.</returns> 
        public IUnit? DoSpecialPropertyСolumn(List<IUnit> ownArmy, 
            List<IUnit> enemyArmy, int number)
        {
            string text = $"[{DateTime.Now}] Special Удар от {unit.GetType()}";
            Data.WriteInFile(logFilePath, text);
            return unit.DoSpecialPropertyСolumn(ownArmy, enemyArmy, number);
        }

        /// <summary>
        /// Метод, логирующий удар армий. 
        /// Строка идентификатора "M:Magic.ProxyLogSpecial.DoSpecialPropertyBattalion".
        /// </summary>
        /// <returns>Удар.</returns> 
        public IUnit? DoSpecialPropertyBattalion(List<IUnit> ownArmy, 
            List<IUnit> enemyArmy, int number)
        {
            string text = $"[{DateTime.Now}] Special Удар от {unit.GetType()}";
            Data.WriteInFile(logFilePath, text);
            return unit.DoSpecialPropertyBattalion(ownArmy, enemyArmy, number);
        }

        /// <summary>
        /// Метод,, логирующий удар стенки на стенку. 
        /// Строка идентификатора "M:Magic.ProxyLogSpecial.DoSpecialPropertyWallToWall".
        /// </summary>
        /// <returns>Удар.</returns> 
        public IUnit? DoSpecialPropertyWallToWall(List<IUnit> ownArmy, 
            List<IUnit> enemyArmy, int number)
        {
            string text = $"[{DateTime.Now}] Special Удар от {unit.GetType()}";
            Data.WriteInFile(logFilePath, text);
            return unit.DoSpecialPropertyWallToWall(ownArmy, enemyArmy, number);
        }
    }
}