namespace MacroMouse
{
	public partial class frmInicio : Form
	{
		private KeyboardShortcutManager _shortcutManager;
		private AtivarMacro ativarMacro;
		public frmInicio()
		{
			InitializeComponent();
			_shortcutManager = new KeyboardShortcutManager(valorMacroManual, btnAtivar, this);
		}
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			_shortcutManager.Dispose();
		}

		protected override void WndProc(ref Message m)
		{
			_shortcutManager.HandleHotKey(m);
			base.WndProc(ref m);
		}
		private void btnSairClick(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnAtivar_Click(object sender, EventArgs e)
		{
			int intVlrMacroX = 0;
			int intVlrMacroY = 0;


			if (valorMacroManual.Value != 0)
			{
				intVlrMacroY = valorMacroManual.Value;

			}
			else
			{
				intVlrMacroY = 0;
			}

			bool vlbTimeAtivadoAnteriormente = false;
			parametrosTimer(intVlrMacroX, intVlrMacroY, vlbTimeAtivadoAnteriormente);
		}

		private void txbValorMacro_EventoChave(object sender, KeyPressEventArgs e)
		{
			// Verifica se o caractere pressionado não é um número ou a tecla Backspace
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true; // Ignora o caractere digitado
			}
		}

		private void frmInicio_Load(object sender, EventArgs e)
		{
			//IntPtr hwnd = getControls.GetForegroundWindows();
			//int currentDpi = getControls.GetDPIForWindows(hwnd);
		}

		private void trackBarValorManual(object sender, EventArgs e)
		{
			labelValorMacro.Text = valorMacroManual.Value.ToString();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void gbDPI_Enter(object sender, EventArgs e)
		{

		}

		private void ativarMacro_Click(object sender, EventArgs e)
		{
			int intVlrMacroX = 0;
			int intVlrMacroY = 0;


			if (valorMacroManual.Value != 0)
			{
				intVlrMacroY = valorMacroManual.Value;

			}
			else
			{
				intVlrMacroY = 0;
			}

			bool vlbTimeAtivadoAnteriormente = false;
			parametrosTimer(intVlrMacroX, intVlrMacroY, vlbTimeAtivadoAnteriormente);
		}
	}
}
