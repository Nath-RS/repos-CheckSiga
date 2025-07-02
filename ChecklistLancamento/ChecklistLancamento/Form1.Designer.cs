
namespace ChecklistLancamento
{
    partial class FrmMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.dgvAtividades = new System.Windows.Forms.DataGridView();
            this.lblTitleTotal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnGerarelatorio = new System.Windows.Forms.Button();
            this.gpbxSetor = new System.Windows.Forms.GroupBox();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtn93 = new System.Windows.Forms.RadioButton();
            this.rbtn92 = new System.Windows.Forms.RadioButton();
            this.rbtn91 = new System.Windows.Forms.RadioButton();
            this.btngrafico = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtividades)).BeginInit();
            this.gpbxSetor.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFile
            // 
            this.txtFile.Enabled = false;
            this.txtFile.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFile.Location = new System.Drawing.Point(14, 16);
            this.txtFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(461, 26);
            this.txtFile.TabIndex = 0;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(483, 15);
            this.btnImport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(87, 29);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dgvAtividades
            // 
            this.dgvAtividades.AllowUserToAddRows = false;
            this.dgvAtividades.AllowUserToDeleteRows = false;
            this.dgvAtividades.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvAtividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAtividades.Location = new System.Drawing.Point(14, 75);
            this.dgvAtividades.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvAtividades.MultiSelect = false;
            this.dgvAtividades.Name = "dgvAtividades";
            this.dgvAtividades.ReadOnly = true;
            this.dgvAtividades.RowTemplate.ReadOnly = true;
            this.dgvAtividades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAtividades.Size = new System.Drawing.Size(558, 260);
            this.dgvAtividades.TabIndex = 2;
            // 
            // lblTitleTotal
            // 
            this.lblTitleTotal.AutoSize = true;
            this.lblTitleTotal.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleTotal.Location = new System.Drawing.Point(12, 45);
            this.lblTitleTotal.Name = "lblTitleTotal";
            this.lblTitleTotal.Size = new System.Drawing.Size(52, 18);
            this.lblTitleTotal.TabIndex = 3;
            this.lblTitleTotal.Text = "Total :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(61, 45);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(17, 18);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "0";
            // 
            // btnGerarelatorio
            // 
            this.btnGerarelatorio.BackColor = System.Drawing.Color.Red;
            this.btnGerarelatorio.Enabled = false;
            this.btnGerarelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarelatorio.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarelatorio.ForeColor = System.Drawing.Color.White;
            this.btnGerarelatorio.Location = new System.Drawing.Point(609, 287);
            this.btnGerarelatorio.Name = "btnGerarelatorio";
            this.btnGerarelatorio.Size = new System.Drawing.Size(113, 48);
            this.btnGerarelatorio.TabIndex = 5;
            this.btnGerarelatorio.Text = "&Gerar Relatório";
            this.btnGerarelatorio.UseVisualStyleBackColor = false;
            this.btnGerarelatorio.Click += new System.EventHandler(this.btnGerarelatorio_Click);
            // 
            // gpbxSetor
            // 
            this.gpbxSetor.Controls.Add(this.rbtnTodos);
            this.gpbxSetor.Controls.Add(this.rbtn93);
            this.gpbxSetor.Controls.Add(this.rbtn92);
            this.gpbxSetor.Controls.Add(this.rbtn91);
            this.gpbxSetor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbxSetor.Location = new System.Drawing.Point(609, 75);
            this.gpbxSetor.Name = "gpbxSetor";
            this.gpbxSetor.Size = new System.Drawing.Size(121, 154);
            this.gpbxSetor.TabIndex = 6;
            this.gpbxSetor.TabStop = false;
            this.gpbxSetor.Text = "Sub Setores";
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Checked = true;
            this.rbtnTodos.Location = new System.Drawing.Point(25, 112);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(68, 22);
            this.rbtnTodos.TabIndex = 3;
            this.rbtnTodos.TabStop = true;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            // 
            // rbtn93
            // 
            this.rbtn93.AutoSize = true;
            this.rbtn93.Location = new System.Drawing.Point(25, 86);
            this.rbtn93.Name = "rbtn93";
            this.rbtn93.Size = new System.Drawing.Size(48, 22);
            this.rbtn93.TabIndex = 2;
            this.rbtn93.Text = "9.3";
            this.rbtn93.UseVisualStyleBackColor = true;
            // 
            // rbtn92
            // 
            this.rbtn92.AutoSize = true;
            this.rbtn92.Location = new System.Drawing.Point(25, 60);
            this.rbtn92.Name = "rbtn92";
            this.rbtn92.Size = new System.Drawing.Size(48, 22);
            this.rbtn92.TabIndex = 1;
            this.rbtn92.Text = "9.2";
            this.rbtn92.UseVisualStyleBackColor = true;
            // 
            // rbtn91
            // 
            this.rbtn91.AutoSize = true;
            this.rbtn91.Location = new System.Drawing.Point(25, 34);
            this.rbtn91.Name = "rbtn91";
            this.rbtn91.Size = new System.Drawing.Size(48, 22);
            this.rbtn91.TabIndex = 0;
            this.rbtn91.Text = "9.1";
            this.rbtn91.UseVisualStyleBackColor = true;
            // 
            // btngrafico
            // 
            this.btngrafico.BackColor = System.Drawing.Color.DarkOrange;
            this.btngrafico.Enabled = false;
            this.btngrafico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngrafico.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngrafico.ForeColor = System.Drawing.Color.White;
            this.btngrafico.Location = new System.Drawing.Point(609, 233);
            this.btngrafico.Name = "btngrafico";
            this.btngrafico.Size = new System.Drawing.Size(113, 48);
            this.btngrafico.TabIndex = 7;
            this.btngrafico.Text = "&Gerar análise";
            this.btngrafico.UseVisualStyleBackColor = false;
            this.btngrafico.Click += new System.EventHandler(this.btngrafico_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 354);
            this.Controls.Add(this.btngrafico);
            this.Controls.Add(this.gpbxSetor);
            this.Controls.Add(this.btnGerarelatorio);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTitleTotal);
            this.Controls.Add(this.dgvAtividades);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtFile);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.Text = "Check Lançamentos Siga";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtividades)).EndInit();
            this.gpbxSetor.ResumeLayout(false);
            this.gpbxSetor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridView dgvAtividades;
        private System.Windows.Forms.Label lblTitleTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnGerarelatorio;
        private System.Windows.Forms.GroupBox gpbxSetor;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtn93;
        private System.Windows.Forms.RadioButton rbtn92;
        private System.Windows.Forms.RadioButton rbtn91;
        private System.Windows.Forms.Button btngrafico;
    }
}

