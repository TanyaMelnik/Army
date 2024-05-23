using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    // Команда для смены построения
    // Реализация - менять команды без пользователя ( программа сама меняет на следующую)
    class ChangeTypeConstruction : ICommand
    {
        public ITypeConstruction _typeConstruction;

        public ChangeTypeConstruction(ITypeConstruction iTypeConstruction)
        {
            _typeConstruction = iTypeConstruction;
        }

        //ITypeConstruction _TypeConstruction;
        // Меняем стратегию и запоминаем старую
        public void Execute()
        {
            //_oldITypeConstruction = _newITypeConstruction;
            //_newITypeConstruction= newITypeConstruction;
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }

        // Здесь ничего не будет, это чтобы работал интерфейс 
        public void Redo()
        {
            return;
        }
    }

}
