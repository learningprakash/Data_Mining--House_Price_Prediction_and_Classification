namespace ID3DecisionTree
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.graphPlotter1 = new ID3DecisionTree.GraphPlotter();
            this.graphMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyText = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyImage = new System.Windows.Forms.ToolStripMenuItem();
            this.exportImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opnFile = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.graphMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.Color.White;
            this.txtOutput.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(17, 17);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(496, 291);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.Text = "";
            this.txtOutput.WordWrap = false;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(17, 25);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.lblFileName);
            this.GroupBox1.Controls.Add(this.btnOpenFile);
            this.GroupBox1.Location = new System.Drawing.Point(12, 9);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(620, 70);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Input";
            // 
            // lblFileName
            // 
            this.lblFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFileName.Location = new System.Drawing.Point(108, 25);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(494, 23);
            this.lblFileName.TabIndex = 1;
            this.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRun
            // 
            this.btnRun.Enabled = false;
            this.btnRun.Location = new System.Drawing.Point(638, 13);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(121, 66);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.graphPlotter1);
            this.GroupBox2.Controls.Add(this.txtOutput);
            this.GroupBox2.Location = new System.Drawing.Point(12, 85);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(746, 396);
            this.GroupBox2.TabIndex = 5;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Output Tree";
            // 
            // graphPlotter1
            // 
            this.graphPlotter1.AutoScroll = true;
            this.graphPlotter1.BackColor = System.Drawing.Color.White;
            this.graphPlotter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.graphPlotter1.ContextMenuStrip = this.graphMenu;
            this.graphPlotter1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.graphPlotter1.LineColor = System.Drawing.Color.Black;
            this.graphPlotter1.LineTextBackColor = System.Drawing.Color.White;
            this.graphPlotter1.LineTextForeColor = System.Drawing.Color.Black;
            this.graphPlotter1.LineThickness = 2F;
            this.graphPlotter1.Location = new System.Drawing.Point(17, 17);
            this.graphPlotter1.Name = "graphPlotter1";
            this.graphPlotter1.NodeBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.graphPlotter1.NodeBorderThickness = 5F;
            this.graphPlotter1.NodeColor = System.Drawing.Color.Maroon;
            this.graphPlotter1.OffsetNodeString = 12;
            this.graphPlotter1.OffsetX = 100;
            this.graphPlotter1.OffsetY = 20;
            this.graphPlotter1.Size = new System.Drawing.Size(711, 349);
            this.graphPlotter1.TabIndex = 7;
            this.graphPlotter1.DoubleClick += new System.EventHandler(this.graphPlotter1_DoubleClick);
            this.graphPlotter1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.graphPlotter1_MouseDown);
            // 
            // graphMenu
            // 
            this.graphMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyText,
            this.toolStripMenuItem1,
            this.copyImage,
            this.exportImage,
            this.toolStripMenuItem2,
            this.fullScreenToolStripMenuItem});
            this.graphMenu.Name = "graphMenu";
            this.graphMenu.Size = new System.Drawing.Size(162, 104);
            // 
            // copyText
            // 
            this.copyText.Name = "copyText";
            this.copyText.Size = new System.Drawing.Size(161, 22);
            this.copyText.Text = "Copy Text Mode";
            this.copyText.Click += new System.EventHandler(this.copyText_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
            // 
            // copyImage
            // 
            this.copyImage.Name = "copyImage";
            this.copyImage.Size = new System.Drawing.Size(161, 22);
            this.copyImage.Text = "Copy Image";
            this.copyImage.Click += new System.EventHandler(this.copyImage_Click);
            // 
            // exportImage
            // 
            this.exportImage.Name = "exportImage";
            this.exportImage.Size = new System.Drawing.Size(161, 22);
            this.exportImage.Text = "Export Image";
            this.exportImage.Click += new System.EventHandler(this.exportImage_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(158, 6);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.fullScreenToolStripMenuItem.Text = "Full Screen";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // opnFile
            // 
            this.opnFile.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(12, 484);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(746, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Shrada Pradhan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveFile
            // 
            this.saveFile.Filter = "JPEG files (*.jpg,*.jpeg)|*.jpg";
            this.saveFile.Title = "Export Image";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 515);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Decision Tree ID3 Algorithm";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.graphMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.RichTextBox txtOutput;
        internal System.Windows.Forms.Button btnOpenFile;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label lblFileName;
        internal System.Windows.Forms.Button btnRun;
        internal System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.OpenFileDialog opnFile;
        private GraphPlotter graphPlotter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip graphMenu;
        private System.Windows.Forms.ToolStripMenuItem copyText;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyImage;
        private System.Windows.Forms.ToolStripMenuItem exportImage;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
    }
}

