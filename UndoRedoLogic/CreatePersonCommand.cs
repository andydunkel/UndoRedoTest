using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UndoRedoModel;

namespace UndoRedoLogic
{
    public class CreatePersonCommand : ACommand
    {
        public string Name { get; set; }
        public int Age { get; set; }

        private Person createdPerson = null;

        public override void Execute()
        {
            createdPerson = new Person() { Name = Name, Age = Age };
            this.DataModel.PersonList.Add(createdPerson);
        }

        public override void Redo()
        {
            this.DataModel.PersonList.Add(createdPerson);
        }

        public override void Undo()
        {
            this.DataModel.PersonList.Remove(createdPerson);
        }
    }
}
