using Magic;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    // Команда для смены построения
    // Реализация - менять команды без пользователя ( программа сама меняет на следующую)
    class ChangeTypeConstruction : ICommand
    {
        private ITypeConstruction _typeConstruction;
        public ITypeConstruction _TypeConstruction { get => _typeConstruction; set => _typeConstruction = value; }
        private readonly ITypeConstruction[] strategy;

        public ChangeTypeConstruction(ITypeConstruction oldTypeConstruction)
        {
            _typeConstruction = oldTypeConstruction;
            strategy = [new Сolumn(_typeConstruction.Army1, _typeConstruction.Army2), new Battalion(_typeConstruction.Army1, _typeConstruction.Army2), new WallToWall(_typeConstruction.Army1, _typeConstruction.Army2)];
        }

        //ITypeConstruction _TypeConstruction;
        // Меняем стратегию и запоминаем старую
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

        // Здесь ничего не будет, это чтобы работал интерфейс 
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
