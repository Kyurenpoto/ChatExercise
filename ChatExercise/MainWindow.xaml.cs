﻿using MahApps.Metro;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Media;

namespace ChatExercise
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            System.Tuple<AppTheme, Accent> theme =
                ThemeManager.DetectAppStyle(Application.Current);

            ThemeManagerHelper.CreateAppStyleBy(Colors.Black, true);

            AppTheme basedark = ThemeManager.GetAppTheme("BaseDark");

            ThemeManager.ChangeAppStyle(this, theme.Item2, newTheme: basedark);
        }
    }
}
