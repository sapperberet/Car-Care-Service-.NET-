using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ElipseToolDemo
{
        [ToolboxBitmap(typeof(ElipseControl), "ElipseControl.bmp")]
    [ToolboxItem(true)]
    public class ElipseControl : Control
    {
        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        private Control _cntrl; // Nullable to avoid warnings
        private int _CornerRadius = 30;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control TargetControl
        {
            get { return _cntrl; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                _cntrl = value;
                _cntrl.SizeChanged += (sender, eventArgs) =>
                {
                    _cntrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _cntrl.Width, _cntrl.Height, _CornerRadius, _CornerRadius));
                };
            }
        }
        public ElipseControl()
        {
            // Default initialization
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CornerRadius
        {
            get { return _CornerRadius; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "CornerRadius must be non-negative.");
                _CornerRadius = value;
                if (_cntrl != null)
                    _cntrl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, _cntrl.Width, _cntrl.Height, _CornerRadius, _CornerRadius));
            }
        }
    }
}
