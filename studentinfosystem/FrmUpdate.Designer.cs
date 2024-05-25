namespace studentinfosystem
{
    partial class FrmUpdate
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
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            bindingSource1 = new BindingSource(components);
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            txtName = new TextBox();
            txtSurname = new TextBox();
            txtClass = new TextBox();
            txtNumber = new TextBox();
            cbDept = new ComboBox();
            cbCourse = new ComboBox();
            txtTopic = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            txtGrade = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label11 = new Label();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 198);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(940, 257);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellEnter += dataGridView1_CellEnter;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 168);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(269, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(148, 20);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 2;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(145, 53);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 3;
            label2.Text = "Surname";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(148, 81);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 4;
            label3.Text = "Class";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(148, 109);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 5;
            label4.Text = "Number";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(148, 138);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 6;
            label5.Text = "Department";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(505, 23);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 11;
            label6.Text = "Course";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(505, 51);
            label7.Name = "label7";
            label7.Size = new Size(35, 15);
            label7.TabIndex = 10;
            label7.Text = "Topic";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(463, 79);
            label8.Name = "label8";
            label8.Size = new Size(97, 15);
            label8.TabIndex = 9;
            label8.Text = "Assignment Date";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(469, 107);
            label9.Name = "label9";
            label9.Size = new Size(95, 15);
            label9.TabIndex = 8;
            label9.Text = "Submission Date";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(513, 139);
            label10.Name = "label10";
            label10.Size = new Size(38, 15);
            label10.TabIndex = 7;
            label10.Text = "Grade";
            // 
            // txtName
            // 
            txtName.Location = new Point(220, 17);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 12;
            // 
            // txtSurname
            // 
            txtSurname.Location = new Point(220, 49);
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(100, 23);
            txtSurname.TabIndex = 13;
            // 
            // txtClass
            // 
            txtClass.Location = new Point(220, 78);
            txtClass.Name = "txtClass";
            txtClass.Size = new Size(100, 23);
            txtClass.TabIndex = 14;
            // 
            // txtNumber
            // 
            txtNumber.Location = new Point(220, 106);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(100, 23);
            txtNumber.TabIndex = 15;
            // 
            // cbDept
            // 
            cbDept.FormattingEnabled = true;
            cbDept.Location = new Point(220, 135);
            cbDept.Name = "cbDept";
            cbDept.Size = new Size(121, 23);
            cbDept.TabIndex = 16;
            cbDept.SelectedIndexChanged += cbDept_SelectedIndexChanged;
            // 
            // cbCourse
            // 
            cbCourse.FormattingEnabled = true;
            cbCourse.Location = new Point(570, 18);
            cbCourse.Name = "cbCourse";
            cbCourse.Size = new Size(121, 23);
            cbCourse.TabIndex = 17;
            // 
            // txtTopic
            // 
            txtTopic.Location = new Point(570, 49);
            txtTopic.Name = "txtTopic";
            txtTopic.Size = new Size(100, 23);
            txtTopic.TabIndex = 18;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(570, 78);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 19;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(570, 104);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 20;
            // 
            // txtGrade
            // 
            txtGrade.Location = new Point(570, 133);
            txtGrade.Name = "txtGrade";
            txtGrade.Size = new Size(100, 23);
            txtGrade.TabIndex = 21;
            // 
            // button1
            // 
            button1.Location = new Point(570, 162);
            button1.Name = "button1";
            button1.Size = new Size(100, 28);
            button1.TabIndex = 22;
            button1.Text = "Update Record";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(776, 162);
            button2.Name = "button2";
            button2.Size = new Size(85, 28);
            button2.TabIndex = 23;
            button2.Text = "Close";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(287, 167);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 24;
            button3.Text = "Search";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(368, 172);
            label11.Name = "label11";
            label11.Size = new Size(196, 15);
            label11.TabIndex = 25;
            label11.Text = "Please use student's name to search";
            // 
            // button4
            // 
            button4.Location = new Point(676, 162);
            button4.Name = "button4";
            button4.Size = new Size(94, 28);
            button4.TabIndex = 26;
            button4.Text = "Delete Record";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // FrmUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(965, 471);
            Controls.Add(button4);
            Controls.Add(label11);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtGrade);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(txtTopic);
            Controls.Add(cbCourse);
            Controls.Add(cbDept);
            Controls.Add(txtNumber);
            Controls.Add(txtClass);
            Controls.Add(txtSurname);
            Controls.Add(txtName);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Name = "FrmUpdate";
            Text = "FrmUpdate";
            Load += FrmUpdate_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource bindingSource1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox txtName;
        private TextBox txtSurname;
        private TextBox txtClass;
        private TextBox txtNumber;
        private ComboBox cbDept;
        private ComboBox cbCourse;
        private TextBox txtTopic;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private TextBox txtGrade;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label11;
        private Button button4;
    }
}