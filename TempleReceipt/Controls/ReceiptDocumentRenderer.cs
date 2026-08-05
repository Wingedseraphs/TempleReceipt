using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using TempleReceipt.Models;
using TempleReceipt.Services;

namespace TempleReceipt.Controls
{
    /// <summary>繪製直式中一刀（14 x 21.5 公分）感謝狀。</summary>
    public static class ReceiptDocumentRenderer
    {
        public const float PageWidth = 1400f;
        public const float PageHeight = 2150f;

        private const float SafeMargin = 100f;
        private const float ContentLeft = 135f;
        private const float ContentRight = 1265f;
        private const float ContentTop = 470f;
        private const float DetailBottom = 1450f;
        private const float FooterTop = 1590f;
        private const string TempleAddress = "地址:基隆市中正區觀海街八號四樓";
        private const string ThankYouMessage =
            "上款係 貴大德喜贊本宮 如額收訖無訛，敬表申謝並祝闔府平安、萬事如意。";
        private const string CopyNote =
            "本收據共三聯，第一聯(白)存根聯；第二聯(紅)收執聯；第三聯(黃)會計聯。";

        private static readonly ChineseMoneyService MoneyService =
            new ChineseMoneyService();

        private static readonly DaoCalendarService DaoCalendarService =
            new DaoCalendarService();

        public static void Draw(Graphics graphics, RectangleF pageBounds,
            Receipt receipt)
        {
            if (receipt == null)
                return;

            GraphicsState state = graphics.Save();
            float scale = pageBounds.Width / PageWidth;

            graphics.TranslateTransform(pageBounds.X, pageBounds.Y);
            graphics.ScaleTransform(scale, scale);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint =
                System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            DrawDocument(graphics, receipt);
            graphics.Restore(state);
        }

        private static void DrawDocument(Graphics graphics, Receipt receipt)
        {
            float rowScale = CalculateRowScale(receipt);

            using (Pen borderPen = new Pen(Color.Black, 2.5f))
            using (Pen linePen = new Pen(Color.DimGray, 1.5f))
            using (Font templeFont = new Font("Microsoft JhengHei", 48f,
                FontStyle.Bold))
            using (Font certificateFont = new Font("Microsoft JhengHei", 30f,
                FontStyle.Bold))
            using (Font bodyFont = new Font("Microsoft JhengHei", 22f))
            using (Font addressFont = new Font("Microsoft JhengHei", 20f))
            using (Font messageFont = new Font("Microsoft JhengHei", 18f))
            using (Font detailFont = new Font("Microsoft JhengHei",
                20f * rowScale))
            using (Font detailBoldFont = new Font("Microsoft JhengHei",
                18f * rowScale, FontStyle.Bold))
            {
                graphics.FillRectangle(Brushes.White, 0, 0, PageWidth, PageHeight);
                graphics.DrawRectangle(borderPen, SafeMargin, SafeMargin,
                    PageWidth - SafeMargin * 2, PageHeight - SafeMargin * 2);

                DrawDistributedText(graphics, "元始清靜宮", templeFont, Brushes.Black,
                    new RectangleF(395, 125, 610, 70));
                DrawCenteredText(graphics, "感謝狀", certificateFont, 215, PageWidth);

                graphics.DrawString($"收據編號：{receipt.ReceiptNo ?? string.Empty}",
                    bodyFont, Brushes.Black, ContentLeft, 315);
                graphics.DrawString($"日期：{FormatRocDate(receipt.CreateTime)}",
                    bodyFont, Brushes.Black, 760, 315);
                graphics.DrawString($"經手人：{receipt.Operator ?? string.Empty}",
                    bodyFont, Brushes.Black, ContentLeft, 365);
                graphics.DrawString(DaoCalendarService.GetDaoCalendar(receipt.CreateTime),
                    bodyFont, Brushes.Black, 760, 365);
                graphics.DrawLine(linePen, ContentLeft, 430, ContentRight, 430);

                float personHeaderHeight = 48f * rowScale;
                float itemRowHeight = 50f * rowScale;
                float subtotalHeight = 50f * rowScale;
                float y = ContentTop;

                foreach (ReceiptPerson person in receipt.Persons)
                {
                    string name = string.IsNullOrWhiteSpace(person.Name)
                        ? "未命名捐款人"
                        : person.Name;

                    graphics.FillRectangle(Brushes.Gainsboro, ContentLeft, y,
                        ContentRight - ContentLeft, personHeaderHeight);
                    graphics.DrawRectangle(linePen, ContentLeft, y,
                        ContentRight - ContentLeft, personHeaderHeight);
                    graphics.DrawString($"捐款人：{name}", detailBoldFont,
                        Brushes.Black, ContentLeft + 20, y + 10f * rowScale);
                    y += personHeaderHeight;

                    if (person.Items.Count == 0)
                    {
                        DrawItemRow(graphics, linePen, detailFont, y, itemRowHeight,
                            "尚未輸入項目", 0);
                        y += itemRowHeight;
                    }
                    else
                    {
                        foreach (ReceiptItem item in person.Items)
                        {
                            DrawItemRow(graphics, linePen, detailFont, y,
                                itemRowHeight, item.ItemName, item.Amount);
                            y += itemRowHeight;
                        }
                    }

                    graphics.DrawString("小計", detailFont, Brushes.Black, 780,
                        y + 11f * rowScale);
                    DrawRightText(graphics, $"{person.TotalAmount:N0} 元",
                        detailBoldFont, ContentRight - 20, y + 8f * rowScale);
                    graphics.DrawLine(linePen, ContentLeft, y + 43f * rowScale,
                        ContentRight, y + 43f * rowScale);
                    y += subtotalHeight;
                }

                graphics.DrawString($"地址：{receipt.Address ?? string.Empty}",
                    addressFont, Brushes.Black, ContentLeft, DetailBottom + 15);
                DrawDistributedText(graphics, ThankYouMessage, messageFont,
                    Brushes.Black, new RectangleF(ContentLeft, 1515,
                    ContentRight - ContentLeft, 30));

                graphics.DrawLine(borderPen, ContentLeft, FooterTop,
                    ContentRight, FooterTop);
                graphics.DrawString("總計", bodyFont, Brushes.Black,
                    ContentLeft, FooterTop + 42);
                DrawRightText(graphics, $"{receipt.TotalAmount:N0} 元",
                    templeFont, ContentRight - 20, FooterTop + 20);
                graphics.DrawString("新台幣：", bodyFont, Brushes.Black,
                    ContentLeft, FooterTop + 125);
                DrawDistributedText(graphics, MoneyService.Convert(receipt.TotalAmount),
                    bodyFont, Brushes.Black, new RectangleF(505, FooterTop + 125,
                    ContentRight - 505, 35));
                DrawRightText(graphics, TempleAddress, messageFont,
                    ContentRight - 20, 1970);
                DrawRightText(graphics, CopyNote, messageFont,
                    PageWidth - 25, 2085);
            }
        }

