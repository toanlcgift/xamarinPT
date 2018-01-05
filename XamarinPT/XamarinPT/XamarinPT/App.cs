using PCLStorage;
using System.IO;
using System.Reflection;

using Xamarin.Forms;

namespace XamarinPT
{
    public class App : Application
    {
        public App()
        {
            MainPage = new Page() ;
        }

        protected override async void OnStart()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(XamarinPT.Resources.EMBEDDED_KANJI_DB);
            var file = await FileSystem.Current.LocalStorage.CreateFileAsync(XamarinPT.Resources.DB_NAME, CreationCollisionOption.ReplaceExisting);
            Stream str = await file.OpenAsync(FileAccess.ReadAndWrite);
            await stream.CopyToAsync(str);
            MainPage = new MainPage();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
