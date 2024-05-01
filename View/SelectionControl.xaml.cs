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

namespace practice_test_wpf_1
{
    /// <summary>
    /// Логика взаимодействия для SelectionControl.xaml
    /// </summary>
    public partial class SelectionControl : UserControl
    {
        //выбор внутри карточки
        private Punct ikonka;
        public SelectionControl(Punct punct)
        {
            InitializeComponent();

            ikonka = punct;
            NameLabel.Content = punct.name;
            //это для иконок с пикчами
            PunctImage.Source = new BitmapImage(new Uri(punct.image, UriKind.Relative));

        }

       
    }
}
