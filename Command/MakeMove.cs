namespace Magic
{

    // Команда для пунктов: сделать, отменить и повторить ход
    class MakeMove : ICommand
    {
        public ITypeConstruction _typeConstruction;
        public List<IUnit> oldArmy1;
        public List<IUnit> oldArmy2;

        public MakeMove(ITypeConstruction typeConstruction)
        {
            _typeConstruction = typeConstruction;
            oldArmy1 = [];
            oldArmy2=[];
        }

        // Сделать новый ход
        public bool Execute()
        {
            // Сохраняем состояние старых армий с новыми ссылками
            foreach (var unit in _typeConstruction.Army1)
            {
                oldArmy1.Add(unit.MakeClone());
            }
            foreach (var unit in _typeConstruction.Army2)
            {
                oldArmy2.Add(unit.MakeClone());
            }
            // Делаем ход для ближнего боя 
             _typeConstruction.MakeMeleeFight();
            // Ход спец свойств
            _typeConstruction.DoSpecialProperties();
            // false - игра закончена
            return _typeConstruction.Army1.Count >=1 && _typeConstruction.Army2.Count >= 1;
        }

        public void Undo()
        {
            (_typeConstruction.Army1, _typeConstruction.Army2, oldArmy1, oldArmy2) = (oldArmy1, oldArmy2, _typeConstruction.Army1, _typeConstruction.Army2);
        }
        // Отменить и повторить.
        public void Redo()
        {
            (_typeConstruction.Army1, _typeConstruction.Army2, oldArmy1, oldArmy2) = (oldArmy1, oldArmy2, _typeConstruction.Army1, _typeConstruction.Army2);
        }
    }
}
    
    

    