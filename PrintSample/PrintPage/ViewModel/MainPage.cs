using AYam.Common.ViewModel;
using System;
using System.Windows.Media.Imaging;

namespace PrintSample.PrintPage.ViewModel
{

    /// <summary>
    /// MainPage.ViewModel
    /// </summary>
    /// <remarks>
    /// 参照の追加：プロジェクト→Common
    /// </remarks>
    public class MainPage : VMBase, IDisposable
    {

        /// <summary>
        /// MainPage.Model
        /// </summary>
        private Model.MainPage _Model;

        #region Property

        /// <summary>
        /// 画像イメージプロパティ
        /// </summary>
        public BitmapImage BitmapImage
        {
            get { return _Model.BitmapImage; }
            set
            {
                if (_Model.BitmapImage != value)
                {

                    _Model.BitmapImage = value;
                    CallPropertyChanged();

                }
            }
        }

        /// <summary>
        /// 文章プロパティ
        /// </summary>
        public string Text
        {
            get { return _Model.Text; }
            set
            {
                if (_Model.Text != value)
                {
                    _Model.Text = value;
                    CallPropertyChanged();
                }
            }
        }

        /// <summary>
        /// 縦サイズプロパティ
        /// </summary>
        public double DesignHeight
        {
            get { return _Model.DesignHeight; }
            set
            {
                if (_Model.DesignHeight != value)
                {
                    _Model.DesignHeight = value;
                    CallPropertyChanged();
                }
            }
        }

        /// <summary>
        /// 横サイズプロパティ
        /// </summary>
        public double DesignWidth
        {
            get { return _Model.DesignWidth; }
            set
            {
                if (_Model.DesignWidth != value)
                {
                    _Model.DesignWidth = value;
                    CallPropertyChanged();
                }
            }
        }

        #endregion

        /// <summary>
        /// MainPage.ViewModel
        /// </summary>
        public MainPage()
        {

            _Model = new Model.MainPage();

        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Dispose()
        {

            if (_Model != null)
            {

                _Model.Dispose();
                _Model = null;

            }

        }

    }

}
