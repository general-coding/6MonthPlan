using PeopleViewer.Presentation;
using PersonDataReader.Decorators;
using PersonDataReader.Service;
using System.Windows;

namespace PeopleViewer
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ComposeObjects();
            Current.MainWindow.Title = "With Dependency Injection";
            Current.MainWindow.Show();
        }

        private static void ComposeObjects()
        {
            //ServiceReader reader = new ServiceReader();

            //CSVReader reader = new CSVReader();

            //SQLReader reader = new SQLReader();

            ServiceReader wrapperReader = new ServiceReader();
            CachingReader reader = new CachingReader(wrapperReader);
            PeopleViewModel viewModel = new PeopleViewModel(reader);
            Current.MainWindow = new PeopleViewerWindow(viewModel);
        }
    }
}
