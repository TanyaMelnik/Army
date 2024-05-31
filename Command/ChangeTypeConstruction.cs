namespace Magic
{
    /// <summary>
    ///  Класс настроек.
    ///  Строка идентификатора "T:Magic.ChangeTypeConstruction".
    /// </summary>
    class ChangeTypeConstruction : ICommand
    {
        /// <summary>
        /// Поле команды, которую нужно сменить.
        /// Строка идентификатора "F:Magic.ChangeTypeConstruction._typeConstruction".
        /// </summary>
        private ITypeConstruction _typeConstruction;

        /// <summary>
        /// Интерфейс типа юнита.
        /// Строка идентификатора "F:Magic.ChangeTypeConstruction.TypeConstruction".
        /// </summary>
        public ITypeConstruction TypeConstruction { get => _typeConstruction; 
            set => _typeConstruction = value; }

        /// <summary>
        /// Поле, содержащее стратегию.
        /// Строка идентификатора "F:Magic.ChangeTypeConstruction.strategy".
        /// </summary>
        private readonly ITypeConstruction[] strategy;

        /// <summary>
        /// Метод смены типа.
        /// Строка идентификатора "M:Magic.ChangeTypeConstruction.ChangeTypeConstruction(Magic.ITypeConstruction)".
        /// </summary>
        /// <param name="oldTypeConstruction">Старый тип.</param>
        public ChangeTypeConstruction(ITypeConstruction oldTypeConstruction)
        {
            _typeConstruction = oldTypeConstruction;
            strategy = [new Сolumn(_typeConstruction.Army1, 
                _typeConstruction.Army2), 
                new Battalion(_typeConstruction.Army1, 
                _typeConstruction.Army2), 
                new WallToWall(_typeConstruction.Army1, 
                _typeConstruction.Army2)];
        }

        /// <summary>
        /// Метод Execute.
        /// Строка идентификатора "M:Magic.ChangeTypeConstruction.Execute".
        /// </summary>
        public bool Execute()
        {
            for (int i = 0; i < strategy.Length; i++)
            {
                if (_typeConstruction.GetType() == strategy[i].GetType())
                {
                    _typeConstruction = strategy[(i + 1) % strategy.Length];
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Метод Undo.
        /// Строка идентификатора "M:Magic.ChangeTypeConstruction.Execute".
        /// </summary>
        public void Undo()
        {
            for (int i = 0; i < strategy.Length; i++)
            {
                if (_typeConstruction.GetType() == strategy[i].GetType())
                {
                    _typeConstruction = strategy[(i - 1) % strategy.Length];
                }
            }
        }

        /// <summary>
        /// Метод Redo.
        /// Строка идентификатора "M:Magic.ChangeTypeConstruction.Execute".
        /// </summary>
        public void Redo()
        {
            for (int i = 0; i < strategy.Length; i++)
            {
                if (_typeConstruction.GetType() == strategy[i].GetType())
                {
                    _typeConstruction = strategy[(i + 1) % strategy.Length];
                }
            }
        }
    }
}