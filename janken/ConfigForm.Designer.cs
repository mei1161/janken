namespace mei1161
{
    partial class ConfigForm
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
            this.btn_recever = new System.Windows.Forms.Button();
            this.btn_sender = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_recever
            // 
            this.btn_recever.Location = new System.Drawing.Point(109, 56);
            this.btn_recever.Name = "btn_recever";
            this.btn_recever.Size = new System.Drawing.Size(110, 23);
            this.btn_recever.TabIndex = 0;
            this.btn_recever.Text = "待ち受けを開始する";
            this.btn_recever.UseVisualStyleBackColor = true;
            this.btn_recever.Click += new System.EventHandler(this.ListenerClick);
            // 
            // btn_sender
            // 
            this.btn_sender.Location = new System.Drawing.Point(505, 56);
            this.btn_sender.Name = "btn_sender";
            this.btn_sender.Size = new System.Drawing.Size(100, 23);
            this.btn_sender.TabIndex = 1;
            this.btn_sender.Text = "対戦相手を探す";
            this.btn_sender.UseVisualStyleBackColor = true;
            this.btn_sender.Click += new System.EventHandler(this.SenderClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(616, 387);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 27);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.button1.Location = new System.Drawing.Point(704, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 18);
            this.button1.TabIndex = 3;
            this.button1.Text = "送信";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.label1.Location = new System.Drawing.Point(613, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "相手のIPアドレス";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(545, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "上のボタンでつながらない場合";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_sender);
            this.Controls.Add(this.btn_recever);
            this.Name = "ConfigForm";
            this.Text = "Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_recever;
        private System.Windows.Forms.Button btn_sender;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}