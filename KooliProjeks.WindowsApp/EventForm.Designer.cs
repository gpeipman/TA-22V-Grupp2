namespace KooliProjeks.WindowsApp
{
    partial class EventForm
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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            menuStrip2 = new MenuStrip();
            listBox1 = new ListBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            textBox1 = new TextBox();
            button1 = new Button();
            contextMenuStrip2 = new ContextMenuStrip(components);
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            richTextBox3 = new RichTextBox();
            richTextBox4 = new RichTextBox();
            richTextBox5 = new RichTextBox();
            richTextBox6 = new RichTextBox();
            richTextBox7 = new RichTextBox();
            richTextBox8 = new RichTextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 24);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(789, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(789, 24);
            menuStrip2.TabIndex = 2;
            menuStrip2.Text = "menuStrip2";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(27, 27);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(356, 379);
            listBox1.TabIndex = 4;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.1958771F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.8041229F));
            tableLayoutPanel1.Controls.Add(textBox8, 1, 7);
            tableLayoutPanel1.Controls.Add(textBox7, 1, 6);
            tableLayoutPanel1.Controls.Add(textBox6, 1, 5);
            tableLayoutPanel1.Controls.Add(textBox5, 1, 4);
            tableLayoutPanel1.Controls.Add(textBox4, 1, 3);
            tableLayoutPanel1.Controls.Add(textBox3, 1, 2);
            tableLayoutPanel1.Controls.Add(textBox2, 1, 1);
            tableLayoutPanel1.Controls.Add(richTextBox2, 0, 1);
            tableLayoutPanel1.Controls.Add(textBox1, 1, 0);
            tableLayoutPanel1.Controls.Add(richTextBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(richTextBox3, 0, 2);
            tableLayoutPanel1.Controls.Add(richTextBox5, 0, 3);
            tableLayoutPanel1.Controls.Add(richTextBox7, 0, 4);
            tableLayoutPanel1.Controls.Add(richTextBox4, 0, 5);
            tableLayoutPanel1.Controls.Add(richTextBox6, 0, 6);
            tableLayoutPanel1.Controls.Add(richTextBox8, 0, 7);
            tableLayoutPanel1.Location = new Point(389, 24);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 47.1428566F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 52.8571434F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 57F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.Size = new Size(388, 382);
            tableLayoutPanel1.TabIndex = 6;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // textBox1
            // 
            textBox1.Location = new Point(190, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 8;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // button1
            // 
            button1.Location = new Point(702, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Edit";
            button1.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.WhiteSmoke;
            richTextBox1.Location = new Point(3, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(100, 43);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "Id";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // richTextBox2
            // 
            richTextBox2.BackColor = Color.WhiteSmoke;
            richTextBox2.Location = new Point(3, 52);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(100, 43);
            richTextBox2.TabIndex = 10;
            richTextBox2.Text = "Event Name";
            // 
            // richTextBox3
            // 
            richTextBox3.BackColor = Color.WhiteSmoke;
            richTextBox3.Location = new Point(3, 107);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(100, 43);
            richTextBox3.TabIndex = 11;
            richTextBox3.Text = "Event Date Start";
            // 
            // richTextBox4
            // 
            richTextBox4.BackColor = Color.WhiteSmoke;
            richTextBox4.Location = new Point(3, 275);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(100, 37);
            richTextBox4.TabIndex = 12;
            richTextBox4.Text = "User Id";
            // 
            // richTextBox5
            // 
            richTextBox5.BackColor = Color.WhiteSmoke;
            richTextBox5.Location = new Point(3, 163);
            richTextBox5.Name = "richTextBox5";
            richTextBox5.Size = new Size(100, 43);
            richTextBox5.TabIndex = 12;
            richTextBox5.Text = "Event Date End";
            // 
            // richTextBox6
            // 
            richTextBox6.BackColor = Color.WhiteSmoke;
            richTextBox6.Location = new Point(3, 318);
            richTextBox6.Name = "richTextBox6";
            richTextBox6.Size = new Size(181, 25);
            richTextBox6.TabIndex = 13;
            richTextBox6.Text = "Maximum Participants";
            // 
            // richTextBox7
            // 
            richTextBox7.BackColor = Color.WhiteSmoke;
            richTextBox7.Location = new Point(3, 220);
            richTextBox7.Name = "richTextBox7";
            richTextBox7.Size = new Size(100, 43);
            richTextBox7.TabIndex = 14;
            richTextBox7.Text = "Event Description";
            // 
            // richTextBox8
            // 
            richTextBox8.BackColor = Color.WhiteSmoke;
            richTextBox8.Location = new Point(3, 349);
            richTextBox8.Name = "richTextBox8";
            richTextBox8.Size = new Size(100, 30);
            richTextBox8.TabIndex = 15;
            richTextBox8.Text = "Event Price";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(190, 52);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 16;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(190, 107);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 17;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(190, 163);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 18;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(190, 220);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 19;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(190, 275);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(100, 23);
            textBox6.TabIndex = 20;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(190, 318);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(100, 23);
            textBox7.TabIndex = 21;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(190, 349);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(100, 23);
            textBox8.TabIndex = 22;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 450);
            Controls.Add(button1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(listBox1);
            Controls.Add(menuStrip1);
            Controls.Add(menuStrip2);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Click += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private MenuStrip menuStrip2;
        private ListBox listBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBox1;
        private ContextMenuStrip contextMenuStrip1;
        private RichTextBox richTextBox1;
        private Button button1;
        private ContextMenuStrip contextMenuStrip2;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private RichTextBox richTextBox5;
        private RichTextBox richTextBox7;
        private RichTextBox richTextBox4;
        private RichTextBox richTextBox6;
        private RichTextBox richTextBox8;
        private TextBox textBox8;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
    }
}