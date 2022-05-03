using System;
using Xamarin.Forms;

namespace DatePickerTester
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            SimpleDatePicker.MinimumDate = DateTime.UtcNow;
            SimpleDatePicker.MaximumDate = new DateTime(2023,12,10);

            //SimpleDatePicker.MaximumYear = 2022;

            //SimpleDatePicker.SetDate(DateTime.UtcNow);

            //SimpleDatePicker.SetDate(DateTime.UtcNow);

            //StDatePicker.YearItemsSource = DateUtil.GetYears();
        }

        private void SimpleDatePicker_OnDateSelected(object sender, EventArgs e)
        {
            DateLabel.Text = SimpleDatePicker.GetDate().GetValueOrDefault().ToShortDateString();
        }

        private void ClearBtn_OnClicked(object sender, EventArgs e)
        {
            SimpleDatePicker.ClearDate();
        }
    }
}
