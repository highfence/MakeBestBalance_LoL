namespace MakeBestBalance_LoL
{
	partial class Form1
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.InsertPlayerButton = new System.Windows.Forms.Button();
			this.DeletePlayerButton = new System.Windows.Forms.Button();
			this.PlayerGridView = new System.Windows.Forms.DataGridView();
			this.SavePlayersButton = new System.Windows.Forms.Button();
			this.LoadPlayersButton = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			((System.ComponentModel.ISupportInitialize)(this.PlayerGridView)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// InsertPlayerButton
			// 
			this.InsertPlayerButton.Location = new System.Drawing.Point(877, 34);
			this.InsertPlayerButton.Name = "InsertPlayerButton";
			this.InsertPlayerButton.Size = new System.Drawing.Size(172, 37);
			this.InsertPlayerButton.TabIndex = 0;
			this.InsertPlayerButton.Text = "선수 추가";
			this.InsertPlayerButton.UseVisualStyleBackColor = true;
			this.InsertPlayerButton.Click += new System.EventHandler(this.InsertNewPlayer);
			// 
			// DeletePlayerButton
			// 
			this.DeletePlayerButton.Location = new System.Drawing.Point(877, 78);
			this.DeletePlayerButton.Name = "DeletePlayerButton";
			this.DeletePlayerButton.Size = new System.Drawing.Size(172, 41);
			this.DeletePlayerButton.TabIndex = 1;
			this.DeletePlayerButton.Text = "선택한 선수 삭제";
			this.DeletePlayerButton.UseVisualStyleBackColor = true;
			this.DeletePlayerButton.Click += new System.EventHandler(this.DeleteSelectPlayer);
			// 
			// PlayerGridView
			// 
			this.PlayerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.PlayerGridView.Location = new System.Drawing.Point(0, 0);
			this.PlayerGridView.Name = "PlayerGridView";
			this.PlayerGridView.RowTemplate.Height = 23;
			this.PlayerGridView.Size = new System.Drawing.Size(841, 790);
			this.PlayerGridView.TabIndex = 2;
			// 
			// SavePlayersButton
			// 
			this.SavePlayersButton.Location = new System.Drawing.Point(877, 142);
			this.SavePlayersButton.Name = "SavePlayersButton";
			this.SavePlayersButton.Size = new System.Drawing.Size(172, 37);
			this.SavePlayersButton.TabIndex = 3;
			this.SavePlayersButton.Text = "선수 목록 저장";
			this.SavePlayersButton.UseVisualStyleBackColor = true;
			this.SavePlayersButton.Click += new System.EventHandler(this.SavePlayerListToFile);
			// 
			// LoadPlayersButton
			// 
			this.LoadPlayersButton.Location = new System.Drawing.Point(877, 185);
			this.LoadPlayersButton.Name = "LoadPlayersButton";
			this.LoadPlayersButton.Size = new System.Drawing.Size(172, 38);
			this.LoadPlayersButton.TabIndex = 4;
			this.LoadPlayersButton.Text = "선수 목록 로드";
			this.LoadPlayersButton.UseVisualStyleBackColor = true;
			this.LoadPlayersButton.Click += new System.EventHandler(this.LoadPlayersFromFile);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(849, 816);
			this.tabControl1.TabIndex = 5;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.PlayerGridView);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(841, 790);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(841, 790);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1061, 858);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.LoadPlayersButton);
			this.Controls.Add(this.SavePlayersButton);
			this.Controls.Add(this.DeletePlayerButton);
			this.Controls.Add(this.InsertPlayerButton);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.PlayerGridView)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button InsertPlayerButton;
		private System.Windows.Forms.Button DeletePlayerButton;
		private System.Windows.Forms.DataGridView PlayerGridView;
		private System.Windows.Forms.Button SavePlayersButton;
		private System.Windows.Forms.Button LoadPlayersButton;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
	}
}

