using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UndoRedoModel;

namespace UndoRedoLogic
{
    public class EditPersonCommand : ACommand
    {
        public Person PersonToEdit { get; set; }
        public String OldName { get; set; }
        public int OldAge { get; set; }

        public String NewName { get; set; }
        public int NewAge { get; set; }


        public override void Execute()
        {
            OldName = PersonToEdit.Name;
            OldAge = PersonToEdit.Age;

            PersonToEdit.Name = NewName;
            PersonToEdit.Age = NewAge;
        }

        public override void Redo()
        {
            PersonToEdit.Name = NewName;
            PersonToEdit.Age = NewAge;
        }

        public override void Undo()
        {
            PersonToEdit.Name = OldName;
            PersonToEdit.Age = OldAge;
        }
    }
}
