namespace SqlServerProcedureGenerator
{
    partial class ProcedureGenerator
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
            this.textBoxStatement = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxProcedurePrefix = new System.Windows.Forms.TextBox();
            this.textBoxProcedureSufix = new System.Windows.Forms.TextBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCreateProcedures = new System.Windows.Forms.Button();
            this.textBoxSearchBy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxStatement
            // 
            this.textBoxStatement.Location = new System.Drawing.Point(13, 135);
            this.textBoxStatement.Multiline = true;
            this.textBoxStatement.Name = "textBoxStatement";
            this.textBoxStatement.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStatement.Size = new System.Drawing.Size(700, 151);
            this.textBoxStatement.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CREATE TABLE statement:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Procedure prefix:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Procedure sufix:";
            // 
            // textBoxProcedurePrefix
            // 
            this.textBoxProcedurePrefix.Location = new System.Drawing.Point(101, 31);
            this.textBoxProcedurePrefix.Name = "textBoxProcedurePrefix";
            this.textBoxProcedurePrefix.Size = new System.Drawing.Size(184, 20);
            this.textBoxProcedurePrefix.TabIndex = 4;
            // 
            // textBoxProcedureSufix
            // 
            this.textBoxProcedureSufix.Location = new System.Drawing.Point(101, 66);
            this.textBoxProcedureSufix.Name = "textBoxProcedureSufix";
            this.textBoxProcedureSufix.Size = new System.Drawing.Size(184, 20);
            this.textBoxProcedureSufix.TabIndex = 5;
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(13, 406);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResult.Size = new System.Drawing.Size(700, 336);
            this.textBoxResult.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 390);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Result:";
            // 
            // buttonCreateProcedures
            // 
            this.buttonCreateProcedures.Location = new System.Drawing.Point(15, 320);
            this.buttonCreateProcedures.Name = "buttonCreateProcedures";
            this.buttonCreateProcedures.Size = new System.Drawing.Size(698, 46);
            this.buttonCreateProcedures.TabIndex = 8;
            this.buttonCreateProcedures.Text = "Create procedures";
            this.buttonCreateProcedures.UseVisualStyleBackColor = true;
            this.buttonCreateProcedures.Click += new System.EventHandler(this.buttonCreateProcedures_Click);
            // 
            // textBoxSearchBy
            // 
            this.textBoxSearchBy.Location = new System.Drawing.Point(521, 31);
            this.textBoxSearchBy.Name = "textBoxSearchBy";
            this.textBoxSearchBy.Size = new System.Drawing.Size(184, 20);
            this.textBoxSearchBy.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(459, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Search by";
            // 
            // ProcedureGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 744);
            this.Controls.Add(this.textBoxSearchBy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonCreateProcedures);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.textBoxProcedureSufix);
            this.Controls.Add(this.textBoxProcedurePrefix);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxStatement);
            this.Name = "ProcedureGenerator";
            this.Text = "Procedure Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxStatement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxProcedurePrefix;
        private System.Windows.Forms.TextBox textBoxProcedureSufix;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCreateProcedures;
        private System.Windows.Forms.TextBox textBoxSearchBy;
        private System.Windows.Forms.Label label5;
    }
}

