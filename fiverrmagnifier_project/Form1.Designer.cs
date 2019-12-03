using System.Threading;
namespace fiverrmagnifier_project
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxViewer = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.size_txtbox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.y_txtbx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.percentageLbl = new System.Windows.Forms.Label();
            this.zoomin = new System.Windows.Forms.Button();
            this.zoomout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViewer)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(171, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Picture Box";
            // 
            // pictureBoxViewer
            // 
            this.pictureBoxViewer.Location = new System.Drawing.Point(12, 43);
            this.pictureBoxViewer.Name = "pictureBoxViewer";
            this.pictureBoxViewer.Size = new System.Drawing.Size(459, 232);
            this.pictureBoxViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxViewer.TabIndex = 1;
            this.pictureBoxViewer.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer_eventhandler);
            // 
            // size_txtbox
            // 
            this.size_txtbox.Location = new System.Drawing.Point(27, 4);
            this.size_txtbox.Name = "size_txtbox";
            this.size_txtbox.Size = new System.Drawing.Size(40, 20);
            this.size_txtbox.TabIndex = 4;
            this.size_txtbox.TextChanged += new System.EventHandler(this.size_txtbox_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Change";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.click_eventhandler);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.percentageLbl);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.zoomout);
            this.panel1.Controls.Add(this.zoomin);
            this.panel1.Controls.Add(this.y_txtbx);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.size_txtbox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 290);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 56);
            this.panel1.TabIndex = 6;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(177, 36);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "GrayScale";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // y_txtbx
            // 
            this.y_txtbx.Location = new System.Drawing.Point(112, 3);
            this.y_txtbx.Name = "y_txtbx";
            this.y_txtbx.Size = new System.Drawing.Size(40, 20);
            this.y_txtbx.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(89, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y";
            // 
            // percentageLbl
            // 
            this.percentageLbl.AutoSize = true;
            this.percentageLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentageLbl.Location = new System.Drawing.Point(212, 9);
            this.percentageLbl.Name = "percentageLbl";
            this.percentageLbl.Size = new System.Drawing.Size(25, 15);
            this.percentageLbl.TabIndex = 2;
            this.percentageLbl.Text = "0%";
            // 
            // zoomin
            // 
            this.zoomin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomin.Location = new System.Drawing.Point(172, 4);
            this.zoomin.Name = "zoomin";
            this.zoomin.Size = new System.Drawing.Size(34, 23);
            this.zoomin.TabIndex = 1;
            this.zoomin.Text = "+";
            this.zoomin.UseVisualStyleBackColor = true;
            this.zoomin.Click += new System.EventHandler(this.zoomin_Click);
            // 
            // zoomout
            // 
            this.zoomout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomout.Location = new System.Drawing.Point(248, 4);
            this.zoomout.Name = "zoomout";
            this.zoomout.Size = new System.Drawing.Size(34, 23);
            this.zoomout.TabIndex = 0;
            this.zoomout.Text = "-";
            this.zoomout.UseVisualStyleBackColor = true;
            this.zoomout.Click += new System.EventHandler(this.zoomout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 346);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxViewer);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Magnifier Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_keydown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViewer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        //All the Gui Objects used including the timer
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxViewer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox size_txtbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox y_txtbx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label percentageLbl;
        private System.Windows.Forms.Button zoomin;
        private System.Windows.Forms.Button zoomout;
    }
}

