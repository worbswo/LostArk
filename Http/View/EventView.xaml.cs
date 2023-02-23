using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LostArkAction.View
{
    /// <summary>
    /// EventView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EventView : UserControl
    {
        private const string DATA_FORMAT = "EmployeeDataFormat";

        /// <summary>
        /// 드래그 여부
        /// </summary>
        private bool isDragging = false;

        /// <summary>
        /// 드래그 인덱스
        /// </summary>
        private int dragIndex = -1;

        public EventView()
        {
            InitializeComponent();
            this.events.PreviewMouseLeftButtonDown += listView_PreviewMouseLeftButtonDown;
            this.events.PreviewMouseMove += listView_PreviewMouseMove;
            this.events.Drop += listView_Drop;
            this.events.DragOver += listView_DragOver;
        }
        #region 리스트 뷰 마우스 왼쪽 버튼 DOWN PREVIEW 처리하기 - listView_PreviewMouseLeftButtonDown(sender, e)

        /// <summary>
        /// 리스트 뷰 마우스 왼쪽 버튼 DOWN PREVIEW 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void listView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListView listView = sender as ListView;

            Point mousePoint = e.GetPosition(listView);

            IInputElement inputElement = listView.InputHitTest(mousePoint);

            ListViewItem item = FindAncestor<ListViewItem>(inputElement as DependencyObject);

            if (item != null)
            {
                this.isDragging = true;
            }
        }

        #endregion
        #region 리스트 뷰 마우스 이동시 PREVIEW 처리하기 - listView_PreviewMouseMove(sender, e)

        /// <summary>
        /// 리스트 뷰 마우스 이동시 PREVIEW 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void listView_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (this.isDragging && e.LeftButton == MouseButtonState.Pressed)
            {
                ListView listView = sender as ListView;

                ListViewItem listViewItem = FindAncestor<ListViewItem>(e.OriginalSource as DependencyObject);

                if (listViewItem == null)
                {
                    return;
                }

                this.dragIndex = listView.Items.IndexOf(listViewItem.Content);

                DataObject dataObject = new DataObject(DATA_FORMAT, listViewItem.Content);

                DragDrop.DoDragDrop(listViewItem, dataObject, DragDropEffects.Move);
            }
        }

        #endregion
        #region 리스트 뷰 DROP 처리하기 - listView_Drop(sender, e)

        /// <summary>
        /// 리스트 뷰 DROP 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void listView_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DATA_FORMAT))
            {
                ListView listView = sender as ListView;

                Point mousePoint = e.GetPosition(listView);

                IInputElement inputElement = listView.InputHitTest(mousePoint);

                ListViewItem item = FindAncestor<ListViewItem>(inputElement as DependencyObject);

                int itemIndex = -1;

                if (item == null)
                {
                    itemIndex = listView.Items.Count - 1;
                }
                else
                {
                    itemIndex = listView.Items.IndexOf(item.Content);
                }

                object content = e.Data.GetData(DATA_FORMAT);

                listView.Items.RemoveAt(dragIndex);

                if ((dragIndex < itemIndex) && (item != null))
                {
                    itemIndex--;
                }

                listView.Items.Insert(itemIndex, content);

                listView.Items.Refresh();

                this.dragIndex = -1;

                this.isDragging = false;
            }
        }

        #endregion
        #region 리스트 뷰 DRAG OVER 처리하기 - listView_DragOver(sender, e)

        /// <summary>
        /// 리스트 뷰 DRAG OVER 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void listView_DragOver(object sender, System.Windows.DragEventArgs e)
        {
            System.Windows.Controls.ListView listView = sender as System.Windows.Controls.ListView;

            ScrollViewer scrollViewer = FindChild<ScrollViewer>(listView);

            double tolerance = 10;
            double mouseY = e.GetPosition(listView).Y;
            double offset = 1;

            if (mouseY < tolerance)
            {
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - offset);
            }
            else if (mouseY > listView.ActualHeight - tolerance)
            {
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + offset);
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////// Function

        #region 조상 찾기 - FindAncestor<TAncestor>(dependencyObject)

        /// <summary>
        /// 조상 찾기
        /// </summary>
        /// <typeparam name="TAncestor">조상 타입</typeparam>
        /// <param name="dependencyObject">의존 객체</param>
        /// <returns>조상 객체</returns>
        private static TAncestor FindAncestor<TAncestor>(DependencyObject dependencyObject) where TAncestor : DependencyObject
        {
            DependencyObject current = dependencyObject;

            do
            {
                if (current is TAncestor)
                {
                    return (TAncestor)current;
                }

                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);

            return null;
        }

        #endregion
        #region 자식 찾기 - FindChild<TChilde>(dependencyObject)

        /// <summary>
        /// 자식 찾기
        /// </summary>
        /// <typeparam name="TChild">자식 타입</typeparam>
        /// <param name="dependencyObject">의존 객체</param>
        /// <returns>자식 객체</returns>
        private static TChild FindChild<TChild>(DependencyObject dependencyObject) where TChild : DependencyObject
        {
            int childCount = VisualTreeHelper.GetChildrenCount(dependencyObject);

            for (int i = 0; i < childCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(dependencyObject, i);

                if (child != null && child is TChild)
                {
                    return (TChild)child;
                }
                else
                {
                    TChild grandChild = FindChild<TChild>(child);

                    if (grandChild != null)
                    {
                        return grandChild;
                    }
                }
            }

            return null;
        }
        #endregion

    }
}
