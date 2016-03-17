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
    public partial class GraphPlotter : UserControl
    {
        public PictureBox PictureBox { get { return pictureBox1; } }
        int top = 0;
        int left = 0;
        int width = 0;
        int height = 0;
        ID3TreeNode _root;

        int _offsetY = 20;
        int _offsetX = 50;
        int _offsetNodeString = 20;

        float nodeBorderThickness = 2;
        float lineThickness = 2;
 
        Padding _padding = new Padding(10);

        Color nodeBorderColor = Color.Black;
        Color nodeColor = Color.Black;
        Color lineColor = Color.Black;
        Color lineTextForeColor = Color.Black;
        Color lineTextBackColor = Color.White;

        public int OffsetY { set { _offsetY = value; pictureBox1.Invalidate(); } get { return _offsetY; } }
        public int OffsetX { set { _offsetX = value; pictureBox1.Invalidate(); } get { return _offsetX; } }
        public Padding Padding { get { return _padding; } set { _padding = value; pictureBox1.Invalidate(); } }
        public int OffsetNodeString { get { return _offsetNodeString; } set { _offsetNodeString = value; pictureBox1.Invalidate(); } }
        public float NodeBorderThickness { get { return nodeBorderThickness; } set { nodeBorderThickness = value; pictureBox1.Invalidate(); } }
        public float LineThickness { get { return lineThickness; } set { lineThickness = value; pictureBox1.Invalidate(); } }

        public Color NodeBorderColor { get { return nodeBorderColor; } set { nodeBorderColor = value; pictureBox1.Invalidate(); } }
        public Color NodeColor { get { return nodeColor; } set { nodeColor = value; pictureBox1.Invalidate(); } }
        public Color LineColor { get { return lineColor; } set { lineColor = value; pictureBox1.Invalidate(); } }
        public Color LineTextForeColor { get { return lineTextForeColor; } set { lineTextForeColor = value; pictureBox1.Invalidate(); } }
        public Color LineTextBackColor { get { return lineTextBackColor; } set { lineTextBackColor = value; pictureBox1.Invalidate(); } }


        public GraphPlotter()
        {
            InitializeComponent();
        }
        public void SetSourceNode(ID3TreeNode rootNode)
        {
            _root = rootNode;
            pictureBox1.Invalidate();
            
        }

        private void DrawNodes(ID3TreeNode node, Graphics g, Rectangle location, string lineText, Rectangle? parentLocation, bool isFirst)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            SizeF size = g.MeasureString(node.attribute.ToString(), this.Font);
            int strWidth = Convert.ToInt32( g.MeasureString(node.attribute.ToString(), this.Font).Width);
            int strHeight = Convert.ToInt32(g.MeasureString(node.attribute.ToString(), this.Font).Height);

            location = new Rectangle(location.Left, location.Top, strWidth + (_offsetNodeString * 2), strHeight + (_offsetNodeString * 2));

            top = location.Y;
            height = top + location.Height;
            if (node.attribute.values == null)
            {
                g.DrawRectangle(new Pen(nodeBorderColor,nodeBorderThickness), location);
                g.FillRectangle(new SolidBrush(nodeColor), location);
            }
            else
            {
                g.DrawEllipse(new Pen(nodeBorderColor, nodeBorderThickness), location);
                g.FillEllipse(new SolidBrush(nodeColor), location);
            }

            if (!isFirst)
            {
                g.DrawLine(new Pen(lineColor, lineThickness), GetMidPoint(location), AdjustLeft(location, parentLocation.Value.Width / 2 + _offsetX));

                SizeF lTextSize = g.MeasureString(lineText,this.Font);
                Point stringStartPoint = GetStringPoint(lTextSize, GetMidPoint(location), AdjustLeft(location, parentLocation.Value.Width / 2 + _offsetX));
                Rectangle rect = new Rectangle(stringStartPoint.X - 5, stringStartPoint.Y - 5, Convert.ToInt32( lTextSize.Width +10), Convert.ToInt32( lTextSize.Height + 10));
                g.DrawRectangle(new Pen(Color.Black), rect);
                g.FillRectangle(new SolidBrush(lineTextBackColor), rect);
                g.DrawString(lineText, this.Font, new SolidBrush(lineTextForeColor), stringStartPoint );
            }
            g.DrawString(node.attribute.ToString(), this.Font, new SolidBrush(this.ForeColor), GetPoint(size, location));
            
            left = Math.Max(left, location.Left);
            
            width = Math.Max(width, location.Left + location.Width);
            
            Rectangle nLocation = new Rectangle(location.X + location.Width + _offsetX, location.Y + location.Height + _offsetY, 50, 50);
            
            if (node.attribute.values != null)
            {
                for (int i = 0; i < node.attribute.values.Length; i++)
                {
                    ID3TreeNode n = node.getChild(i);
                    DrawNodes(n, g, nLocation, node.attribute.values[i], location, false);

                    if (i == node.attribute.values.Length - 1)
                    {
                        int x = location.X + location.Width/2;
                        int y = location.Y + location.Height;

                        int y2 = nLocation.Y + location.Height/2;
                        g.DrawLine(new Pen(lineColor, lineThickness), new Point(x, y), new Point(x, y2));
                    }
                    nLocation = new Rectangle(location.X + location.Width + _offsetX, top + location.Height + _offsetY, 50, 50);
                }
            }
        }

        private Point GetStringPoint(SizeF size, Point first, Point second)
        {
            int x = second.X+((first.X - second.X) - Convert.ToInt32(size.Width)) / 2;
            int y = first.Y - Convert.ToInt32((size.Height / 2));
            return new Point(x, y);
        }
        private Rectangle AddPadding(Rectangle rect, Padding pad)
        {
            int x = rect.Left + pad.Left;
            int y = rect.Top + pad.Top;
            return new Rectangle(x, y, rect.Width, rect.Height);
        }

        private Point AdjustLeft(Rectangle rect, int distance)
        {
            int y = rect.Top + (rect.Height / 2);
            int x = rect.Left - distance;
            return new Point(x, y);
        }
        private Point GetMidPoint(Rectangle rect)
        {
            int y = rect.Top + (rect.Height / 2);
            return new Point(rect.Left, y);
        }
        
        private PointF GetPoint(SizeF size, Rectangle rect)
        {
            //PointF p = new PointF();
            float top = (rect.Height - size.Height) / 2.0f;
            float left = (rect.Width - size.Width) / 2.0f;
            return new PointF(left + rect.Left, top + rect.Top);

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (_root != null)
            {
                try
                {
                    DrawNodes(_root, e.Graphics, new Rectangle(_padding.Left, _padding.Top, 0, 0),"",null,true);
                    pictureBox1.Height = height + _padding.Bottom;
                    pictureBox1.Width = width + _padding.Right;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            this.OnDoubleClick(e);
        }
    }
}
