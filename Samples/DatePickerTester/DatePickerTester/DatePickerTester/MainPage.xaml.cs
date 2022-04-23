using System;
using Xamarin.Forms;

namespace DatePickerTester
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            SimpleDatePicker.MinimumYear = 2010;

            SimpleDatePicker.MaximumYear = 2022;

            //SimpleDatePicker.Date = DateTime.UtcNow;

            //SimpleDatePicker.SetDate(DateTime.UtcNow);
        }

        private void SimpleDatePicker_OnDateSelected(object sender, EventArgs e)
        {
            DateLabel.Text = SimpleDatePicker.Date.GetValueOrDefault().ToShortDateString();
        }
    }
}
