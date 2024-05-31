using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    /// <summary>
    /// Интерфейс, определение Command.
    /// Строка идентификатора "M:Magic.ICommand".
    /// </summary>
    interface ICommand
    {
        public ITypeConstruction TypeConstruction { get; set; }
        bool Execute();
        void Undo();
        void Redo();
    }
}