        private static float CalculateRowScale(Receipt receipt)
        {
            int personCount = Math.Max(1, receipt.Persons.Count);
            int itemCount = 0;

            foreach (ReceiptPerson person in receipt.Persons)
                itemCount += Math.Max(1, person.Items.Count);

            float requiredHeight = personCount * 118f + itemCount * 65f;
            float availableHeight = DetailBottom - ContentTop;
            return Math.Min(1.25f, availableHeight / requiredHeight);
        }

        private static string FormatRocDate(DateTime date)
        {
            return $"{date.Year - 1911}年{date.Month}月{date.Day}日";
        }

        private static void DrawItemRow(Graphics graphics, Pen linePen,
            Font font, float y, float height, string name, decimal amount)
        {
            graphics.DrawRectangle(linePen, ContentLeft, y,
                ContentRight - ContentLeft, height);
            graphics.DrawLine(linePen, 930, y, 930, y + height);
            graphics.DrawString(name ?? string.Empty, font, Brushes.Black,
                ContentLeft + 20, y + height * 0.2f);
            DrawRightText(graphics, $"{amount:N0}", font, ContentRight - 20,
                y + height * 0.2f);
        }

        private static void DrawCenteredText(Graphics graphics, string text,
            Font font, float y, float width)
        {
            using (StringFormat format = new StringFormat())
            {
                format.Alignment = StringAlignment.Center;
                graphics.DrawString(text, font, Brushes.Black,
                    new RectangleF(0, y, width, font.GetHeight(graphics) + 12), format);
            }
        }

        private static void DrawDistributedText(Graphics graphics, string text,
            Font font, Brush brush, RectangleF bounds)
        {
            if (string.IsNullOrEmpty(text))
                return;

            float[] widths = new float[text.Length];
            float textWidth = 0;

            for (int i = 0; i < text.Length; i++)
            {
                widths[i] = graphics.MeasureString(text[i].ToString(), font).Width;
                textWidth += widths[i];
            }

            float spacing = text.Length > 1
                ? Math.Max(0, (bounds.Width - textWidth) / (text.Length - 1))
                : 0;
            float x = bounds.X;

            for (int i = 0; i < text.Length; i++)
            {
                graphics.DrawString(text[i].ToString(), font, brush, x, bounds.Y);
                x += widths[i] + spacing;
            }
        }

        private static void DrawRightText(Graphics graphics, string text,
            Font font, float right, float y)
        {
            using (StringFormat format = new StringFormat())
            {
                format.Alignment = StringAlignment.Far;
                graphics.DrawString(text, font, Brushes.Black,
                    new RectangleF(0, y, right, font.GetHeight(graphics) + 14), format);
            }
        }
    }
}
