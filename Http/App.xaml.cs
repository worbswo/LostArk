using LostArkAction.View;
using LostArkAction.viewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
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
        private static DownloadProgress DownloadProgress;

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
            WebClient Update = new WebClient();
            Update.DownloadProgressChanged += webClient_DownloadProgressChanged;
            Update.DownloadFileCompleted += webClient_DownloadFileCompleted;

            Uri UpgradeUri = new Uri("https://onedrive.live.com/download?cid=E0C2B3D1108565EA&resid=E0C2B3D1108565EA%2111321&authkey=AH35XOVsmpGVi-M");
            List<string> list = new List<string>();
            try
            {
                Stream aa = Update.OpenRead(UpgradeUri);
                StreamReader reader = new StreamReader(aa);
                string text = reader.ReadToEnd();
                list = text.Split('\n').ToList();
                list[0] = list[0].Split('\r').ToList()[0];
                list[1] = list[1].Split('\r').ToList()[0];

            }
            catch (WebException ex)

            {

                MessageBox.Show("BMTUpdate" + "Download WebException" + ex.Message);

            }

            catch (UriFormatException ex)

            {
                MessageBox.Show("BMTUpdate" + "Download UriFormatException" + ex.Message);


            }

            catch (Exception ex)
            {
                MessageBox.Show("BMTUpdate" + "Download Exception" + ex.Message);
            }



            if (list.Count > 0)
            {
                if (list[0] != "version 2.1.1")
                {

                    if (MessageBox.Show("새 버전 " + list[0] + " 이 발견되었습니다. 설치하겠습니까?", "Yes-No", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        string updatestr = "업데이트 내역 - \n";
                        for (int i = 3; i < list.Count; i++)
                        {
                            updatestr += list[i] + "\n";
                        }
                        MessageBox.Show(updatestr);
                        DownloadProgress = new DownloadProgress();
                        DownloadProgress.DataContext = new DownloadProgressVM();
                        DownloadProgress.Show();
                        Uri UpgradeUri2 = new Uri(list[2]);
                        Update.DownloadFileAsync(UpgradeUri2, list[1]);
                    }
                    else
                    {
                        base.OnStartup(e);

                        MainWindow main = new MainWindow();
                        main.DataContext = new MainWinodwVM();
                        main.Closing += (o, c) =>
                        {
                            (main.DataContext as MainWinodwVM).Close();
                        };
                        main.Show();
                        (main.DataContext as MainWinodwVM).SetEngraveText(true);
                    }
                }
                else
                {
                    base.OnStartup(e);

                    MainWindow main = new MainWindow();
                    main.DataContext = new MainWinodwVM();
                    main.Closing += (o, c) =>
                    {
                        (main.DataContext as MainWinodwVM).Close();
                    };
                    main.Show();
                    (main.DataContext as MainWinodwVM).SetEngraveText(true);
                }
            }
            else
            {
                base.OnStartup(e);

                MainWindow main = new MainWindow();
                main.DataContext = new MainWinodwVM();
                main.Closing += (o, c) =>
                {
                    (main.DataContext as MainWinodwVM).Close();
                };
                main.Show();
                (main.DataContext as MainWinodwVM).SetEngraveText(true);
            }   
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
        private static void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            string message = string.Format
            (
                "다운로드 : {0}/{1} Byte",
                e.BytesReceived,
                e.TotalBytesToReceive
            );
            (DownloadProgress.DataContext as DownloadProgressVM).ProgressBar = e.ProgressPercentage;
            (DownloadProgress.DataContext as DownloadProgressVM).Data = message;
            Console.WriteLine(message);
        }


        /// <summary>
        /// 웹 클라이언트 파일 다운로드 완료시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private static void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("다운로드 완료");
            Environment.Exit(0);

        }
    }
}
