using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;
using TempleReceipt.Controls;
using TempleReceipt.Models;

namespace TempleReceipt.Services
{
    /// <summary>
    /// 將直式中一刀收據旋轉 90 度後交由 Windows 印表機驅動列印。
    /// </summary>
    public class PrinterService
    {
        private const int PaperWidth = 846;
        private const int PaperHeight = 551;

        public void Print(IWin32Window owner, Receipt receipt)
        {
            if (receipt == null)
                throw new ArgumentNullException(nameof(receipt));

            using (PrintDocument document = new PrintDocument())
            using (PrintDialog dialog = new PrintDialog())
            {
                document.DocumentName = "TempleReceipt 功德收據";
                document.DefaultPageSettings.PaperSize = new PaperSize(
                    "中一刀 21.5 x 14 cm", PaperWidth, PaperHeight);
                document.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                document.PrintPage += (sender, args) =>
                    DrawRotatedReceipt(args.Graphics, args.PageBounds, receipt);

                dialog.Document = document;
                dialog.UseEXDialog = true;

                if (dialog.ShowDialog(owner) == DialogResult.OK)
                    document.Print();
            }
        }

        private static void DrawRotatedReceipt(Graphics graphics,
            Rectangle pageBounds, Receipt receipt)
        {
            float scale = Math.Min(
                pageBounds.Width / ReceiptDocumentRenderer.PageHeight,
                pageBounds.Height / ReceiptDocumentRenderer.PageWidth);
            float rotatedWidth = ReceiptDocumentRenderer.PageHeight * scale;
            float rotatedHeight = ReceiptDocumentRenderer.PageWidth * scale;
            float left = pageBounds.Left + (pageBounds.Width - rotatedWidth) / 2f;
            float top = pageBounds.Top + (pageBounds.Height - rotatedHeight) / 2f;

            GraphicsState state = graphics.Save();

            // 將直式預覽順時針旋轉 90 度，置中於 21.5 x 14 公分紙張。
            using (Matrix rotation = new Matrix(0, scale, -scale, 0,
                left + rotatedWidth, top))
            {
                graphics.Transform = rotation;
                ReceiptDocumentRenderer.Draw(graphics, new RectangleF(0, 0,
                    ReceiptDocumentRenderer.PageWidth,
                    ReceiptDocumentRenderer.PageHeight), receipt);
            }
            graphics.Restore(state);
        }
    }
}
