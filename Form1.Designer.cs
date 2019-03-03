namespace Remote_Control_Server
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.divider0 = new MaterialSkin.Controls.MaterialDivider();
            this.LoginBTN = new MaterialSkin.Controls.MaterialRaisedButton();
            this.rememeberBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.logineclipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.closeControl = new Bunifu.Framework.UI.BunifuImageButton();
            this.loginDragCTRL = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.errorLabel = new MaterialSkin.Controls.MaterialLabel();
            this.passtxt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.userTxt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeControl)).BeginInit();
            this.SuspendLayout();
            // 
            // divider0
            // 
            this.divider0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.divider0.Depth = 0;
            this.divider0.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.divider0.Location = new System.Drawing.Point(0, 208);
            this.divider0.MouseState = MaterialSkin.MouseState.HOVER;
            this.divider0.Name = "divider0";
            this.divider0.Size = new System.Drawing.Size(419, 44);
            this.divider0.TabIndex = 14;
            this.divider0.Text = "materialDivider1";
            // 
            // LoginBTN
            // 
            this.LoginBTN.Depth = 0;
            this.LoginBTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(46)))));
            this.LoginBTN.Location = new System.Drawing.Point(245, 159);
            this.LoginBTN.MouseState = MaterialSkin.MouseState.HOVER;
            this.LoginBTN.Name = "LoginBTN";
            this.LoginBTN.Primary = true;
            this.LoginBTN.Size = new System.Drawing.Size(75, 23);
            this.LoginBTN.TabIndex = 13;
            this.LoginBTN.Text = "Log in";
            this.LoginBTN.UseVisualStyleBackColor = true;
            // 
            // rememeberBox
            // 
            this.rememeberBox.AutoSize = true;
            this.rememeberBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(44)))), ((int)(((byte)(79)))));
            this.rememeberBox.Depth = 0;
            this.rememeberBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rememeberBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.rememeberBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(46)))));
            this.rememeberBox.Location = new System.Drawing.Point(94, 152);
            this.rememeberBox.Margin = new System.Windows.Forms.Padding(0);
            this.rememeberBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rememeberBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.rememeberBox.Name = "rememeberBox";
            this.rememeberBox.Ripple = true;
            this.rememeberBox.Size = new System.Drawing.Size(120, 30);
            this.rememeberBox.TabIndex = 12;
            this.rememeberBox.Text = "Remember me";
            this.rememeberBox.UseVisualStyleBackColor = true;
            // 
            // logineclipse
            // 
            this.logineclipse.ElipseRadius = 7;
            this.logineclipse.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bunifuImageButton2);
            this.panel1.Controls.Add(this.closeControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 37);
            this.panel1.TabIndex = 17;
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(46)))));
            this.bunifuImageButton2.Image = global::Remote_Control_Server.Properties.Resources.greencontrol;
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(29, 3);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(20, 20);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 5;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 10;
            this.bunifuImageButton2.Click += new System.EventHandler(this.bunifuImageButton2_Click);
            // 
            // closeControl
            // 
            this.closeControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(46)))));
            this.closeControl.Image = global::Remote_Control_Server.Properties.Resources.pinkControl;
            this.closeControl.ImageActive = null;
            this.closeControl.Location = new System.Drawing.Point(3, 3);
            this.closeControl.Name = "closeControl";
            this.closeControl.Size = new System.Drawing.Size(20, 20);
            this.closeControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeControl.TabIndex = 4;
            this.closeControl.TabStop = false;
            this.closeControl.Zoom = 10;
            this.closeControl.Click += new System.EventHandler(this.closeControl_Click);
            // 
            // loginDragCTRL
            // 
            this.loginDragCTRL.Fixed = true;
            this.loginDragCTRL.Horizontal = true;
            this.loginDragCTRL.TargetControl = this;
            this.loginDragCTRL.Vertical = true;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.Transparent;
            this.errorLabel.Depth = 0;
            this.errorLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.errorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.errorLabel.Location = new System.Drawing.Point(145, 44);
            this.errorLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 19);
            this.errorLabel.TabIndex = 20;
            // 
            // passtxt
            // 
            this.passtxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.passtxt.ForeColor = System.Drawing.Color.White;
            this.passtxt.HintForeColor = System.Drawing.Color.White;
            this.passtxt.HintText = " Password";
            this.passtxt.isPassword = false;
            this.passtxt.LineFocusedColor = System.Drawing.Color.White;
            this.passtxt.LineIdleColor = System.Drawing.Color.White;
            this.passtxt.LineMouseHoverColor = System.Drawing.Color.Yellow;
            this.passtxt.LineThickness = 3;
            this.passtxt.Location = new System.Drawing.Point(94, 119);
            this.passtxt.Margin = new System.Windows.Forms.Padding(4);
            this.passtxt.Name = "passtxt";
            this.passtxt.Size = new System.Drawing.Size(255, 29);
            this.passtxt.TabIndex = 19;
            this.passtxt.Text = "admin";
            this.passtxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // userTxt
            // 
            this.userTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.userTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.userTxt.ForeColor = System.Drawing.Color.White;
            this.userTxt.HintForeColor = System.Drawing.Color.White;
            this.userTxt.HintText = " Username";
            this.userTxt.isPassword = false;
            this.userTxt.LineFocusedColor = System.Drawing.Color.White;
            this.userTxt.LineIdleColor = System.Drawing.Color.White;
            this.userTxt.LineMouseHoverColor = System.Drawing.Color.Yellow;
            this.userTxt.LineThickness = 3;
            this.userTxt.Location = new System.Drawing.Point(94, 92);
            this.userTxt.Margin = new System.Windows.Forms.Padding(4);
            this.userTxt.Name = "userTxt";
            this.userTxt.Size = new System.Drawing.Size(255, 29);
            this.userTxt.TabIndex = 18;
            this.userTxt.Text = "admin";
            this.userTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(419, 252);
            this.Controls.Add(this.divider0);
            this.Controls.Add(this.LoginBTN);
            this.Controls.Add(this.rememeberBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.passtxt);
            this.Controls.Add(this.userTxt);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialDivider divider0;
        private MaterialSkin.Controls.MaterialRaisedButton LoginBTN;
        private MaterialSkin.Controls.MaterialCheckBox rememeberBox;
        private Bunifu.Framework.UI.BunifuElipse logineclipse;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private Bunifu.Framework.UI.BunifuImageButton closeControl;
        private MaterialSkin.Controls.MaterialLabel errorLabel;
        private Bunifu.Framework.UI.BunifuMaterialTextbox passtxt;
        private Bunifu.Framework.UI.BunifuMaterialTextbox userTxt;
        private Bunifu.Framework.UI.BunifuDragControl loginDragCTRL;
    }
}

