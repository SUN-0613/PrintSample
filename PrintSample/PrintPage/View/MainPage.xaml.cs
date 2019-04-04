using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace PrintSample.PrintPage.View
{
    /// <summary>
    /// MainPage.xaml の相互作用ロジック
    /// </summary>
    public partial class MainPage : Page, IDisposable, ICloneable
    {

        /// <summary>
        /// クローンとして作成されたか
        /// </summary>
        private readonly bool _IsClone = false;

        /// <summary>
        /// MainPage.View
        /// </summary>
        public MainPage()
        {

            InitializeComponent();

            if (DataContext is ViewModel.MainPage viewModel)
            {
                viewModel.PropertyChanged += OnPropertyChanged;
            }

        }

        /// <summary>
        /// MainPage.View
        /// </summary>
        /// <param name="dataContext">ViewModel</param>
        private MainPage(object dataContext)
        {

            InitializeComponent();

            DataContext = dataContext;
            _IsClone = true;

            if (DataContext is ViewModel.MainPage viewModel)
            {
                viewModel.PropertyChanged += OnPropertyChanged;
            }

        }

        /// <summary>
        /// クローン作成
        /// </summary>
        public object Clone()
        {
            return new MainPage(DataContext);
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Dispose()
        {

            if (DataContext is ViewModel.MainPage viewModel)
            {

                viewModel.PropertyChanged -= OnPropertyChanged;

                if (!_IsClone)
                {
                    viewModel.Dispose();
                }

            }

            DataContext = null;

        }

        /// <summary>
        /// ViewModelプロパティ変更イベント
        /// </summary>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            switch (e.PropertyName)
            {
                default:
                    break;
            }

        }

    }
}
