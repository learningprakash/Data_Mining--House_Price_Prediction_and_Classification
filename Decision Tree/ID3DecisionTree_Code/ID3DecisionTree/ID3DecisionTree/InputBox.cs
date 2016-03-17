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
    public partial class InputBox : Form
    {
        public String InputText
        {

            get
            {
                return this.txtInput.Text;
            }
            set
            {
                this.txtInput.Text = value;
            }
        }
        public InputBox()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void InputBox_Load(object sender, EventArgs e)
        {
            txtInput.Focus();
        }
    }
}
