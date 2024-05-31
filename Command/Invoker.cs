namespace Magic
{
    /// <summary>
    ///  Класс вызова.
    ///  Строка идентификатора "T:Magic.Invoker".
    /// </summary>
    class Invoker
    {
        /// <summary>
        /// Приватное поле, содержащее команды.
        /// Строка идентификатора "F:Magic.Invoker._commands".
        /// </summary>
        private readonly List<ICommand> _commands = [];

        public List<ICommand> Commands {  get { return _commands; } }

        public int _count = -1;

        public int Count { get { return _count; } }

        /// <summary>
        /// Метод добавления команды.
        /// Строка идентификатора "M:Magic.Invoker.AddCommand(Magic.ICommand)".
        /// </summary>
        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
            _count++;
        }

        /// <summary>
        /// Метод Execute команды.
        /// Строка идентификатора "M:Magic.Invoker.ExecuteCommand".
        /// </summary>
        public bool ExecuteCommand()
        {
            // Удаляем все команды, начиная с индекса _count(текущее место) и до конца списка.
            if (_count + 1< _commands.Count)
            {
                _commands.RemoveRange(_count + 1, _commands.Count-_count-1);
            }
            // Выполнить i команду.
            return _commands[_count].Execute();
        }

        /// <summary>
        /// Метод Undo команды.
        /// Строка идентификатора "M:Magic.Invoker.UndoCommand".
        /// </summary>
        public bool UndoCommand()
        {
            if (_count >= 0)
            {
                // Отменить i команду.
                _commands[_count].Undo();
                _count--;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Метод Redo команды.
        /// Строка идентификатора "M:Magic.Invoker.RedoCommand".
        /// </summary>
        public bool RedoCommand()
        {
            // Если после текущей была команда (т.е. была отмена),
            // то можно выполнять повторение.
            if (_count+1< _commands.Count)
            {
                // Отменить i  команду.
                _commands[_count+1].Redo();
                _count++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Метод вызова стратегии.
        /// Строка идентификатора "M:Magic.Invoker.GetStategy".
        /// </summary>
        public ITypeConstruction GetStategy()
        {
            return _count >=0 ? _commands[_count].TypeConstruction : 
                User.ChooseStrategy();
        }
    }
}