using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static LiveSplit.ItTakesTwo.ItTakesTwoStatics;

namespace LiveSplit.ItTakesTwo {
    public partial class ItTakesTwoSplitSettings : UserControl {
        public SplitName? Split { get; set; }
        private int mX = 0;
        private int mY = 0;
        private bool isDragging = false;
        public ItTakesTwoSplitSettings() {
            InitializeComponent();
            cboName.MouseWheel += (o, e) => ((HandledMouseEventArgs)e).Handled = true;
        }

        private void picHandle_MouseMove(object sender, MouseEventArgs e) {
            if (!isDragging) {
                if (e.Button == MouseButtons.Left) {
                    int num1 = mX - e.X;
                    int num2 = mY - e.Y;
                    if (((num1 * num1) + (num2 * num2)) > 20) {
                        DoDragDrop(this, DragDropEffects.All);
                        isDragging = true;
                        return;
                    }
                }
            }
        }
        private void picHandle_MouseDown(object sender, MouseEventArgs e) {
            mX = e.X;
            mY = e.Y;
            isDragging = false;
        }
    }
}
