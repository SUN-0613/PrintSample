using AYam.Common.MVVM;
using System;

namespace PrintSample.Form.ViewModel
{

    /// <summary>
    /// 複数印刷用Window.ViewModel
    /// </summary>
    public class MultiWindow : ViewModelBase, IDisposable
    {

        /// <summary>
        /// Model
        /// </summary>
        private Model.MultiWindow _Model;

        #region Property

        /// <summary>
        /// 表示ページ
        /// </summary>
        public string ShowPage
        {
            get { return _Model.ShowPage.ToString(); }   
            set
            {

                _Model.ShowPage = _Model.CheckInputPage(value);
                CallPropertyChanged();
                CallPropertyChanged(nameof(PageSource));

            }
        }

        /// <summary>
        /// ページ数
        /// </summary>
        public int MaxPage { get { return _Model.MaxPage; } }

        /// <summary>
        /// 表示Pageプロパティ
        /// </summary>
        public object PageSource { get { return _Model.PageSources[_Model.Index]; } }

        /// <summary>
        /// 前頁コマンド
        /// </summary>
        public DelegateCommand PreviousPageCommand
        {
            get
            {

                if (_Model.PreviousPageCommand == null)
                {

                    _Model.PreviousPageCommand = new DelegateCommand(
                        () => { ShowPage = (--_Model.ShowPage).ToString(); },
                        () => true
                    );

                }

                return _Model.PreviousPageCommand;

            }
        }

        /// <summary>
        /// 次頁コマンド
        /// </summary>
        public DelegateCommand NextPageCommand
        {
            get
            {

                if (_Model.NextPageCommand == null)
                {

                    _Model.NextPageCommand = new DelegateCommand(
                        () => { ShowPage = (++_Model.ShowPage).ToString(); },
                        () => true
                    );

                }

                return _Model.NextPageCommand;

            }
        }

        /// <summary>
        /// 新規頁コマンド
        /// </summary>
        public DelegateCommand NewPageCommand
        {
            get
            {

                if (_Model.NewPageCommand == null)
                {

                    _Model.NewPageCommand = new DelegateCommand(
                        () => 
                        {
                            _Model.CreatePage();
                            CallPropertyChanged(nameof(ShowPage));
                            CallPropertyChanged(nameof(MaxPage));
                        },
                        () => true
                    );

                }

                return _Model.NewPageCommand;

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
        /// 複数印刷用Window.ViewModel
        /// </summary>
        public MultiWindow()
        {

            _Model = new Model.MultiWindow();

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
