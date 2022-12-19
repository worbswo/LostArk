using LostArkAction.Code;
using LostArkAction.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http.viewModel
{
    public class AccessoriesVM :ViewModelBase
    {
        #region Field
        private List<string> _characteristics;

        #endregion
        #region Property

        public List<string> Characteristics
        {
            get
            {
                if (_characteristics == null)
                {
                    _characteristics = new List<string>
                    {
                        "치명","특화","제압","신속","인내","숙련"
                    };

                }
                return _characteristics;
            }
        }



        #endregion

        #region Constroctor
        public AccessoriesVM()
        {


        }
        #endregion

        #region Method

        internal void Close(bool isClosing = false)
        {
            if (!isClosing)
            {
            }
        }
        #endregion
    }
}
