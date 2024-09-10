namespace HAStoreVis
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
            btnCreateDatabase = new Button();
            btnInitializeData = new Button();
            btnCountCustomers = new Button();
            btnAverageAge = new Button();
            btnAverageCheck = new Button();
            SuspendLayout();
            // 
            // btnCreateDatabase
            // 
            btnCreateDatabase.Location = new Point(12, 12);
            btnCreateDatabase.Name = "btnCreateDatabase";
            btnCreateDatabase.Size = new Size(139, 29);
            btnCreateDatabase.TabIndex = 0;
            btnCreateDatabase.Text = "Создать БД";
            btnCreateDatabase.UseVisualStyleBackColor = true;
            btnCreateDatabase.Click += btnCreateDatabase_Click;
            // 
            // btnInitializeData
            // 
            btnInitializeData.Location = new Point(12, 47);
            btnInitializeData.Name = "btnInitializeData";
            btnInitializeData.Size = new Size(139, 29);
            btnInitializeData.TabIndex = 1;
            btnInitializeData.Text = "Запустить БД";
            btnInitializeData.UseVisualStyleBackColor = true;
            // 
            // btnCountCustomers
            // 
            btnCountCustomers.Location = new Point(12, 82);
            btnCountCustomers.Name = "btnCountCustomers";
            btnCountCustomers.Size = new Size(139, 29);
            btnCountCustomers.TabIndex = 2;
            btnCountCustomers.Text = "Считать клиентов";
            btnCountCustomers.UseVisualStyleBackColor = true;
            // 
            // btnAverageAge
            // 
            btnAverageAge.Location = new Point(12, 117);
            btnAverageAge.Name = "btnAverageAge";
            btnAverageAge.Size = new Size(139, 29);
            btnAverageAge.TabIndex = 3;
            btnAverageAge.Text = "Средний возраст";
            btnAverageAge.UseVisualStyleBackColor = true;
            // 
            // btnAverageCheck
            // 
            btnAverageCheck.Location = new Point(12, 152);
            btnAverageCheck.Name = "btnAverageCheck";
            btnAverageCheck.Size = new Size(139, 29);
            btnAverageCheck.TabIndex = 4;
            btnAverageCheck.Text = "Средний чек";
            btnAverageCheck.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAverageCheck);
            Controls.Add(btnAverageAge);
            Controls.Add(btnCountCustomers);
            Controls.Add(btnInitializeData);
            Controls.Add(btnCreateDatabase);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnCreateDatabase;
        private Button btnInitializeData;
        private Button btnCountCustomers;
        private Button btnAverageAge;
        private Button btnAverageCheck;
    }
}
