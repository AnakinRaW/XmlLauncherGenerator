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
            this.label2.Location = new System.Drawing.Point(12, 223);
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
            "Check"});
            this.cbt_genType.Location = new System.Drawing.Point(100, 6);
            this.cbt_genType.Name = "cbt_genType";
            this.cbt_genType.Size = new System.Drawing.Size(121, 21);
            this.cbt_genType.TabIndex = 3;
            // 
            // tb_version
            // 
            this.tb_version.Location = new System.Drawing.Point(100, 33);
            this.tb_version.Name = "tb_version";
            this.tb_version.Size = new System.Drawing.Size(100, 20);
            this.tb_version.TabIndex = 4;
            // 
            // tb_outDir
            // 
            this.tb_outDir.Location = new System.Drawing.Point(100, 59);
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
            this.btn_generate.Location = new System.Drawing.Point(100, 85);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(121, 44);
            this.btn_generate.TabIndex = 8;
            this.btn_generate.Text = "Generate XML";
            this.btn_generate.UseVisualStyleBackColor = true;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // btn_selDir
            // 
            this.btn_selDir.Location = new System.Drawing.Point(298, 59);
            this.btn_selDir.Name = "btn_selDir";
            this.btn_selDir.Size = new System.Drawing.Size(75, 23);
            this.btn_selDir.TabIndex = 9;
            this.btn_selDir.Text = "Select";
            this.btn_selDir.UseVisualStyleBackColor = true;
            this.btn_selDir.Click += new System.EventHandler(this.btn_selDir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 245);
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
    }
}

