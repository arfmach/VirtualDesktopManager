namespace VirtualDesktopManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer _Components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (_Components != null))
            {
                _Components.Dispose();
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
            this._Components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._NotifyIcon = new System.Windows.Forms.NotifyIcon(this._Components);
            this._ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this._Components);
            this._SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._CheckBox1 = new System.Windows.Forms.CheckBox();
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._RemoveButton = new System.Windows.Forms.Button();
            this._DownButton = new System.Windows.Forms.Button();
            this._UpButton = new System.Windows.Forms.Button();
            this._ListView1 = new System.Windows.Forms.ListView();
            this._AddFileButton = new System.Windows.Forms.Button();
            this._SaveButton = new System.Windows.Forms.Button();
            this._PictureBox1 = new System.Windows.Forms.PictureBox();
            this._LabelStatus = new System.Windows.Forms.Label();
            this._OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this._ContextMenuStrip1.SuspendLayout();
            this._GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this._NotifyIcon.ContextMenuStrip = this._ContextMenuStrip1;
            this._NotifyIcon.Icon = global::VirtualDesktopManager.Properties.Resources.mainIco;
            this._NotifyIcon.Text = "Virtual Desktop Manager";
            this._NotifyIcon.Visible = true;
            this._NotifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this._ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this._ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._SettingsToolStripMenuItem,
            this._ExitToolStripMenuItem});
            this._ContextMenuStrip1.Name = "contextMenuStrip1";
            this._ContextMenuStrip1.Size = new System.Drawing.Size(117, 48);
            // 
            // settingsToolStripMenuItem
            // 
            this._SettingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this._SettingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this._SettingsToolStripMenuItem.Text = "Settings";
            this._SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this._ExitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this._ExitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this._ExitToolStripMenuItem.Text = "Exit";
            this._ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // checkBox1
            // 
            this._CheckBox1.AutoSize = true;
            this._CheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CheckBox1.ForeColor = System.Drawing.Color.White;
            this._CheckBox1.Location = new System.Drawing.Point(14, 54);
            this._CheckBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._CheckBox1.Name = "checkBox1";
            this._CheckBox1.Size = new System.Drawing.Size(353, 21);
            this._CheckBox1.TabIndex = 1;
            this._CheckBox1.Text = "Use alternate key combination (Shift+Alt+Left/Right)";
            this._CheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._CheckBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.BackColor = System.Drawing.Color.Black;
            this._GroupBox1.Controls.Add(this._RemoveButton);
            this._GroupBox1.Controls.Add(this._DownButton);
            this._GroupBox1.Controls.Add(this._UpButton);
            this._GroupBox1.Controls.Add(this._ListView1);
            this._GroupBox1.Controls.Add(this._AddFileButton);
            this._GroupBox1.Controls.Add(this._SaveButton);
            this._GroupBox1.Controls.Add(this._CheckBox1);
            this._GroupBox1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._GroupBox1.ForeColor = System.Drawing.Color.White;
            this._GroupBox1.Location = new System.Drawing.Point(8, 9);
            this._GroupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._GroupBox1.Name = "groupBox1";
            this._GroupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._GroupBox1.Size = new System.Drawing.Size(593, 347);
            this._GroupBox1.TabIndex = 3;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Settings";
            // 
            // removeButton
            // 
            this._RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._RemoveButton.BackColor = System.Drawing.Color.Black;
            this._RemoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._RemoveButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._RemoveButton.ForeColor = System.Drawing.Color.White;
            this._RemoveButton.Location = new System.Drawing.Point(175, 282);
            this._RemoveButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._RemoveButton.Name = "removeButton";
            this._RemoveButton.Size = new System.Drawing.Size(144, 37);
            this._RemoveButton.TabIndex = 7;
            this._RemoveButton.Text = "Remove file";
            this._RemoveButton.UseVisualStyleBackColor = false;
            this._RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // downButton
            // 
            this._DownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._DownButton.BackColor = System.Drawing.Color.Black;
            this._DownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._DownButton.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this._DownButton.ForeColor = System.Drawing.Color.White;
            this._DownButton.Location = new System.Drawing.Point(539, 188);
            this._DownButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._DownButton.Name = "downButton";
            this._DownButton.Size = new System.Drawing.Size(41, 37);
            this._DownButton.TabIndex = 6;
            this._DownButton.Text = "â";
            this._DownButton.UseVisualStyleBackColor = false;
            this._DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // upButton
            // 
            this._UpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._UpButton.BackColor = System.Drawing.Color.Black;
            this._UpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._UpButton.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this._UpButton.ForeColor = System.Drawing.Color.White;
            this._UpButton.Location = new System.Drawing.Point(539, 128);
            this._UpButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._UpButton.Name = "upButton";
            this._UpButton.Size = new System.Drawing.Size(41, 37);
            this._UpButton.TabIndex = 5;
            this._UpButton.Text = "á";
            this._UpButton.UseVisualStyleBackColor = false;
            this._UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // listView1
            // 
            this._ListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._ListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._ListView1.HideSelection = false;
            this._ListView1.Location = new System.Drawing.Point(14, 98);
            this._ListView1.Name = "listView1";
            this._ListView1.ShowGroups = false;
            this._ListView1.ShowItemToolTips = true;
            this._ListView1.Size = new System.Drawing.Size(508, 168);
            this._ListView1.TabIndex = 4;
            this._ListView1.UseCompatibleStateImageBehavior = false;
            this._ListView1.View = System.Windows.Forms.View.Details;
            // 
            // addFileButton
            // 
            this._AddFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._AddFileButton.BackColor = System.Drawing.Color.Black;
            this._AddFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._AddFileButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._AddFileButton.ForeColor = System.Drawing.Color.White;
            this._AddFileButton.Location = new System.Drawing.Point(14, 282);
            this._AddFileButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._AddFileButton.Name = "addFileButton";
            this._AddFileButton.Size = new System.Drawing.Size(144, 37);
            this._AddFileButton.TabIndex = 3;
            this._AddFileButton.Text = "Add background";
            this._AddFileButton.UseVisualStyleBackColor = false;
            this._AddFileButton.Click += new System.EventHandler(this.AddFileButton_Click);
            // 
            // saveButton
            // 
            this._SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._SaveButton.BackColor = System.Drawing.Color.Black;
            this._SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._SaveButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._SaveButton.ForeColor = System.Drawing.Color.White;
            this._SaveButton.Location = new System.Drawing.Point(477, 45);
            this._SaveButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._SaveButton.Name = "saveButton";
            this._SaveButton.Size = new System.Drawing.Size(103, 37);
            this._SaveButton.TabIndex = 2;
            this._SaveButton.Text = "Save";
            this._SaveButton.UseVisualStyleBackColor = false;
            this._SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // pictureBox1
            // 
            this._PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._PictureBox1.Location = new System.Drawing.Point(8, 363);
            this._PictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._PictureBox1.Name = "pictureBox1";
            this._PictureBox1.Size = new System.Drawing.Size(171, 76);
            this._PictureBox1.TabIndex = 4;
            this._PictureBox1.TabStop = false;
            // 
            // labelStatus
            // 
            this._LabelStatus.AutoSize = true;
            this._LabelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this._LabelStatus.Location = new System.Drawing.Point(184, 363);
            this._LabelStatus.Name = "labelStatus";
            this._LabelStatus.Size = new System.Drawing.Size(0, 17);
            this._LabelStatus.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this._OpenFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(609, 451);
            this.Controls.Add(this._LabelStatus);
            this.Controls.Add(this._PictureBox1);
            this.Controls.Add(this._GroupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Virtual Desktop Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this._ContextMenuStrip1.ResumeLayout(false);
            this._GroupBox1.ResumeLayout(false);
            this._GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



        private System.Windows.Forms.NotifyIcon _NotifyIcon;
        private System.Windows.Forms.ContextMenuStrip _ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _SettingsToolStripMenuItem;
        private System.Windows.Forms.CheckBox _CheckBox1;
        private System.Windows.Forms.GroupBox _GroupBox1;
        private System.Windows.Forms.Button _SaveButton;
        private System.Windows.Forms.PictureBox _PictureBox1;
        private System.Windows.Forms.Label _LabelStatus;
        private System.Windows.Forms.Button _AddFileButton;
        private System.Windows.Forms.OpenFileDialog _OpenFileDialog1;
        private System.Windows.Forms.ListView _ListView1;
        private System.Windows.Forms.Button _DownButton;
        private System.Windows.Forms.Button _UpButton;
        private System.Windows.Forms.Button _RemoveButton;
    }
}

