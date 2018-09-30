

namespace mRemoteNG.UI.Forms.OptionsPages
{
	
    public sealed partial class ApiConnectionPage : OptionsPage
	{
			
		//UserControl overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
			
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlServerPage));
            this.lblTennantName = new mRemoteNG.UI.Controls.Base.NGLabel();
            this.txtAPITennant = new mRemoteNG.UI.Controls.Base.NGTextBox();
            this.lblExperimental = new mRemoteNG.UI.Controls.Base.NGLabel();
            this.chkUseAPISync = new mRemoteNG.UI.Controls.Base.NGCheckBox();
            this.lblSQLUsername = new mRemoteNG.UI.Controls.Base.NGLabel();
            this.txtAPIPassword = new mRemoteNG.UI.Controls.Base.NGTextBox();
            this.lblSQLInfo = new mRemoteNG.UI.Controls.Base.NGLabel();
            this.lblAPIEndpoint = new mRemoteNG.UI.Controls.Base.NGLabel();
            this.txtAPIUsername = new mRemoteNG.UI.Controls.Base.NGTextBox();
            this.txtAPIEndpoint = new mRemoteNG.UI.Controls.Base.NGTextBox();
            this.lblSQLPassword = new mRemoteNG.UI.Controls.Base.NGLabel();
            this.btnTestConnection = new mRemoteNG.UI.Controls.Base.NGButton();
            this.imgConnectionStatus = new System.Windows.Forms.PictureBox();
            this.lblTestConnectionResults = new mRemoteNG.UI.Controls.Base.NGLabel();
            ((System.ComponentModel.ISupportInitialize)(this.imgConnectionStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTennantName
            // 
            this.lblTennantName.Enabled = false;
            this.lblTennantName.Location = new System.Drawing.Point(23, 132);
            this.lblTennantName.Name = "lblTennantName";
            this.lblTennantName.Size = new System.Drawing.Size(111, 13);
            this.lblTennantName.TabIndex = 5;
            this.lblTennantName.Text = "Tennant:";
            this.lblTennantName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtAPITennant
            // 
            this.txtAPITennant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAPITennant.Enabled = false;
            this.txtAPITennant.Location = new System.Drawing.Point(140, 130);
            this.txtAPITennant.Name = "txtAPITennant";
            this.txtAPITennant.Size = new System.Drawing.Size(153, 20);
            this.txtAPITennant.TabIndex = 6;
            // 
            // lblExperimental
            // 
            this.lblExperimental.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExperimental.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lblExperimental.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblExperimental.Location = new System.Drawing.Point(3, 0);
            this.lblExperimental.Name = "lblExperimental";
            this.lblExperimental.Size = new System.Drawing.Size(596, 25);
            this.lblExperimental.TabIndex = 0;
            this.lblExperimental.Text = "EXPERIMENTAL";
            this.lblExperimental.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkUseAPISync
            // 
            this.chkUseAPISync._mice = mRemoteNG.UI.Controls.Base.NGCheckBox.MouseState.HOVER;
            this.chkUseAPISync.AutoSize = true;
            this.chkUseAPISync.Location = new System.Drawing.Point(3, 76);
            this.chkUseAPISync.Name = "chkUseAPISync";
            this.chkUseAPISync.Size = new System.Drawing.Size(196, 17);
            this.chkUseAPISync.TabIndex = 2;
            this.chkUseAPISync.Text = "Use API to load && save connections";
            this.chkUseAPISync.UseVisualStyleBackColor = true;
            this.chkUseAPISync.CheckedChanged += new System.EventHandler(this.chkUseSQLServer_CheckedChanged);
            // 
            // lblSQLUsername
            // 
            this.lblSQLUsername.Enabled = false;
            this.lblSQLUsername.Location = new System.Drawing.Point(23, 158);
            this.lblSQLUsername.Name = "lblSQLUsername";
            this.lblSQLUsername.Size = new System.Drawing.Size(111, 13);
            this.lblSQLUsername.TabIndex = 7;
            this.lblSQLUsername.Text = "Username:";
            this.lblSQLUsername.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtAPIPassword
            // 
            this.txtAPIPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAPIPassword.Enabled = false;
            this.txtAPIPassword.Location = new System.Drawing.Point(140, 182);
            this.txtAPIPassword.Name = "txtAPIPassword";
            this.txtAPIPassword.Size = new System.Drawing.Size(153, 20);
            this.txtAPIPassword.TabIndex = 10;
            this.txtAPIPassword.UseSystemPasswordChar = true;
            // 
            // lblSQLInfo
            // 
            this.lblSQLInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSQLInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lblSQLInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSQLInfo.Location = new System.Drawing.Point(3, 25);
            this.lblSQLInfo.Name = "lblSQLInfo";
            this.lblSQLInfo.Size = new System.Drawing.Size(596, 25);
            this.lblSQLInfo.TabIndex = 1;
            this.lblSQLInfo.Text = "Please see Help - Getting started - SQL Configuration for more Info!";
            this.lblSQLInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAPIEndpoint
            // 
            this.lblAPIEndpoint.Enabled = false;
            this.lblAPIEndpoint.Location = new System.Drawing.Point(23, 106);
            this.lblAPIEndpoint.Name = "lblAPIEndpoint";
            this.lblAPIEndpoint.Size = new System.Drawing.Size(111, 13);
            this.lblAPIEndpoint.TabIndex = 3;
            this.lblAPIEndpoint.Text = "API URL:";
            this.lblAPIEndpoint.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtAPIUsername
            // 
            this.txtAPIUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAPIUsername.Enabled = false;
            this.txtAPIUsername.Location = new System.Drawing.Point(140, 156);
            this.txtAPIUsername.Name = "txtAPIUsername";
            this.txtAPIUsername.Size = new System.Drawing.Size(153, 20);
            this.txtAPIUsername.TabIndex = 8;
            // 
            // txtAPIEndpoint
            // 
            this.txtAPIEndpoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAPIEndpoint.Enabled = false;
            this.txtAPIEndpoint.Location = new System.Drawing.Point(140, 103);
            this.txtAPIEndpoint.Name = "txtAPIEndpoint";
            this.txtAPIEndpoint.Size = new System.Drawing.Size(153, 20);
            this.txtAPIEndpoint.TabIndex = 4;
            // 
            // lblSQLPassword
            // 
            this.lblSQLPassword.Enabled = false;
            this.lblSQLPassword.Location = new System.Drawing.Point(23, 184);
            this.lblSQLPassword.Name = "lblSQLPassword";
            this.lblSQLPassword.Size = new System.Drawing.Size(111, 13);
            this.lblSQLPassword.TabIndex = 9;
            this.lblSQLPassword.Text = "Password:";
            this.lblSQLPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection._mice = mRemoteNG.UI.Controls.Base.NGButton.MouseState.HOVER;
            this.btnTestConnection.Enabled = false;
            this.btnTestConnection.Location = new System.Drawing.Point(140, 228);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(153, 23);
            this.btnTestConnection.TabIndex = 11;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // imgConnectionStatus
            // 
            this.imgConnectionStatus.Image = global::mRemoteNG.Resources.Help;
            this.imgConnectionStatus.Location = new System.Drawing.Point(297, 231);
            this.imgConnectionStatus.Name = "imgConnectionStatus";
            this.imgConnectionStatus.Size = new System.Drawing.Size(16, 16);
            this.imgConnectionStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgConnectionStatus.TabIndex = 12;
            this.imgConnectionStatus.TabStop = false;
            // 
            // lblTestConnectionResults
            // 
            this.lblTestConnectionResults.AutoSize = true;
            this.lblTestConnectionResults.Location = new System.Drawing.Point(137, 254);
            this.lblTestConnectionResults.Name = "lblTestConnectionResults";
            this.lblTestConnectionResults.Size = new System.Drawing.Size(117, 13);
            this.lblTestConnectionResults.TabIndex = 13;
            this.lblTestConnectionResults.Text = "Test connection details";
            // 
            // ApiConnectionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTestConnectionResults);
            this.Controls.Add(this.imgConnectionStatus);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.lblTennantName);
            this.Controls.Add(this.txtAPITennant);
            this.Controls.Add(this.lblExperimental);
            this.Controls.Add(this.chkUseAPISync);
            this.Controls.Add(this.lblSQLUsername);
            this.Controls.Add(this.txtAPIPassword);
            this.Controls.Add(this.lblSQLInfo);
            this.Controls.Add(this.lblAPIEndpoint);
            this.Controls.Add(this.txtAPIUsername);
            this.Controls.Add(this.txtAPIEndpoint);
            this.Controls.Add(this.lblSQLPassword);
            this.Name = "ApiConnectionPage";
            this.PageIcon = ((System.Drawing.Icon)(resources.GetObject("$this.PageIcon")));
            this.Size = new System.Drawing.Size(610, 489);
            ((System.ComponentModel.ISupportInitialize)(this.imgConnectionStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal Controls.Base.NGLabel lblTennantName;
		internal Controls.Base.NGTextBox txtAPITennant;
		internal Controls.Base.NGLabel lblExperimental;
		internal Controls.Base.NGCheckBox chkUseAPISync;
		internal Controls.Base.NGLabel lblSQLUsername;
		internal Controls.Base.NGTextBox txtAPIPassword;
		internal Controls.Base.NGLabel lblSQLInfo;
		internal Controls.Base.NGLabel lblAPIEndpoint;
		internal Controls.Base.NGTextBox txtAPIUsername;
		internal Controls.Base.NGTextBox txtAPIEndpoint;
		internal Controls.Base.NGLabel lblSQLPassword;
        private Controls.Base.NGButton btnTestConnection;
        private System.Windows.Forms.PictureBox imgConnectionStatus;
        private System.ComponentModel.IContainer components;
        private Controls.Base.NGLabel lblTestConnectionResults;
    }
}
