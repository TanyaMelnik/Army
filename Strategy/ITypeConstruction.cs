namespace Magic
{
    /// <summary>
    /// Интерфейс, определение метода ApplyInterlace
    /// Строка идентификатора "M:Magic.Battalion.CheckDecorator".
    /// </summary>
    interface ITypeConstruction
    {
        public List<IUnit> Army1 { get; set; }
        public List<IUnit> Army2 { get; set; }

        // Ближний бой
        void MakeMeleeFight();

        // Специальные свойства
        void DoSpecialProperties();

        // Проверка убитых солдат
        void Update(List<IUnit> army);

        // Проверка на декораторы
        void CheckDecorator();

        // Состав армии 
        string Show();
    }
}
