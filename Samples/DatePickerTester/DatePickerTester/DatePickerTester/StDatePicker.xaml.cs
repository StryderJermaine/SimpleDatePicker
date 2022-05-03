using System;
using System.Collections;
using System.Collections.Generic;
using Acr.UserDialogs;
using SimpleDatePicker.Utils;
using Syncfusion.XForms.ComboBox;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace DatePickerTester
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StDatePicker : ContentView
	{
		public static readonly BindableProperty YearItemsSourceProperty =
			BindableProperty.Create("YearItemsSource", typeof(IList), typeof(StDatePicker), default(IList));

		//public static readonly BindableProperty YearTitleProperty =
		//    BindableProperty.Create("YearTitle", typeof(string), typeof(StDatePicker), default(string));

		//public static readonly BindableProperty MonthTitleProperty =
		//    BindableProperty.Create("MonthTitle", typeof(string), typeof(StDatePicker), default(string));

		//public static readonly BindableProperty DayTitleProperty =
		//    BindableProperty.Create("DayTitle", typeof(string), typeof(StDatePicker), default(string));

		public static readonly BindableProperty MonthItemsSourceProperty =
			BindableProperty.Create("MonthItemsSource", typeof(IList), typeof(StDatePicker), default(IList));

		public static readonly BindableProperty DayItemsSourceProperty =
			BindableProperty.Create("DayItemsSource", typeof(IList), typeof(StDatePicker), default(IList));

		public static readonly BindableProperty YearSelectedIndexProperty =
			BindableProperty.Create("YearSelectedIndex", typeof(int), typeof(StDatePicker), -1, BindingMode.TwoWay,
				propertyChanged: OnSelectedYearIndexChanged);

		public static readonly BindableProperty MonthSelectedIndexProperty =
			BindableProperty.Create("MonthSelectedIndex", typeof(int), typeof(StDatePicker), -1, BindingMode.TwoWay,
				propertyChanged: OnSelectedMonthIndexChanged);

		public static readonly BindableProperty DaySelectedIndexProperty =
			BindableProperty.Create("DaySelectedIndex", typeof(int), typeof(StDatePicker), -1, BindingMode.TwoWay,
				propertyChanged: OnSelectedDayIndexChanged);

		public static readonly BindableProperty YearSelectedItemProperty =
			BindableProperty.Create("YearSelectedItem", typeof(object), typeof(StDatePicker), null, BindingMode.TwoWay,
				propertyChanged: OnSelectedYearItemChanged);

		public static readonly BindableProperty MonthSelectedItemProperty =
			BindableProperty.Create("MonthSelectedItem", typeof(object), typeof(StDatePicker), null, BindingMode.TwoWay,
				propertyChanged: OnSelectedMonthItemChanged);

		public static readonly BindableProperty DaySelectedItemProperty =
			BindableProperty.Create("DaySelectedItem", typeof(object), typeof(StDatePicker), null, BindingMode.TwoWay,
				propertyChanged: OnSelectedDayItemChanged);

		public static readonly BindableProperty DateProperty =
			BindableProperty.Create("Date", typeof(DateTime), typeof(StDatePicker), DateTime.Today, BindingMode.TwoWay);

		//public static readonly BindableProperty DateSelectedProperty =
		//    BindableProperty.Create("DateSelected", typeof(EventHandler), typeof(StDatePicker), null, BindingMode.TwoWay, propertyChanged: OnDateSelected);

		public static readonly BindableProperty MonthComboBoxSourceProperty =
			BindableProperty.Create("MonthComboBoxSourceProperty", typeof(IList), typeof(StDatePicker), default(IList));

		public IList YearItemsSource
		{
			get => (IList)GetValue(YearItemsSourceProperty);
			set => SetValue(YearItemsSourceProperty, value);
		}

		public IList MonthItemsSource
		{
			get => (IList)GetValue(MonthItemsSourceProperty);
			set => SetValue(MonthItemsSourceProperty, value);
		}

		public IList DayItemsSource
		{
			get => (IList)GetValue(DayItemsSourceProperty);
			set => SetValue(DayItemsSourceProperty, value);
		}

		public IList MonthComboBoxSource
		{
			get => (IList)GetValue(MonthComboBoxSourceProperty);
			set => SetValue(MonthComboBoxSourceProperty, value);
		}

		//public string YearTitle
		//{
		//    get => (string)GetValue(YearTitleProperty);
		//    set => SetValue(YearTitleProperty, value);
		//}

		//public string MonthTitle
		//{
		//    get => (string)GetValue(MonthTitleProperty);
		//    set => SetValue(MonthTitleProperty, value);
		//}

		//public string DayTitle
		//{
		//    get => (string)GetValue(DayTitleProperty);
		//    set => SetValue(DayTitleProperty, value);
		//}

		public int YearSelectedIndex
		{
			get => (int)GetValue(YearSelectedIndexProperty);
			set => SetValue(YearSelectedIndexProperty, value);
		}

		public int MonthSelectedIndex
		{
			get => (int)GetValue(MonthSelectedIndexProperty);
			set => SetValue(MonthSelectedIndexProperty, value);
		}

		public int DaySelectedIndex
		{
			get => (int)GetValue(DaySelectedIndexProperty);
			set => SetValue(DaySelectedIndexProperty, value);
		}

		public object YearSelectedItem
		{
			get => (object)GetValue(YearSelectedItemProperty);
			set => SetValue(YearSelectedItemProperty, value);
		}

		public object MonthSelectedItem
		{
			get => (object)GetValue(MonthSelectedItemProperty);
			set => SetValue(MonthSelectedItemProperty, value);
		}

		public object DaySelectedItem
		{
			get => (object)GetValue(DaySelectedItemProperty);
			set => SetValue(DaySelectedItemProperty, value);
		}

		public DateTime Date
		{
			get => (DateTime)GetValue(DateProperty);
			set => SetValue(DateProperty, value);
		}

		//public EventHandler DateSelectedEvent
		//{
		//    get => (EventHandler)GetValue(DateSelectedProperty);
		//    set => SetValue(DateSelectedProperty, value);
		//}

		public IList<string> YearItems { get; } = new LockableObservableListWrapper();
		public IList<string> MonthItems { get; } = new LockableObservableListWrapper();
		public IList<string> DayItems { get; } = new LockableObservableListWrapper();

		public event EventHandler YearSelectedIndexChanged;

		public event EventHandler MonthSelectedIndexChanged;

		public event EventHandler DaySelectedIndexChanged;

		//public event EventHandler YearClicked;

		//public event EventHandler MonthClicked;

		//public event EventHandler DayClicked;

		//public event EventHandler YearFocused;

		//public event EventHandler YearUnfocused;

		//public event EventHandler MonthFocused;

		//public event EventHandler MonthUnfocused;

		//public event EventHandler DayFocused;

		public event EventHandler DateSelected;

		void UpdateSelectedYearIndex(object selectedItem)
		{
			if (YearItemsSource != null)
			{
				YearSelectedIndex = YearItemsSource.IndexOf(selectedItem);
				return;
			}
			YearSelectedIndex = YearItems.IndexOf(selectedItem);
		}

		void UpdateSelectedMonthIndex(object selectedItem)
		{
			if (MonthItemsSource != null)
			{
				MonthSelectedIndex = MonthItemsSource.IndexOf(selectedItem);
				return;
			}
			MonthSelectedIndex = MonthItems.IndexOf(selectedItem);
		}

		void UpdateSelectedDayIndex(object selectedItem)
		{
			if (DayItemsSource != null)
			{
				DaySelectedIndex = DayItemsSource.IndexOf(selectedItem);
				return;
			}
			DaySelectedIndex = DayItems.IndexOf(selectedItem);
		}

		void UpdateSelectedYearItem(int index)
		{
			if (index == -1)
			{
				YearSelectedItem = null;
				//YearTitle = "YYYY";
				YearLabel.Text = "Year";
				return;
			}

			if (YearItemsSource != null)
			{
				YearSelectedItem = YearItemsSource[index];
				YearLabel.Text = YearSelectedItem.ToString();

				SetDate();

				return;
			}

			YearSelectedItem = YearItems[index];

			// Reset Month and Day
			//MonthSelectedItem = null;
			//MonthSelectedIndex = -1;

			//DaySelectedItem = null;
			//DaySelectedIndex = -1;
			//DayItemsSource = null;
		}

		void UpdateSelectedMonthItem(int index)
		{
			try
			{
				if (YearSelectedItem == null)
				{
					MonthSelectedItem = null;
					MonthLabel.Text = "Month";
					UserDialogs.Instance.Toast("Select year first");

					return;
				}

				if (index == -1)
				{
					MonthSelectedItem = null;
					//MonthTitle = "MM";
					MonthLabel.Text = "Month";
					return;
				}

				if (MonthItemsSource != null)
				{
					MonthSelectedItem = MonthItemsSource[index];
					MonthLabel.Text = MonthSelectedItem.ToString();

					SetDate();

					//Reset Day
					if (DaySelectedItem != null && DayItemsSource != null)
					{
						if (Convert.ToInt32(DaySelectedItem) > DayItemsSource.Count)
						{
							DaySelectedItem = null;
							DaySelectedIndex = -1;
							DayLabel.Text = "Day";
						}
					}

					return;
				}

				MonthSelectedItem = MonthItems[index];
			}
			catch (Exception e)
			{
				var x = e.Message;
			}
		}

		void UpdateSelectedDayItem(int index)
		{


			if (MonthSelectedItem == null)
			{
				DaySelectedItem = null;
				DayLabel.Text = "Day";
				UserDialogs.Instance.Toast("Select month first");

				return;
			}

			if (index == -1)
			{
				DaySelectedItem = null;
				//DayTitle = "DD";
				DayLabel.Text = "Day";
				return;
			}

			if (DayItemsSource != null)
			{
				DaySelectedItem = DayItemsSource[index];
				DayLabel.Text = DaySelectedItem.ToString();

				SetDate();

				DateSelected?.Invoke(this, EventArgs.Empty);

				return;
			}

			DaySelectedItem = DayItems[index];
		}

		public static void OnSelectedYearIndexChanged(object bindable, object oldValue, object newValue)
		{
			var picker = (StDatePicker)bindable;
			picker.UpdateSelectedYearItem(picker.YearSelectedIndex);
			picker.YearSelectedIndexChanged?.Invoke(bindable, EventArgs.Empty);
		}

		public static void OnSelectedMonthIndexChanged(object bindable, object oldValue, object newValue)
		{
			var picker = (StDatePicker)bindable;
			picker.UpdateSelectedMonthItem(picker.MonthSelectedIndex);
			picker.MonthSelectedIndexChanged?.Invoke(bindable, EventArgs.Empty);
		}

		public static void OnSelectedDayIndexChanged(object bindable, object oldValue, object newValue)
		{
			var picker = (StDatePicker)bindable;
			picker.UpdateSelectedDayItem(picker.DaySelectedIndex);
			picker.DaySelectedIndexChanged?.Invoke(bindable, EventArgs.Empty);
		}

		static void OnSelectedYearItemChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var picker = (StDatePicker)bindable;
			picker.UpdateSelectedYearIndex(newValue);
		}

		static void OnSelectedMonthItemChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var picker = (StDatePicker)bindable;
			picker.UpdateSelectedMonthIndex(newValue);
		}

		static void OnSelectedDayItemChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var picker = (StDatePicker)bindable;
			picker.UpdateSelectedDayIndex(newValue);
		}

		//static void OnDateSelected(BindableObject bindable, object oldValue, object newValue)
		//{
		//    var picker = (StDatePicker)bindable;
		//    picker.DateSelectedEvent?.Invoke(bindable, EventArgs.Empty);
		//}

		public StDatePicker()
		{
			InitializeComponent();

			// ItemsSource
			YearPicker.SetBinding(SfComboBox.DataSourceProperty, new Binding("YearItemsSource", source: this));

			MonthPicker.SetBinding(SfComboBox.DataSourceProperty, new Binding("MonthItemsSource", source: this));

			DayPicker.SetBinding(SfComboBox.DataSourceProperty, new Binding("DayItemsSource", source: this));

			MonthPicker.SetBinding(SfComboBox.ComboBoxSourceProperty, new Binding("MonthComboBoxSourceProperty", source: this));

			// Title
			// DayPicker.SetBinding(Picker.TitleProperty, new Binding("DayTitle", source: this));

			// MonthPicker.SetBinding(Picker.TitleProperty, new Binding("MonthTitle", source: this));

			// YearPicker.SetBinding(Picker.TitleProperty, new Binding("YearTitle", source: this));

			// Selected Index
			YearPicker.SetBinding(SfComboBox.SelectedIndexProperty, new Binding("YearSelectedIndex", source: this));

			MonthPicker.SetBinding(SfComboBox.SelectedIndexProperty, new Binding("MonthSelectedIndex", source: this));

			DayPicker.SetBinding(SfComboBox.SelectedIndexProperty, new Binding("DaySelectedIndex", source: this));

			// Selected Item
			YearPicker.SetBinding(SfComboBox.SelectedItemProperty, new Binding("YearSelectedItem", source: this));

			MonthPicker.SetBinding(SfComboBox.SelectedItemProperty, new Binding("MonthSelectedItem", source: this));

			DayPicker.SetBinding(SfComboBox.SelectedItemProperty, new Binding("DaySelectedItem", source: this));

			// Events
			//DayPicker.SetBinding(SfComboBox., new Binding("", source: this));



			// Tap
			//      YearPicker.GestureRecognizers.Add(new TapGestureRecognizer
			//{
			//    Command = new Command(() => {
			//        YearClicked?.Invoke(this, EventArgs.Empty);
			//    })
			//});

			//MonthPicker.GestureRecognizers.Add(new TapGestureRecognizer
			//{
			//    Command = new Command(() => {
			//        MonthClicked?.Invoke(this, EventArgs.Empty);
			//    })
			//});

			//DayPicker.GestureRecognizers.Add(new TapGestureRecognizer
			//{
			//    Command = new Command(() => {
			//        DayClicked?.Invoke(this, EventArgs.Empty);
			//    })
			//});


			//YearItemsSource = DateUtil.GetDobYears();

			//MonthItemsSource = DateUtil.Months;
			MonthItemsSource = DateUtil.MonthNames;

			//MonthComboBoxSource = DateUtil.MonthNames;

			//DayItemsSource = DateUtil.GetDaysList();

			//MonthPicker.SelectedIndexChanged += MonthPicker_MonthSelecedIndexChanged;

			MonthPicker.SelectionChanged += MonthPicker_MonthSelectionChanged;

			//  YearTitle = "YYYY";

			//  MonthTitle = "MM";

			//   DayTitle = "DD";

			YearPicker.Focused += YearPicker_Focused;

			YearPicker.Unfocused += YearPicker_Unfocused;

			MonthPicker.Focused += MonthPicker_Focused;

			MonthPicker.Unfocused += MonthPicker_Unfocused;

			DayPicker.Focused += DayPicker_Focused;

			DayPicker.Unfocused += DayPicker_Unfocused;

			//DateSelected += DateSelectedEvent;

			// Initialize pickers
			//YearPicker.SelectedItem = DateUtil.GetDobYears()[0];
			//MonthPicker.SelectedItem = DateUtil.Months[0];
			//DayPicker.SelectedItem = DateUtil.GetDaysList()[0];
		}

		//private void MonthPicker_MonthSelectedIndexChanged(object sender, EventArgs e)
		//   private void MonthPicker_MonthSelectionChanged(object sender, EventArgs e)
		//   {
		//    if (MonthSelectedIndex != -1)
		//    {
		//        DayItemsSource = DateUtil.GetDays((string)MonthSelectedItem, Convert.ToInt32((string)YearSelectedItem));
		//       }
		//}

		private void MonthPicker_MonthSelectionChanged(object sender, EventArgs e)
		{
			try
			{
				if (MonthSelectedItem != null)
				{
					if (DayItemsSource == null)
					{
						//DayItemsSource = null;
						// DayItemsSource = DateUtil.GetDays((string)MonthSelectedItem, Convert.ToInt32((string)YearSelectedItem));

						var month = DateUtil.GetMonthIndex((string)MonthSelectedItem).ToString();

						DayItemsSource = DateUtil.GetDays(month, Convert.ToInt32((string)YearSelectedItem));
					}

				}
			}
			catch (Exception ex)
			{
				//
			}

		}

		public DateTime GetDate()
		{
			try
			{
				if (YearSelectedItem != null && MonthSelectedItem != null && DaySelectedItem != null)
				{
					return new DateTime(Convert.ToInt32(YearSelectedItem), Convert.ToInt32(MonthSelectedItem),
						Convert.ToInt32(DaySelectedItem));
				}

				return DateTime.Today;
			}
			catch (Exception e)
			{
				//Console.WriteLine(e);
				//throw;
				return DateTime.Today;
			}

		}

		public void SetDate(DateTime date)
		{
			try
			{
				YearSelectedItem = date.Year;
				YearSelectedIndex = YearItemsSource.IndexOf(date.Year);
				//YearTitle = date.Year.ToString();
				YearLabel.Text = date.Year.ToString();

				//MonthSelectedItem = date.Month;
				MonthSelectedItem = DateUtil.GetMonthName(date.Month);
				// MonthSelectedIndex = MonthItemsSource.IndexOf(date.Month);
				MonthSelectedIndex = MonthItemsSource.IndexOf(DateUtil.GetMonthName(date.Month));
				//MonthTitle = date.Month.ToString();
				//MonthLabel.Text = date.Month.ToString();
				MonthLabel.Text = DateUtil.GetMonthName(date.Month);

				DaySelectedItem = date.Day;
				if (DayItemsSource == null)
				{
					DayItemsSource = DateUtil.GetDays(date.Month.ToString(), date.Year);
				}
				DaySelectedIndex = DayItemsSource.IndexOf(date.Day);
				//DayTitle = date.Day.ToString();
				DayLabel.Text = date.Day.ToString();

				Date = date;
			}
			catch (Exception ex)
			{
				var x = ex.Message;
			}

		}

		protected void SetDate()
		{
			try
			{
				if (YearSelectedItem != null && MonthSelectedItem != null && DaySelectedItem != null)
				{
					int year = Convert.ToInt32(YearSelectedItem);
					//int month = Convert.ToInt32(MonthSelectedItem);
					int month = Convert.ToInt32(DateUtil.GetMonthIndex((string)MonthSelectedItem).ToString());
					int day = Convert.ToInt32(DaySelectedItem);

					var date = new DateTime(year, month, day);

					Date = date;
				}
			}
			catch (Exception e)
			{
				//Console.WriteLine(e);
				//throw;
			}

		}

		public void ClearDate()
		{
			YearSelectedItem = null;
			YearSelectedIndex = -1;

			MonthSelectedItem = null;
			MonthSelectedIndex = -1;

			DaySelectedItem = null;
			DaySelectedIndex = -1;

			Date = DateTime.Today;

			YearLabel.Text = "Year";

			MonthLabel.Text = "Month";

			DayLabel.Text = "Day";

			//   YearTitle = "YYYY";

			//   MonthTitle = "MM";

			//   DayTitle = "DD";
		}

		public void YearPicker_Focused(object sender, EventArgs e)
		{
			//  YearTitle = "Select Year";
		}

		public void YearPicker_Unfocused(object sender, EventArgs e)
		{
			//if (YearSelectedItem == null)
			//{
			//    YearTitle = "YYYY";
			//   }
		}

		public void MonthPicker_Focused(object sender, EventArgs e)
		{
			if (YearSelectedItem == null)
			{
				UserDialogs.Instance.Toast("Select a year first");

				MonthPicker.Unfocus();

				return;
			}

			//  MonthTitle = "Select Month";
		}

		public void MonthPicker_Unfocused(object sender, EventArgs e)
		{
			if (MonthSelectedItem == null)
			{
				//      MonthTitle = "MM";
			}
		}

		public void DayPicker_Focused(object sender, EventArgs e)
		{
			if (MonthSelectedItem == null)
			{
				UserDialogs.Instance.Toast("Select a month first");

				DayPicker.Unfocus();

				return;
			}

			//  DayTitle = "Select Day";
		}

		public void DayPicker_Unfocused(object sender, EventArgs e)
		{
			if (DaySelectedItem == null)
			{
				//      DayTitle = "DD";
			}
			else
			{
				if (YearSelectedItem != null && MonthSelectedItem != null && DaySelectedItem != null)
				{
					Date = new DateTime(Convert.ToInt32(YearSelectedItem), Convert.ToInt32(DateUtil.GetMonthIndex((string)MonthSelectedItem).ToString()),
						Convert.ToInt32(DaySelectedItem));
				}
			}
		}
	}
}