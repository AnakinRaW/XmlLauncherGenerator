namespace RawXmlLauncherGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbt_genType = new System.Windows.Forms.ComboBox();
            this.tb_version = new System.Windows.Forms.TextBox();
            this.tb_outDir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_generate = new System.Windows.Forms.Button();
            this.btn_selDir = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_customModDir = new System.Windows.Forms.TextBox();
            this.tb_prevFile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_selFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Version Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "This tool generates the required xml files used for the launcher";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Generate Type:";
            // 
            // cbt_genType
            // 
            this.cbt_genType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbt_genType.FormattingEnabled = true;
            this.cbt_genType.Items.AddRange(new object[] {
            "Check",
            "Restore/Update"});
            this.cbt_genType.Location = new System.Drawing.Point(132, 6);
            this.cbt_genType.Name = "cbt_genType";
            this.cbt_genType.Size = new System.Drawing.Size(121, 21);
            this.cbt_genType.TabIndex = 3;
            this.cbt_genType.SelectedIndexChanged += new System.EventHandler(this.cbt_genType_SelectedIndexChanged);
            // 
            // tb_version
            // 
            this.tb_version.Location = new System.Drawing.Point(132, 33);
            this.tb_version.Name = "tb_version";
            this.tb_version.Size = new System.Drawing.Size(100, 20);
            this.tb_version.TabIndex = 4;
            // 
            // tb_outDir
            // 
            this.tb_outDir.Location = new System.Drawing.Point(132, 59);
            this.tb_outDir.Name = "tb_outDir";
            this.tb_outDir.Size = new System.Drawing.Size(192, 20);
            this.tb_outDir.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Output-Dir:";
            // 
            // btn_generate
            // 
            this.btn_generate.Location = new System.Drawing.Point(132, 206);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(121, 44);
            this.btn_generate.TabIndex = 8;
            this.btn_generate.Text = "Generate XML";
            this.btn_generate.UseVisualStyleBackColor = true;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // btn_selDir
            // 
            this.btn_selDir.Location = new System.Drawing.Point(330, 59);
            this.btn_selDir.Name = "btn_selDir";
            this.btn_selDir.Size = new System.Drawing.Size(75, 23);
            this.btn_selDir.TabIndex = 9;
            this.btn_selDir.Text = "Select";
            this.btn_selDir.UseVisualStyleBackColor = true;
            this.btn_selDir.Click += new System.EventHandler(this.btn_selDir_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Custom Mod Directory:";
            // 
            // tb_customModDir
            // 
            this.tb_customModDir.Location = new System.Drawing.Point(132, 85);
            this.tb_customModDir.Name = "tb_customModDir";
            this.tb_customModDir.Size = new System.Drawing.Size(100, 20);
            this.tb_customModDir.TabIndex = 11;
            // 
            // tb_prevFile
            // 
            this.tb_prevFile.Location = new System.Drawing.Point(15, 124);
            this.tb_prevFile.Name = "tb_prevFile";
            this.tb_prevFile.Size = new System.Drawing.Size(309, 20);
            this.tb_prevFile.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Restore XML of the previous version:";
            // 
            // btn_selFile
            // 
            this.btn_selFile.Location = new System.Drawing.Point(330, 122);
            this.btn_selFile.Name = "btn_selFile";
            this.btn_selFile.Size = new System.Drawing.Size(75, 23);
            this.btn_selFile.TabIndex = 14;
            this.btn_selFile.Text = "Select";
            this.btn_selFile.UseVisualStyleBackColor = true;
            this.btn_selFile.Click += new System.EventHandler(this.btn_selFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 150);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(313, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Copy all new Files to Outputdir (new Directory will be created)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 289);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btn_selFile);
            this.Controls.Add(this.tb_prevFile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_customModDir);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_selDir);
            this.Controls.Add(this.btn_generate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_outDir);
            this.Controls.Add(this.tb_version);
            this.Controls.Add(this.cbt_genType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "XML Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbt_genType;
        private System.Windows.Forms.TextBox tb_version;
        private System.Windows.Forms.TextBox tb_outDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_generate;
        private System.Windows.Forms.Button btn_selDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_customModDir;
        private System.Windows.Forms.TextBox tb_prevFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_selFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

