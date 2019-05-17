using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndoRedoLogic
{
    public class UndoRedoStack
    {
        private readonly Stack<ICommand> undoStack = new Stack<ICommand>();
        private readonly Stack<ICommand> redoStack = new Stack<ICommand>();

        public Stack<ICommand> UndoStack => undoStack;
        public Stack<ICommand> RedoStack => redoStack;

        public void Undo()
        {
            if (undoStack.Count != 0)
            {
                ICommand cmd = undoStack.Pop();
                if (cmd != null)
                {
                    cmd.Undo();
                    redoStack.Push(cmd);
                }
            }
        }

        public void Redo()
        {
            if (redoStack.Count != 0)
            {
                ICommand cmd = redoStack.Pop();
                if (cmd != null)
                {
                    cmd.Redo();
                    undoStack.Push(cmd);
                }
            }
        }

        public void ClearUndo()
        {
            undoStack.Clear();
        }


        public void ExecuteCommand(ICommand cmd)
        {
            cmd.Execute();
            undoStack.Push(cmd);
        }
    }
}
