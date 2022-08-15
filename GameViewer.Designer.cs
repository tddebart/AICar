using SharpNeat.Windows;
using SharpNeat.Windows.Neat;

namespace AICar;

partial class GameViewer
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            // this.button1 = new System.Windows.Forms.Button();
            this.fitnessCheckBox = new System.Windows.Forms.CheckBox();
            this.fitnessLabel = new System.Windows.Forms.Label();
            this.genomeControl = new NeatGenomeControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox.Location = new System.Drawing.Point(22, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1900, 962);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.Update);
            // 
            // button1
            // 
            // this.button1.Location = new System.Drawing.Point(1446, 23);
            // this.button1.Name = "button1";
            // this.button1.Size = new System.Drawing.Size(224, 104);
            // this.button1.TabIndex = 1;
            // this.button1.Text = "Save lines";
            // this.button1.UseVisualStyleBackColor = true;
            // this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fitnessCheckBox
            // 
            this.fitnessCheckBox.AutoSize = true;
            this.fitnessCheckBox.Checked = true;
            this.fitnessCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fitnessCheckBox.ForeColor = System.Drawing.Color.White;
            this.fitnessCheckBox.Location = new System.Drawing.Point(1743, 23);
            this.fitnessCheckBox.Name = "fitnessCheckBox";
            this.fitnessCheckBox.Size = new System.Drawing.Size(195, 24);
            this.fitnessCheckBox.TabIndex = 2;
            this.fitnessCheckBox.Text = "Show fitness checkpoints";
            this.fitnessCheckBox.UseVisualStyleBackColor = true;
            // 
            // fitnessLabel
            // 
            this.fitnessLabel.AutoSize = true;
            this.fitnessLabel.ForeColor = System.Drawing.Color.White;
            this.fitnessLabel.Location = new System.Drawing.Point(1452, 157);
            this.fitnessLabel.Name = "fitnessLabel";
            this.fitnessLabel.Size = new System.Drawing.Size(60, 20);
            this.fitnessLabel.TabIndex = 3;
            this.fitnessLabel.Text = "Fitness: ";
            //
            // genomeControl
            //
            this.genomeControl.Location = new System.Drawing.Point(1446, 187);
            this.genomeControl.Name = "genomeControl";
            this.genomeControl.Size = new System.Drawing.Size(400, 600);
            this.genomeControl.TabIndex = 4;
            this.genomeControl.BackColor = Color.Transparent;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1950, 1005);
            this.Controls.Add(this.genomeControl);
            this.Controls.Add(this.fitnessLabel);
            this.Controls.Add(this.fitnessCheckBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox);
            this.KeyPreview = true;
            this.Name = "GameViewer";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeysDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeysUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private PictureBox pictureBox;
    private System.Windows.Forms.Timer timer;
    private Button button1;
    private CheckBox fitnessCheckBox;
    public Label fitnessLabel;
    private GenomeControl genomeControl;
}