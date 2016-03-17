using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ID3DecisionTree
{
    public partial class FrmMain : Form
    {
        string inputFileName = string.Empty;
        Random random = new Random();

        FullScreen fs = new FullScreen();
        frmSelectTable selectTable = new frmSelectTable();

        ID3TreeNode root;

        DataTable mainDataset = new DataTable();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (opnFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mainDataset = new DataTable();
                txtOutput.Clear();
                graphPlotter1.SetSourceNode(null);
                fs = new ID3DecisionTree.FullScreen();
                selectTable = new frmSelectTable();
                btnRun.Enabled = true;
                inputFileName = opnFile.FileName;
                mainDataset = GetDatatable(inputFileName);
            }
           
            lblFileName.Text = inputFileName;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            DecisionTree tree = new DecisionTree();
            selectTable.MainDataset = mainDataset;
            if (selectTable.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bool hasContinuousValue = selectTable.IsDataContainsContinuousValue;
                string tAttribute = selectTable.SelectedAttribute;
                txtOutput.Clear();
                
                graphPlotter1.SetSourceNode(null);
                //try
                //{
                    tree.TargetAttribute = tAttribute;
                    //string[] lists = { "temperature", "humidity" };
                    DataTable myTable = mainDataset;
                    
                    if (hasContinuousValue)
                    {
                        Dictionary<string, string> a = selectTable.ColumnDataTypes;
                        myTable = GetBestPartitionedTable(myTable, a, tree);
                    }
                    List<Attribute> attributes = new List<Attribute>();

                    foreach (DataColumn column in myTable.Columns)
                    {
                        //if (column != myTable.Columns[myTable.Columns.Count - 1])
                        {
                            string[] dValue = GetDistinctValues(myTable, column);
                            Attribute attr = new Attribute(column.ColumnName, dValue);
                            attributes.Add(attr);
                        }
                    }

                    root = tree.mountTree(myTable, tAttribute, attributes.ToArray());
                    
                    PrintTree(root, "", GetColor());
                    graphPlotter1.SetSourceNode(root);
                    graphPlotter1.Focus();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

        private void DrawTree(ID3TreeNode root)
        {
            
        }
        private void PrintTree(ID3TreeNode root, string indent,Color textColor)
        {
            txtOutput.Text += root.attribute + Environment.NewLine;
            if (root.attribute.values != null)
            {
                for (int i = 0; i < root.attribute.values.Length; i++)
                {
                    txtOutput.Text += indent;
                    string write = string.Format("|---- {0} ----",root.attribute.values[i]);
                    txtOutput.Text += write;
                    ID3TreeNode childNode = root.getChildByBranchName(root.attribute.values[i]);
                    PrintTree(childNode, indent + "".PadRight(write.Length,' '), GetColor() );
                }
            }
        }

        private DataTable UpdateTable(DataTable table, string column, int partitionPoint)
        {
            DataTable finalTable = table.Copy();
            string item = column;
            foreach (DataRow rows in finalTable.Rows)
            {
                if (Convert.ToInt32(rows[item].ToString()) <= partitionPoint)
                {
                    rows[item] = "<=" + partitionPoint.ToString();
                }
                else
                {
                    rows[item] = ">" + partitionPoint.ToString();
                }
            }
            return finalTable;
        }

        private DataTable GetDatatable(string csvFilePath)
        {
            GenericParsing.GenericParserAdapter adapter = new GenericParsing.GenericParserAdapter(csvFilePath);
            adapter.FirstRowHasHeader = true;
            return adapter.GetDataTable();
        }

        private string[] GetDistinctValues(DataTable table, DataColumn column)
        {
            DataView view = new DataView(table);
            DataTable newTable = view.ToTable(true, column.ColumnName);
            return newTable.AsEnumerable().Select(x => x[column.ColumnName].ToString()).ToArray();
        }

        private Color GetColor()
        {
            
            return Color.FromArgb(random.Next(200), random.Next(200), random.Next(200));
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void graphPlotter1_DoubleClick(object sender, EventArgs e)
        {
            FullScreen();
        }

        private void FullScreen()
        {
            fs.Plotter.SetSourceNode(root);
            if (fs.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                fs.Plotter.SetSourceNode(null);
            }
        }
        private void copyText_Click(object sender, EventArgs e)
        {
            
            Clipboard.SetText(txtOutput.Text);
        }

        private void copyImage_Click(object sender, EventArgs e)
        {
            Bitmap bitMap = new Bitmap(graphPlotter1.PictureBox.Width, graphPlotter1.PictureBox.Height);
            
            Rectangle bound = graphPlotter1.PictureBox.Bounds;
            bound.X = 0;
            bound.Y = 0;
            bitMap.SetResolution(600, 600);
            graphPlotter1.PictureBox.DrawToBitmap(bitMap, bound);

            MemoryStream stream = new MemoryStream();
            bitMap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

            Image img = Image.FromStream(stream);
            Clipboard.SetImage(img);
            stream.Close();
            
        }

        private void exportImage_Click(object sender, EventArgs e)
        {
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap bitMap = new Bitmap(graphPlotter1.PictureBox.Width, graphPlotter1.PictureBox.Height);
                Rectangle bound = graphPlotter1.PictureBox.Bounds;
                bound.X =0;
                bound.Y = 0;
                bitMap.SetResolution(600, 600);
                graphPlotter1.PictureBox.DrawToBitmap(bitMap, bound);

                bitMap.Save(saveFile.FileName, System.Drawing.Imaging.ImageFormat.Jpeg );
            }
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FullScreen();
        }

        private void graphPlotter1_MouseDown(object sender, MouseEventArgs e)
        {
            graphPlotter1.Focus();
        }
       
        private DataTable GetBestPartitionedTable(DataTable dt, Dictionary<string,string> columnsDataType, DecisionTree  tree)
        {
            DataTable dataTable = dt.Copy();
            foreach (KeyValuePair<string,string> pair in columnsDataType)
            {
                string column = pair.Key;
                string dataType = pair.Value;

                DataView dv = new DataView(dataTable);
                dv.Sort = column;

                DataTable dataTableSingleCol = dv.ToTable(true, column);
                dynamic mainPartitionPoint = 0;

                double maxgain = double.MinValue;
                bool first = true;

                DataTable upper = new DataTable();
                foreach (DataRow rows in dataTableSingleCol.Rows)
                {

                    dynamic partitionPoint = 0;
                    if(dataType =="System.Int32")
                        partitionPoint = Convert.ToInt32(rows[column]);
                    if (dataType == "System.Int64")
                        partitionPoint = Convert.ToInt64(rows[column]);
                    if (dataType == "System.Single")
                        partitionPoint = Convert.ToSingle(rows[column]);
                    if (dataType == "System.Double")
                        partitionPoint = Convert.ToDouble(rows[column]);
                    if (dataType == "System.Decimal")
                        partitionPoint = Convert.ToDecimal(rows[column]);
                    
                    upper = dataTable.Copy();
                    
                    foreach (DataRow r in upper.Rows)
                    {
                        dynamic p = 0;
                        if (dataType == "System.Int32")
                            p = Convert.ToInt32(r[column]);
                        if (dataType == "System.Int64")
                            p = Convert.ToInt64(r[column]);
                        if (dataType == "System.Single")
                            p = Convert.ToSingle(r[column]);
                        if (dataType == "System.Double")
                            p = Convert.ToDouble(r[column]);
                        if (dataType == "System.Decimal")
                            p = Convert.ToDecimal(r[column]);

                        if (p <= partitionPoint)
                        {
                            r[column] = "<=" + partitionPoint.ToString();
                        }
                        else
                        {
                            r[column] = ">" + partitionPoint.ToString();
                        }
                    }

                    
                    string[] dval = GetDistinctValues(upper, new DataColumn(column));
                    Attribute attr = new Attribute(column, dval);

                    double gain = tree.gain(upper, attr);
                    if (first)
                    {
                        maxgain = gain;
                        mainPartitionPoint = partitionPoint;
                        first = false;
                    }
                    if (gain > maxgain)
                    {
                        mainPartitionPoint = partitionPoint;
                        maxgain = gain;
                    }
                }

                foreach (DataRow r in dataTable.Rows)
                {
                    dynamic p = 0;
                    if (dataType == "System.Int32")
                        p = Convert.ToInt32(r[column]);
                    if (dataType == "System.Int64")
                        p = Convert.ToInt64(r[column]);
                    if (dataType == "System.Single")
                        p = Convert.ToSingle(r[column]);
                    if (dataType == "System.Double")
                        p = Convert.ToDouble(r[column]);
                    if (dataType == "System.Decimal")
                        p = Convert.ToDecimal(r[column]);

                    if (p <= mainPartitionPoint)
                    {
                        r[column] = "<=" + mainPartitionPoint.ToString();
                    }
                    else
                    {
                        r[column] = ">" + mainPartitionPoint.ToString();
                    }
                }
                
                

            }
            return dataTable;
            
        }
    }
}
