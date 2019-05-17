using System;

using System.Collections.ObjectModel;

namespace UndoRedoModel
{
    public class DataModel
    {
        private ObservableCollection<Person> personList = new ObservableCollection<Person>();

        public ObservableCollection<Person> PersonList { get => personList; }
    }
}

