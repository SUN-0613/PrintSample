using System;

namespace PrintSample.PrintPage.Model
{

    /// <summary>
    /// MultiPage1.Model
    /// </summary>
    public class MultiPage1 : ICloneable, IDisposable
    {

        #region ViewModel.Property

        /// <summary>
        /// 縦サイズ
        /// </summary>
        public double DesignHeight = 1123d;

        /// <summary>
        /// 横サイズ
        /// </summary>
        public double DesignWidth = 794d;

        #endregion

        /// <summary>
        /// MultiPage1.Model
        /// </summary>
        public MultiPage1()
        {

        }

        /// <summary>
        /// MultiPage1.Model
        /// クローン作成用
        /// </summary>
        /// <param name="page1">元データ</param>
        private MultiPage1(MultiPage1 page1)
        {

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

        }

    }

}
