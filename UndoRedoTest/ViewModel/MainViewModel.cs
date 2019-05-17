using System;
using System.Collections.ObjectModel;

using UndoRedoModel;
using UndoRedoLogic;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace UndoRedoTest.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private DataModel dataModel = new DataModel();

        private string name = "Hund";
        private int age = 20;

        private UndoRedoStack undoRedoStack = new UndoRedoStack();

        public Person SelectedPerson { get; set; }

        public RelayCommand InsertCommand { get; private set; }
        public RelayCommand UndoCommand { get; private set; }
        public RelayCommand RedoCommand { get; private set; }

        public RelayCommand DeleteCommand { get; private set; }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                Set(() => Name, ref name, value);
            }
        }

        public int Age
        {
            get
            {
                return age;
            } 
            set
            {
                Set(() => Age, ref age, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                DataModel.PersonList.Add(new Person { Age = 39, Name = "Andy" });
                DataModel.PersonList.Add(new Person { Age = 40, Name = "Herbie" });
                DataModel.PersonList.Add(new Person { Age = 36, Name = "Ebe" });
            }
            else
            {
                DataModel.PersonList.Add(new Person { Age = 39, Name = "Andy" });
                DataModel.PersonList.Add(new Person { Age = 40, Name = "Herbie" });
                DataModel.PersonList.Add(new Person { Age = 36, Name = "Ebe" });
                DataModel.PersonList.Add(new Person { Age = 51, Name = "Wolfgang" });
                DataModel.PersonList.Add(new Person { Age = 48, Name = "Arno" });
            }

            InsertCommand = new RelayCommand(() =>
            {
                var cmd = new CreatePersonCommand() { DataModel = DataModel, Name = name, Age = age };
                ExecuteCommand(cmd);
                Name = "";
                Age = 20;
            });

            UndoCommand = new RelayCommand(() =>
            {
                undoRedoStack.Undo();
            });

            RedoCommand = new RelayCommand(() =>
            {
                undoRedoStack.Redo();
            });

            DeleteCommand = new RelayCommand(() =>
            {
                if (SelectedPerson != null)
                {
                    var cmd = new DeletePersonCommand() { DataModel = DataModel, PersonToDelete = SelectedPerson };
                    ExecuteCommand(cmd);
                }
                
            });
        }

        public void ExecuteCommand(ICommand cmd)
        {
            undoRedoStack.ExecuteCommand(cmd);
        }


        public ObservableCollection<Person> PersonList { get => DataModel.PersonList; }
        public DataModel DataModel { get => dataModel; set => dataModel = value; }
    }
}