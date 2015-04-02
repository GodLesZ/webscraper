using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace GodLesZ.Tools.WebScraper.Components {
    public class ToolStripSpringTextBox : ToolStripTextBox {
        public override Size GetPreferredSize(Size constrainingSize) {
            if (IsOnOverflow || Owner.Orientation == Orientation.Vertical)
                return DefaultSize;
            var num1 = Owner.DisplayRectangle.Width;
            if (Owner.OverflowButton.Visible)
                num1 = num1 - Owner.OverflowButton.Width - Owner.OverflowButton.Margin.Horizontal;
            var num2 = 0;
            foreach (ToolStripItem toolStripItem in Owner.Items) {
                if (!toolStripItem.IsOnOverflow) {
                    if (toolStripItem is ToolStripSpringTextBox) {
                        ++num2;
                        num1 -= toolStripItem.Margin.Horizontal;
                    } else
                        num1 = num1 - toolStripItem.Width - toolStripItem.Margin.Horizontal;
                }
            }
            if (num2 > 1)
                num1 /= num2;
            if (num1 < DefaultSize.Width)
                num1 = DefaultSize.Width;
            var preferredSize = base.GetPreferredSize(constrainingSize);
            preferredSize.Width = num1;
            return preferredSize;
        }
    }
}
