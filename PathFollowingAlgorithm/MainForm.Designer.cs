namespace PathFollowingAlgorithm
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
            this.lblChoosedASCIIMap = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnAddASCIIMap = new System.Windows.Forms.Button();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.btnProcessMap = new System.Windows.Forms.Button();
            this.lblPathName = new System.Windows.Forms.Label();
            this.lblLettersName = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.tbLetters = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblChoosedASCIIMap
            // 
            this.lblChoosedASCIIMap.AutoSize = true;
            this.lblChoosedASCIIMap.Location = new System.Drawing.Point(12, 36);
            this.lblChoosedASCIIMap.Name = "lblChoosedASCIIMap";
            this.lblChoosedASCIIMap.Size = new System.Drawing.Size(135, 17);
            this.lblChoosedASCIIMap.TabIndex = 0;
            this.lblChoosedASCIIMap.Text = "Selected ASCII map:";
            // 
            // btnAddASCIIMap
            // 
            this.btnAddASCIIMap.Location = new System.Drawing.Point(516, 30);
            this.btnAddASCIIMap.Name = "btnAddASCIIMap";
            this.btnAddASCIIMap.Size = new System.Drawing.Size(139, 34);
            this.btnAddASCIIMap.TabIndex = 1;
            this.btnAddASCIIMap.Text = "Add ASCII map";
            this.btnAddASCIIMap.UseVisualStyleBackColor = true;
            this.btnAddASCIIMap.Click += new System.EventHandler(this.btnAddASCIIMap_Click);
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(153, 36);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(357, 22);
            this.tbFilePath.TabIndex = 2;
            // 
            // btnProcessMap
            // 
            this.btnProcessMap.Location = new System.Drawing.Point(516, 98);
            this.btnProcessMap.Name = "btnProcessMap";
            this.btnProcessMap.Size = new System.Drawing.Size(139, 67);
            this.btnProcessMap.TabIndex = 3;
            this.btnProcessMap.Text = "Process map";
            this.btnProcessMap.UseVisualStyleBackColor = true;
            this.btnProcessMap.Click += new System.EventHandler(this.btnProcessMap_Click);
            // 
            // lblPathName
            // 
            this.lblPathName.AutoSize = true;
            this.lblPathName.Location = new System.Drawing.Point(106, 107);
            this.lblPathName.Name = "lblPathName";
            this.lblPathName.Size = new System.Drawing.Size(41, 17);
            this.lblPathName.TabIndex = 4;
            this.lblPathName.Text = "Path:";
            // 
            // lblLettersName
            // 
            this.lblLettersName.AutoSize = true;
            this.lblLettersName.Location = new System.Drawing.Point(94, 133);
            this.lblLettersName.Name = "lblLettersName";
            this.lblLettersName.Size = new System.Drawing.Size(56, 17);
            this.lblLettersName.TabIndex = 5;
            this.lblLettersName.Text = "Letters:";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(153, 107);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(357, 22);
            this.tbPath.TabIndex = 8;
            // 
            // tbLetters
            // 
            this.tbLetters.Location = new System.Drawing.Point(153, 133);
            this.tbLetters.Name = "tbLetters";
            this.tbLetters.Size = new System.Drawing.Size(357, 22);
            this.tbLetters.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 228);
            this.Controls.Add(this.tbLetters);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.lblLettersName);
            this.Controls.Add(this.lblPathName);
            this.Controls.Add(this.btnProcessMap);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.btnAddASCIIMap);
            this.Controls.Add(this.lblChoosedASCIIMap);
            this.Name = "MainForm";
            this.Text = "Path Following";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChoosedASCIIMap;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnAddASCIIMap;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Button btnProcessMap;
        private System.Windows.Forms.Label lblPathName;
        private System.Windows.Forms.Label lblLettersName;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.TextBox tbLetters;
    }
}

