namespace mei1161
{
    partial class JankenForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_rock = new System.Windows.Forms.Button();
            this.btn_scissors = new System.Windows.Forms.Button();
            this.btn_paper = new System.Windows.Forms.Button();
            this.lbl_result = new System.Windows.Forms.Label();
            this.lbl_player2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_player1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_rock
            // 
            this.btn_rock.BackColor = System.Drawing.Color.Tomato;
            this.btn_rock.Font = new System.Drawing.Font("MS UI Gothic", 30F);
            this.btn_rock.Location = new System.Drawing.Point(31, 54);
            this.btn_rock.Name = "btn_rock";
            this.btn_rock.Size = new System.Drawing.Size(227, 108);
            this.btn_rock.TabIndex = 0;
            this.btn_rock.Text = "グー";
            this.btn_rock.UseVisualStyleBackColor = false;
            this.btn_rock.Click += new System.EventHandler(this.SelectRock);
            // 
            // btn_scissors
            // 
            this.btn_scissors.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_scissors.Font = new System.Drawing.Font("MS UI Gothic", 30F);
            this.btn_scissors.Location = new System.Drawing.Point(279, 54);
            this.btn_scissors.Name = "btn_scissors";
            this.btn_scissors.Size = new System.Drawing.Size(239, 108);
            this.btn_scissors.TabIndex = 1;
            this.btn_scissors.Text = "チョキ";
            this.btn_scissors.UseVisualStyleBackColor = false;
            this.btn_scissors.Click += new System.EventHandler(this.SelectScissors);
            // 
            // btn_paper
            // 
            this.btn_paper.BackColor = System.Drawing.Color.Gold;
            this.btn_paper.Font = new System.Drawing.Font("MS UI Gothic", 30F);
            this.btn_paper.Location = new System.Drawing.Point(536, 54);
            this.btn_paper.Name = "btn_paper";
            this.btn_paper.Size = new System.Drawing.Size(236, 108);
            this.btn_paper.TabIndex = 2;
            this.btn_paper.Text = "パー";
            this.btn_paper.UseVisualStyleBackColor = false;
            this.btn_paper.Click += new System.EventHandler(this.SelectPaper);
            // 
            // lbl_result
            // 
            this.lbl_result.AutoSize = true;
            this.lbl_result.Font = new System.Drawing.Font("MS UI Gothic", 30F);
            this.lbl_result.Location = new System.Drawing.Point(24, 271);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(122, 40);
            this.lbl_result.TabIndex = 3;
            this.lbl_result.Text = "Result";
            // 
            // lbl_player2
            // 
            this.lbl_player2.AutoSize = true;
            this.lbl_player2.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.lbl_player2.Location = new System.Drawing.Point(645, 298);
            this.lbl_player2.Name = "lbl_player2";
            this.lbl_player2.Size = new System.Drawing.Size(98, 27);
            this.lbl_player2.TabIndex = 4;
            this.lbl_player2.Text = "Player2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "結果";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(387, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "あなた";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(667, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "あいて";
            // 
            // lbl_player1
            // 
            this.lbl_player1.AutoSize = true;
            this.lbl_player1.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.lbl_player1.Location = new System.Drawing.Point(357, 284);
            this.lbl_player1.Name = "lbl_player1";
            this.lbl_player1.Size = new System.Drawing.Size(98, 27);
            this.lbl_player1.TabIndex = 8;
            this.lbl_player1.Text = "Player1";
            // 
            // JankenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_player1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_player2);
            this.Controls.Add(this.lbl_result);
            this.Controls.Add(this.btn_paper);
            this.Controls.Add(this.btn_scissors);
            this.Controls.Add(this.btn_rock);
            this.Name = "JankenForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JankenForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_rock;
        private System.Windows.Forms.Button btn_scissors;
        private System.Windows.Forms.Button btn_paper;
        private System.Windows.Forms.Label lbl_result;
        private System.Windows.Forms.Label lbl_player2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_player1;
    }
}

