using SimpleDatePicker.Utils;
using Syncfusion.XForms.ComboBox;
using System;
using System.Collections;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleDatePicker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleDatePicker : ContentView
    {
        public static readonly BindableProperty YearItemsSourceProperty =
            BindableProperty.Create(nameof(YearItemsSource), typeof(IList), typeof(SimpleDatePicker));

        public static readonly BindableProperty MonthItemsSourceProperty =
            BindableProperty.Create(nameof(MonthItemsSource), typeof(IList), typeof(SimpleDatePicker));

        public static readonly BindableProperty DayItemsSourceProperty =
            BindableProperty.Create(nameof(DayItemsSource), typeof(IList), typeof(SimpleDatePicker));

        public static readonly BindableProperty YearSelectedIndexProperty =
            BindableProperty.Create(nameof(YearSelectedIndex), typeof(int), typeof(SimpleDatePicker), -1, BindingMode.TwoWay,
                propertyChanged: OnSelectedYearIndexChanged);

        public static readonly BindableProperty MonthSelectedIndexProperty =
            BindableProperty.Create(nameof(MonthSelectedIndex), typeof(int), typeof(SimpleDatePicker), -1, BindingMode.TwoWay,
                propertyChanged: OnSelectedMonthIndexChanged);

        public static readonly BindableProperty DaySelectedIndexProperty =
            BindableProperty.Create(nameof(DaySelectedIndex), typeof(int), typeof(SimpleDatePicker), -1, BindingMode.TwoWay,
                propertyChanged: OnSelectedDayIndexChanged);

        public static readonly BindableProperty SelectedYearProperty =
            BindableProperty.Create(nameof(SelectedYear), typeof(object), typeof(SimpleDatePicker), null, BindingMode.TwoWay,
                propertyChanged: OnSelectedYearItemChanged);

        public static readonly BindableProperty SelectedMonthProperty =
            BindableProperty.Create(nameof(SelectedMonth), typeof(object), typeof(SimpleDatePicker), null, BindingMode.TwoWay,
                propertyChanged: OnSelectedMonthItemChanged);

        public static readonly BindableProperty SelectedDayProperty =
            BindableProperty.Create(nameof(SelectedDay), typeof(object), typeof(SimpleDatePicker), null, BindingMode.TwoWay,
                propertyChanged: OnSelectedDayItemChanged);

        public static readonly BindableProperty DateProperty =
            BindableProperty.Create(nameof(Date), typeof(DateTime), typeof(SimpleDatePicker), DateTime.Today, BindingMode.TwoWay);

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(string), typeof(SimpleDatePicker), default(string), BindingMode.TwoWay);

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(SimpleDatePicker), default(string), BindingMode.TwoWay);

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(SimpleDatePicker), default(Color), BindingMode.TwoWay);

        public static readonly BindableProperty MinimumDateProperty =
            BindableProperty.Create(nameof(MinimumDate), typeof(DateTime?), typeof(SimpleDatePicker), null, BindingMode.TwoWay,
                propertyChanged: OnMinimumDateSelected);

        public static readonly BindableProperty MaximumDateProperty =
            BindableProperty.Create(nameof(MaximumDate), typeof(DateTime?), typeof(SimpleDatePicker), null, BindingMode.TwoWay,
                propertyChanged: OnMaximumDateSelected);

        public IList? YearItemsSource
        {
            get => (IList)GetValue(YearItemsSourceProperty);
            set => SetValue(YearItemsSourceProperty, value);
        }

        public IList? MonthItemsSource
        {
            get => (IList)GetValue(MonthItemsSourceProperty);
            set => SetValue(MonthItemsSourceProperty, value);
        }

        public IList? DayItemsSource
        {
            get => (IList)GetValue(DayItemsSourceProperty);
            set => SetValue(DayItemsSourceProperty, value);
        }

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

        public object? SelectedYear
        {
            get => (object)GetValue(SelectedYearProperty);
            set => SetValue(SelectedYearProperty, value);
        }

        public object? SelectedMonth
        {
            get => (object)GetValue(SelectedMonthProperty);
            set => SetValue(SelectedMonthProperty, value);
        }

        public object? SelectedDay
        {
            get => (object)GetValue(SelectedDayProperty);
            set => SetValue(SelectedDayProperty, value);
        }

        /// <summary>
        /// Gets/sets the font size of the picker label
        /// </summary>
        public string FontSize
        {
            get => (string)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        /// <summary>
        /// Gets/sets the font family of the picker label 
        /// </summary>
        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        /// <summary>
        /// Gets/sets the text color for the picker label
        /// </summary>
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        private DateTime? Date
        {
            get => (DateTime)GetValue(DateProperty);
            set => SetValue(DateProperty, value);
        }

        /// <summary>
        /// Gets/sets the lowest date selectable
        /// </summary>
        public DateTime? MinimumDate
        {
            get => (DateTime?)GetValue(MinimumDateProperty);
            set => SetValue(MinimumDateProperty, value);
        }

        /// <summary>
        /// Gets/sets the highest date selectable
        /// </summary>
        public DateTime? MaximumDate
        {
            get => (DateTime?)GetValue(MaximumDateProperty);
            set => SetValue(MaximumDateProperty, value);
        }

        public event EventHandler? YearSelectedIndexChanged;

        public event EventHandler? MonthSelectedIndexChanged;

        public event EventHandler? DaySelectedIndexChanged;

        /// <summary>
        /// Event raised after a date is selected
        /// </summary>
        public event EventHandler? DateSelected;

        private void UpdateSelectedYearIndex(object selectedItem)
        {
            if (YearItemsSource == null) return;

            YearSelectedIndex = YearItemsSource.IndexOf(selectedItem);
            return;
            //YearSelectedIndex = YearItems.IndexOf(selectedItem);
        }

        private void UpdateSelectedMonthIndex(object selectedItem)
        {
            if (MonthItemsSource == null) return;

            MonthSelectedIndex = MonthItemsSource.IndexOf(selectedItem);
            return;
            //MonthSelectedIndex = MonthItems.IndexOf(selectedItem);
        }

        private void UpdateSelectedDayIndex(object selectedItem)
        {
            if (DayItemsSource == null) return;

            DaySelectedIndex = DayItemsSource.IndexOf(selectedItem);
            return;
            //DaySelectedIndex = DayItems.IndexOf(selectedItem);
        }

        private void UpdateSelectedYearItem(int index)
        {
            if (index == -1)
            {
                SelectedYear = null;

                return;
            }

            if (YearItemsSource == null) return;

            SelectedYear = YearItemsSource[index];

            YearLabel.Text = SelectedYear.ToString();

            SetDate();

            //YearSelectedItem = YearItems?[index];
        }

        private void UpdateSelectedMonthItem(int index)
        {
            try
            {
                if (SelectedYear == null)
                {
                    SelectedMonth = null;

                    //Application.Current.MainPage.DisplayAlert("Date", "Select a year first", "Ok");

                    return;
                }

                if (index == -1)
                {
                    SelectedMonth = null;

                    return;
                }

                if (MonthItemsSource != null)
                {
                    SelectedMonth = MonthItemsSource[index];

                    MonthLabel.Text = SelectedMonth.ToString();

                    SetDate();

                    //Reset Day
                    if (SelectedDay != null && DayItemsSource != null)
                    {
                        if (Convert.ToInt32(SelectedDay) > DayItemsSource.Count)
                        {
                            SelectedDay = null;

                            DaySelectedIndex = -1;

                            DayLabel.Text = "Day";
                        }
                    }

                    return;
                }

                //MonthSelectedItem = MonthItems?[index];
            }
            catch (Exception)
            {
                //
            }
        }

        private void UpdateSelectedDayItem(int index)
        {
            if (SelectedMonth == null)
            {
                SelectedDay = null;

                //Application.Current.MainPage.DisplayAlert("Date", "Select a month first", "Ok");

                return;
            }

            if (index == -1)
            {
                SelectedDay = null;

                return;
            }

            if (DayItemsSource != null)
            {
                SelectedDay = DayItemsSource[index];

                DayLabel.Text = SelectedDay.ToString();

                SetDate();

                DateSelected?.Invoke(this, EventArgs.Empty);
            }

            //DaySelectedItem = DayItems?[index];
        }

        private void SetMinimumDate(DateTime? minimumDate)
        {
            if(minimumDate == null) return;

            MinimumDate = minimumDate;

            SetYearItems();
        }

        private void SetMaximumDate(DateTime? maximumDate)
        {
            if(maximumDate == null) return;

            MaximumDate = maximumDate;

            SetYearItems();
        }

        private void SetYearItems()
        {
            YearItemsSource = DateUtil.GetYears(MinimumDate.GetValueOrDefault().Year, MaximumDate.GetValueOrDefault().Year);

            MonthItemsSource = DateUtil.GetFilteredMonths(MinimumDate.GetValueOrDefault().Month);
        }

        public static void OnSelectedYearIndexChanged(object bindable, object oldValue, object newValue)
        {
            var picker = (SimpleDatePicker)bindable;
            picker.UpdateSelectedYearItem(picker.YearSelectedIndex);
            picker.YearSelectedIndexChanged?.Invoke(bindable, EventArgs.Empty);
        }

        public static void OnSelectedMonthIndexChanged(object bindable, object oldValue, object newValue)
        {
            var picker = (SimpleDatePicker)bindable;
            picker.UpdateSelectedMonthItem(picker.MonthSelectedIndex);
            picker.MonthSelectedIndexChanged?.Invoke(bindable, EventArgs.Empty);
        }

        public static void OnSelectedDayIndexChanged(object bindable, object oldValue, object newValue)
        {
            var picker = (SimpleDatePicker)bindable;
            picker.UpdateSelectedDayItem(picker.DaySelectedIndex);
            picker.DaySelectedIndexChanged?.Invoke(bindable, EventArgs.Empty);
        }

        public static void OnSelectedYearItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var picker = (SimpleDatePicker)bindable;
            picker.UpdateSelectedYearIndex(newValue);
        }

        public static void OnSelectedMonthItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var picker = (SimpleDatePicker)bindable;
            picker.UpdateSelectedMonthIndex(newValue);
        }

        public static void OnSelectedDayItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var picker = (SimpleDatePicker)bindable;
            picker.UpdateSelectedDayIndex(newValue);
        }
        
        public static void OnMinimumDateSelected(BindableObject bindable, object oldValue, object newValue)
        {
            var picker = (SimpleDatePicker)bindable;
            picker.SetMinimumDate(DateTime.Parse(newValue.ToString()));
        }

        public static void OnMaximumDateSelected(BindableObject bindable, object oldValue, object newValue)
        {
            var picker = (SimpleDatePicker)bindable;
            picker.SetMaximumDate(DateTime.Parse(newValue.ToString()));
        }


        public SimpleDatePicker()
        {
            InitializeComponent();

            // ItemsSource property binding
            YearPicker.SetBinding(SfComboBox.DataSourceProperty, new Binding(nameof(YearItemsSource), source: this));
            YearPicker.SetBinding(SfComboBox.ItemsSourceProperty, new Binding(nameof(YearItemsSource), source: this));
            YearPicker.SetBinding(SfComboBox.ComboBoxSourceProperty, new Binding(nameof(YearItemsSource), source: this));

            MonthPicker.SetBinding(SfComboBox.DataSourceProperty, new Binding(nameof(MonthItemsSource), source: this));
            MonthPicker.SetBinding(SfComboBox.ComboBoxSourceProperty, new Binding(nameof(MonthItemsSource), source: this));
            MonthPicker.SetBinding(SfComboBox.ItemsSourceProperty, new Binding(nameof(MonthItemsSource), source: this));

            DayPicker.SetBinding(SfComboBox.DataSourceProperty, new Binding(nameof(DayItemsSource), source: this));
            DayPicker.SetBinding(SfComboBox.ItemsSourceProperty, new Binding(nameof(DayItemsSource), source: this));
            DayPicker.SetBinding(SfComboBox.ComboBoxSourceProperty, new Binding(nameof(DayItemsSource), source: this));


            // Selected Index
            YearPicker.SetBinding(SfComboBox.SelectedIndexProperty, new Binding(nameof(YearSelectedIndex), source: this));

            MonthPicker.SetBinding(SfComboBox.SelectedIndexProperty, new Binding(nameof(MonthSelectedIndex), source: this));

            DayPicker.SetBinding(SfComboBox.SelectedIndexProperty, new Binding(nameof(DaySelectedIndex), source: this));
            // Selected Item
            YearPicker.SetBinding(SfComboBox.SelectedItemProperty, new Binding(nameof(SelectedYear), source: this));

            MonthPicker.SetBinding(SfComboBox.SelectedItemProperty, new Binding(nameof(SelectedMonth), source: this));

            DayPicker.SetBinding(SfComboBox.SelectedItemProperty, new Binding(nameof(SelectedDay), source: this));

            // Font Size property binding
            YearLabel.SetBinding(SfComboBox.TextSizeProperty, new Binding(nameof(FontSize), source: this));
            MonthLabel.SetBinding(SfComboBox.TextSizeProperty, new Binding(nameof(FontSize), source: this));
            DayLabel.SetBinding(SfComboBox.TextSizeProperty, new Binding(nameof(FontSize), source: this));

            // Font Family property binding
            YearLabel.SetBinding(Label.FontFamilyProperty, new Binding(nameof(FontFamily), source: this));
            MonthLabel.SetBinding(Label.FontFamilyProperty, new Binding(nameof(FontFamily), source: this));
            DayLabel.SetBinding(Label.FontFamilyProperty, new Binding(nameof(FontFamily), source: this));

            // Picker Text color property binding
            YearLabel.SetBinding(Label.TextColorProperty, new Binding(nameof(TextColor), source: this));
            MonthLabel.SetBinding(Label.TextColorProperty, new Binding(nameof(TextColor), source: this));
            DayLabel.SetBinding(Label.TextColorProperty, new Binding(nameof(TextColor), source: this));

            YearItemsSource = DateUtil.GetYears();

            //YearSelectedItem = DateTime.Now.Year;

            //MonthItemsSource = DateUtil.Months;
            MonthItemsSource = DateUtil.MonthNames;

            MonthPicker.SelectionChanged += MonthPicker_MonthSelectionChanged;

            YearPicker.SelectionChanged += YearPicker_SelectionChanged;

            //YearPicker.Focused += YearPicker_Focused;

            //YearPicker.Unfocused += YearPicker_Unfocused;

            //MonthPicker.Focused += MonthPicker_Focused;

            //MonthPicker.Unfocused += MonthPicker_Unfocused;

            //DayPicker.Focused += DayPicker_Focused;

            //DayPicker.Unfocused += DayPicker_Unfocused;

            //YearPicker.DropDownButtonSettings = new DropDownButtonSettings
            //{
            //   // BackgroundColor = Color.Green,
            //    FontColor = Color.Red,
            //    //HighlightedBackgroundColor = Color.Green,
            //    //HighlightFontColor = Color.Yellow,

            //};
        }

        private void MonthPicker_MonthSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (SelectedMonth == null) return;

                var year = Convert.ToInt32(SelectedYear?.ToString());

                var month = Convert.ToInt32(DateUtil.GetMonthIndex((string)SelectedMonth).ToString());

                if (MinimumDate != null && MaximumDate != null)
                {
                    ResetDay();

                    if (year == MinimumDate.Value.Year && month == MinimumDate.Value.Month)
                    {
                        ResetDay();

                        DayItemsSource = DateUtil.GetFilteredDays(DateUtil.GetMonthIndex(SelectedMonth.ToString()).ToString(), MinimumDate.Value.Day);
                    }
                    else if (year == MaximumDate.Value.Year && month == MaximumDate.Value.Month)
                    {
                        ResetDay();

                        DayItemsSource = DateUtil.GetFilteredDaysMax(DateUtil.GetMonthIndex(SelectedMonth.ToString()).ToString(), MaximumDate.Value.Day);
                    }
                    else if (year == MaximumDate.Value.Year && month < MaximumDate.Value.Month)
                    {
                        ResetDay();

                        DayItemsSource = DateUtil.GetDays(DateUtil.GetMonthIndex((string)SelectedMonth).ToString(),
                            Convert.ToInt32((string)SelectedYear!));
                    }
                    else if (year == MinimumDate.Value.Year && month > MinimumDate.Value.Month)
                    {
                        ResetDay();

                        DayItemsSource = DateUtil.GetDays(DateUtil.GetMonthIndex((string)SelectedMonth).ToString(),
                            Convert.ToInt32((string)SelectedYear!));
                    }
                    else if (year < MaximumDate.Value.Year)
                    {
                        ResetDay();

                        DayItemsSource = DateUtil.GetDays(DateUtil.GetMonthIndex((string)SelectedMonth).ToString(),
                            Convert.ToInt32((string)SelectedYear!));
                    }
                }
                else if (MinimumDate != null && MaximumDate == null)
                {
                    if (year > MinimumDate.Value.Year
                        || month > MinimumDate.Value.Month)
                    {
                        ResetDay();

                        DayItemsSource = DateUtil.GetDays(DateUtil.GetMonthIndex((string)SelectedMonth).ToString(),
                            Convert.ToInt32((string)SelectedYear!));
                    }
                    else
                    {
                        ResetDay();

                        DayItemsSource = DateUtil.GetFilteredDays(DateUtil.GetMonthIndex(SelectedMonth.ToString()).ToString(), MinimumDate.Value.Day);
                    }
                }
                else if (MinimumDate == null && MaximumDate != null)
                {
                    if (year == MaximumDate.Value.Year && month == MaximumDate.Value.Month)
                    {
                        ResetDay();

                        DayItemsSource = DateUtil.GetFilteredDaysMax(DateUtil.GetMonthIndex(SelectedMonth.ToString()).ToString(), MaximumDate.Value.Day);
                    }
                }
                else
                {
                    DayItemsSource = DateUtil.GetDays(DateUtil.GetMonthIndex((string)SelectedMonth).ToString(),
                        Convert.ToInt32((string)SelectedYear!));
                }
            }
            catch (Exception)
            {
                //
            }
        }

        private void YearPicker_SelectionChanged(object sender, EventArgs e)
        {
            if(SelectedYear == null) return;

            var year = Convert.ToInt32(SelectedYear.ToString());

            //if (MinimumDate == null) return;

            if (MinimumDate != null && MaximumDate != null)
            {
                ResetMonth();

                if (year < MaximumDate.Value.Year)
                {
                    MonthItemsSource = year > MinimumDate.Value.Year
                        ? DateUtil.MonthNames
                        : DateUtil.GetFilteredMonths(MinimumDate.Value.Month);
                }
                else
                {
                    MonthItemsSource = DateUtil.GetFilteredMonths(MaximumDate.Value.Month);
                }
            }
            else if (MinimumDate != null && MaximumDate == null)
            {
                ResetMonth();

                if (year > MinimumDate.Value.Year) MonthItemsSource = DateUtil.MonthNames;
            }
            else if (MinimumDate == null && MaximumDate != null)
            {
                ResetMonth();

                if (year == MaximumDate.Value.Year)
                    MonthItemsSource = DateUtil.GetFilteredMonths(MaximumDate.Value.Month);
            }
        }

        /// <summary>
        /// Gets the selected date
        /// </summary>
        /// <returns>A <see cref="DateTime"/></returns>
        public DateTime? GetDate() => Date;

        /// <summary>
        /// Sets the date
        /// </summary>
        /// <param name="date">The date to be set</param>
        public void SetDate(DateTime? date)
        {
            try
            {
                SelectedYear = date!.Value.Year;
                YearSelectedIndex = YearItemsSource!.IndexOf(date.Value.Year);
                //YearPickerTitle = date.Year.ToString();
                YearLabel.Text = date.Value.Year.ToString();


                //MonthSelectedItem = date.Month;
                SelectedMonth = DateUtil.GetMonthName(date.Value.Month);
                // MonthSelectedIndex = MonthItemsSource.IndexOf(date.Month);
                MonthSelectedIndex = MonthItemsSource!.IndexOf(DateUtil.GetMonthName(date.Value.Month));
                //MonthPickerTitle = DateUtil.GetMonthName(date.Month);
                //MonthLabel.Text = date.Month.ToString();
                MonthLabel.Text = DateUtil.GetMonthName(date.Value.Month);

                DayItemsSource ??= DateUtil.GetDays(date.Value.Month.ToString(), date.Value.Year);

                SelectedDay = date.Value.Day;

                DaySelectedIndex = DayItemsSource.IndexOf(date.Value.Day);

                //DayPickerTitle = date.Day.ToString();
                DayLabel.Text = date.Value.Day.ToString();

                Date = date;
            }
            catch (Exception)
            {
                //
            }
        }

        protected void SetDate()
        {
            try
            {
                if (SelectedYear == null || SelectedMonth == null || SelectedDay == null) return;

                Date = new DateTime(Convert.ToInt32(SelectedYear),
                    Convert.ToInt32(DateUtil.GetMonthIndex((string)SelectedMonth).ToString()),
                    Convert.ToInt32(SelectedDay));
            }
            catch (Exception)
            {
                //
            }
        }

        /// <summary>
        /// Clears the set date 
        /// </summary>
        public void ClearDate()
        {
            ResetYear();
            
            ResetMonth();

            ResetDay();

            Date = null;
        }

        //public void YearPicker_Focused(object sender, EventArgs e)
        //{
        //    //YearPicker.Title = YearTitle;
        //}

        //public void YearPicker_Unfocused(object sender, EventArgs e)
        //{
        //    YearLabel.Text = YearSelectedItem == null ? "Year" : YearSelectedItem.ToString();
        //}

        //public void MonthPicker_Focused(object sender, EventArgs e)
        //{
        //    if (YearSelectedItem != null) return;

        //    Application.Current.MainPage.DisplayAlert("Date", "Select a year first", "Ok");

        //    MonthPicker.Unfocus();

        //    //MonthPicker.Title = MonthTitle;
        //}

        //public void MonthPicker_Unfocused(object sender, EventArgs e)
        //{
        //    MonthLabel.Text = MonthSelectedItem == null ? "Month" : DateUtil.GetMonthName(Convert.ToInt32(MonthSelectedItem.ToString()));
        //}

        //public void DayPicker_Focused(object sender, EventArgs e)
        //{
        //    if (MonthSelectedItem != null) return;

        //    Application.Current.MainPage.DisplayAlert("Date", "Select a month first", "Ok");

        //    DayPicker.Unfocus();

        //    //DayPicker.Title = DayTitle;
        //}

        //public void DayPicker_Unfocused(object sender, EventArgs e)
        //{
        //    if (DaySelectedItem == null) return;

        //    if (YearSelectedItem != null && MonthSelectedItem != null && DaySelectedItem != null)
        //    {
        //        Date = new DateTime(Convert.ToInt32(YearSelectedItem), Convert.ToInt32(DateUtil.GetMonthIndex((string)MonthSelectedItem).ToString()),
        //            Convert.ToInt32(DaySelectedItem));
        //    }
        //}

        private void ResetDay()
        {
            SelectedDay = null;
            DaySelectedIndex = -1;
            DayLabel.Text = "Day";
        }
        
        private void ResetMonth()
        {
            SelectedMonth = null;
            MonthSelectedIndex = -1;
            MonthLabel.Text = "Month";
        }
        
        private void ResetYear()
        {
            SelectedYear = null;
            YearSelectedIndex = -1;
            YearLabel.Text = "Year";
        }
    }
}