namespace DatabaseControlPanel.Forms
{
    partial class DatabaseControlPanel
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
            this.ExecuteQueryButton = new System.Windows.Forms.Button();
            this.DatabaseConnectedLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.QueryField = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ExecuteQueryButton
            // 
            this.ExecuteQueryButton.Location = new System.Drawing.Point(668, 48);
            this.ExecuteQueryButton.Name = "ExecuteQueryButton";
            this.ExecuteQueryButton.Size = new System.Drawing.Size(104, 28);
            this.ExecuteQueryButton.TabIndex = 1;
            this.ExecuteQueryButton.Text = "Execute query";
            this.ExecuteQueryButton.UseVisualStyleBackColor = true;
            this.ExecuteQueryButton.Click += new System.EventHandler(this.ExecuteQueryButton_Click);
            // 
            // DatabaseConnectedLabel
            // 
            this.DatabaseConnectedLabel.AutoSize = true;
            this.DatabaseConnectedLabel.Location = new System.Drawing.Point(110, 14);
            this.DatabaseConnectedLabel.Name = "DatabaseConnectedLabel";
            this.DatabaseConnectedLabel.Size = new System.Drawing.Size(35, 13);
            this.DatabaseConnectedLabel.TabIndex = 3;
            this.DatabaseConnectedLabel.Text = "label1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(102, 156);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(541, 282);
            this.dataGridView1.TabIndex = 5;
            // 
            // QueryField
            // 
            this.QueryField.Location = new System.Drawing.Point(105, 50);
            this.QueryField.Name = "QueryField";
            this.QueryField.Size = new System.Drawing.Size(537, 85);
            this.QueryField.TabIndex = 6;
            this.QueryField.Text = "";
            // 
            // DatabaseControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.QueryField);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.DatabaseConnectedLabel);
            this.Controls.Add(this.ExecuteQueryButton);
            this.Name = "DatabaseControlPanel";
            this.Text = "Database Control Panel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ExecuteQueryButton;
        private System.Windows.Forms.Label DatabaseConnectedLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox QueryField;
    }
}