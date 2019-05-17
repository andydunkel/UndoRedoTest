using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UndoRedoModel;

namespace UndoRedoLogic
{
    public abstract class ACommand : ICommand
    {
        private DataModel dataModel = null;

        public DataModel DataModel { get => dataModel; set => dataModel = value; }

        public abstract void Execute();

        public abstract void Redo();

        public abstract void Undo();
    }
}
