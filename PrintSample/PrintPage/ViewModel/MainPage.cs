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
