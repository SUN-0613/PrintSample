using AYam.Common.ViewModel;
using System;

namespace PrintSample.PrintPage.ViewModel
{

    /// <summary>
    /// MultiPage1.ViewModel
    /// </summary>
    public class MultiPage1 : VMBase, ICloneable, IDisposable
    {

        /// <summary>
        /// MultiPage1.Model
        /// </summary>
        private Model.MultiPage1 _Model;

        #region Property

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
        /// MultiPage1.ViewModel
        /// </summary>
        public MultiPage1()
        {

            _Model = new Model.MultiPage1();

        }

        /// <summary>
        /// MultiPage1.ViewModel
        /// クローン作成用
        /// </summary>
        /// <param name="page1">元データ</param>
        private MultiPage1(MultiPage1 page1)
        {

            _Model = page1._Model.Clone() as Model.MultiPage1;

        }

        /// <summary>
        /// クローン作成
        /// </summary>
        public object Clone()
        {
            return new MultiPage1(this);
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
