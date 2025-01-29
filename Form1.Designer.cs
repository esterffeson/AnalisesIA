using System;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Button = System.Windows.Forms.Button;
using TrackBar = System.Windows.Forms.TrackBar;

namespace MacroMouse
{
    partial class frmInicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer timer;
        //private KeyboardShortcutManager _shortcutManager;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code
        public void parametrosTimer(int intMacroX, int intMacroY, bool vlbTimeAtivadoAnteriormente)
        {
            if (!vlbTimeAtivadoAnteriormente)
            {
                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                }
                timer = new System.Windows.Forms.Timer();
                timer.Interval = 2;
                timer.Tick += Timer1_Tick;
                timer.Start();
                intValorMacroY = intMacroY;
                intValorMacroX = intMacroX;
                vlbTimeAtivadoAnteriormente = true;

            }
            else
            {
                if (vlbTimeAtivadoAnteriormente)
                {
                    timer.Stop();
                    timer.Dispose();
                    vlbTimeAtivadoAnteriormente = false;
                }

            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            bool capsLockAtivado = getControls.IsCapsLockOn();
            bool botaoEsquerdoPessionado = getControls.isLeftMouseButtonDown();
            if (capsLockAtivado && botaoEsquerdoPessionado)
            {
                getControls.verticalMouseAtivo(intValorMacroX, intValorMacroY);
            }
        }


		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicio));
			macroManual = new RadioButton();
			btnAtivar = new Button();
			btnSair = new Button();
			label1 = new System.Windows.Forms.Label();
			valorMacroManual = new TrackBar();
			labelValorMacro = new System.Windows.Forms.Label();
			ativarMacro = new AtivarMacro();
			((System.ComponentModel.ISupportInitialize)valorMacroManual).BeginInit();
			SuspendLayout();
			// 
			// macroManual
			// 
			macroManual.Location = new Point(0, 0);
			macroManual.Name = "macroManual";
			macroManual.Size = new Size(104, 24);
			macroManual.TabIndex = 0;
			// 
			// btnAtivar
			// 
			btnAtivar.BackColor = SystemColors.Highlight;
			btnAtivar.FlatAppearance.BorderColor = Color.Red;
			btnAtivar.FlatAppearance.BorderSize = 0;
			btnAtivar.FlatStyle = FlatStyle.Flat;
			btnAtivar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
			btnAtivar.ForeColor = SystemColors.ButtonFace;
			btnAtivar.Location = new Point(12, 157);
			btnAtivar.Name = "btnAtivar";
			btnAtivar.Size = new Size(98, 35);
			btnAtivar.TabIndex = 6;
			btnAtivar.Text = "Ativar";
			btnAtivar.UseVisualStyleBackColor = true;
			btnAtivar.Click += btnAtivar_Click;
			// 
			// btnSair
			// 
			btnSair.BackColor = SystemColors.Highlight;
			btnSair.FlatAppearance.BorderColor = Color.Red;
			btnSair.FlatAppearance.BorderSize = 0;
			btnSair.FlatStyle = FlatStyle.Flat;
			btnSair.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
			btnSair.ForeColor = SystemColors.ButtonFace;
			btnSair.Location = new Point(156, 157);
			btnSair.Name = "btnSair";
			btnSair.Size = new Size(98, 35);
			btnSair.TabIndex = 12;
			btnSair.Text = "Fechar";
			btnSair.UseVisualStyleBackColor = true;
			btnSair.Click += btnSairClick;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 7F);
			label1.ForeColor = SystemColors.ControlDarkDark;
			label1.Location = new Point(308, 430);
			label1.Name = "label1";
			label1.Size = new Size(22, 12);
			label1.TabIndex = 16;
			label1.Text = "v1.0";
			// 
			// valorMacroManual
			// 
			valorMacroManual.LargeChange = 1;
			valorMacroManual.Location = new Point(12, 25);
			valorMacroManual.Maximum = 30;
			valorMacroManual.Minimum = 10;
			valorMacroManual.Name = "valorMacroManual";
			valorMacroManual.Size = new Size(262, 45);
			valorMacroManual.TabIndex = 17;
			valorMacroManual.Value = 15;
			valorMacroManual.ValueChanged += trackBarValorManual;
			// 
			// labelValorMacro
			// 
			labelValorMacro.BackColor = SystemColors.Control;
			labelValorMacro.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
			labelValorMacro.Location = new Point(103, -12);
			labelValorMacro.Name = "labelValorMacro";
			labelValorMacro.Padding = new Padding(10, 10, 10, 0);
			labelValorMacro.Size = new Size(88, 39);
			labelValorMacro.TabIndex = 18;
			labelValorMacro.Text = "15";
			labelValorMacro.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// ativarMacro
			// 
			ativarMacro.IsToggled = false;
			ativarMacro.Location = new Point(12, 100);
			ativarMacro.Name = "ativarMacro";
			ativarMacro.Size = new Size(60, 30);
			ativarMacro.TabIndex = 19;
			ativarMacro.Click += ativarMacro_Click;
			// 
			// frmInicio
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(284, 204);
			Controls.Add(valorMacroManual);
			Controls.Add(labelValorMacro);
			Controls.Add(label1);
			Controls.Add(btnSair);
			Controls.Add(btnAtivar);
			Controls.Add(ativarMacro);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			Name = "frmInicio";
			Text = "MacroMouse";
			Load += frmInicio_Load;
			((System.ComponentModel.ISupportInitialize)valorMacroManual).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion


		private Button btnAtivar;

        private Button btnSair;
        //s private int valorMouse;
        public int intValorMacro;

        private RadioButton macroManual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar valorMacroManual;
        private System.Windows.Forms.Label labelValorMacro;

		public int intValorMacroY { get; private set; }
        public int intValorMacroX { get; private set; }
    }


}
