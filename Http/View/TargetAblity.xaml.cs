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
    /// Ablity.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TargetAblity : UserControl
    {
        public TargetAblity()
        {

            InitializeComponent();
            init(Combo1);
            init(Combo2);
            init(Combo3);
            init(Combo4);
            init(Combo5);
            init(Combo6);
            init(Combo7);

        }

        private void Combo1_KeyUp(object sender, KeyEventArgs e)
        {

        }
        private void init(ComboBox comboBox)
        {
            comboBox.IsDropDownOpen = true;

            comboBox.Items.Filter = ((o) =>
            {
                string sValue = string.Empty;
                if (o is string)
                {
                    sValue = o.ToString();
                }
                else if (o is ComboBoxItem)
                {
                    System.Reflection.PropertyInfo info = o.GetType().GetProperty(comboBox.DisplayMemberPath);
                    if (info != null)
                    {
                        object oValue = info.GetValue(o, null);
                        if (oValue != null)
                        {
                            sValue = oValue.ToString();
                        }
                    }
                }
                if (!string.IsNullOrEmpty(sValue) && sValue.Contains(comboBox.Text)) return true;
                else return false;
            });
            comboBox.IsDropDownOpen = false;
            comboBox.Items.Filter = null;
            comboBox.SelectedIndex = -1;
        }
    }
}
