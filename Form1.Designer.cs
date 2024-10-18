namespace Celengan_Ayam
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.addCelenganButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(200, 426);
            this.treeView1.TabIndex = 0;
            this.treeView1.Nodes.Add("Celengan");

            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(218, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(570, 426);
            this.mainPanel.TabIndex = 1;

            // 
            // addCelenganButton
            // 
            this.addCelenganButton.Location = new System.Drawing.Point(12, 444);
            this.addCelenganButton.Name = "addCelenganButton";
            this.addCelenganButton.Size = new System.Drawing.Size(200, 30);
            this.addCelenganButton.TabIndex = 2;
            this.addCelenganButton.Text = "Tambah Celengan";
            this.addCelenganButton.UseVisualStyleBackColor = true;
            this.addCelenganButton.Click += new System.EventHandler(this.AddCelenganButton_Click);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 486);
            this.Controls.Add(this.addCelenganButton);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Celengan Ayam";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button addCelenganButton;
    }
}
