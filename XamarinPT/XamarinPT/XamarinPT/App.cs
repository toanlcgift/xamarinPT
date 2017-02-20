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
            // The root page of your application
            var content = new ContentPage
            {
                Title = "XamarinPT",
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms!"
                        }
                    }
                }
            };

            MainPage = new NavigationPage(content);
        }

        protected override async void OnStart()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(XamarinPT.Resources.EMBEDDED_KANJI_DB);
            var file = await FileSystem.Current.LocalStorage.CreateFileAsync(XamarinPT.Resources.DB_NAME, CreationCollisionOption.ReplaceExisting);
            Stream str = await file.OpenAsync(FileAccess.ReadAndWrite);
            await stream.CopyToAsync(str);
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
