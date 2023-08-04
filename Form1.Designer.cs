namespace Star_Wars_Starfighter_TEX
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoadTex = new Button();
            pictureBox1 = new PictureBox();
            ImportTex = new Button();
            SaveTex = new Button();
            ExportTex = new Button();
            label1 = new Label();
            gameCombobox = new ComboBox();
            imageComboBox = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            U0Tex = new NumericUpDown();
            blackCheck = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)U0Tex).BeginInit();
            SuspendLayout();
            // 
            // LoadTex
            // 
            LoadTex.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LoadTex.Location = new Point(12, 415);
            LoadTex.Name = "LoadTex";
            LoadTex.Size = new Size(75, 23);
            LoadTex.TabIndex = 0;
            LoadTex.Text = "Load Image";
            LoadTex.UseVisualStyleBackColor = true;
            LoadTex.Click += LoadTex_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(398, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(395, 395);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // ImportTex
            // 
            ImportTex.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ImportTex.Location = new Point(93, 415);
            ImportTex.Name = "ImportTex";
            ImportTex.Size = new Size(88, 23);
            ImportTex.TabIndex = 2;
            ImportTex.Text = "Import Image";
            ImportTex.UseVisualStyleBackColor = true;
            ImportTex.Click += ImportTex_Click;
            // 
            // SaveTex
            // 
            SaveTex.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SaveTex.Location = new Point(299, 415);
            SaveTex.Name = "SaveTex";
            SaveTex.Size = new Size(75, 23);
            SaveTex.TabIndex = 3;
            SaveTex.Text = "Save";
            SaveTex.UseVisualStyleBackColor = true;
            SaveTex.Click += SaveTex_Click;
            // 
            // ExportTex
            // 
            ExportTex.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ExportTex.Location = new Point(202, 415);
            ExportTex.Name = "ExportTex";
            ExportTex.Size = new Size(91, 23);
            ExportTex.TabIndex = 4;
            ExportTex.Text = "Export Image";
            ExportTex.UseVisualStyleBackColor = true;
            ExportTex.Click += ExportTex_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 13);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 5;
            label1.Text = "Game";
            // 
            // gameCombobox
            // 
            gameCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            gameCombobox.FormattingEnabled = true;
            gameCombobox.Items.AddRange(new object[] { "Starfighter", "Jedi Starfighter" });
            gameCombobox.Location = new Point(15, 31);
            gameCombobox.Name = "gameCombobox";
            gameCombobox.Size = new Size(354, 23);
            gameCombobox.TabIndex = 7;
            gameCombobox.SelectedIndexChanged += gameCombobox_SelectedIndexChanged;
            // 
            // imageComboBox
            // 
            imageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            imageComboBox.FormattingEnabled = true;
            imageComboBox.Items.AddRange(new object[] { "Jedi Starfighter", "Starfighter" });
            imageComboBox.Location = new Point(15, 75);
            imageComboBox.Name = "imageComboBox";
            imageComboBox.Size = new Size(354, 23);
            imageComboBox.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 57);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 8;
            label2.Text = "Image Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 104);
            label3.Name = "label3";
            label3.Size = new Size(21, 15);
            label3.TabIndex = 10;
            label3.Text = "U1";
            // 
            // U0Tex
            // 
            U0Tex.Location = new Point(17, 122);
            U0Tex.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            U0Tex.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            U0Tex.Name = "U0Tex";
            U0Tex.Size = new Size(120, 23);
            U0Tex.TabIndex = 11;
            // 
            // blackCheck
            // 
            blackCheck.AutoSize = true;
            blackCheck.Location = new Point(398, 415);
            blackCheck.Name = "blackCheck";
            blackCheck.Size = new Size(198, 19);
            blackCheck.TabIndex = 12;
            blackCheck.Text = "Black Background (Display Only)";
            blackCheck.UseVisualStyleBackColor = true;
            blackCheck.CheckedChanged += blackCheck_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(blackCheck);
            Controls.Add(U0Tex);
            Controls.Add(label3);
            Controls.Add(imageComboBox);
            Controls.Add(label2);
            Controls.Add(gameCombobox);
            Controls.Add(label1);
            Controls.Add(ExportTex);
            Controls.Add(SaveTex);
            Controls.Add(ImportTex);
            Controls.Add(pictureBox1);
            Controls.Add(LoadTex);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)U0Tex).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoadTex;
        private PictureBox pictureBox1;
        private Button ImportTex;
        private Button SaveTex;
        private Button ExportTex;
        private Label label1;
        private ComboBox gameCombobox;
        private ComboBox imageComboBox;
        private Label label2;
        private Label label3;
        private NumericUpDown U0Tex;
        private CheckBox blackCheck;
    }
}