using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ID3DecisionTree
{
    public partial class FullScreen : Form
    {
        public GraphPlotter Plotter { get { return graphPlotter1; } }
        public FullScreen()
        {
            InitializeComponent();
        }

        private void FullScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
