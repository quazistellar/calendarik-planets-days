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

namespace practice_test_wpf_1
{
    /// <summary>
    /// Логика взаимодействия для CalendarMain.xaml
    /// </summary>
    public partial class CalendarMain : Page
    {
        List<DaySelect> daySelects;


        public CalendarMain(DateTime? startDate = null)
        {
            InitializeComponent();

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
            return new DateTime(month.Year, month.Month, day);
        }


        private void UpdateDays()
        {
            DateTime month = Convert.ToDateTime(MonthSelect.Text);
            List<DayControl> cards = new List<DayControl>();
            int CountdaysInMonth = DateTime.DaysInMonth(month.Year, month.Month);

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

             
        }

        private void vpered_data_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = Convert.ToDateTime(MonthSelect.Text);
            date = date.AddMonths(+1);
            MonthSelect.Text = date.ToString();
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
            int index = chisla_month.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            int day = index + 1;
            DateTime date = GetToDay(day);
            swappage.Swap(new DayInfoPage(date));
        }

        //спасибо что работает это для контекстного меню чтоб лкм не ломалось
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
    }
}
