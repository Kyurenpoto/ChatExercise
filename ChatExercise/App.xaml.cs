using MahApps.Metro;
using System;
using System.Windows;
using System.Windows.Media;

namespace ChatExercise
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            const string current_app = "pack://application:,,,/ChatExercise";
            const string custom_accent_1 = current_app +
                ";component/CustomThemes/CustomAccent1.xaml";
            const string custom_accent_2 = current_app +
                ";component/CustomThemes/CustomAccent2.xaml";
            const string custom_theme = current_app +
                ";component/CustomThemes/CustomTheme.xaml";

            ThemeManager.AddAccent("CustomAccent1", new Uri(custom_accent_1));
            ThemeManager.AddAccent("CustomAccent2", new Uri(custom_accent_2));
            ThemeManager.AddAppTheme("CustomTheme", new Uri(custom_theme));

            ThemeManagerHelper.CreateAppStyleBy(Color.FromArgb(0xff, 0x17, 0x17, 0x17), true);

            base.OnStartup(e);
        }
    }
}
