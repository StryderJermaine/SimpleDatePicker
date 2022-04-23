using SimpleDatePicker.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SimpleDatePicker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleDatePicker : ContentView
    {
        /*
         * Properties
         */
        public static readonly BindableProperty YearPickerTitleProperty =
            BindableProperty.Create(nameof(YearPickerTitle), typeof(string), typeof(SimpleDatePicker), default(string), BindingMode.TwoWay);

        public static readonly BindableProperty MonthPickerTitleProperty =
            BindableProperty.Create(nameof(MonthPickerTitle), typeof(string), typeof(SimpleDatePicker), default(string), BindingMode.TwoWay);

        public static readonly BindableProperty DayPickerTitleProperty =
            BindableProperty.Create("DayPickerTitle", typeof(string), typeof(SimpleDatePicker), default(string), BindingMode.TwoWay);


        /// <summary>
        /// Bindable property for the list of years for the Year Picker
        /// </summary>
        public static readonly BindableProperty YearItemsSourceProperty =
            BindableProperty.Create("YearItemsSource", typeof(IList), typeof(SimpleDatePicker), default(IList));

        public static readonly BindableProperty MonthItemsSourceProperty =
            BindableProperty.Create("MonthItemsSource", typeof(IList), typeof(SimpleDatePicker), default(IList));

        public static readonly BindableProperty DayItemsSourceProperty =
            BindableProperty.Create("DayItemsSource", typeof(IList), typeof(SimpleDatePicker), default(IList));

        public static readonly BindableProperty YearSelectedIndexProperty =
            BindableProperty.Create("YearSelectedIndex", typeof(int), typeof(SimpleDatePicker), -1, BindingMode.TwoWay,
                propertyChanged: OnSelectedYearIndexChanged);

        public static readonly BindableProperty MonthSelectedIndexProperty =
            BindableProperty.Create("MonthSelectedIndex", typeof(int), typeof(SimpleDatePicker), -1, BindingMode.TwoWay,
                propertyChanged: OnSelectedMonthIndexChanged);

        public static readonly BindableProperty DaySelectedIndexProperty =
            BindableProperty.Create("DaySelectedIndex", typeof(int), typeof(SimpleDatePicker), -1, BindingMode.TwoWay,
                propertyChanged: OnSelectedDayIndexChanged);

        public static readonly BindableProperty YearSelectedItemProperty =
            BindableProperty.Create("YearSelectedItem", typeof(object), typeof(SimpleDatePicker), null, BindingMode.TwoWay,
                propertyChanged: OnSelectedYearItemChanged);

        public static readonly BindableProperty MonthSelectedItemProperty =
            BindableProperty.Create("MonthSelectedItem", typeof(object), typeof(SimpleDatePicker), null, BindingMode.TwoWay,
                propertyChanged: OnSelectedMonthItemChanged);

        public static readonly BindableProperty DaySelectedItemProperty =
            BindableProperty.Create("DaySelectedItem", typeof(object), typeof(SimpleDatePicker), null, BindingMode.TwoWay,
                propertyChanged: OnSelectedDayItemChanged);

        public static readonly BindableProperty DateProperty =
            BindableProperty.Create(nameof(Date), typeof(DateTime), typeof(SimpleDatePicker), DateTime.Today, BindingMode.TwoWay);

        public static readonly BindableProperty MinimumDateProperty =
            BindableProperty.Create(nameof(Date), typeof(DateTime), typeof(SimpleDatePicker), DateTime.Today, BindingMode.TwoWay);

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(string), typeof(SimpleDatePicker), default(string), BindingMode.TwoWay);

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(SimpleDatePicker), default(string), BindingMode.TwoWay);

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(SimpleDatePicker), default(Color), BindingMode.TwoWay);

        public static readonly BindableProperty TitleColorProperty =
            BindableProperty.Create(nameof(TitleColor), typeof(Color), typeof(SimpleDatePicker), default(Color), BindingMode.TwoWay);

        public static readonly BindableProperty SeparatorColorProperty =
            BindableProperty.Create(nameof(SeparatorColor), typeof(Color), typeof(SimpleDatePicker), default(Color), BindingMode.TwoWay);

        public static readonly BindableProperty SeparatorProperty =
            BindableProperty.Create(nameof(Separator), typeof(string), typeof(SimpleDatePicker),
                default(string), BindingMode.TwoWay);

        public static readonly BindableProperty MinimumYearProperty =
            BindableProperty.Create(nameof(MinimumYear), typeof(int), typeof(SimpleDatePicker), default(int), BindingMode.TwoWay);
        
        public static readonly BindableProperty MaximumYearProperty =
            BindableProperty.Create(nameof(MaximumYear), typeof(int), typeof(SimpleDatePicker), default(int), BindingMode.TwoWay);

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

        public object? YearSelectedItem
        {
            get => (object)GetValue(YearSelectedItemProperty);
            set => SetValue(YearSelectedItemProperty, value);
        }

        public object? MonthSelectedItem
        {
            get => (object)GetValue(MonthSelectedItemProperty);
            set => SetValue(MonthSelectedItemProperty, value);
        }

        public object? DaySelectedItem
        {
            get => (object)GetValue(DaySelectedItemProperty);
            set => SetValue(DaySelectedItemProperty, value);
        }

        public string YearPickerTitle
        {
            get => (string)GetValue(YearPickerTitleProperty);
            set => SetValue(YearPickerTitleProperty, value);
        }

        public string MonthPickerTitle
        {
            get => (string)GetValue(MonthPickerTitleProperty);
            set => SetValue(MonthPickerTitleProperty, value);
        }

        public string DayPickerTitle
        {
            get => (string)GetValue(DayPickerTitleProperty);
            set => SetValue(DayPickerTitleProperty, value);
        }

        /// <summary>
        /// Gets/sets the font size of the text for all three pickers and the separators
        /// </summary>
        public string FontSize
        {
            get => (string)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        /// <summary>
        /// Gets/sets the font family of the text for all three pickers 
        /// </summary>
        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        /// <summary>
        /// Gets/sets the text color for all three pickers 
        /// </summary>
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        /// <summary>
        /// Gets/sets the title color for all three pickers 
        /// </summary>
        public Color TitleColor
        {
            get => (Color)GetValue(TitleColorProperty);
            set => SetValue(TitleColorProperty, value);
        }

        /// <summary>
        /// Gets/sets the color of the separators
        /// </summary>
        public Color SeparatorColor
        {
            get => (Color)GetValue(SeparatorColorProperty);
            set => SetValue(SeparatorColorProperty, value);
        }

        /// <summary>
		/// Gets/sets the separator type
		/// </summary>
        public string Separator
        {
            get => (string)GetValue(SeparatorProperty);
            set => SetValue(SeparatorProperty, value);
        }

        /// <summary>
        /// Gets/sets the minimum year date picker
        /// </summary>
        public int? MinimumYear
        {
            get => (int)GetValue(MinimumYearProperty);
            set => SetValue(MinimumYearProperty, value);
        }

        /// <summary>
        /// Gets/sets the minimum year date picker
        /// </summary>
        public int? MaximumYear
        {
            get => (int)GetValue(MaximumYearProperty);
            set => SetValue(MaximumYearProperty, value);
        }

        public string YearTitle { get; set; }

        public string MonthTitle { get; set; }

        public string DayTitle { get; set; }

        /// <summary>
        /// Get/sets the date
        /// </summary>
        public DateTime? Date
        {
            get => (DateTime)GetValue(DateProperty);
            set
            {
                SetValue(DateProperty, value);
                //SetDate(Date);
            }
        }

        /// <summary>
        /// Get/sets the minimum date
        /// </summary>
        public DateTime? MinimumDate
        {
            get => (DateTime)GetValue(MinimumDateProperty);
            set
            {
                SetValue(DateProperty, value);
            }
        }

        public IList<string>? YearItems { get; } = new LockableObservableListWrapper();
        public IList<string>? MonthItems { get; } = new LockableObservableListWrapper();
        public IList<string>? DayItems { get; } = new LockableObservableListWrapper();

        public event EventHandler YearSelectedIndexChanged;

        public event EventHandler MonthSelectedIndexChanged;

        public event EventHandler DaySelectedIndexChanged;

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

                return;
            }

            if (YearItemsSource != null)
            {
                YearSelectedItem = YearItemsSource[index];

                SetDate();

                return;
            }

            YearSelectedItem = YearItems[index];
        }

        void UpdateSelectedMonthItem(int index)
        {
            try
            {
                if (YearSelectedItem == null)
                {
                    MonthSelectedItem = null;

                    Application.Current.MainPage.DisplayAlert("Date", "Select a year first", "Ok");

                    return;
                }

                if (index == -1)
                {
                    MonthSelectedItem = null;

                    return;
                }

                if (MonthItemsSource != null)
                {
                    MonthSelectedItem = MonthItemsSource[index];

                    SetDate();

                    //Reset Day
                    if (DaySelectedItem != null && DayItemsSource != null)
                    {
                        if (Convert.ToInt32(DaySelectedItem) > DayItemsSource.Count)
                        {
                            DaySelectedItem = null;

                            DaySelectedIndex = -1;
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

                Application.Current.MainPage.DisplayAlert("Date", "Select a month first", "Ok");

                return;
            }

            if (index == -1)
            {
                DaySelectedItem = null;

                return;
            }

            if (DayItemsSource != null)
            {
                DaySelectedItem = DayItemsSource[index];

                SetDate();

                DateSelected?.Invoke(this, EventArgs.Empty);

                return;
            }

            DaySelectedItem = DayItems[index];
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

        static void OnSelectedYearItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var picker = (SimpleDatePicker)bindable;
            picker.UpdateSelectedYearIndex(newValue);
        }

        static void OnSelectedMonthItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var picker = (SimpleDatePicker)bindable;
            picker.UpdateSelectedMonthIndex(newValue);
        }

        static void OnSelectedDayItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var picker = (SimpleDatePicker)bindable;
            picker.UpdateSelectedDayIndex(newValue);
        }

        private static void MinimumDatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (SimpleDatePicker)bindable;
            
            control.UpdateYearItems();
        }

        void UpdateYearItems()
        {

        }

        public SimpleDatePicker()
        {
            InitializeComponent();

            //Titles
            YearPicker.SetBinding(Picker.TitleProperty, new Binding(nameof(YearPickerTitle), source: this));

            MonthPicker.SetBinding(Picker.TitleProperty, new Binding(nameof(MonthPickerTitle), source: this));

            DayPicker.SetBinding(Picker.TitleProperty, new Binding(nameof(DayPickerTitle), source: this));

            // ItemsSource property binding
            YearPicker.SetBinding(Picker.ItemsSourceProperty, new Binding(nameof(YearItemsSource), source: this));

            MonthPicker.SetBinding(Picker.ItemsSourceProperty, new Binding(nameof(MonthItemsSource), source: this));

            DayPicker.SetBinding(Picker.ItemsSourceProperty, new Binding(nameof(DayItemsSource), source: this));

            // Selected Index
            YearPicker.SetBinding(Picker.SelectedIndexProperty, new Binding(nameof(YearSelectedIndex), source: this));

            MonthPicker.SetBinding(Picker.SelectedIndexProperty, new Binding("MonthSelectedIndex", source: this));

            DayPicker.SetBinding(Picker.SelectedIndexProperty, new Binding("DaySelectedIndex", source: this));

            // Selected Item
            YearPicker.SetBinding(Picker.SelectedItemProperty, new Binding("YearSelectedItem", source: this));

            MonthPicker.SetBinding(Picker.SelectedItemProperty, new Binding("MonthSelectedItem", source: this));

            DayPicker.SetBinding(Picker.SelectedItemProperty, new Binding("DaySelectedItem", source: this));

            // Font Size property binding
            YearPicker.SetBinding(Picker.FontSizeProperty, new Binding(nameof(FontSize), source: this));
            MonthPicker.SetBinding(Picker.FontSizeProperty, new Binding(nameof(FontSize), source: this));
            DayPicker.SetBinding(Picker.FontSizeProperty, new Binding(nameof(FontSize), source: this));

            Separator1.SetBinding(Label.FontSizeProperty, new Binding(nameof(FontSize), source: this));
            Separator2.SetBinding(Label.FontSizeProperty, new Binding(nameof(FontSize), source: this));

            // Font Family property binding
            YearPicker.SetBinding(Picker.FontFamilyProperty, new Binding(nameof(FontFamily), source: this));
            MonthPicker.SetBinding(Picker.FontFamilyProperty, new Binding(nameof(FontFamily), source: this));
            DayPicker.SetBinding(Picker.FontFamilyProperty, new Binding(nameof(FontFamily), source: this));

            // Picker Text color property binding
            YearPicker.SetBinding(Picker.TextColorProperty, new Binding(nameof(TextColor), source: this));
            MonthPicker.SetBinding(Picker.TextColorProperty, new Binding(nameof(TextColor), source: this));
            DayPicker.SetBinding(Picker.TextColorProperty, new Binding(nameof(TextColor), source: this));

            // Picker Title color property binding
            YearPicker.SetBinding(Picker.TitleColorProperty, new Binding(nameof(TitleColor), source: this));
            MonthPicker.SetBinding(Picker.TitleColorProperty, new Binding(nameof(TitleColor), source: this));
            DayPicker.SetBinding(Picker.TitleColorProperty, new Binding(nameof(TitleColor), source: this));

            // Separator color property binding
            Separator1.SetBinding(Label.TextColorProperty, new Binding(nameof(SeparatorColor), source: this));
            Separator2.SetBinding(Label.TextColorProperty, new Binding(nameof(SeparatorColor), source: this));

            // Separator Text property binding
            Separator1.SetBinding(Label.TextProperty, new Binding(nameof(Separator), source: this));
            Separator2.SetBinding(Label.TextProperty, new Binding(nameof(Separator), source: this));

            YearItemsSource = DateUtil.GetYears(MinimumYear, MaximumYear);

            //MonthItemsSource = DateUtil.Months;
            MonthItemsSource = DateUtil.MonthNames;

            MonthPicker.SelectedIndexChanged += MonthPicker_MonthSelectionChanged;

            YearPicker.Focused += YearPicker_Focused;

            YearPicker.Unfocused += YearPicker_Unfocused;

            MonthPicker.Focused += MonthPicker_Focused;

            MonthPicker.Unfocused += MonthPicker_Unfocused;

            DayPicker.Focused += DayPicker_Focused;

            DayPicker.Unfocused += DayPicker_Unfocused;

            YearTitle = YearPickerTitle;

            MonthTitle = MonthPickerTitle;

            DayTitle = DayPickerTitle;

            SetYears();
        }

        

        private void MonthPicker_MonthSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (MonthSelectedItem != null)
                {
                    //if (DayItemsSource == null)
                    //{
                    var month = DateUtil.GetMonthIndex((string)MonthSelectedItem).ToString();

                    DayItemsSource = DateUtil.GetDays(month, Convert.ToInt32((string)YearSelectedItem));
                    //}

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

        private void SetDate(DateTime date)
        {
            try
            {
                YearSelectedItem = date.Year;
                YearSelectedIndex = YearItemsSource.IndexOf(date.Year);
                YearPickerTitle = date.Year.ToString();
                //YearLabel.Text = date.Year.ToString();


                //MonthSelectedItem = date.Month;
                MonthSelectedItem = DateUtil.GetMonthName(date.Month);
                // MonthSelectedIndex = MonthItemsSource.IndexOf(date.Month);
                MonthSelectedIndex = MonthItemsSource.IndexOf(DateUtil.GetMonthName(date.Month));
                MonthPickerTitle = DateUtil.GetMonthName(date.Month);
                //MonthLabel.Text = date.Month.ToString();
                //MonthLabel.Text = DateUtil.GetMonthName(date.Month);

                DaySelectedItem = date.Day;
                if (DayItemsSource == null)
                {
                    DayItemsSource = DateUtil.GetDays(date.Month.ToString(), date.Year);
                }
                DaySelectedIndex = DayItemsSource.IndexOf(date.Day);
                DayPickerTitle = date.Day.ToString();
                //DayLabel.Text = date.Day.ToString();

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

            //YearLabel.Text = "Year";

            //MonthLabel.Text = "Month";

            //DayLabel.Text = "Day";

            //   YearTitle = "YYYY";

            //   MonthTitle = "MM";

            //   DayTitle = "DD";
        }

        public void YearPicker_Focused(object sender, EventArgs e)
        {
            YearPicker.Title = YearTitle;
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
                Application.Current.MainPage.DisplayAlert("Date", "Select a year first", "Ok");

                MonthPicker.Unfocus();

                return;
            }

            MonthPicker.Title = MonthTitle;
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
                Application.Current.MainPage.DisplayAlert("Date", "Select a month first", "Ok");

                DayPicker.Unfocus();

                return;
            }

            DayPicker.Title = DayTitle;
        }

        public void DayPicker_Unfocused(object sender, EventArgs e)
        {
            if (DaySelectedItem == null)
            {

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

        //private static void MinMaxYearTextChanged(BindableObject bindable, object oldValue, object newValue)
        //{
        //    // TODO better error handling
        //    SetYears();
        //    // ((SimpleDatePicker)bindable).YearItemsSource = newValue.ToString();
        //}

        private void SetYears()
        {
            YearPicker.ItemsSource = DateUtil.GetYears(MinimumYear, MaximumYear);
        }
    }

}