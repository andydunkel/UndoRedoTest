using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UndoRedoModel;

namespace UndoRedoLogic
{
    public class DeletePersonCommand : ACommand
    {
        public Person PersonToDelete { get; set; }

        private int index = -1;

        public override void Execute()
        {
            index = DataModel.PersonList.IndexOf(PersonToDelete);
            DataModel.PersonList.Remove(PersonToDelete);
        }

        public override void Redo()
        {
            Execute();
        }

        public override void Undo()
        {
            DataModel.PersonList.Insert(index, PersonToDelete);
        }
    }
}
