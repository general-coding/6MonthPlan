using PeopleViewer.Presentation;
using PersonRepository.CSV;
using System.Windows;

namespace PeopleViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var repository = new CSVRepository();
            var viewModel = new PeopleViewModel(repository);

            Application.Current.MainWindow = new MainWindow(viewModel);
        }
    }
}
