using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    // Интерфейс команды, объявляющий метод Execute
    interface ICommand
    {
        bool Execute();
        void Undo();
        void Redo();
    }
}
