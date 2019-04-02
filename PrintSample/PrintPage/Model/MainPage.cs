using System;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PrintSample.PrintPage.Model
{

    /// <summary>
    /// MainPage.Model
    /// </summary>
    public class MainPage : IDisposable
    {

        #region ViewModel.Property

        /// <summary>
        /// 画像イメージ
        /// </summary>
        public BitmapImage BitmapImage;

        /// <summary>
        /// 文章
        /// </summary>
        public string Text;

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
        /// MainPage.Model
        /// </summary>
        public MainPage()
        {
            MakeBitmapImage("../../Image/print.png");
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Dispose()
        {

            

        }

        /// <summary>
        /// 画像イメージ作成
        /// </summary>
        /// <param name="path">画像ファイル相対パス</param>
        private async void MakeBitmapImage(string path)
        {

            await Task.Run(() => 
            {

                try
                {

                    BitmapImage = new BitmapImage();
                    BitmapImage.BeginInit();
                    BitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    BitmapImage.CreateOptions = BitmapCreateOptions.None;
                    BitmapImage.UriSource = new Uri(path, UriKind.Relative);
                    BitmapImage.EndInit();
                    BitmapImage.Freeze();

                }
                catch (Exception ex)
                {
#if DEBUG
                    System.Diagnostics.Debug.WriteLine(ex.Message);
#endif
                }

            });

        }

    }

}
