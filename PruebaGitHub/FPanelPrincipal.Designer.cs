
namespace PruebaGitHub
{
    partial class FPanelPrincipal
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btngestionarorigen = new System.Windows.Forms.Button();
            this.btngestionarpickiu = new System.Windows.Forms.Button();
            this.panelcontenedor = new System.Windows.Forms.Panel();
            this.btngestionarclientes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelcontenedor);
            this.splitContainer1.Size = new System.Drawing.Size(639, 494);
            this.splitContainer1.SplitterDistance = 146;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btngestionarclientes, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btngestionarorigen, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btngestionarpickiu, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(139, 88);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btngestionarorigen
            // 
            this.btngestionarorigen.Location = new System.Drawing.Point(3, 3);
            this.btngestionarorigen.Name = "btngestionarorigen";
            this.btngestionarorigen.Size = new System.Drawing.Size(127, 22);
            this.btngestionarorigen.TabIndex = 0;
            this.btngestionarorigen.Text = "Gestionar Origen";
            this.btngestionarorigen.UseVisualStyleBackColor = true;
            this.btngestionarorigen.Click += new System.EventHandler(this.btngestionarorigen_Click);
            // 
            // btngestionarpickiu
            // 
            this.btngestionarpickiu.Location = new System.Drawing.Point(3, 31);
            this.btngestionarpickiu.Name = "btngestionarpickiu";
            this.btngestionarpickiu.Size = new System.Drawing.Size(127, 23);
            this.btngestionarpickiu.TabIndex = 1;
            this.btngestionarpickiu.Text = "Gestionar Pickiu";
            this.btngestionarpickiu.UseVisualStyleBackColor = true;
            this.btngestionarpickiu.Click += new System.EventHandler(this.btngestionarpickiu_Click);
            // 
            // panelcontenedor
            // 
            this.panelcontenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelcontenedor.Location = new System.Drawing.Point(0, 0);
            this.panelcontenedor.Name = "panelcontenedor";
            this.panelcontenedor.Size = new System.Drawing.Size(489, 494);
            this.panelcontenedor.TabIndex = 0;
            // 
            // btngestionarclientes
            // 
            this.btngestionarclientes.Location = new System.Drawing.Point(3, 60);
            this.btngestionarclientes.Name = "btngestionarclientes";
            this.btngestionarclientes.Size = new System.Drawing.Size(127, 22);
            this.btngestionarclientes.TabIndex = 2;
            this.btngestionarclientes.Text = "Gestionar Clientes";
            this.btngestionarclientes.UseVisualStyleBackColor = true;
            this.btngestionarclientes.Click += new System.EventHandler(this.btngestionarcliente_Click);
            // 
            // FPanelPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(639, 494);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FPanelPrincipal";
            this.Text = "FPanelPrincipal";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelcontenedor;
        private System.Windows.Forms.Button btngestionarorigen;
        private System.Windows.Forms.Button btngestionarpickiu;
        private System.Windows.Forms.Button btngestionarclientes;
    }
}