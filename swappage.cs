using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace practice_test_wpf_1
{
    public class swappage
    {
        //навигация, смена страничек в окне, тоже для проверки интерфейса
        public static void Swap(Page page)
        {
            stranitca.Content = page;
        }
        public static Frame stranitca { get; set; }
    }
}
