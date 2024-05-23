using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class Invoker
    {
        private List<ICommand> _commands = [];
        int _count = -1;

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
            _count++;
        }

        public bool ExecuteCommand()
        {
            // Удаляем все команды, начиная с индекса _count(текущее место) и до конца списка
            if (_count + 1< _commands.Count)
            {
                _commands.RemoveRange(_count + 1, _commands.Count-_count-1);
            }
            // Выполнить i 
            return _commands[_count].Execute();
        }

        public bool UndoCommand()
        {
            if (_count < 0)
            {
                // Отменить i 
                _commands[_count].Undo();
                _count--;
                return true;
            }
            return false;
        }
        public bool RedoCommand()
        {
            // Если после текущей была команда (т.е. была отмена), то можно выполнять повторение
            if (_count+1< _commands.Count)
            {
                // Отменить i 
                _commands[_count+1].Redo();
                _count++;
                return true;
            }
            return false;
        }
        public ITypeConstruction? GetStategy()
        {
            return _commands.Count != 0 ? _commands[_commands.Count - 1]._TypeConstruction :null ;
        }
    }
}






// Команда для ближнего боя
/*public class MakeMeleeFight : ICommand
{
    bool isDie =false;
    public IUnit deffender;
    List<IUnit> _army1;
    List<IUnit> _army2;
    // Конструктор команды, принимающий атакующую армию 
    public MakeMeleeFight(List<IUnit> army1, List<IUnit> army2)
    {
        deffender = army2[0].MakeClone();
        _army1 = army1;
        _army2 = army2;
       // Проинициализировать массив ударов 
    }

    // Метод выполнения команды
    public void Execute()
    {
        ProxyDie proxy = new(new DeadUnit());
        _army2[0].GetHit(_army1[0].Attack());
        if (_army2[0].Health() < 0) 
        { 
            isDie = true;
            proxy.DeleteUnit(_army2, 0); 
        }

       *//* if (_army2.Count > 0)
        {
            _army1[0].GetHit(_army2[0].Attack());
            if (_army1[0].Health() < 0) proxy.DeleteUnit(_army1, 0);
        }*//*
        // Логика удара и занесения в массив
    }

    public void Undo()
    {
        // Проверяем что мертв
        if (isDie) _army2.Insert(0, deffender);
        else _army2[0] = deffender;
    }

    public void Redo()
    {
        throw new NotImplementedException();
    }
}*/

/* // Команда для отмены хода
 public class UndoCommand : ICommand
 {
     private readonly Receiver _receiver;

     // Конструктор команды, принимающий получателя (Receiver)
     public UndoCommand(Receiver receiver)
     {
         _receiver = receiver;
     }

     // Метод выполнения команды
     public void Execute()
     {
         _receiver.Undo();
     }
 }

 // Команда для повтора хода (отменить и повторить)
 public class RedoCommand : ICommand
 {
     private readonly Receiver _receiver;

     // Конструктор команды, принимающий получателя (Receiver)
     public RedoCommand(Receiver receiver)
     {
         _receiver = receiver;
     }

     // Метод выполнения команды
     public void Execute()
     {
         _receiver.Redo();
     }
 }

 // Инициатор команд, вызывающий команды по запросу
 public class Invoker
 {
     // Словарь для хранения команд по их именам
     private readonly Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();

     // Метод для назначения команды
     public void SetCommand(string name, ICommand command)
     {
         _commands[name] = command;
     }

     // Метод для выполнения команды по имени
     public void ExecuteCommand(string name)
     {
         if (_commands.TryGetValue(name, out ICommand command))
         {
             // Выполнение команды
             command.Execute();
         }
         else
         {
             Console.WriteLine($"Команда {name} не найдена");
         }
     }
 }*/
//}
