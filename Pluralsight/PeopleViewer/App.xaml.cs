using PeopleViewer.Presentation;
using PersonRepository.Caching;
using PersonRepository.Service;
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

            var wrappedRepository = new ServiceRepository();
            var repository = new CachingRepository(wrappedRepository);
            var viewModel = new PeopleViewModel(repository);

            Application.Current.MainWindow = new MainWindow(viewModel);
            Application.Current.MainWindow.Show();
        }
    }
}
