using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LostArkAction.Code
{
    public class RelayCommand : ICommand
    {
        #region Field
        Action<object> _executeMethod;
        Predicate<object> _canexecuteMethod;
        Action<object, object> _executeEventMethod;
        Action<object, object, object> _executeEventParamMethod;
        #endregion

        #region Consturctor
        /// <summary>
        ///executeMethod가 항상 실행 가능하도록 Command 생성
        /// </summary>
        /// <param name="executeMethod"> 실행 함수</param>
        public RelayCommand(Action<object> executeMethod)
         : this(executeMethod, null)
        {

        }
        /// <summary>
        /// Command 생성
        /// </summary>
        /// <param name="executeMethod"> 실행 함수</param>
        /// <param name="canexecuteMethod"> 실행 상태 함수</param>
        /// <exception cref="ArgumentNullException"></exception>
        public RelayCommand(Action<object> executeMethod, Predicate<object> canexecuteMethod)
        {
            if (executeMethod == null)
                throw new ArgumentNullException("executeMethod");
            _executeMethod = executeMethod;
            _canexecuteMethod = canexecuteMethod;
        }
        /// <summary>
        /// Event Command 생성
        /// </summary>
        /// <param name="executeMethod"> event를 포함한 실행 함수</param>
        /// <param name="canexecuteMethod">실행 상태 함수</param>
        /// <exception cref="ArgumentNullException">executeMethod가 null일 때 예외처리</exception>
        public RelayCommand(Action<object, object> executeMethod, Predicate<object> canexecuteMethod)
        {
            if (executeMethod == null)
                throw new ArgumentNullException("executeMethod");
            _executeEventMethod = executeMethod;
            _canexecuteMethod = canexecuteMethod;
        }
        /// <summary>
        /// Event + CommandParameter Command 생성
        /// </summary>
        /// <param name="executeMethod">Event와 CommandParameter가 포함된 실행 함수</param>
        /// <param name="canexecuteMethod"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public RelayCommand(Action<object, object, object> executeMethod, Predicate<object> canexecuteMethod)
        {
            if (executeMethod == null)
                throw new ArgumentNullException("executeMethod");
            _executeEventParamMethod = executeMethod;
            _canexecuteMethod = canexecuteMethod;
        }
        #endregion

        #region Event
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion

        #region Method
        public bool CanExecute(object parameter)
        {
            return _canexecuteMethod == null ? true : _canexecuteMethod(parameter);
        }

        /// <summary>
        /// Event 여부와 CommandParameter 여부에 따라서 다른 실행함수에 배치
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (_executeMethod != null)
            {
                _executeMethod(parameter);
            }
            else if (_executeEventMethod != null)
            {
                _executeEventMethod((parameter as object[])[0], (parameter as object[])[1]);
            }
            else if (_executeEventParamMethod != null)
            {
                _executeEventParamMethod((parameter as object[])[0], (parameter as object[])[1], (parameter as object[])[2]);
            }
        }

        #endregion

    }
}
