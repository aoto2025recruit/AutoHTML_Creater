namespace auto_member_detail
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button save;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.active = new System.Windows.Forms.Button();
            this.exist_excel = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.excel_fpass = new System.Windows.Forms.RichTextBox();
            this.summary_e = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.html_fpass = new System.Windows.Forms.RichTextBox();
            this.summary_h = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.start_id = new System.Windows.Forms.RichTextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.end_id = new System.Windows.Forms.RichTextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.save_fname = new System.Windows.Forms.RichTextBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.richTextBox6 = new System.Windows.Forms.RichTextBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.col_endid = new System.Windows.Forms.Label();
            this.exist_folder = new System.Windows.Forms.Label();
            this.exist_html = new System.Windows.Forms.Label();
            this.col_startid = new System.Windows.Forms.Label();
            this.selectbox = new System.Windows.Forms.ComboBox();
            this.error_select = new System.Windows.Forms.Label();
            this.result_text = new System.Windows.Forms.RichTextBox();
            this.Icons8Link = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            this.SuspendLayout();
            // 
            // save
            // 
            save.BackColor = System.Drawing.Color.White;
            save.Cursor = System.Windows.Forms.Cursors.Hand;
            save.FlatAppearance.BorderColor = System.Drawing.Color.White;
            save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            save.Image = global::auto_member_detail.Properties.Resources.icons8_folder;
            save.Location = new System.Drawing.Point(691, 335);
            save.Name = "save";
            save.Size = new System.Drawing.Size(25, 23);
            save.TabIndex = 59;
            save.UseVisualStyleBackColor = false;
            save.Click += new System.EventHandler(this.Save_Click);
            // 
            // active
            // 
            this.active.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.active.BackColor = System.Drawing.Color.Transparent;
            this.active.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.active.Cursor = System.Windows.Forms.Cursors.Hand;
            this.active.FlatAppearance.BorderSize = 0;
            this.active.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.active.Font = new System.Drawing.Font("Meiryo UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.active.Image = global::auto_member_detail.Properties.Resources.Button1;
            this.active.Location = new System.Drawing.Point(344, 708);
            this.active.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.active.Name = "active";
            this.active.Size = new System.Drawing.Size(118, 38);
            this.active.TabIndex = 3;
            this.active.TabStop = false;
            this.active.UseVisualStyleBackColor = false;
            this.active.Click += new System.EventHandler(this.Active_Click);
            this.active.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Change_BottonD_Back);
            this.active.MouseEnter += new System.EventHandler(this.Change_Button_Color);
            this.active.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Change_BottonU_Back);
            // 
            // exist_excel
            // 
            this.exist_excel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.exist_excel.AutoSize = true;
            this.exist_excel.BackColor = System.Drawing.Color.Transparent;
            this.exist_excel.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.exist_excel.ForeColor = System.Drawing.Color.OrangeRed;
            this.exist_excel.Location = new System.Drawing.Point(279, 106);
            this.exist_excel.Name = "exist_excel";
            this.exist_excel.Size = new System.Drawing.Size(112, 20);
            this.exist_excel.TabIndex = 19;
            this.exist_excel.Text = "エラーメッセージ";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::auto_member_detail.Properties.Resources.Component1;
            this.pictureBox6.Location = new System.Drawing.Point(31, 66);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(247, 40);
            this.pictureBox6.TabIndex = 35;
            this.pictureBox6.TabStop = false;
            // 
            // excel_fpass
            // 
            this.excel_fpass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.excel_fpass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.excel_fpass.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.excel_fpass.Location = new System.Drawing.Point(283, 74);
            this.excel_fpass.Margin = new System.Windows.Forms.Padding(0);
            this.excel_fpass.Multiline = false;
            this.excel_fpass.Name = "excel_fpass";
            this.excel_fpass.Size = new System.Drawing.Size(408, 23);
            this.excel_fpass.TabIndex = 40;
            this.excel_fpass.Text = "";
            this.excel_fpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoSpace_KeyPress);
            // 
            // summary_e
            // 
            this.summary_e.BackColor = System.Drawing.Color.White;
            this.summary_e.Cursor = System.Windows.Forms.Cursors.Hand;
            this.summary_e.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.summary_e.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.summary_e.Image = global::auto_member_detail.Properties.Resources.icons8_file;
            this.summary_e.Location = new System.Drawing.Point(691, 74);
            this.summary_e.Name = "summary_e";
            this.summary_e.Size = new System.Drawing.Size(25, 23);
            this.summary_e.TabIndex = 39;
            this.summary_e.UseVisualStyleBackColor = false;
            this.summary_e.Click += new System.EventHandler(this.Summary_e_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::auto_member_detail.Properties.Resources.pass1;
            this.pictureBox4.Location = new System.Drawing.Point(276, 66);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(457, 40);
            this.pictureBox4.TabIndex = 38;
            this.pictureBox4.TabStop = false;
            // 
            // html_fpass
            // 
            this.html_fpass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.html_fpass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.html_fpass.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.html_fpass.Location = new System.Drawing.Point(283, 136);
            this.html_fpass.Margin = new System.Windows.Forms.Padding(0);
            this.html_fpass.Multiline = false;
            this.html_fpass.Name = "html_fpass";
            this.html_fpass.Size = new System.Drawing.Size(408, 23);
            this.html_fpass.TabIndex = 45;
            this.html_fpass.Text = "";
            this.html_fpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoSpace_KeyPress);
            // 
            // summary_h
            // 
            this.summary_h.BackColor = System.Drawing.Color.White;
            this.summary_h.Cursor = System.Windows.Forms.Cursors.Hand;
            this.summary_h.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.summary_h.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.summary_h.Image = global::auto_member_detail.Properties.Resources.icons8_file;
            this.summary_h.Location = new System.Drawing.Point(691, 136);
            this.summary_h.Name = "summary_h";
            this.summary_h.Size = new System.Drawing.Size(25, 23);
            this.summary_h.TabIndex = 44;
            this.summary_h.UseVisualStyleBackColor = false;
            this.summary_h.Click += new System.EventHandler(this.Summary_h_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::auto_member_detail.Properties.Resources.pass1;
            this.pictureBox1.Location = new System.Drawing.Point(276, 128);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(457, 40);
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::auto_member_detail.Properties.Resources.Component2;
            this.pictureBox2.Location = new System.Drawing.Point(122, 128);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(161, 40);
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            // 
            // start_id
            // 
            this.start_id.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.start_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.start_id.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.start_id.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.start_id.Location = new System.Drawing.Point(283, 196);
            this.start_id.Margin = new System.Windows.Forms.Padding(0);
            this.start_id.Multiline = false;
            this.start_id.Name = "start_id";
            this.start_id.ShortcutsEnabled = false;
            this.start_id.Size = new System.Drawing.Size(87, 23);
            this.start_id.TabIndex = 50;
            this.start_id.Text = "";
            this.start_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Start_id_KeyPress);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(276, 188);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(121, 40);
            this.pictureBox3.TabIndex = 48;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::auto_member_detail.Properties.Resources.Component3;
            this.pictureBox5.Location = new System.Drawing.Point(169, 188);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(114, 40);
            this.pictureBox5.TabIndex = 47;
            this.pictureBox5.TabStop = false;
            // 
            // end_id
            // 
            this.end_id.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.end_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.end_id.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.end_id.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.end_id.Location = new System.Drawing.Point(283, 256);
            this.end_id.Margin = new System.Windows.Forms.Padding(0);
            this.end_id.Multiline = false;
            this.end_id.Name = "end_id";
            this.end_id.ShortcutsEnabled = false;
            this.end_id.Size = new System.Drawing.Size(87, 23);
            this.end_id.TabIndex = 54;
            this.end_id.Text = "";
            this.end_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.End_id_KeyPress);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(276, 248);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(121, 40);
            this.pictureBox7.TabIndex = 53;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.Image = global::auto_member_detail.Properties.Resources.Component4;
            this.pictureBox8.Location = new System.Drawing.Point(169, 248);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(114, 40);
            this.pictureBox8.TabIndex = 52;
            this.pictureBox8.TabStop = false;
            // 
            // save_fname
            // 
            this.save_fname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.save_fname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.save_fname.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.save_fname.Location = new System.Drawing.Point(283, 335);
            this.save_fname.Margin = new System.Windows.Forms.Padding(0);
            this.save_fname.Multiline = false;
            this.save_fname.Name = "save_fname";
            this.save_fname.Size = new System.Drawing.Size(408, 23);
            this.save_fname.TabIndex = 60;
            this.save_fname.Text = "";
            this.save_fname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoSpace_KeyPress);
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox9.Image = global::auto_member_detail.Properties.Resources.pass1;
            this.pictureBox9.Location = new System.Drawing.Point(276, 327);
            this.pictureBox9.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(457, 40);
            this.pictureBox9.TabIndex = 58;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.Image = global::auto_member_detail.Properties.Resources.Component5;
            this.pictureBox10.Location = new System.Drawing.Point(101, 327);
            this.pictureBox10.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(177, 40);
            this.pictureBox10.TabIndex = 57;
            this.pictureBox10.TabStop = false;
            // 
            // richTextBox6
            // 
            this.richTextBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox6.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.richTextBox6.Location = new System.Drawing.Point(283, 435);
            this.richTextBox6.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox6.Multiline = false;
            this.richTextBox6.Name = "richTextBox6";
            this.richTextBox6.Size = new System.Drawing.Size(408, 23);
            this.richTextBox6.TabIndex = 66;
            this.richTextBox6.Text = "";
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox11.Image = global::auto_member_detail.Properties.Resources.pass1;
            this.pictureBox11.Location = new System.Drawing.Point(276, 427);
            this.pictureBox11.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(457, 40);
            this.pictureBox11.TabIndex = 64;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox12.Image = global::auto_member_detail.Properties.Resources.Component6;
            this.pictureBox12.Location = new System.Drawing.Point(92, 427);
            this.pictureBox12.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(191, 40);
            this.pictureBox12.TabIndex = 63;
            this.pictureBox12.TabStop = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox13.Image = global::auto_member_detail.Properties.Resources.Component7;
            this.pictureBox13.Location = new System.Drawing.Point(180, 513);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(447, 162);
            this.pictureBox13.TabIndex = 68;
            this.pictureBox13.TabStop = false;
            // 
            // col_endid
            // 
            this.col_endid.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.col_endid.AutoSize = true;
            this.col_endid.BackColor = System.Drawing.Color.Transparent;
            this.col_endid.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.col_endid.ForeColor = System.Drawing.Color.OrangeRed;
            this.col_endid.Location = new System.Drawing.Point(279, 288);
            this.col_endid.Name = "col_endid";
            this.col_endid.Size = new System.Drawing.Size(112, 20);
            this.col_endid.TabIndex = 22;
            this.col_endid.Text = "エラーメッセージ";
            // 
            // exist_folder
            // 
            this.exist_folder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.exist_folder.AutoSize = true;
            this.exist_folder.BackColor = System.Drawing.Color.Transparent;
            this.exist_folder.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.exist_folder.ForeColor = System.Drawing.Color.OrangeRed;
            this.exist_folder.Location = new System.Drawing.Point(279, 367);
            this.exist_folder.Name = "exist_folder";
            this.exist_folder.Size = new System.Drawing.Size(112, 20);
            this.exist_folder.TabIndex = 23;
            this.exist_folder.Text = "エラーメッセージ";
            // 
            // exist_html
            // 
            this.exist_html.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.exist_html.AutoSize = true;
            this.exist_html.BackColor = System.Drawing.Color.Transparent;
            this.exist_html.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.exist_html.ForeColor = System.Drawing.Color.OrangeRed;
            this.exist_html.Location = new System.Drawing.Point(279, 168);
            this.exist_html.Name = "exist_html";
            this.exist_html.Size = new System.Drawing.Size(112, 20);
            this.exist_html.TabIndex = 20;
            this.exist_html.Text = "エラーメッセージ";
            // 
            // col_startid
            // 
            this.col_startid.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.col_startid.AutoSize = true;
            this.col_startid.BackColor = System.Drawing.Color.Transparent;
            this.col_startid.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.col_startid.ForeColor = System.Drawing.Color.OrangeRed;
            this.col_startid.Location = new System.Drawing.Point(279, 228);
            this.col_startid.Name = "col_startid";
            this.col_startid.Size = new System.Drawing.Size(112, 20);
            this.col_startid.TabIndex = 21;
            this.col_startid.Text = "エラーメッセージ";
            // 
            // selectbox
            // 
            this.selectbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectbox.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.selectbox.FormattingEnabled = true;
            this.selectbox.Items.AddRange(new object[] {
            "メンバー詳細ページ",
            "アルバム詳細ページ"});
            this.selectbox.Location = new System.Drawing.Point(283, 435);
            this.selectbox.Name = "selectbox";
            this.selectbox.Size = new System.Drawing.Size(430, 25);
            this.selectbox.TabIndex = 24;
            this.selectbox.SelectedIndexChanged += new System.EventHandler(this.selectbox_SelectedIndexChanged);
            // 
            // error_select
            // 
            this.error_select.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.error_select.AutoSize = true;
            this.error_select.BackColor = System.Drawing.Color.Transparent;
            this.error_select.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.error_select.ForeColor = System.Drawing.Color.OrangeRed;
            this.error_select.Location = new System.Drawing.Point(279, 467);
            this.error_select.Name = "error_select";
            this.error_select.Size = new System.Drawing.Size(112, 20);
            this.error_select.TabIndex = 25;
            this.error_select.Text = "エラーメッセージ";
            // 
            // result_text
            // 
            this.result_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.result_text.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.result_text.Location = new System.Drawing.Point(188, 519);
            this.result_text.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.result_text.Name = "result_text";
            this.result_text.ReadOnly = true;
            this.result_text.ShortcutsEnabled = false;
            this.result_text.Size = new System.Drawing.Size(428, 145);
            this.result_text.TabIndex = 6;
            this.result_text.Text = "実行されるとここにログが表示されます";
            // 
            // Icons8Link
            // 
            this.Icons8Link.AutoSize = true;
            this.Icons8Link.BackColor = System.Drawing.Color.Transparent;
            this.Icons8Link.Location = new System.Drawing.Point(749, 769);
            this.Icons8Link.Margin = new System.Windows.Forms.Padding(0);
            this.Icons8Link.Name = "Icons8Link";
            this.Icons8Link.Size = new System.Drawing.Size(45, 15);
            this.Icons8Link.TabIndex = 71;
            this.Icons8Link.TabStop = true;
            this.Icons8Link.Text = "Icons8";
            this.Icons8Link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Icons8Link_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(692, 769);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 72;
            this.label2.Text = "Icons By";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::auto_member_detail.Properties.Resources.background11;
            this.ClientSize = new System.Drawing.Size(803, 793);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Icons8Link);
            this.Controls.Add(this.error_select);
            this.Controls.Add(this.result_text);
            this.Controls.Add(this.col_startid);
            this.Controls.Add(this.pictureBox13);
            this.Controls.Add(this.exist_html);
            this.Controls.Add(this.selectbox);
            this.Controls.Add(this.richTextBox6);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.save_fname);
            this.Controls.Add(save);
            this.Controls.Add(this.exist_folder);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.end_id);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.start_id);
            this.Controls.Add(this.col_endid);
            this.Controls.Add(this.active);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.html_fpass);
            this.Controls.Add(this.summary_h);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.excel_fpass);
            this.Controls.Add(this.summary_e);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.exist_excel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "音見鶏_AutoHTML_Creater";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button active;
        private System.Windows.Forms.Label exist_excel;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.RichTextBox excel_fpass;
        private System.Windows.Forms.Button summary_e;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.RichTextBox html_fpass;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox start_id;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.RichTextBox end_id;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.RichTextBox save_fname;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.RichTextBox richTextBox6;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.Label col_endid;
        private System.Windows.Forms.Label exist_folder;
        private System.Windows.Forms.Label exist_html;
        private System.Windows.Forms.Label col_startid;
        private System.Windows.Forms.Button summary_h;
        private System.Windows.Forms.ComboBox selectbox;
        private System.Windows.Forms.Label error_select;
        private System.Windows.Forms.RichTextBox result_text;
        private System.Windows.Forms.LinkLabel Icons8Link;
        private System.Windows.Forms.Label label2;
    }
}

