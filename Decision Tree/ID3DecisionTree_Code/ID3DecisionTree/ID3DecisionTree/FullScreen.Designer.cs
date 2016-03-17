namespace ID3DecisionTree
{
    partial class FullScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.graphPlotter1 = new ID3DecisionTree.GraphPlotter();
            this.SuspendLayout();
            // 
            // graphPlotter1
            // 
            this.graphPlotter1.AutoScroll = true;
            this.graphPlotter1.BackColor = System.Drawing.Color.White;
            this.graphPlotter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.graphPlotter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphPlotter1.ForeColor = System.Drawing.Color.White;
            this.graphPlotter1.LineColor = System.Drawing.Color.Black;
            this.graphPlotter1.LineTextBackColor = System.Drawing.Color.White;
            this.graphPlotter1.LineTextForeColor = System.Drawing.Color.Black;
            this.graphPlotter1.LineThickness = 2F;
            this.graphPlotter1.Location = new System.Drawing.Point(0, 0);
            this.graphPlotter1.Name = "graphPlotter1";
            this.graphPlotter1.NodeBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.graphPlotter1.NodeBorderThickness = 5F;
            this.graphPlotter1.NodeColor = System.Drawing.Color.Maroon;
            this.graphPlotter1.OffsetNodeString = 12;
            this.graphPlotter1.OffsetX = 100;
            this.graphPlotter1.OffsetY = 20;
            this.graphPlotter1.Size = new System.Drawing.Size(284, 261);
            this.graphPlotter1.TabIndex = 0;
            // 
            // FullScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.graphPlotter1);
            this.Name = "FullScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "b ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FullScreen_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private GraphPlotter graphPlotter1;
    }
}