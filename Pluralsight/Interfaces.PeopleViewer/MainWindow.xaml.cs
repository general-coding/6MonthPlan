using Interfaces.Common;
using Interfaces.People.Library;
using System.Collections.Generic;
using System.Windows;

namespace PeopleViewer
{
    public partial class MainWindow : Window
    {
        PersonRepository repository = new PersonRepository();

        public MainWindow()
        {
            InitializeComponent();
        }

        //Returns a list of Persons that has been defined as a List
        //The people variable in this code has to match the data type of the source
        //As long as the source returns the specified type in the destination, this code will work
        //For example, we change from List to an Array, this cod will break
        private void ConcreteFetchButton_Click(object sender, RoutedEventArgs e)
        {
            List<Person> people = repository.GetPeople();
            PersonListBox.ItemsSource = people;
        }

        //Returns a list of Persons that has been defained as a List
        //The people variable in this code is IEnumberable of Persons.
        //As long as the source returns an IEnumber of Persons, this code will execute.
        //For example, we change from List to an Array, this code will still work
        private void AbstractFetchButton_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Person> people = repository.GetPeople();
            PersonListBox.ItemsSource = people;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();
        }

        private void ClearListBox()
        {
            //PersonListBox.Items.Clear();
            PersonListBox.ItemsSource = null;
        }
    }
}
