namespace library_management_new
{
    partial class Form7
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
            this.rid = new System.Windows.Forms.TextBox();
            this.rfname = new System.Windows.Forms.TextBox();
            this.rlname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.rcity = new System.Windows.Forms.ComboBox();
            this.rmaxbooks = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rid
            // 
            this.rid.Location = new System.Drawing.Point(483, 125);
            this.rid.Name = "rid";
            this.rid.Size = new System.Drawing.Size(100, 22);
            this.rid.TabIndex = 0;
            // 
            // rfname
            // 
            this.rfname.Location = new System.Drawing.Point(483, 201);
            this.rfname.Name = "rfname";
            this.rfname.Size = new System.Drawing.Size(100, 22);
            this.rfname.TabIndex = 1;
            // 
            // rlname
            // 
            this.rlname.Location = new System.Drawing.Point(589, 199);
            this.rlname.Name = "rlname";
            this.rlname.Size = new System.Drawing.Size(100, 22);
            this.rlname.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(367, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "ReaderID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(367, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "City";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(443, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rcity
            // 
            this.rcity.AllowDrop = true;
            this.rcity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.rcity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.rcity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rcity.FormattingEnabled = true;
            this.rcity.Location = new System.Drawing.Point(483, 272);
            this.rcity.Name = "rcity";
            this.rcity.Size = new System.Drawing.Size(121, 24);
            this.rcity.TabIndex = 10;
            // 
            // rmaxbooks
            // 
            this.rmaxbooks.AllowDrop = true;
            this.rmaxbooks.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.rmaxbooks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rmaxbooks.FormattingEnabled = true;
            this.rmaxbooks.Location = new System.Drawing.Point(483, 326);
            this.rmaxbooks.Name = "rmaxbooks";
            this.rmaxbooks.Size = new System.Drawing.Size(121, 24);
            this.rmaxbooks.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Max books";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(145, 29);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 66);
            this.button3.TabIndex = 14;
            this.button3.Text = "Go to Main Menu";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(21, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 66);
            this.button2.TabIndex = 13;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(55, 214);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(169, 66);
            this.button4.TabIndex = 15;
            this.button4.Text = "New Borrowing ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(671, 29);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(86, 38);
            this.button5.TabIndex = 16;
            this.button5.Text = "Log Out";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rmaxbooks);
            this.Controls.Add(this.rcity);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rlname);
            this.Controls.Add(this.rfname);
            this.Controls.Add(this.rid);
            this.Name = "Form7";
            this.Text = "Add a Reader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rid;
        private System.Windows.Forms.TextBox rfname;
        private System.Windows.Forms.TextBox rlname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox rcity;
        private System.Windows.Forms.ComboBox rmaxbooks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}