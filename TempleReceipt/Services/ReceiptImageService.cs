using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using TempleReceipt.Controls;
using TempleReceipt.Models;

namespace TempleReceipt.Services
{
    public static class ReceiptImageService
    {
        public static string SaveReceiptImage(Receipt receipt)
        {
            if (receipt == null)
                throw new ArgumentNullException(nameof(receipt));

            // Picture 資料夾
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "TempleReceipt", "Picture");

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            // 第一位捐款人
            string firstPerson = "未命名";

            if (receipt.Persons.Count > 0 &&
                !string.IsNullOrWhiteSpace(receipt.Persons[0].Name))
            {
                firstPerson = receipt.Persons[0].Name.Trim();
            }

            // 移除非法字元
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                firstPerson = firstPerson.Replace(c.ToString(), "");
            }

            // 基本檔名
            string baseFileName =
                $"{receipt.ReceiptNo}-{DateTime.Now:yyyyMMdd}-{firstPerson}";

            string filePath = Path.Combine(folder, baseFileName + ".jpg");

            // 若重複，自動加 -1、-2、-3...
            if (File.Exists(filePath))
            {
                int index = 1;

                do
                {
                    filePath = Path.Combine(
                        folder,
                        $"{baseFileName}-{index}.jpg");

                    index++;

                } while (File.Exists(filePath));
            }

            // 建立圖片
            using (Bitmap bmp = new Bitmap(
    (int)ReceiptDocumentRenderer.PageWidth,
    (int)ReceiptDocumentRenderer.PageHeight,
    PixelFormat.Format24bppRgb))
            {
                // 不要用 300 DPI
                bmp.SetResolution(96f, 96f);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);

                    g.PageUnit = GraphicsUnit.Pixel;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.TextRenderingHint =
                        System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                    ReceiptDocumentRenderer.Draw(
                        g,
                        new RectangleF(
                            0,
                            0,
                            bmp.Width,
                            bmp.Height),
                        receipt);
                }

                bmp.Save(filePath, ImageFormat.Jpeg);
            }

            return filePath;
        }
    }
}