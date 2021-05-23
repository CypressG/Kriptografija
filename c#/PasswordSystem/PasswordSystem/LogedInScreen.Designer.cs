
namespace PasswordSystem
{
    partial class LogedInScreen
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
            this.searchOptionButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.changePasswordButton = new System.Windows.Forms.Button();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.newPasswordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.argon2TextBox = new System.Windows.Forms.TextBox();
            this.passwordNameBox = new System.Windows.Forms.CheckedListBox();
            this.addNewPSWbutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchOptionButton
            // 
            this.searchOptionButton.Location = new System.Drawing.Point(67, 633);
            this.searchOptionButton.Name = "searchOptionButton";
            this.searchOptionButton.Size = new System.Drawing.Size(182, 29);
            this.searchOptionButton.TabIndex = 0;
            this.searchOptionButton.Text = "Search";
            this.searchOptionButton.UseVisualStyleBackColor = true;
            this.searchOptionButton.Click += new System.EventHandler(this.searchOptionButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(378, 587);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "Delete user";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // changePasswordButton
            // 
            this.changePasswordButton.Location = new System.Drawing.Point(378, 633);
            this.changePasswordButton.Name = "changePasswordButton";
            this.changePasswordButton.Size = new System.Drawing.Size(182, 29);
            this.changePasswordButton.TabIndex = 2;
            this.changePasswordButton.Text = "Change password";
            this.changePasswordButton.UseVisualStyleBackColor = true;
            this.changePasswordButton.Click += new System.EventHandler(this.changePasswordButton_Click);
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(175, 300);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(385, 27);
            this.inputBox.TabIndex = 3;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(175, 358);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(385, 27);
            this.passwordBox.TabIndex = 4;
            // 
            // newPasswordBox
            // 
            this.newPasswordBox.Location = new System.Drawing.Point(175, 490);
            this.newPasswordBox.Name = "newPasswordBox";
            this.newPasswordBox.Size = new System.Drawing.Size(385, 27);
            this.newPasswordBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Username for search";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 497);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "New password";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(586, 488);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(94, 29);
            this.generateButton.TabIndex = 11;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(586, 358);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(94, 29);
            this.decryptButton.TabIndex = 12;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(711, 356);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(94, 29);
            this.copyButton.TabIndex = 13;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // argon2TextBox
            // 
            this.argon2TextBox.Location = new System.Drawing.Point(175, 435);
            this.argon2TextBox.Name = "argon2TextBox";
            this.argon2TextBox.Size = new System.Drawing.Size(385, 27);
            this.argon2TextBox.TabIndex = 14;
            // 
            // passwordNameBox
            // 
            this.passwordNameBox.FormattingEnabled = true;
            this.passwordNameBox.Location = new System.Drawing.Point(27, 12);
            this.passwordNameBox.Name = "passwordNameBox";
            this.passwordNameBox.Size = new System.Drawing.Size(863, 268);
            this.passwordNameBox.TabIndex = 15;
            this.passwordNameBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.passwordNameBox_ItemCheck);
            // 
            // addNewPSWbutton
            // 
            this.addNewPSWbutton.Location = new System.Drawing.Point(981, 572);
            this.addNewPSWbutton.Name = "addNewPSWbutton";
            this.addNewPSWbutton.Size = new System.Drawing.Size(162, 112);
            this.addNewPSWbutton.TabIndex = 16;
            this.addNewPSWbutton.Text = "Add new password";
            this.addNewPSWbutton.UseVisualStyleBackColor = true;
            this.addNewPSWbutton.Click += new System.EventHandler(this.addNewPSWbutton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(896, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 27);
            this.button1.TabIndex = 17;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LogedInScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 767);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addNewPSWbutton);
            this.Controls.Add(this.passwordNameBox);
            this.Controls.Add(this.argon2TextBox);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newPasswordBox);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.changePasswordButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.searchOptionButton);
            this.Name = "LogedInScreen";
            this.Text = "LogedInScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogedInScreen_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchOptionButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button changePasswordButton;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox newPasswordBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.TextBox argon2TextBox;
        private System.Windows.Forms.CheckedListBox passwordNameBox;
        private System.Windows.Forms.Button addNewPSWbutton;
        private System.Windows.Forms.Button button1;
    }
}