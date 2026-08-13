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
        private const float RenderOffsetX = -10f;
        private const float RenderOffsetY = -2f;
        public const float PageWidth = 1400f;
        public const float PageHeight = 2150f;

        private const float SafeMargin = 120f;
        private const float ContentLeft = 135f;
        private const float ContentRight = 1265f;
        private const float ContentTop = 460f;
       
        private const float FooterTop = 1590f;
        private const string TempleAddress = "地址:基隆市中正區觀海街八號四樓";
        private const string ThankYouMessage =
            "上款係 貴大德喜贊本宮 如額收訖無訛";
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

            graphics.TranslateTransform(
                pageBounds.X + RenderOffsetX,
                pageBounds.Y + RenderOffsetY);
            graphics.ScaleTransform(scale, scale);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint =
                System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            DrawDocument(graphics, receipt);
            graphics.Restore(state);
        }

        private static void DrawDocument(Graphics graphics, Receipt receipt)
        {

            //float rowScale = CalculateRowScale(receipt);
            float rowScale = 1f;

            using (Pen borderPen = new Pen(Color.Black, 2.5f))
            using (Pen linePen = new Pen(Color.DimGray, 1.5f))
            using (Font templeFont = new Font("DFKai-SB", 62f,
                FontStyle.Bold))
            using (Font certificateFont = new Font("DFKai-SB", 44f,
                FontStyle.Bold))
            using (Font bodyFont = new Font("DFKai-SB", 32f)) //26
            using (Font moneyFont = new Font("DFKai-SB", 60f, //34
                FontStyle.Bold))
            using (Font addressFont = new Font("DFKai-SB", 30f)) //26
            using (Font templeaddressFont = new Font("DFKai-SB", 26f)) //20
            using (Font messageFont = new Font("DFKai-SB", 26f))
            using (Font copyNoteFont = new Font("DFKai-SB", 20f))
            using (Font detailFont = new Font("DFKai-SB", 36f)) 
            using (Font detailBoldFont = new Font("DFKai-SB", 32f,
                FontStyle.Bold))

            {
                graphics.FillRectangle(Brushes.White, 0, 0, PageWidth, PageHeight);
                graphics.DrawRectangle(borderPen, SafeMargin, SafeMargin,
                    PageWidth - SafeMargin * 2, PageHeight - SafeMargin * 2);

                DrawTempleName(graphics, "元始清靜宮", templeFont, Brushes.Black,
                    new RectangleF(395, 125, 610, 70));
                DrawCenteredText(graphics, "感謝狀", certificateFont, 215, PageWidth);

                graphics.DrawString($"收據編號：{receipt.ReceiptNo ?? string.Empty}",
                    bodyFont, Brushes.Black, ContentLeft, 305);
                graphics.DrawString($"日期：{FormatRocDate(receipt.CreateTime)}",
                    bodyFont, Brushes.Black, ContentLeft, 370);
                graphics.DrawString(DaoCalendarService.GetDaoCalendar(receipt.CreateTime),
                    bodyFont, Brushes.Black, 760, 370);
                graphics.DrawLine(linePen, ContentLeft, 430, ContentRight, 430);

                // 地址放在 Header 下方
                graphics.DrawString(
                    $"地址：{receipt.Address ?? string.Empty}",
                    bodyFont, Brushes.Black, ContentLeft, 438);

                float personHeaderHeight = 48f * rowScale;

                // 第一位捐款人往下移
                float y = ContentTop + 35f;

                float itemRowHeight = 50f * rowScale;

                foreach (ReceiptPerson person in receipt.Persons)
                {
                    string name = string.IsNullOrWhiteSpace(person.Name)
                        ? "未命名捐款人"
                        : person.Name;

                    graphics.FillRectangle(Brushes.Gainsboro, ContentLeft, y,
                        ContentRight - ContentLeft, personHeaderHeight);
                    graphics.DrawRectangle(linePen, ContentLeft, y,
                        ContentRight - ContentLeft, personHeaderHeight);
                    float headerTextY = y + (personHeaderHeight - detailBoldFont.GetHeight(graphics)) / 2f + 2f;
                    graphics.DrawString($"捐款人：{name}", detailBoldFont,
                        Brushes.Black, ContentLeft + 20, headerTextY);
                    y += personHeaderHeight + 4f;

                    if (person.Items.Count == 0)
                    {
                        DrawItemRow(graphics, linePen, detailFont, y, itemRowHeight,
                            "尚未輸入項目", 0);
                        y += itemRowHeight + 2f;
                    }
                    else
                    {
                        foreach (ReceiptItem item in person.Items)
                        {
                            DrawItemRow(graphics, linePen, detailFont, y,
                                itemRowHeight, item.ItemName, item.Amount);
                            y += itemRowHeight + 2f;
                        }
                    }

                    y += 6f;
                }
                
                DrawDistributedText(graphics, ThankYouMessage, messageFont,
                    Brushes.Black, new RectangleF(ContentLeft, 1655,
                    ContentRight - ContentLeft, 30));
                graphics.DrawLine(borderPen, ContentLeft, FooterTop + 100,
                    ContentRight, FooterTop + 100);
                graphics.DrawString("總計", bodyFont, Brushes.Black,
                    ContentLeft, FooterTop + 142);
                DrawRightText(graphics, $"{receipt.TotalAmount:N0} 元",
                    templeFont, ContentRight - 20, FooterTop + 120);
                graphics.DrawString("新台幣", bodyFont, Brushes.Black,
                    ContentLeft, FooterTop + 215);
                DrawRightText(graphics,MoneyService.Convert(receipt.TotalAmount),
                    moneyFont, ContentRight - 20, FooterTop + 215 );
                graphics.DrawString($"經手人：{receipt.Operator ?? string.Empty}",
                    bodyFont, Brushes.Black, ContentLeft, 1970);
                DrawRightText(graphics, TempleAddress, templeaddressFont,
                    ContentRight - 20, 1970);
                DrawRightText(graphics, CopyNote, copyNoteFont,
                    ContentRight - 5, 2085);
            }
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

            float textY = y + (height - font.GetHeight(graphics)) / 2f + 2f;

            graphics.DrawString(
                name ?? string.Empty,
                font,
                Brushes.Black,
                ContentLeft + 20,
                textY);

            DrawRightText(
                graphics,
                $"{amount:N0}",
                font,
                ContentRight - 20,
                textY);
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
        private static void DrawTempleName( Graphics graphics, string text,
            Font font, Brush brush, RectangleF bounds)
        {
            if (string.IsNullOrEmpty(text))
                return;

            float[] widths = new float[text.Length];
            float textWidth = 0;

            // 計算每個字的實際寬度
            for (int i = 0; i < text.Length; i++)
            {
                widths[i] = graphics.MeasureString(
                    text[i].ToString(),
                    font).Width;

                textWidth += widths[i];
            }

            // 宮名使用固定字距
            const float spacing = 28f;

            float totalWidth =
                textWidth +
                spacing * (text.Length - 1);

            // ★ 整個宮名區塊真正水平置中
            float x =
                bounds.X +
                (bounds.Width - totalWidth) / 2f;

            for (int i = 0; i < text.Length; i++)
            {
                graphics.DrawString(
                    text[i].ToString(),
                    font,
                    brush,
                    x,
                    bounds.Y);

                x += widths[i] + spacing;
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
