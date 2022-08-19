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
            this.fitnessCheckBox = new System.Windows.Forms.CheckBox();
            this.fitnessLabel = new System.Windows.Forms.Label();
            this.genomeControl = new SharpNeat.Windows.Neat.NeatGenomeControl();
            this.indexBack = new System.Windows.Forms.Button();
            this.indexForw = new System.Windows.Forms.Button();
            this.genomeIndexControl = new System.Windows.Forms.Label();
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
            this.genomeControl.BackColor = System.Drawing.Color.Transparent;
            this.genomeControl.Genome = null;
            this.genomeControl.Location = new System.Drawing.Point(1446, 187);
            this.genomeControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.genomeControl.Name = "genomeControl";
            this.genomeControl.Size = new System.Drawing.Size(400, 600);
            this.genomeControl.TabIndex = 4;
            // 
            // indexBack
            // 
            this.indexBack.Location = new System.Drawing.Point(1452, 852);
            this.indexBack.Name = "indexBack";
            this.indexBack.Size = new System.Drawing.Size(49, 53);
            this.indexBack.TabIndex = 5;
            this.indexBack.Text = "<";
            this.indexBack.UseVisualStyleBackColor = true;
            this.indexBack.Click += new System.EventHandler(this.indexBack_Click);
            // 
            // indexForw
            // 
            this.indexForw.Location = new System.Drawing.Point(1555, 852);
            this.indexForw.Name = "indexForw";
            this.indexForw.Size = new System.Drawing.Size(51, 53);
            this.indexForw.TabIndex = 6;
            this.indexForw.Text = ">";
            this.indexForw.UseVisualStyleBackColor = true;
            this.indexForw.Click += new System.EventHandler(this.indexForw_Click);
            // 
            // genomeIndexControl
            // 
            this.genomeIndexControl.AutoSize = true;
            this.genomeIndexControl.BackColor = System.Drawing.Color.Black;
            this.genomeIndexControl.ForeColor = System.Drawing.SystemColors.Control;
            this.genomeIndexControl.Location = new System.Drawing.Point(1519, 868);
            this.genomeIndexControl.Name = "genomeIndexControl";
            this.genomeIndexControl.Size = new System.Drawing.Size(17, 20);
            this.genomeIndexControl.TabIndex = 7;
            this.genomeIndexControl.Text = "0";
            // 
            // GameViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1950, 1005);
            this.Controls.Add(this.genomeIndexControl);
            this.Controls.Add(this.indexForw);
            this.Controls.Add(this.indexBack);
            this.Controls.Add(this.genomeControl);
            this.Controls.Add(this.fitnessLabel);
            this.Controls.Add(this.fitnessCheckBox);
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
    private Button indexBack;
    private Button indexForw;
    private Label genomeIndexControl;
    private NeatGenomeControl genomeControl;
}