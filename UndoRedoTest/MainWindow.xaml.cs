using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using UndoRedoTest.ViewModel;

using UndoRedoModel;
using UndoRedoLogic;

namespace UndoRedoTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModelLocator _locator;

        public MainWindow()
        {
            InitializeComponent();
            _locator = new ViewModelLocator();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = "";

            foreach (var p in _locator.Main.PersonList)
            {
                s += p.ToString();
            }

            MessageBox.Show(s);
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Person p = e.Row.Item as Person;

            string name = p.Name;
            int age = p.Age;

            EditPersonCommand cmd = new EditPersonCommand();
            cmd.PersonToEdit = p;
            cmd.DataModel = _locator.Main.DataModel;

            switch (e.Column.DisplayIndex)
            {
                case 0:
                    cmd.NewName = (e.EditingElement as TextBox).Text;
                    cmd.NewAge = age;
                    break;
                case 1:
                    cmd.NewName = name;
                    int newAge = -1;

                    if (!Int32.TryParse((e.EditingElement as TextBox).Text, out newAge))
                    {
                        e.Cancel = true;
                        return;

                    }

                    cmd.NewAge = newAge;

                    break;
            }

            _locator.Main.ExecuteCommand(cmd);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OtherWindow w = new OtherWindow();
            w.ShowDialog();
        }
    }
}
