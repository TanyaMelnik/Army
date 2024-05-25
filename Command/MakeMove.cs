namespace Magic
{
    class MakeMove(ITypeConstruction typeConstruction) : ICommand
    {
        private ITypeConstruction _typeConstruction = typeConstruction;
        public ITypeConstruction TypeConstruction { get => _typeConstruction; set => _typeConstruction = value; }
        public List<IUnit> oldArmy1 = [];
        public List<IUnit> oldArmy2 = [];

        public bool Execute()
        {
            // Сохраняем состояние старых армий с новыми ссылками.
            foreach (var unit in _typeConstruction.Army1)
            {
                oldArmy1.Add(unit.MakeClone());
            }
            foreach (var unit in _typeConstruction.Army2)
            {
                oldArmy2.Add(unit.MakeClone());
            }
            _typeConstruction.CheckDecorator();
            // Делаем ход для ближнего боя. 
             _typeConstruction.MakeMeleeFight();
            _typeConstruction.CheckDecorator();
            // Ход спец свойств.
            _typeConstruction.DoSpecialProperties();
            // false - игра закончена.
            return _typeConstruction.Army1.Count >=1 && _typeConstruction.Army2.Count >= 1;
        }

        public void Undo()
        {
            (_typeConstruction.Army1, _typeConstruction.Army2, oldArmy1, oldArmy2) = (oldArmy1, oldArmy2, _typeConstruction.Army1, _typeConstruction.Army2);
        }
        public void Redo()
        {
            (_typeConstruction.Army1, _typeConstruction.Army2, oldArmy1, oldArmy2) = (oldArmy1, oldArmy2, _typeConstruction.Army1, _typeConstruction.Army2);
        }
    }
}
    
    

    