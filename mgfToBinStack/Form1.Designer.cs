namespace mgfToBinStack
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusLabel = new System.Windows.Forms.Label();
            this.createBinStackBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.massUnitsCmb = new System.Windows.Forms.ComboBox();
            this.parentalMassTxt = new System.Windows.Forms.TextBox();
            this.parentalMassChb = new System.Windows.Forms.CheckBox();
            this.posBox = new System.Windows.Forms.ComboBox();
            this.specTypeBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.quiXMLtxt = new System.Windows.Forms.TextBox();
            this.specFolderTxt = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.integerToFirstScanChk = new System.Windows.Forms.CheckBox();
            this.scanFieldsBox = new System.Windows.Forms.ListBox();
            this.scanNumberResTxt = new System.Windows.Forms.Label();
            this.joinFieldsTxt = new System.Windows.Forms.TextBox();
            this.scanFieldsTxt = new System.Windows.Forms.TextBox();
            this.splitCharsTxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.titleLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.schemaTxt = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(15, 465);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(66, 18);
            this.statusLabel.TabIndex = 9;
            this.statusLabel.Text = "Status...";
            this.statusLabel.Visible = false;
            // 
            // createBinStackBtn
            // 
            this.createBinStackBtn.Location = new System.Drawing.Point(218, 493);
            this.createBinStackBtn.Name = "createBinStackBtn";
            this.createBinStackBtn.Size = new System.Drawing.Size(108, 29);
            this.createBinStackBtn.TabIndex = 8;
            this.createBinStackBtn.Text = "create binStack";
            this.createBinStackBtn.UseVisualStyleBackColor = true;
            this.createBinStackBtn.Click += new System.EventHandler(this.createBinStackBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.massUnitsCmb);
            this.groupBox2.Controls.Add(this.parentalMassTxt);
            this.groupBox2.Controls.Add(this.parentalMassChb);
            this.groupBox2.Controls.Add(this.posBox);
            this.groupBox2.Controls.Add(this.specTypeBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 395);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(529, 67);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "options";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "position :";
            this.label4.Visible = false;
            // 
            // massUnitsCmb
            // 
            this.massUnitsCmb.Enabled = false;
            this.massUnitsCmb.FormattingEnabled = true;
            this.massUnitsCmb.Location = new System.Drawing.Point(359, 25);
            this.massUnitsCmb.Name = "massUnitsCmb";
            this.massUnitsCmb.Size = new System.Drawing.Size(49, 21);
            this.massUnitsCmb.TabIndex = 12;
            // 
            // parentalMassTxt
            // 
            this.parentalMassTxt.Enabled = false;
            this.parentalMassTxt.Location = new System.Drawing.Point(303, 26);
            this.parentalMassTxt.Name = "parentalMassTxt";
            this.parentalMassTxt.Size = new System.Drawing.Size(50, 20);
            this.parentalMassTxt.TabIndex = 11;
            // 
            // parentalMassChb
            // 
            this.parentalMassChb.AutoSize = true;
            this.parentalMassChb.Location = new System.Drawing.Point(105, 27);
            this.parentalMassChb.Name = "parentalMassChb";
            this.parentalMassChb.Size = new System.Drawing.Size(192, 17);
            this.parentalMassChb.TabIndex = 10;
            this.parentalMassChb.Text = "spectra centered at parental mass :";
            this.parentalMassChb.UseVisualStyleBackColor = true;
            this.parentalMassChb.CheckedChanged += new System.EventHandler(this.parentalMassChb_CheckedChanged);
            // 
            // posBox
            // 
            this.posBox.FormattingEnabled = true;
            this.posBox.Location = new System.Drawing.Point(314, 40);
            this.posBox.Name = "posBox";
            this.posBox.Size = new System.Drawing.Size(136, 21);
            this.posBox.TabIndex = 8;
            this.posBox.Visible = false;
            // 
            // specTypeBox
            // 
            this.specTypeBox.FormattingEnabled = true;
            this.specTypeBox.Location = new System.Drawing.Point(105, 40);
            this.specTypeBox.Name = "specTypeBox";
            this.specTypeBox.Size = new System.Drawing.Size(141, 21);
            this.specTypeBox.TabIndex = 5;
            this.specTypeBox.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "spectrum type :";
            this.label3.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.schemaTxt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.quiXMLtxt);
            this.groupBox1.Controls.Add(this.specFolderTxt);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 136);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "data source";
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "spectra folder :";
            this.label2.DragDrop += new System.Windows.Forms.DragEventHandler(this.label2_DragDrop);
            this.label2.DragEnter += new System.Windows.Forms.DragEventHandler(this.label2_DragEnter);
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "QuiXML file :";
            this.label1.DragDrop += new System.Windows.Forms.DragEventHandler(this.label1_DragDrop);
            this.label1.DragEnter += new System.Windows.Forms.DragEventHandler(this.label1_DragEnter);
            // 
            // quiXMLtxt
            // 
            this.quiXMLtxt.AllowDrop = true;
            this.quiXMLtxt.Location = new System.Drawing.Point(105, 34);
            this.quiXMLtxt.Name = "quiXMLtxt";
            this.quiXMLtxt.Size = new System.Drawing.Size(411, 20);
            this.quiXMLtxt.TabIndex = 0;
            this.quiXMLtxt.DragDrop += new System.Windows.Forms.DragEventHandler(this.quiXMLtxt_DragDrop);
            this.quiXMLtxt.DragEnter += new System.Windows.Forms.DragEventHandler(this.quiXMLtxt_DragEnter);
            // 
            // specFolderTxt
            // 
            this.specFolderTxt.AllowDrop = true;
            this.specFolderTxt.Location = new System.Drawing.Point(105, 89);
            this.specFolderTxt.Name = "specFolderTxt";
            this.specFolderTxt.Size = new System.Drawing.Size(411, 20);
            this.specFolderTxt.TabIndex = 1;
            this.specFolderTxt.TextChanged += new System.EventHandler(this.specFolderTxt_TextChanged);
            this.specFolderTxt.DragDrop += new System.Windows.Forms.DragEventHandler(this.specFolderTxt_DragDrop);
            this.specFolderTxt.DragEnter += new System.Windows.Forms.DragEventHandler(this.specFolderTxt_DragEnter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.integerToFirstScanChk);
            this.groupBox3.Controls.Add(this.scanFieldsBox);
            this.groupBox3.Controls.Add(this.scanNumberResTxt);
            this.groupBox3.Controls.Add(this.joinFieldsTxt);
            this.groupBox3.Controls.Add(this.scanFieldsTxt);
            this.groupBox3.Controls.Add(this.splitCharsTxt);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.titleLbl);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 157);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(529, 232);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mascot Generic Format file parser";
            // 
            // integerToFirstScanChk
            // 
            this.integerToFirstScanChk.AutoSize = true;
            this.integerToFirstScanChk.Location = new System.Drawing.Point(6, 149);
            this.integerToFirstScanChk.Name = "integerToFirstScanChk";
            this.integerToFirstScanChk.Size = new System.Drawing.Size(203, 17);
            this.integerToFirstScanChk.TabIndex = 11;
            this.integerToFirstScanChk.Text = "assign an integer number to FirstScan";
            this.integerToFirstScanChk.UseVisualStyleBackColor = true;
            this.integerToFirstScanChk.Visible = false;
            // 
            // scanFieldsBox
            // 
            this.scanFieldsBox.FormattingEnabled = true;
            this.scanFieldsBox.Location = new System.Drawing.Point(221, 72);
            this.scanFieldsBox.Name = "scanFieldsBox";
            this.scanFieldsBox.Size = new System.Drawing.Size(171, 134);
            this.scanFieldsBox.TabIndex = 10;
            this.scanFieldsBox.SelectedIndexChanged += new System.EventHandler(this.scanFieldsBox_SelectedIndexChanged);
            // 
            // scanNumberResTxt
            // 
            this.scanNumberResTxt.AutoSize = true;
            this.scanNumberResTxt.Location = new System.Drawing.Point(350, 56);
            this.scanNumberResTxt.Name = "scanNumberResTxt";
            this.scanNumberResTxt.Size = new System.Drawing.Size(47, 13);
            this.scanNumberResTxt.TabIndex = 9;
            this.scanNumberResTxt.Text = "No scan";
            // 
            // joinFieldsTxt
            // 
            this.joinFieldsTxt.Location = new System.Drawing.Point(85, 130);
            this.joinFieldsTxt.Name = "joinFieldsTxt";
            this.joinFieldsTxt.Size = new System.Drawing.Size(44, 20);
            this.joinFieldsTxt.TabIndex = 8;
            this.joinFieldsTxt.Visible = false;
            this.joinFieldsTxt.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // scanFieldsTxt
            // 
            this.scanFieldsTxt.Location = new System.Drawing.Point(75, 101);
            this.scanFieldsTxt.Name = "scanFieldsTxt";
            this.scanFieldsTxt.Size = new System.Drawing.Size(105, 20);
            this.scanFieldsTxt.TabIndex = 7;
            this.scanFieldsTxt.Visible = false;
            this.scanFieldsTxt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // splitCharsTxt
            // 
            this.splitCharsTxt.Location = new System.Drawing.Point(85, 56);
            this.splitCharsTxt.Name = "splitCharsTxt";
            this.splitCharsTxt.Size = new System.Drawing.Size(105, 20);
            this.splitCharsTxt.TabIndex = 6;
            this.splitCharsTxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(218, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Choose a Scan Number :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "join fields by :";
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "scan fields : ";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "split chars : ";
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Location = new System.Drawing.Point(58, 32);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(37, 13);
            this.titleLbl.TabIndex = 1;
            this.titleLbl.Text = "No file";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Title : ";
            // 
            // label6
            // 
            this.label6.AllowDrop = true;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "QuiXML schema :";
            // 
            // schemaTxt
            // 
            this.schemaTxt.AllowDrop = true;
            this.schemaTxt.Location = new System.Drawing.Point(105, 62);
            this.schemaTxt.Name = "schemaTxt";
            this.schemaTxt.Size = new System.Drawing.Size(411, 20);
            this.schemaTxt.TabIndex = 5;
            this.schemaTxt.DragDrop += new System.Windows.Forms.DragEventHandler(this.schemaTxt_DragDrop);
            this.schemaTxt.DragEnter += new System.Windows.Forms.DragEventHandler(this.schemaTxt_DragEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 532);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.createBinStackBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "mgfToBinStack v";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button createBinStackBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox massUnitsCmb;
        private System.Windows.Forms.TextBox parentalMassTxt;
        private System.Windows.Forms.CheckBox parentalMassChb;
        private System.Windows.Forms.ComboBox posBox;
        private System.Windows.Forms.ComboBox specTypeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox quiXMLtxt;
        private System.Windows.Forms.TextBox specFolderTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox joinFieldsTxt;
        private System.Windows.Forms.TextBox scanFieldsTxt;
        private System.Windows.Forms.TextBox splitCharsTxt;
        private System.Windows.Forms.ListBox scanFieldsBox;
        private System.Windows.Forms.Label scanNumberResTxt;
        private System.Windows.Forms.CheckBox integerToFirstScanChk;
        private System.Windows.Forms.TextBox schemaTxt;
        private System.Windows.Forms.Label label6;
    }
}

