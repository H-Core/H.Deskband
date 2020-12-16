namespace H.SearchDeskBand
{
    partial class DeskBandControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label = new System.Windows.Forms.Label();
            this.MenuButton = new FontAwesome.Sharp.IconButton();
            this.RecordButton = new FontAwesome.Sharp.IconButton();
            this.ShowMainApplicationButton = new FontAwesome.Sharp.IconButton();
            this.SettingsButton = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // Label
            // 
            this.Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label.ForeColor = System.Drawing.Color.Gray;
            this.Label.Location = new System.Drawing.Point(9, 9);
            this.Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(456, 40);
            this.Label.TabIndex = 0;
            this.Label.Text = "Enter Command Here";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label.Click += new System.EventHandler(this.OnClick);
            // 
            // MenuButton
            // 
            this.MenuButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.MenuButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.MenuButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.MenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MenuButton.IconChar = FontAwesome.Sharp.IconChar.List;
            this.MenuButton.IconColor = System.Drawing.Color.Black;
            this.MenuButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MenuButton.IconSize = 24;
            this.MenuButton.Location = new System.Drawing.Point(348, 5);
            this.MenuButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(38, 49);
            this.MenuButton.TabIndex = 1;
            this.MenuButton.UseVisualStyleBackColor = true;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // RecordButton
            // 
            this.RecordButton.BackColor = System.Drawing.Color.White;
            this.RecordButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.RecordButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.RecordButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.RecordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RecordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RecordButton.IconChar = FontAwesome.Sharp.IconChar.Microphone;
            this.RecordButton.IconColor = System.Drawing.Color.Black;
            this.RecordButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.RecordButton.IconSize = 24;
            this.RecordButton.Location = new System.Drawing.Point(306, 5);
            this.RecordButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(38, 49);
            this.RecordButton.TabIndex = 2;
            this.RecordButton.UseVisualStyleBackColor = false;
            this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // ShowMainApplicationButton
            // 
            this.ShowMainApplicationButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.ShowMainApplicationButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.ShowMainApplicationButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.ShowMainApplicationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowMainApplicationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowMainApplicationButton.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.ShowMainApplicationButton.IconColor = System.Drawing.Color.Black;
            this.ShowMainApplicationButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ShowMainApplicationButton.IconSize = 24;
            this.ShowMainApplicationButton.Location = new System.Drawing.Point(432, 5);
            this.ShowMainApplicationButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ShowMainApplicationButton.Name = "ShowMainApplicationButton";
            this.ShowMainApplicationButton.Size = new System.Drawing.Size(38, 49);
            this.ShowMainApplicationButton.TabIndex = 3;
            this.ShowMainApplicationButton.UseVisualStyleBackColor = true;
            this.ShowMainApplicationButton.Click += new System.EventHandler(this.UiButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.SettingsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.SettingsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SettingsButton.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleUp;
            this.SettingsButton.IconColor = System.Drawing.Color.Black;
            this.SettingsButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SettingsButton.IconSize = 24;
            this.SettingsButton.Location = new System.Drawing.Point(390, 5);
            this.SettingsButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(38, 49);
            this.SettingsButton.TabIndex = 4;
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // DeskBandControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.ShowMainApplicationButton);
            this.Controls.Add(this.RecordButton);
            this.Controls.Add(this.MenuButton);
            this.Controls.Add(this.Label);
            this.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(476, 60);
            this.MinimumSize = new System.Drawing.Size(476, 60);
            this.Name = "DeskBandControl";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.Size = new System.Drawing.Size(474, 58);
            this.Load += new System.EventHandler(this.DeskBandControl_Load);
            this.Click += new System.EventHandler(this.OnClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Label;
        private FontAwesome.Sharp.IconButton MenuButton;
        private FontAwesome.Sharp.IconButton RecordButton;
        private FontAwesome.Sharp.IconButton ShowMainApplicationButton;
        private FontAwesome.Sharp.IconButton SettingsButton;
    }
}
