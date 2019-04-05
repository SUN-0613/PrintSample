using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace PrintSample.PrintPage.View
{
    /// <summary>
    /// MainPage.xaml の相互作用ロジック
    /// </summary>
    public partial class MainPage : Page, IDisposable, ICloneable
    {

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
        /// <param name="viewModel">ViewModel</param>
        private MainPage(ViewModel.MainPage viewModel)
        {

            InitializeComponent();

            DataContext = viewModel;
            viewModel.PropertyChanged += OnPropertyChanged;

        }

        /// <summary>
        /// クローン作成
        /// </summary>
        public object Clone()
        {

            if (DataContext is ViewModel.MainPage viewModel)
            {
                return new MainPage((ViewModel.MainPage)viewModel.Clone());
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Dispose()
        {

            if (DataContext is ViewModel.MainPage viewModel)
            {

                viewModel.PropertyChanged -= OnPropertyChanged;

                viewModel.Dispose();
                viewModel = null;

            }

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
