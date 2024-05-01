using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Media;

namespace practice_test_wpf_1
{
    /// <summary>
    /// Логика взаимодействия для CalendarMain.xaml
    /// </summary>
    public partial class CalendarMain : Page
    {
        List<DaySelect> daySelects;
        public MediaPlayer _mediaPlayer;


        //тут код чисто для проверки работы интерфейса

        public CalendarMain(DateTime? startDate = null)
        {
            InitializeComponent();

            _mediaPlayer = new MediaPlayer();

            if (daySelects == null)
            {
                daySelects = new List<DaySelect>();
            }

            if (startDate == null)
            {
                MonthSelect.Text = DateTime.Now.ToString();
            }

            else
            {
                MonthSelect.Text = startDate.ToString();
            }


        }
        private DateTime GetToDay(int day)
        {
            DateTime month = Convert.ToDateTime(MonthSelect.Text);
            int daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);
            if (day > daysInMonth)
            {
                day = daysInMonth;
            }
            return new DateTime(month.Year, month.Month, day);
        }


        private void UpdateDays()
        {
            DateTime month = Convert.ToDateTime(MonthSelect.Text);
            List<DayControl> cards = new List<DayControl>();

            //так как я делаю интерфейс, оставляю статичные 3 карточек
            int CountdaysInMonth = 30; 

            for (int i = 1; i <= CountdaysInMonth; i++)
            {
                DateTime date = GetToDay(i);
                DaySelect daySelect = daySelects.Find((item) => item.date == date.ToString("dd.MM.yyyy"));
                DayControl dayControl = new DayControl(date, daySelect);
                cards.Add(dayControl);
            }

            chisla_month.ItemsSource = cards;
        }

        private void MonthSelect_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime smena_data = Convert.ToDateTime(MonthSelect.Text);
            MonthLabel.Content = smena_data.ToString("MMMM, yyyy");
            UpdateDays();
        }
       
        private void nazad_data_Click(object sender, RoutedEventArgs e)
        {

            DateTime date = Convert.ToDateTime(MonthSelect.Text);
            date = date.AddMonths(-1);
            MonthSelect.Text = date.ToString();

            Color fromColor = ((SolidColorBrush)nazad_data.Background).Color;

            ColorAnimation animation = new ColorAnimation
            {
                From = fromColor,
                To = Colors.DeepPink,
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = true
            };

            nazad_data.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);


            ScaleTransform scaleTransform = new ScaleTransform();
            nazad_data.RenderTransform = scaleTransform;

            DoubleAnimation scaleAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 1.1,
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = true
            };

      
            scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimation);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimation);

        }

        private void vpered_data_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = Convert.ToDateTime(MonthSelect.Text);
            date = date.AddMonths(+1);
            MonthSelect.Text = date.ToString();

            Color fromColor = ((SolidColorBrush)vpered_data.Background).Color;

            ColorAnimation animation = new ColorAnimation
            {
                From = fromColor,
                To = Colors.DarkMagenta,
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = true
            };

            vpered_data.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        }

        private void chisla_month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = chisla_month.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            int day = index + 1;
            DateTime date = GetToDay(day);

            swappage.Swap(new DayInfoPage(date));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        //спасибо что работает это для контекстного меню чтоб ЛКМ не ломалось
        private void ListBoxItem_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                var listBoxItem = sender as ListBoxItem;

                if (listBoxItem != null)
                {
                    int index = chisla_month.SelectedIndex;

                    if (index == -1)
                    {
                        return;
                    }

                    int day = index + 1;
                    DateTime date = GetToDay(day);
                    swappage.Swap(new DayInfoPage(date));
                }
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            _mediaPlayer.Open(new Uri("C:\\Users\\User\\Desktop\\MEMES.mp3", UriKind.Absolute));
            _mediaPlayer.Play();

            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0,
                To = 360,
                Duration = TimeSpan.FromSeconds(17),
                RepeatBehavior = new RepeatBehavior(2) 
            };


            gg.CenterX = 45;
            gg.CenterY = 30;

      
            gg.BeginAnimation(RotateTransform.AngleProperty, animation);

   
            Task.Delay(TimeSpan.FromSeconds(10)).ContinueWith((task) =>
            {
                Dispatcher.Invoke(() =>
                {
                    gg.BeginAnimation(RotateTransform.AngleProperty, null);
                });
            });

  
            
        }
    }
}
