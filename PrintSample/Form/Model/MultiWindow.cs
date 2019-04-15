using AYam.Common.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace PrintSample.Form.Model
{

    /// <summary>
    /// 複数印刷用Window.Model
    /// </summary>
    public class MultiWindow : IDisposable
    {

        #region Property

        /// <summary>
        /// 表示ページ
        /// </summary>
        private int _ShowPage = 1;

        /// <summary>
        /// 表示ページプロパティ
        /// </summary>
        public int ShowPage
        {
            get { return _ShowPage; }
            set
            {
                _ShowPage = value;
                Index = value - 1;
            }
        }

        /// <summary>
        /// ページ数
        /// </summary>
        public int MaxPage = 1;

        /// <summary>
        /// 表示Page一覧
        /// </summary>
        public ArrayList PageSources;

        /// <summary>
        /// 表示Page.Index
        /// </summary>
        public int Index = 0;

        /// <summary>
        /// 前頁コマンド
        /// </summary>
        public DelegateCommand PreviousPageCommand = null;

        /// <summary>
        /// 次頁コマンド
        /// </summary>
        public DelegateCommand NextPageCommand = null;

        /// <summary>
        /// 新規頁コマンド
        /// </summary>
        public DelegateCommand NewPageCommand = null;

        /// <summary>
        /// 印刷実行コマンド
        /// </summary>
        public DelegateCommand PrintCommand = null;

        #endregion

        /// <summary>
        /// 複数印刷用Window.Model
        /// </summary>
        public MultiWindow()
        {

            PageSources = new ArrayList
            {
                new PrintPage.View.MultiPage1()
            };

        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Dispose()
        {

            if (PageSources != null)
            {
                
                for (int iLoop = 0; iLoop < PageSources.Count; iLoop++)
                {

                    if (PageSources[iLoop] is PrintPage.View.MultiPage1 page1)
                    {
                        page1.Dispose();
                        page1 = null;
                    }

                }

                PageSources.Clear();
                PageSources = null;

            }

        }

        /// <summary>
        /// ページ欄に入力した値の適正チェック
        /// </summary>
        /// <param name="value">ページ欄の入力値</param>
        /// <returns>表示ページ数</returns>
        public int CheckInputPage(string value)
        {

            if (int.TryParse(value, out int numValue))
            {

                if (numValue < 1)
                {
                    numValue = 1;
                }
                else if (numValue > MaxPage)
                {
                    numValue = MaxPage;
                }

                return numValue;

            }
            else
            {
                return ShowPage;
            }

        }

        /// <summary>
        /// 新規Page作成
        /// </summary>
        public void CreatePage()
        {

            PageSources.Add(new PrintPage.View.MultiPage1());
            MaxPage++;
            ShowPage++;

        }

        /// <summary>
        /// 印刷実行
        /// </summary>
        /// <remarks>
        /// 参照の追加
        /// System.Printing
        /// ReachFrameWork
        /// </remarks>
        public void ExecutePrint()
        {

            try
            {

                using (var printServer = new LocalPrintServer())
                {

                    using (var queue = printServer.DefaultPrintQueue)
                    {

                        var writer = PrintQueue.CreateXpsDocumentWriter(queue);

                        // 印刷設定
                        var ticket = queue.DefaultPrintTicket;
                        ticket.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA4);
                        ticket.PageOrientation = PageOrientation.Portrait;

                        // 複数ページ処理
                        var document = new FixedDocument();
                        var list = new List<PrintPage.View.MultiPage1>();

                        // クローン作成
                        for (int iLoop = 0; iLoop < PageSources.Count; iLoop++)
                        {

                            if (PageSources[iLoop] is PrintPage.View.MultiPage1 source
                                && source.Clone() is PrintPage.View.MultiPage1 page)
                            {
                                list.Add(page);
                            }

                        }

                        // 印刷内容作成
                        for (int iLoop = 0; iLoop < list.Count; iLoop++)
                        {

                            if (list[iLoop].DataContext is PrintPage.ViewModel.MultiPage1 viewModel)
                            {

                                var size = new Size(viewModel.DesignWidth, viewModel.DesignHeight);
                                document.Pages.Add(CreatePageContent(list[iLoop], size));

                            }

                        }

                        // 印刷実行
                        writer.Write(document, ticket);

                        // メモリ解放
                        list.ForEach(page => 
                        {
                            page.Dispose();
                            page = null;
                        });

                        list.Clear();
                        list = null;

                    }

                }

            }
            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(ex.Message);
#endif
            }

        }

        /// <summary>
        /// PageからFixedPageを作成し、PageContentに追加
        /// </summary>
        /// <param name="sender">Page</param>
        /// <param name="size">縦横サイズ</param>
        /// <returns>PageContent</returns>
        private PageContent CreatePageContent(object sender, Size size)
        {

            var pageContent = new PageContent();
            var fixedPage = new FixedPage();

            if (sender is Page page)
            {

                var frame = new Frame
                {
                    Content = page
                };

                FixedPage.SetLeft(frame, 0d);
                FixedPage.SetTop(frame, 0d);

                fixedPage.Children.Add(frame);
                fixedPage.Width = size.Width;
                fixedPage.Height = size.Height;
                fixedPage.Measure(size);
                fixedPage.Arrange(new Rect(new Point(), size));
                fixedPage.UpdateLayout();

                pageContent.Child = fixedPage;

            }

            return pageContent;

        }

    }

}
