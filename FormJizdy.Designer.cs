namespace Autoskola
{
    partial class FormJizdy
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
            this.BtnVytvoritJizdu = new System.Windows.Forms.Button();
            this.BtnOdstranitJizdu = new System.Windows.Forms.Button();
            this.BtnUpravitJizdu = new System.Windows.Forms.Button();
            this.lvSeznamJizd = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // BtnVytvoritJizdu
            // 
            this.BtnVytvoritJizdu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnVytvoritJizdu.Location = new System.Drawing.Point(41, 46);
            this.BtnVytvoritJizdu.Margin = new System.Windows.Forms.Padding(4);
            this.BtnVytvoritJizdu.Name = "BtnVytvoritJizdu";
            this.BtnVytvoritJizdu.Size = new System.Drawing.Size(264, 140);
            this.BtnVytvoritJizdu.TabIndex = 1;
            this.BtnVytvoritJizdu.Text = "Vytvořit jízdy";
            this.BtnVytvoritJizdu.UseVisualStyleBackColor = true;
            this.BtnVytvoritJizdu.Click += new System.EventHandler(this.BtnVytvoritJizdu_Click);
            // 
            // BtnOdstranitJizdu
            // 
            this.BtnOdstranitJizdu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnOdstranitJizdu.Location = new System.Drawing.Point(41, 368);
            this.BtnOdstranitJizdu.Margin = new System.Windows.Forms.Padding(4);
            this.BtnOdstranitJizdu.Name = "BtnOdstranitJizdu";
            this.BtnOdstranitJizdu.Size = new System.Drawing.Size(264, 140);
            this.BtnOdstranitJizdu.TabIndex = 3;
            this.BtnOdstranitJizdu.Text = "Odstranit jízdu";
            this.BtnOdstranitJizdu.UseVisualStyleBackColor = true;
            this.BtnOdstranitJizdu.Click += new System.EventHandler(this.BtnOdstranitJizdu_Click);
            // 
            // BtnUpravitJizdu
            // 
            this.BtnUpravitJizdu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnUpravitJizdu.Location = new System.Drawing.Point(41, 206);
            this.BtnUpravitJizdu.Margin = new System.Windows.Forms.Padding(4);
            this.BtnUpravitJizdu.Name = "BtnUpravitJizdu";
            this.BtnUpravitJizdu.Size = new System.Drawing.Size(264, 140);
            this.BtnUpravitJizdu.TabIndex = 2;
            this.BtnUpravitJizdu.Text = "Upravit jízdu";
            this.BtnUpravitJizdu.UseVisualStyleBackColor = true;
            this.BtnUpravitJizdu.Click += new System.EventHandler(this.BtnUpravitJizdu_Click);
            // 
            // lvSeznamJizd
            // 
            this.lvSeznamJizd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvSeznamJizd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lvSeznamJizd.FullRowSelect = true;
            this.lvSeznamJizd.GridLines = true;
            this.lvSeznamJizd.HideSelection = false;
            this.lvSeznamJizd.Location = new System.Drawing.Point(312, 46);
            this.lvSeznamJizd.MultiSelect = false;
            this.lvSeznamJizd.Name = "lvSeznamJizd";
            this.lvSeznamJizd.Size = new System.Drawing.Size(645, 462);
            this.lvSeznamJizd.TabIndex = 5;
            this.lvSeznamJizd.UseCompatibleStateImageBehavior = false;
            this.lvSeznamJizd.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Datum & čas";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Student";
            this.columnHeader2.Width = 170;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Instruktor";
            this.columnHeader3.Width = 160;
            // 
            // FormJizdy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 548);
            this.Controls.Add(this.lvSeznamJizd);
            this.Controls.Add(this.BtnOdstranitJizdu);
            this.Controls.Add(this.BtnUpravitJizdu);
            this.Controls.Add(this.BtnVytvoritJizdu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormJizdy";
            this.Text = "FormJizdy";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnVytvoritJizdu;
        private System.Windows.Forms.Button BtnOdstranitJizdu;
        private System.Windows.Forms.Button BtnUpravitJizdu;
        private System.Windows.Forms.ListView lvSeznamJizd;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }

}