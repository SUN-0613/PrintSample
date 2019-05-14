using AYam.Common.MVVM;
using System;
using System.Windows.Controls;

namespace PrintSample.Form.ViewModel
{

    /// <summary>
    /// MainWindow.ViewModel
    /// </summary>
    /// <remarks>
    /// 参照の追加：プロジェクト→Common
    /// </remarks>
    public class MainWindow : ViewModelBase, IDisposable
    {

        /// <summary>
        /// MainWindow.Model
        /// </summary>
        private Model.MainWindow _Model;

        #region Property

        /// <summary>
        /// 表示Pageプロパティ
        /// </summary>
        public object PageSource
        {

            get { return _Model.PageSource; }
            set
            {

                if (_Model.PageSource != value)
                {
                    _Model.PageSource = value;
                }
                
                CallPropertyChanged();

            }

        }

        /// <summary>
        /// 印刷実行コマンド
        /// </summary>
        public DelegateCommand PrintCommand
        {
            get
            {

                if (_Model.PrintCommand == null)
                {

                    _Model.PrintCommand = new DelegateCommand(
                        () => { _Model.ExecutePrint(); },
                        () => true
                    );

                }

                return _Model.PrintCommand;

            }
        }

        #endregion

        /// <summary>
        /// MainWindow.ViewModel
        /// </summary>
        public MainWindow()
        {

            _Model = new Model.MainWindow();

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
