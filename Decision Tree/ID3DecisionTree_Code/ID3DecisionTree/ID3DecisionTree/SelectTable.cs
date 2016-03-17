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
    public partial class frmSelectTable : Form
    {
        List<DataTypeSelector> dataTypes = new List<DataTypeSelector>();

        public Dictionary<string, string> ColumnDataTypes
        {
            get
            {
                Dictionary<string, string> ret = new Dictionary<string, string>();
                foreach (Control c in FlowPanel.Controls)
                {
                    if (((DataTypeSelector)c).Value != "")
                    {
                        ret.Add(((DataTypeSelector)c).Text, ((DataTypeSelector)c).Value);
                    }
                }
                return ret;
            }
        }
        public string SelectedAttribute { get { return (string)cmbAttributes.SelectedItem; } }

        public bool IsDataContainsContinuousValue { get { return chkContinuous.Checked; } }

        public DataTable MainDataset { get; set; }

        public frmSelectTable()
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

        private void frmSelectTable_Load(object sender, EventArgs e)
        {
            LoadAttributes();
            LoadDataTypes();
            chkContinuous.Checked = false;
            FlowPanel.Enabled = false;
        }

        private void LoadDataTypes()
        {
            FlowPanel.Controls.Clear();
            foreach (DataColumn dc in MainDataset.Columns)
            {
                DataTypeSelector selector = new DataTypeSelector();
                selector.Text = dc.ColumnName;
                FlowPanel.Controls.Add(selector);
            }
        }

        private void LoadAttributes()
        {
            cmbAttributes.Items.Clear();
            foreach (DataColumn dc in MainDataset.Columns)
            {
                cmbAttributes.Items.Add(dc.ColumnName);
            }
            cmbAttributes.SelectedIndex = 0;
        }

        private void chkContinuous_CheckedChanged(object sender, EventArgs e)
        {
            FlowPanel.Enabled = chkContinuous.Checked;
        }
    }
}
