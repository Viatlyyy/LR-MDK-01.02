using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class BufferedFlowLayoutPanel : FlowLayoutPanel
    {
        // Windows draws the panel and its child controls in one buffer.
        private const int WsExComposited = 0x02000000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parameters = base.CreateParams;
                parameters.ExStyle |= WsExComposited;
                return parameters;
            }
        }
    }
}
