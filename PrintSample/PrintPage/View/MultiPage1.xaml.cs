using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace PrintSample.PrintPage.View
{
    /// <summary>
    /// MultiPage1.xaml の相互作用ロジック
    /// </summary>
    public partial class MultiPage1 : Page, ICloneable, IDisposable
    {

        /// <summary>
        /// MultiPage1.View
        /// </summary>
        public MultiPage1()
        {

            InitializeComponent();

            if (DataContext is ViewModel.MultiPage1 viewModel)
            {
                viewModel.PropertyChanged += OnPropertyChanged;
            }

        }

        /// <summary>
        /// MultiPage1.View
        /// クローン作成用
        /// </summary>
        /// <param name="viewModel">ViewModel</param>
        private MultiPage1(ViewModel.MultiPage1 viewModel)
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

            if (DataContext is ViewModel.MultiPage1 viewModel)
            {
                return new MultiPage1((ViewModel.MultiPage1)viewModel.Clone());
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

            if (DataContext is ViewModel.MultiPage1 viewModel)
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
