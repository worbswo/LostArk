using LostArkAction.View;
using LostArkAction.viewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace LostArkAction
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // 리소스 포함
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(ResolveAssembly);
            // 전역 예외 처리
            this.Dispatcher.UnhandledException += new DispatcherUnhandledExceptionEventHandler(DispatcherUnhandledException);
            this.Dispatcher.UnhandledExceptionFilter += new DispatcherUnhandledExceptionFilterEventHandler(DispatcherUnhandledExceptionFilter);
        }
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
        static Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            //AssemblyFile 이름
            var name = args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";
            //Load form Embedded Resources - This Function is not called if the Assembly is in the Application Folder
            var resources = thisAssembly.GetManifestResourceNames().Where(s => s.EndsWith(name));
            if (resources.Count() > 0)
            {
                var resourceName = resources.First();
                using (Stream stream = thisAssembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                    { return null; }
                    var block = new byte[stream.Length];
                    stream.Read(block, 0, block.Length);
                    return Assembly.Load(block);
                }
            }
            return null;
        }
        /// <summary>
		/// 디스패처 미처리 예외 필터 처리하기
		/// </summary>
		/// <param name="sender">이벤트 발생자</param>
		/// <param name="e">이벤트 인자</param>
		private void DispatcherUnhandledExceptionFilter(object sender, DispatcherUnhandledExceptionFilterEventArgs e)
        {
            // true를 설정하면 응용 프로그램이 비정상 종료되지 않으나 false를 설정하면 응용 프로그램이 비정상 종료된다.
            e.RequestCatch = true;
        }

        /// <summary>
        /// 디스패처 미처리 예외 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private new void DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            string errorMsg = string.Format("아래와 같이 예상치 않은 오류가 발생하였습니다.\n\n프로그램을 종료 하시겠습니까?\n\n{0}\n", e.Exception.Message);
            errorMsg += Environment.NewLine;
            MessageBoxResult result = MessageBox.Show(errorMsg, "오류발생", MessageBoxButton.OKCancel, MessageBoxImage.Stop);
            e.Handled = true;
            // Exits the program when the user clicks Abort.
            if (result == MessageBoxResult.OK)
            {
                Application.Current.MainWindow.Close();
            }
        }
    }
}
