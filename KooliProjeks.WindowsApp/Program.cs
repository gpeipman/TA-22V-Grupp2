using KooliProjeks.WindowsApp;
using KooliProjektMVP.shared.ApiClient;
using KooliProjektMVP.shared.Presenter;

namespace KooliProjektMVP
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var form = new EventForm();
            var client = new EventApiClient();
            new EventPresenter(form, client);

            Application.Run(form);
        }
    }
}