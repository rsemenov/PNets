namespace PNets.WFClient
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.AnalizeButton = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.PropertiesTab = new System.Windows.Forms.TabPage();
            this.CoverageTreeTab = new System.Windows.Forms.TabPage();
            this.gViewer1 = new Microsoft.Glee.GraphViewerGdi.GViewer();
            this.FullCoverageTreeTab = new System.Windows.Forms.TabPage();
            this.gViewer2 = new Microsoft.Glee.GraphViewerGdi.GViewer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.PropertiesTab.SuspendLayout();
            this.CoverageTreeTab.SuspendLayout();
            this.FullCoverageTreeTab.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.AnalizeButton);
            this.panel1.Controls.Add(this.UploadButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 65);
            this.panel1.TabIndex = 0;
            // 
            // AnalizeButton
            // 
            this.AnalizeButton.Location = new System.Drawing.Point(84, 12);
            this.AnalizeButton.Name = "AnalizeButton";
            this.AnalizeButton.Size = new System.Drawing.Size(75, 47);
            this.AnalizeButton.TabIndex = 1;
            this.AnalizeButton.Text = "Аналіз";
            this.AnalizeButton.UseVisualStyleBackColor = true;
            this.AnalizeButton.Click += new System.EventHandler(this.AnalizeButton_Click);
            // 
            // UploadButton
            // 
            this.UploadButton.Location = new System.Drawing.Point(3, 12);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(75, 47);
            this.UploadButton.TabIndex = 0;
            this.UploadButton.Text = "Відкрити";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TabControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(741, 460);
            this.panel2.TabIndex = 1;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.PropertiesTab);
            this.TabControl.Controls.Add(this.CoverageTreeTab);
            this.TabControl.Controls.Add(this.FullCoverageTreeTab);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(741, 460);
            this.TabControl.TabIndex = 0;
            // 
            // PropertiesTab
            // 
            this.PropertiesTab.Controls.Add(this.panel4);
            this.PropertiesTab.Controls.Add(this.panel3);
            this.PropertiesTab.Location = new System.Drawing.Point(4, 22);
            this.PropertiesTab.Name = "PropertiesTab";
            this.PropertiesTab.Padding = new System.Windows.Forms.Padding(3);
            this.PropertiesTab.Size = new System.Drawing.Size(733, 434);
            this.PropertiesTab.TabIndex = 1;
            this.PropertiesTab.Text = "Властивості";
            this.PropertiesTab.UseVisualStyleBackColor = true;
            // 
            // CoverageTreeTab
            // 
            this.CoverageTreeTab.Controls.Add(this.gViewer1);
            this.CoverageTreeTab.Location = new System.Drawing.Point(4, 22);
            this.CoverageTreeTab.Name = "CoverageTreeTab";
            this.CoverageTreeTab.Padding = new System.Windows.Forms.Padding(3);
            this.CoverageTreeTab.Size = new System.Drawing.Size(733, 434);
            this.CoverageTreeTab.TabIndex = 0;
            this.CoverageTreeTab.Text = "Дерево покриття";
            this.CoverageTreeTab.UseVisualStyleBackColor = true;
            // 
            // gViewer1
            // 
            this.gViewer1.AsyncLayout = false;
            this.gViewer1.AutoScroll = true;
            this.gViewer1.BackwardEnabled = false;
            this.gViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gViewer1.ForwardEnabled = false;
            this.gViewer1.Graph = null;
            this.gViewer1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gViewer1.Location = new System.Drawing.Point(3, 3);
            this.gViewer1.MouseHitDistance = 0.05D;
            this.gViewer1.Name = "gViewer1";
            this.gViewer1.NavigationVisible = false;
            this.gViewer1.PanButtonPressed = true;
            this.gViewer1.SaveButtonVisible = true;
            this.gViewer1.Size = new System.Drawing.Size(727, 428);
            this.gViewer1.TabIndex = 2;
            this.gViewer1.ZoomF = 1D;
            this.gViewer1.ZoomFraction = 0.5D;
            this.gViewer1.ZoomWindowThreshold = 0.05D;
            // 
            // FullCoverageTreeTab
            // 
            this.FullCoverageTreeTab.Controls.Add(this.gViewer2);
            this.FullCoverageTreeTab.Location = new System.Drawing.Point(4, 22);
            this.FullCoverageTreeTab.Name = "FullCoverageTreeTab";
            this.FullCoverageTreeTab.Size = new System.Drawing.Size(733, 434);
            this.FullCoverageTreeTab.TabIndex = 2;
            this.FullCoverageTreeTab.Text = "Повне дерево покриття";
            this.FullCoverageTreeTab.UseVisualStyleBackColor = true;
            // 
            // gViewer2
            // 
            this.gViewer2.AsyncLayout = false;
            this.gViewer2.AutoScroll = true;
            this.gViewer2.BackwardEnabled = false;
            this.gViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gViewer2.ForwardEnabled = false;
            this.gViewer2.Graph = null;
            this.gViewer2.Location = new System.Drawing.Point(0, 0);
            this.gViewer2.MouseHitDistance = 0.05D;
            this.gViewer2.Name = "gViewer2";
            this.gViewer2.NavigationVisible = false;
            this.gViewer2.PanButtonPressed = false;
            this.gViewer2.SaveButtonVisible = true;
            this.gViewer2.Size = new System.Drawing.Size(733, 434);
            this.gViewer2.TabIndex = 0;
            this.gViewer2.ZoomF = 1D;
            this.gViewer2.ZoomFraction = 0.5D;
            this.gViewer2.ZoomWindowThreshold = 0.05D;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(336, 428);
            this.panel3.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Property,
            this.Value});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(336, 428);
            this.dataGridView1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.listBox2);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.listBox1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(339, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(391, 428);
            this.panel4.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 7, 0, 7);
            this.label1.Size = new System.Drawing.Size(78, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "S інваріанти";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(391, 186);
            this.listBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 213);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(10, 7, 0, 7);
            this.label2.Size = new System.Drawing.Size(78, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "T інваріанти";
            // 
            // listBox2
            // 
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(0, 240);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(391, 188);
            this.listBox2.TabIndex = 3;
            // 
            // Property
            // 
            this.Property.HeaderText = "Властивість";
            this.Property.Name = "Property";
            this.Property.Width = 140;
            // 
            // Value
            // 
            this.Value.HeaderText = "Значення";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 150;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 525);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "PNets";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.PropertiesTab.ResumeLayout(false);
            this.CoverageTreeTab.ResumeLayout(false);
            this.FullCoverageTreeTab.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.Button AnalizeButton;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage PropertiesTab;
        private System.Windows.Forms.TabPage CoverageTreeTab;
        private Microsoft.Glee.GraphViewerGdi.GViewer gViewer1;
        private System.Windows.Forms.TabPage FullCoverageTreeTab;
        private Microsoft.Glee.GraphViewerGdi.GViewer gViewer2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;

    }
}

