namespace Magic
{
    /// <summary>
    /// Интерфейс, определение метода ApplyInterlace
    /// Строка идентификатора "M:Magic.Battalion.CheckDecorator".
    /// </summary>
    interface ITypeConstruction
    {
        /// <summary>
        /// Поле первой армии.
        /// Строка идентификатора "F:Magic.ITypeConstruction.Army1".
        /// </summary>
        public List<IUnit> Army1 { get; set; }

        /// <summary>
        /// Поле второй армии.
        /// Строка идентификатора "F:Magic.ITypeConstruction.Army2".
        /// </summary>
        public List<IUnit> Army2 { get; set; }

        /// <summary>
        /// Метод ближнего боя.
        /// Строка идентификатора "M:Magic.ITypeConstruction.MakeMeleeFight".
        /// </summary>
        void MakeMeleeFight();

        /// <summary>
        /// Метод специальных свойств.
        /// Строка идентификатора "M:Magic.ITypeConstruction.DoSpecialProperties".
        /// </summary>
        void DoSpecialProperties();

        /// <summary>
        /// Метод проверки убитых солдат.
        /// Строка идентификатора "M:Magic.ITypeConstruction.Update(Magic.IUnit)".
        /// </summary>
        void Update(List<IUnit> army);

        /// <summary>
        /// Метод проверки на декораторы.
        /// Строка идентификатора "M:Magic.ITypeConstruction.CheckDecorator".
        /// </summary>
        void CheckDecorator();

        /// <summary>
        /// Метод состава армии.
        /// Строка идентификатора "M:Magic.ITypeConstruction.Show".
        /// </summary>
        string Show();
    }
}