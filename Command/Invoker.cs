using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class Invoker
    {
        private readonly List<ICommand> _commands = [];
        public List<ICommand> Commands {  get { return _commands; } }
        public int _count = -1;
        public int Count { get { return _count; } }

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
            _count++;
        }

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
        public bool RedoCommand()
        {
            // Если после текущей была команда (т.е. была отмена), то можно выполнять повторение.
            if (_count+1< _commands.Count)
            {
                // Отменить i  команду.
                _commands[_count+1].Redo();
                _count++;
                return true;
            }
            return false;
        }
        public ITypeConstruction GetStategy()
        {
            return _count >=0 ? _commands[_count].TypeConstruction : User.ChooseStrategy();
        }
    }
}