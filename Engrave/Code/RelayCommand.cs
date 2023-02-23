using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LostAblity.Code
{
    class RelayCommand : ICommand
    {
        Action<object> _executeMethod;
        Predicate<object> _canexecuteMethod;
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

        public event EventHandler CanExecuteChanged;


        #endregion

        #region Event

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
  
                _executeMethod(parameter);
            
            
        }

        #endregion
    }
}
