using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using TempleReceipt.Models;

namespace TempleReceipt.Controls
{
    /// <summary>
    /// 以實際紙張比例顯示的收據預覽控制項。
    /// </summary>
    public class ReceiptPreviewControl : UserControl
    {
        private Receipt _receipt;

        public Receipt Receipt
        {
            get { return _receipt; }
            set
            {
                _receipt = value;
                Invalidate();
            }
        }

        public ReceiptPreviewControl()
        {
            DoubleBuffered = true;
            BackColor = Color.Gainsboro;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_receipt == null)
                return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            float scale = Math.Min(Width / ReceiptDocumentRenderer.PageWidth,
                Height / ReceiptDocumentRenderer.PageHeight);
            float width = ReceiptDocumentRenderer.PageWidth * scale;
            float height = ReceiptDocumentRenderer.PageHeight * scale;
            RectangleF pageBounds = new RectangleF((Width - width) / 2f,
                (Height - height) / 2f, width, height);

            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(60,
                Color.Black)))
            {
                e.Graphics.FillRectangle(shadowBrush, pageBounds.X + 6,
                    pageBounds.Y + 6, pageBounds.Width, pageBounds.Height);
            }

            ReceiptDocumentRenderer.Draw(e.Graphics, pageBounds, _receipt);
        }
    }
}
