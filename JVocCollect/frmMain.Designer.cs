namespace JVocCollect
{
	partial class frmMain
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
			this.btnGet = new System.Windows.Forms.Button();
			this.IE = new System.Windows.Forms.WebBrowser();
			this.txtSql = new System.Windows.Forms.TextBox();
			this.txtOrder = new System.Windows.Forms.TextBox();
			this.lblOrder = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnGet
			// 
			this.btnGet.Location = new System.Drawing.Point(1449, 75);
			this.btnGet.Name = "btnGet";
			this.btnGet.Size = new System.Drawing.Size(71, 27);
			this.btnGet.TabIndex = 0;
			this.btnGet.Text = "Get";
			this.btnGet.UseVisualStyleBackColor = true;
			this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
			// 
			// IE
			// 
			this.IE.Location = new System.Drawing.Point(0, 0);
			this.IE.MinimumSize = new System.Drawing.Size(20, 20);
			this.IE.Name = "IE";
			this.IE.Size = new System.Drawing.Size(1432, 438);
			this.IE.TabIndex = 1;
			// 
			// txtSql
			// 
			this.txtSql.Location = new System.Drawing.Point(0, 444);
			this.txtSql.Multiline = true;
			this.txtSql.Name = "txtSql";
			this.txtSql.Size = new System.Drawing.Size(1523, 246);
			this.txtSql.TabIndex = 2;
			// 
			// txtOrder
			// 
			this.txtOrder.Location = new System.Drawing.Point(1489, 148);
			this.txtOrder.Name = "txtOrder";
			this.txtOrder.Size = new System.Drawing.Size(34, 20);
			this.txtOrder.TabIndex = 3;
			this.txtOrder.Text = "1";
			// 
			// lblOrder
			// 
			this.lblOrder.AutoSize = true;
			this.lblOrder.Location = new System.Drawing.Point(1449, 148);
			this.lblOrder.Name = "lblOrder";
			this.lblOrder.Size = new System.Drawing.Size(34, 13);
			this.lblOrder.TabIndex = 4;
			this.lblOrder.Text = "order:";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1535, 690);
			this.Controls.Add(this.lblOrder);
			this.Controls.Add(this.txtOrder);
			this.Controls.Add(this.txtSql);
			this.Controls.Add(this.IE);
			this.Controls.Add(this.btnGet);
			this.Name = "frmMain";
			this.Text = "JVocCollect";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnGet;
		private System.Windows.Forms.WebBrowser IE;
		private System.Windows.Forms.TextBox txtSql;
		private System.Windows.Forms.TextBox txtOrder;
		private System.Windows.Forms.Label lblOrder;
	}
}

