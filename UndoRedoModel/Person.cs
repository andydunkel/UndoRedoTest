using System;
using System.Collections.Generic;
using System.Text;

using GalaSoft.MvvmLight;

namespace UndoRedoModel
{
    public class Person : ObservableObject
    {
        private string name = "";
        private int age = 20;

        public String Name
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

        public override string ToString()
        {
            return "Name: " + Name + " ; Age: " + Age.ToString() + Environment.NewLine;
        }
    }
}
