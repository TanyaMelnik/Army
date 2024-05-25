using Magic;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class ChangeTypeConstruction : ICommand
    {
        /// <summary>
        /// Команда, которую нужно сменить.
        /// </summary>
        private ITypeConstruction _typeConstruction;
        public ITypeConstruction TypeConstruction { get => _typeConstruction; set => _typeConstruction = value; }
        private readonly ITypeConstruction[] strategy;

        public ChangeTypeConstruction(ITypeConstruction oldTypeConstruction)
        {
            _typeConstruction = oldTypeConstruction;
            strategy = [new Сolumn(_typeConstruction.Army1, _typeConstruction.Army2), new Battalion(_typeConstruction.Army1, _typeConstruction.Army2), new WallToWall(_typeConstruction.Army1, _typeConstruction.Army2)];
        }

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
