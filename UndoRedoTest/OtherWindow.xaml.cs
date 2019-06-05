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
using System.Windows.Shapes;

using UndoRedoModel;

namespace UndoRedoTest
{
    /// <summary>
    /// Interaction logic for OtherWindow.xaml
    /// </summary>
    public partial class OtherWindow : Window
    {
        private Person person = new Person();

        public OtherWindow()
        {
            InitializeComponent();
            this.DataContext = person;
            person.Name = "Willy";
            person.Age = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Name: " + person.Name + " - Age: " + person.Age);
        }
    }

}
