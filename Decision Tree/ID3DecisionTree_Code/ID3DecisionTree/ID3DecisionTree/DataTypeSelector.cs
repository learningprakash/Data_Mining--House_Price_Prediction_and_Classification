using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ID3DecisionTree
{
    public partial class DataTypeSelector : UserControl
    {
        public string Text
        {
            get
            {
                return lblText.Text;
            }
            set
            {
                lblText.Text = value;
            }
        }

        public string Value
        {
            get
            {
                if(cmbDataType.SelectedIndex >= 0)
                    return (string)cmbDataType.SelectedItem;
                return "";
            }
        }
        public DataTypeSelector()
        {
            InitializeComponent();
        }
    }
}
