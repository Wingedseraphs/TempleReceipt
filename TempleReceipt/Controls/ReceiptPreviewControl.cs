using System.Windows.Forms;

namespace TempleReceipt.Controls
{
    /// <summary>
    /// 收據預覽控制項
    /// 後續會負責繪製收據內容與列印預覽。
    /// </summary>
    public class ReceiptPreviewControl : UserControl
    {
        public ReceiptPreviewControl()
        {
            DoubleBuffered = true;
        }
    }
}