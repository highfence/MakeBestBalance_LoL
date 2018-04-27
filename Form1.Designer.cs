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
			this.Tabs = new System.Windows.Forms.TabControl();
			this.PlayerManagePage = new System.Windows.Forms.TabPage();
			this.MatchingList = new System.Windows.Forms.TabPage();
			((System.ComponentModel.ISupportInitialize)(this.PlayerGridView)).BeginInit();
			this.Tabs.SuspendLayout();
			this.PlayerManagePage.SuspendLayout();
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
			this.PlayerGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PlayerGridView_CellContentDoubleClick);
			this.PlayerGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PlayerGridView_CellContentDoubleClick);
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
			// Tabs
			// 
			this.Tabs.Controls.Add(this.PlayerManagePage);
			this.Tabs.Controls.Add(this.MatchingList);
			this.Tabs.Location = new System.Drawing.Point(12, 12);
			this.Tabs.Name = "Tabs";
			this.Tabs.SelectedIndex = 0;
			this.Tabs.Size = new System.Drawing.Size(849, 816);
			this.Tabs.TabIndex = 5;
			// 
			// PlayerManagePage
			// 
			this.PlayerManagePage.Controls.Add(this.PlayerGridView);
			this.PlayerManagePage.Location = new System.Drawing.Point(4, 22);
			this.PlayerManagePage.Name = "PlayerManagePage";
			this.PlayerManagePage.Padding = new System.Windows.Forms.Padding(3);
			this.PlayerManagePage.Size = new System.Drawing.Size(841, 790);
			this.PlayerManagePage.TabIndex = 0;
			this.PlayerManagePage.Text = "선수 관리";
			this.PlayerManagePage.UseVisualStyleBackColor = true;
			// 
			// MatchingList
			// 
			this.MatchingList.Location = new System.Drawing.Point(4, 22);
			this.MatchingList.Name = "MatchingList";
			this.MatchingList.Padding = new System.Windows.Forms.Padding(3);
			this.MatchingList.Size = new System.Drawing.Size(841, 790);
			this.MatchingList.TabIndex = 1;
			this.MatchingList.Text = "매칭 선수 목록";
			this.MatchingList.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1061, 858);
			this.Controls.Add(this.Tabs);
			this.Controls.Add(this.LoadPlayersButton);
			this.Controls.Add(this.SavePlayersButton);
			this.Controls.Add(this.DeletePlayerButton);
			this.Controls.Add(this.InsertPlayerButton);
			this.Name = "Form1";
			this.Text = "MakeBestBalance_LoL v1.0.0";
			((System.ComponentModel.ISupportInitialize)(this.PlayerGridView)).EndInit();
			this.Tabs.ResumeLayout(false);
			this.PlayerManagePage.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button InsertPlayerButton;
		private System.Windows.Forms.Button DeletePlayerButton;
		private System.Windows.Forms.DataGridView PlayerGridView;
		private System.Windows.Forms.Button SavePlayersButton;
		private System.Windows.Forms.Button LoadPlayersButton;
		private System.Windows.Forms.TabControl Tabs;
		private System.Windows.Forms.TabPage PlayerManagePage;
		private System.Windows.Forms.TabPage MatchingList;
	}
}

