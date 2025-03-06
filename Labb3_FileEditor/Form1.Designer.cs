namespace Labb3_FileEditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            text_box = new TextBox();
            save_button = new Button();
            remove_button = new Button();
            SaveAs_button = new Button();
            open_button = new Button();
            SuspendLayout();
            // 
            // text_box
            // 
            text_box.Location = new Point(217, 24);
            text_box.Multiline = true;
            text_box.Name = "text_box";
            text_box.Size = new Size(553, 329);
            text_box.TabIndex = 0;
            text_box.TextChanged += text_box_TextChanged;
            // 
            // save_button
            // 
            save_button.Location = new Point(12, 55);
            save_button.Name = "save_button";
            save_button.Size = new Size(75, 23);
            save_button.TabIndex = 1;
            save_button.Text = "Save";
            save_button.UseVisualStyleBackColor = true;
            save_button.Click += save_button_Click;
            // 
            // remove_button
            // 
            remove_button.Location = new Point(113, 55);
            remove_button.Name = "remove_button";
            remove_button.Size = new Size(75, 23);
            remove_button.TabIndex = 2;
            remove_button.Text = "Remove";
            remove_button.UseVisualStyleBackColor = true;
            remove_button.Click += remove_button_Click;
            // 
            // SaveAs_button
            // 
            SaveAs_button.Location = new Point(12, 125);
            SaveAs_button.Name = "SaveAs_button";
            SaveAs_button.Size = new Size(75, 23);
            SaveAs_button.TabIndex = 3;
            SaveAs_button.Text = "Save as";
            SaveAs_button.UseVisualStyleBackColor = true;
            SaveAs_button.Click += SaveAs_button_Click;
            // 
            // open_button
            // 
            open_button.Location = new Point(113, 125);
            open_button.Name = "open_button";
            open_button.Size = new Size(75, 23);
            open_button.TabIndex = 4;
            open_button.Text = "Open";
            open_button.UseVisualStyleBackColor = true;
            open_button.Click += open_button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 416);
            Controls.Add(open_button);
            Controls.Add(SaveAs_button);
            Controls.Add(remove_button);
            Controls.Add(save_button);
            Controls.Add(text_box);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox text_box;
        private Button save_button;
        private Button remove_button;
        private Button SaveAs_button;
        private Button open_button;
    }
}
