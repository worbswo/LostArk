using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace LostArkAction.Code
{
    public class CommandBehavior
    {

        /// <summary>
        /// 이벤트 첨부 속성
        /// </summary>
        public static readonly DependencyProperty EventProperty = DependencyProperty.RegisterAttached("Event", typeof(string), typeof(CommandBehavior), new PropertyMetadata(EventPropertyChangedCallback));
        /// <summary>
        /// 명령 속성
        /// </summary>
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(CommandBehavior), new PropertyMetadata(CommandPropertyChangedCallback));
        /// <summary>
        /// CommandParameter 속성
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(CommandBehavior), new PropertyMetadata(CommandParamterPropertyChangedCallback));




        /// <summary>
        /// 이벤트명 구하기
        /// </summary>
        /// <param name="d">의존 객체</param>
        /// <returns>이벤트명</returns>
        public static string GetEvent(DependencyObject d)
        {
            return d.GetValue(EventProperty) as string;
        }

        /// <summary>
        /// 이벤트명 설정하기
        /// </summary>
        /// <param name="d">의존 객체</param>
        /// <param name="eventName">이벤트명</param>
        public static void SetEvent(DependencyObject d, string eventName)
        {
            d.SetValue(EventProperty, eventName);
        }



        /// <summary>
        /// Command 반환
        /// </summary>
        /// <param name="d">의존 객체</param>
        /// <returns>Command</returns>
        public static ICommand GetCommand(DependencyObject d)
        {
            return d.GetValue(CommandProperty) as ICommand;
        }



        /// <summary>
        /// Command 설정
        /// </summary>
        /// <param name="d">의존 객체</param>
        /// <param name="command">Command</param>
        public static void SetCommand(DependencyObject d, ICommand command)
        {
            d.SetValue(CommandProperty, command);
        }

        /// <summary>
        /// commandParater 반환 
        /// </summary>
        /// <param name="d">의존 객체</param>
        /// <returns>commandParater</returns>
        public static object GetCommandParamter(DependencyObject d)
        {
            return d.GetValue(CommandParameterProperty) as object;
        }



        /// <summary>
        /// commandParater 설정
        /// </summary>
        /// <param name="d">의존 객체</param>
        /// <param name="commandParater">commandParater</param>
        public static void SetCommandParameter(DependencyObject d, object commandParater)
        {
            d.SetValue(CommandParameterProperty, commandParater);
        }

        /// <summary>
        /// 이벤트 속성 변경시 콜백 처리
        /// </summary>
        /// <param name="d">의존 객체</param>
        /// <param name="e">이벤트 인자</param>
        private static void EventPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BindEvent(d, e.NewValue as string);
        }

        /// <summary>
        /// 명령 속성 변경시 콜백 처리
        /// </summary>
        /// <param name="d">의존 객체</param>
        /// <param name="e">이벤트 인자</param>
        private static void CommandPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        /// <summary>
        /// CommandParameter 변경시 콜백 처리
        /// </summary>
        /// <param name="d">의존 객체</param>
        /// <param name="e">이벤트 인자</param>
        private static void CommandParamterPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }


        /// <summary>
        /// 이벤트 바인딩
        /// </summary>
        /// <param name="owner">소유자 객체</param>
        /// <param name="eventName">이벤트명</param>
        private static void BindEvent(DependencyObject owner, string eventName)
        {
            if (string.IsNullOrWhiteSpace(eventName))
            {
                return;
            }

            EventInfo eventInfo = owner.GetType().GetEvent(eventName, BindingFlags.Public | BindingFlags.Instance);

            if (eventInfo == null)
            {
                throw new InvalidOperationException(string.Format("Could not resolve event name {0}", eventName));
            }

            MethodInfo targetMethod = typeof(CommandBehavior).GetMethod("EventHandler", BindingFlags.NonPublic | BindingFlags.Instance);

            if (targetMethod == null)
            {
                Debug.Assert(false, string.Format("invalid method type. type = {0}", eventName));

                return;
            }

            Delegate eventHandler = Delegate.CreateDelegate(eventInfo.EventHandlerType, null, targetMethod);
            eventInfo.AddEventHandler(owner, eventHandler);
        }

        /// <summary>
        /// 이벤트 핸들러 처리
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void EventHandler(object sender, EventArgs e)
        {
            DependencyObject d = sender as DependencyObject;

            if (d == null)
            {
                return;
            }

            ICommand command = d.GetValue(CommandProperty) as ICommand;

            if (command == null)
            {
                return;
            }

            if (command.CanExecute(null) == false)
            {
                return;
            }
            if (e == null)
            {
                command.Execute(sender);

            }
            else if ((d.GetValue(CommandParameterProperty) as object) == null)
            {
                object[] objects = new object[2];
                objects[0] = sender;
                objects[1] = e as object;
                command.Execute(objects);

            }
            else
            {
                object[] objects = new object[3];
                objects[0] = sender;
                objects[1] = e as object;
                objects[2] = d.GetValue(CommandParameterProperty) as object;
                command.Execute(objects);
            }
        }
    }
}
