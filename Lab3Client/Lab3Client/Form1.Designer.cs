namespace Lab3Client
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.Name = new System.Windows.Forms.TextBox();
            this.Position = new System.Windows.Forms.TextBox();
            this.Salary = new System.Windows.Forms.TextBox();
            this.AddWorker = new System.Windows.Forms.Button();
            this.ShowAll = new System.Windows.Forms.Button();
            this.WorkerName = new System.Windows.Forms.TextBox();
            this.SearchByName = new System.Windows.Forms.Button();
            this.SearchAllOutput = new System.Windows.Forms.TextBox();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.OldName = new System.Windows.Forms.TextBox();
            this.NewName = new System.Windows.Forms.TextBox();
            this.NewPosition = new System.Windows.Forms.TextBox();
            this.NewSalary = new System.Windows.Forms.TextBox();
            this.Edit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Name
            // 
            this.Name.Location = new System.Drawing.Point(105, 12);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(100, 22);
            this.Name.TabIndex = 1;
            // 
            // Position
            // 
            this.Position.Location = new System.Drawing.Point(105, 41);
            this.Position.Name = "Position";
            this.Position.Size = new System.Drawing.Size(100, 22);
            this.Position.TabIndex = 2;
            // 
            // Salary
            // 
            this.Salary.Location = new System.Drawing.Point(105, 70);
            this.Salary.Name = "Salary";
            this.Salary.Size = new System.Drawing.Size(100, 22);
            this.Salary.TabIndex = 3;
            // 
            // AddWorker
            // 
            this.AddWorker.Location = new System.Drawing.Point(105, 99);
            this.AddWorker.Name = "AddWorker";
            this.AddWorker.Size = new System.Drawing.Size(100, 23);
            this.AddWorker.TabIndex = 4;
            this.AddWorker.Text = "Add worker";
            this.AddWorker.UseVisualStyleBackColor = true;
            this.AddWorker.Click += new System.EventHandler(this.AddWorker_Click_1);
            // 
            // ShowAll
            // 
            this.ShowAll.Location = new System.Drawing.Point(395, 11);
            this.ShowAll.Name = "ShowAll";
            this.ShowAll.Size = new System.Drawing.Size(75, 23);
            this.ShowAll.TabIndex = 5;
            this.ShowAll.Text = "Show all";
            this.ShowAll.UseVisualStyleBackColor = true;
            this.ShowAll.Click += new System.EventHandler(this.ShowAll_Click);
            // 
            // WorkerName
            // 
            this.WorkerName.Location = new System.Drawing.Point(242, 13);
            this.WorkerName.Name = "WorkerName";
            this.WorkerName.Size = new System.Drawing.Size(100, 22);
            this.WorkerName.TabIndex = 6;
            // 
            // SearchByName
            // 
            this.SearchByName.Location = new System.Drawing.Point(242, 41);
            this.SearchByName.Name = "SearchByName";
            this.SearchByName.Size = new System.Drawing.Size(130, 23);
            this.SearchByName.TabIndex = 7;
            this.SearchByName.Text = "Search by name";
            this.SearchByName.UseVisualStyleBackColor = true;
            this.SearchByName.Click += new System.EventHandler(this.SearchByName_Click);
            // 
            // SearchAllOutput
            // 
            this.SearchAllOutput.AcceptsReturn = true;
            this.SearchAllOutput.Location = new System.Drawing.Point(13, 175);
            this.SearchAllOutput.Multiline = true;
            this.SearchAllOutput.Name = "SearchAllOutput";
            this.SearchAllOutput.Size = new System.Drawing.Size(489, 193);
            this.SearchAllOutput.TabIndex = 9;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(242, 70);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 10;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(395, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Sort by salary";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // OldName
            // 
            this.OldName.Location = new System.Drawing.Point(548, 13);
            this.OldName.Name = "OldName";
            this.OldName.Size = new System.Drawing.Size(100, 22);
            this.OldName.TabIndex = 12;
            // 
            // NewName
            // 
            this.NewName.Location = new System.Drawing.Point(548, 40);
            this.NewName.Name = "NewName";
            this.NewName.Size = new System.Drawing.Size(100, 22);
            this.NewName.TabIndex = 13;
            // 
            // NewPosition
            // 
            this.NewPosition.Location = new System.Drawing.Point(548, 70);
            this.NewPosition.Name = "NewPosition";
            this.NewPosition.Size = new System.Drawing.Size(100, 22);
            this.NewPosition.TabIndex = 14;
            // 
            // NewSalary
            // 
            this.NewSalary.Location = new System.Drawing.Point(548, 99);
            this.NewSalary.Name = "NewSalary";
            this.NewSalary.Size = new System.Drawing.Size(100, 22);
            this.NewSalary.TabIndex = 15;
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(548, 128);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(75, 23);
            this.Edit.TabIndex = 16;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.NewSalary);
            this.Controls.Add(this.NewPosition);
            this.Controls.Add(this.NewName);
            this.Controls.Add(this.OldName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.SearchAllOutput);
            this.Controls.Add(this.SearchByName);
            this.Controls.Add(this.WorkerName);
            this.Controls.Add(this.ShowAll);
            this.Controls.Add(this.AddWorker);
            this.Controls.Add(this.Salary);
            this.Controls.Add(this.Position);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Name;
        private System.Windows.Forms.TextBox Position;
        private System.Windows.Forms.TextBox Salary;
        private System.Windows.Forms.Button AddWorker;
        private System.Windows.Forms.Button ShowAll;
        private System.Windows.Forms.TextBox WorkerName;
        private System.Windows.Forms.Button SearchByName;
        private System.Windows.Forms.TextBox SearchAllOutput;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox OldName;
        private System.Windows.Forms.TextBox NewName;
        private System.Windows.Forms.TextBox NewPosition;
        private System.Windows.Forms.TextBox NewSalary;
        private System.Windows.Forms.Button Edit;
    }
}

