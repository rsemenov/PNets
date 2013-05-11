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
            this.panel2 = new System.Windows.Forms.Panel();
            this.UploadButton = new System.Windows.Forms.Button();
            this.AnalizeButton = new System.Windows.Forms.Button();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.CoverageTreeTab = new System.Windows.Forms.TabPage();
            this.PropertiesTab = new System.Windows.Forms.TabPage();
            this.gViewer1 = new Microsoft.Glee.GraphViewerGdi.GViewer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullCoverageTreeTab = new System.Windows.Forms.TabPage();
            this.gViewer2 = new Microsoft.Glee.GraphViewerGdi.GViewer();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.CoverageTreeTab.SuspendLayout();
            this.PropertiesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.FullCoverageTreeTab.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(727, 65);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TabControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(727, 459);
            this.panel2.TabIndex = 1;
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
            // TabControl
            // 
            this.TabControl.Controls.Add(this.PropertiesTab);
            this.TabControl.Controls.Add(this.CoverageTreeTab);
            this.TabControl.Controls.Add(this.FullCoverageTreeTab);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(727, 459);
            this.TabControl.TabIndex = 0;
            // 
            // CoverageTreeTab
            // 
            this.CoverageTreeTab.Controls.Add(this.gViewer1);
            this.CoverageTreeTab.Location = new System.Drawing.Point(4, 22);
            this.CoverageTreeTab.Name = "CoverageTreeTab";
            this.CoverageTreeTab.Padding = new System.Windows.Forms.Padding(3);
            this.CoverageTreeTab.Size = new System.Drawing.Size(719, 433);
            this.CoverageTreeTab.TabIndex = 0;
            this.CoverageTreeTab.Text = "Дерево покриття";
            this.CoverageTreeTab.UseVisualStyleBackColor = true;
            // 
            // PropertiesTab
            // 
            this.PropertiesTab.Controls.Add(this.dataGridView1);
            this.PropertiesTab.Location = new System.Drawing.Point(4, 22);
            this.PropertiesTab.Name = "PropertiesTab";
            this.PropertiesTab.Padding = new System.Windows.Forms.Padding(3);
            this.PropertiesTab.Size = new System.Drawing.Size(719, 433);
            this.PropertiesTab.TabIndex = 1;
            this.PropertiesTab.Text = "Властивості";
            this.PropertiesTab.UseVisualStyleBackColor = true;
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
            this.gViewer1.PanButtonPressed = false;
            this.gViewer1.SaveButtonVisible = false;
            this.gViewer1.Size = new System.Drawing.Size(713, 427);
            this.gViewer1.TabIndex = 2;
            this.gViewer1.ZoomF = 1D;
            this.gViewer1.ZoomFraction = 0.5D;
            this.gViewer1.ZoomWindowThreshold = 0.05D;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Property,
            this.Value});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(713, 427);
            this.dataGridView1.TabIndex = 2;
            // 
            // Property
            // 
            this.Property.HeaderText = "Властивість";
            this.Property.Name = "Property";
            // 
            // Value
            // 
            this.Value.HeaderText = "Значення";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // FullCoverageTreeTab
            // 
            this.FullCoverageTreeTab.Controls.Add(this.gViewer2);
            this.FullCoverageTreeTab.Location = new System.Drawing.Point(4, 22);
            this.FullCoverageTreeTab.Name = "FullCoverageTreeTab";
            this.FullCoverageTreeTab.Size = new System.Drawing.Size(719, 433);
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
            this.gViewer2.NavigationVisible = true;
            this.gViewer2.PanButtonPressed = false;
            this.gViewer2.SaveButtonVisible = true;
            this.gViewer2.Size = new System.Drawing.Size(719, 433);
            this.gViewer2.TabIndex = 0;
            this.gViewer2.ZoomF = 1D;
            this.gViewer2.ZoomFraction = 0.5D;
            this.gViewer2.ZoomWindowThreshold = 0.05D;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 524);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.CoverageTreeTab.ResumeLayout(false);
            this.PropertiesTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.FullCoverageTreeTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.Button AnalizeButton;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage PropertiesTab;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.TabPage CoverageTreeTab;
        private Microsoft.Glee.GraphViewerGdi.GViewer gViewer1;
        private System.Windows.Forms.TabPage FullCoverageTreeTab;
        private Microsoft.Glee.GraphViewerGdi.GViewer gViewer2;

    }
}

