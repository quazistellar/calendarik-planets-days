using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
using System.Windows.Media.Animation;

namespace practice_test_wpf_1
{
    /// <summary>
    /// Логика взаимодействия для DayInfoPage.xaml
    /// </summary>
    public partial class DayInfoPage : Page
    {
        DateTime date;
        List<Punct> puncts;
        List<DaySelect> choice_day;

        string imagesFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Helpers", "Images");
        public DayInfoPage(DateTime date)
        {
            InitializeComponent();

            if (choice_day == null)
            {
                choice_day = new List<DaySelect>();
            }

            this.date = date;
            DateLabel.Content = date.ToLongDateString();
            LoadIcons();

        }

        private List<Punct> GetSelectedPuncts()
        {
            DaySelect daySelect = choice_day.Find((item) => item.date == date.ToString("dd.MM.yyyy"));
            if (daySelect == null)
            {
                return new List<Punct>();
            }

            return daySelect.puncts;
        }

        private List<Punct> GetAllPuncts(List<Punct> selected)
        {
            var puncts = new List<Punct>
            {
                selected.Find(item => item.name == "Луна") ?? new Punct("Луна", System.IO.Path.Combine(imagesFolder, "moon.png"), false),
                selected.Find(item => item.name == "Венера") ?? new Punct("Венера", System.IO.Path.Combine(imagesFolder, "venus.png"), false),
                selected.Find(item => item.name == "Юпитер") ?? new Punct("Юпитер", System.IO.Path.Combine(imagesFolder, "juptr.png"), false),
                selected.Find(item => item.name == "Сатурн") ?? new Punct("Сатурн", System.IO.Path.Combine(imagesFolder, "saturn.png"), false),
                selected.Find(item => item.name == "Марс") ?? new Punct("Марс", System.IO.Path.Combine(imagesFolder, "mars.png"), false),
                selected.Find(item => item.name == "Меркурий") ?? new Punct("Меркурий", System.IO.Path.Combine(imagesFolder, "mercury.png"), false)
            };

            return puncts;
        }

        private void LoadIcons()
        {
            List<Punct> selected = GetSelectedPuncts();
            puncts = GetAllPuncts(selected);

            List<SelectionControl> selections = new List<SelectionControl>();
            foreach (var punct in puncts)
            {
                selections.Add(new SelectionControl(punct));
            }
            PunctsList.ItemsSource = selections;
        }


        private void nazad_bez_save_Click(object sender, RoutedEventArgs e)
        {
            swappage.Swap(new CalendarMain(date));
        }

        private void nazad_save_Click(object sender, RoutedEventArgs e)
        {


            swappage.Swap(new CalendarMain(date));
        }
    }
}
