using System;
using System.ComponentModel;
using System.Windows;

namespace PrintSample.Form.View
{
    /// <summary>
    /// MultiWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MultiWindow : Window, IDisposable
    {

        /// <summary>
        /// 複数印刷用Window.View
        /// </summary>
        public MultiWindow()
        {

            InitializeComponent();

            if (DataContext is ViewModel.MultiWindow viewModel)
            {
                viewModel.PropertyChanged += OnPropertyChanged;
            }

        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Dispose()
        {

            if (DataContext is ViewModel.MultiWindow viewModel)
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
