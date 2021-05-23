
namespace PasswordSystem
{
    partial class NewPasswordCreation
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.pswBox = new System.Windows.Forms.TextBox();
            this.appBox = new System.Windows.Forms.TextBox();
            this.commBox = new System.Windows.Forms.TextBox();
            this.addButton1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(327, 136);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(209, 27);
            this.nameBox.TabIndex = 0;
            // 
            // pswBox
            // 
            this.pswBox.Location = new System.Drawing.Point(327, 169);
            this.pswBox.Name = "pswBox";
            this.pswBox.Size = new System.Drawing.Size(209, 27);
            this.pswBox.TabIndex = 1;
            // 
            // appBox
            // 
            this.appBox.Location = new System.Drawing.Point(327, 202);
            this.appBox.Name = "appBox";
            this.appBox.Size = new System.Drawing.Size(209, 27);
            this.appBox.TabIndex = 2;
            // 
            // commBox
            // 
            this.commBox.Location = new System.Drawing.Point(327, 235);
            this.commBox.Name = "commBox";
            this.commBox.Size = new System.Drawing.Size(209, 27);
            this.commBox.TabIndex = 3;
            // 
            // addButton1
            // 
            this.addButton1.Location = new System.Drawing.Point(373, 302);
            this.addButton1.Name = "addButton1";
            this.addButton1.Size = new System.Drawing.Size(94, 29);
            this.addButton1.TabIndex = 4;
            this.addButton1.Text = "Add";
            this.addButton1.UseVisualStyleBackColor = true;
            this.addButton1.Click += new System.EventHandler(this.addButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Application:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Comment:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(583, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NewPasswordCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addButton1);
            this.Controls.Add(this.commBox);
            this.Controls.Add(this.appBox);
            this.Controls.Add(this.pswBox);
            this.Controls.Add(this.nameBox);
            this.Name = "NewPasswordCreation";
            this.Text = "NewPasswordCreation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox pswBox;
        private System.Windows.Forms.TextBox appBox;
        private System.Windows.Forms.TextBox commBox;
        private System.Windows.Forms.Button addButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}