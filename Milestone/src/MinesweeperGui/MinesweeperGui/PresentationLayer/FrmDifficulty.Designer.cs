namespace MinesweeperGui.PresentationLayer
{
    partial class FrmDifficulty
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
            lbPrompt = new Label();
            btnPlayGame = new Button();
            rbEasy = new RadioButton();
            rbIntermediate = new RadioButton();
            rbHard = new RadioButton();
            SuspendLayout();
            // 
            // lbPrompt
            // 
            lbPrompt.AutoSize = true;
            lbPrompt.Location = new Point(53, 100);
            lbPrompt.Name = "lbPrompt";
            lbPrompt.Size = new Size(84, 15);
            lbPrompt.TabIndex = 0;
            lbPrompt.Text = "Select dificulty";
            // 
            // btnPlayGame
            // 
            btnPlayGame.Location = new Point(347, 375);
            btnPlayGame.Name = "btnPlayGame";
            btnPlayGame.Size = new Size(102, 41);
            btnPlayGame.TabIndex = 1;
            btnPlayGame.Text = "Play Game";
            btnPlayGame.UseVisualStyleBackColor = true;
            btnPlayGame.Click += BtnStartGame_Click;
            // 
            // rbEasy
            // 
            rbEasy.AutoSize = true;
            rbEasy.Location = new Point(201, 142);
            rbEasy.Name = "rbEasy";
            rbEasy.Size = new Size(48, 19);
            rbEasy.TabIndex = 2;
            rbEasy.TabStop = true;
            rbEasy.Text = "Easy";
            rbEasy.UseVisualStyleBackColor = true;
            // 
            // rbIntermediate
            // 
            rbIntermediate.AutoSize = true;
            rbIntermediate.Location = new Point(201, 189);
            rbIntermediate.Name = "rbIntermediate";
            rbIntermediate.Size = new Size(92, 19);
            rbIntermediate.TabIndex = 3;
            rbIntermediate.TabStop = true;
            rbIntermediate.Text = "intermediate";
            rbIntermediate.UseVisualStyleBackColor = true;
            // 
            // rbHard
            // 
            rbHard.AutoSize = true;
            rbHard.Location = new Point(201, 238);
            rbHard.Name = "rbHard";
            rbHard.Size = new Size(51, 19);
            rbHard.TabIndex = 4;
            rbHard.TabStop = true;
            rbHard.Text = "Hard";
            rbHard.UseVisualStyleBackColor = true;
            // 
            // FrmDifficulty
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(494, 450);
            Controls.Add(rbHard);
            Controls.Add(rbIntermediate);
            Controls.Add(rbEasy);
            Controls.Add(btnPlayGame);
            Controls.Add(lbPrompt);
            Name = "FrmDifficulty";
            Text = "Select Difficulty";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbPrompt;
        private Button btnPlayGame;
        private RadioButton rbEasy;
        private RadioButton rbIntermediate;
        private RadioButton rbHard;
    }
}