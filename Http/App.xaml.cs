using Http.View;
using Http.viewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Http
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow main = new MainWindow();
            main.DataContext = new MainWinodwVM();
            main.Closing += (o, c) =>
            {
                (main.DataContext as MainWinodwVM).Close();
            };
            main.Show();
        }
    }
}
