﻿using AYam.Common.ViewModel;
using System;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace PrintSample.Form.Model
{

    /// <summary>
    /// MainWindow.Model
    /// </summary>
    public class MainWindow : IDisposable
    {

        #region ViewModel.Property

        /// <summary>
        /// 表示Page
        /// </summary>
        public object PageSource = null;

        /// <summary>
        /// 印刷実行コマンド
        /// </summary>
        public DelegateCommand PrintCommand = null;

        #endregion

        /// <summary>
        /// MainWindow.Model
        /// </summary>
        public MainWindow()
        {

            PageSource = new PrintPage.View.MainPage();

        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Dispose()
        {

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

                var printServer = new LocalPrintServer();
                var queue = printServer.DefaultPrintQueue;
                var writer = PrintQueue.CreateXpsDocumentWriter(queue);

                // 用紙サイズ：A4
                var ticket = queue.DefaultPrintTicket;
                ticket.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA4);
                ticket.PageOrientation = PageOrientation.Portrait;

                var source = (PrintPage.View.MainPage)PageSource;
                var viewModel = (PrintPage.ViewModel.MainPage)source.DataContext;
                var page = new PrintPage.View.MainPage() { DataContext = source.DataContext };
                //var size = new Size(source.DesiredSize.Width, source.DesiredSize.Height);
                var size = new Size(viewModel.DesignWidth, viewModel.DesignHeight);

                writer.Write(CreateFixedPage(page, size), ticket);

            }
            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(ex.Message);
#endif
            }

        }

        /// <summary>
        /// PageからFixedPageを作成
        /// </summary>
        /// <param name="sender">Page</param>
        /// <param name="size">縦横サイズ</param>
        /// <returns>FixedPage</returns>
        private FixedPage CreateFixedPage(object sender, Size size)
        {

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

            }

            return fixedPage;

        }

    }

}
