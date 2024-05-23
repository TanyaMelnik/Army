namespace Magic
{

    // Команда для пунктов: сделать, отменить и повторить ход
    class MakeMove : ICommand
    {
        List<IUnit> army1;
        List<IUnit> army2;

        public MakeMove(List<IUnit> army1, List<IUnit> army2)
        {
            this.army1 = army1;
            this.army2 = army2;
        }

        // Сделать новый ход
        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }
    }
}
    
    

    