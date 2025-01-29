using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class AtivarMacro : Control
{
	private bool isToggled = false; // Estado atual do botão
	private Color onBackColor = Color.Green;
	private Color offBackColor = Color.Red;
	private Color toggleColor = Color.White;

	public bool IsToggled
	{
		get { return isToggled; }
		set
		{
			isToggled = value;
			Invalidate(); // Redesenha o botão quando o estado é alterado
		}
	}

	public AtivarMacro()
	{
		this.Size = new Size(60, 20); // Tamanho do botão
		this.DoubleBuffered = true; // Reduz flicker ao desenhar
		this.Cursor = Cursors.Hand; // Altera o cursor para "mão"
		this.Click += ativarMacro_Click; // Evento de clique
	}

	private void ativarMacro_Click(object sender, EventArgs e)
	{
		IsToggled = !IsToggled; // Alterna o estado do botão
	}

	protected override void OnPaint(PaintEventArgs pevent)
	{
		base.OnPaint(pevent);
		Graphics g = pevent.Graphics;

		// Ativa a suavização
		g.SmoothingMode = SmoothingMode.AntiAlias;

		// Limpa o fundo
		// Desenha o retângulo com cantos arredondados
		using (GraphicsPath path = new GraphicsPath())
		{
		g.Clear(Parent.BackColor);

		// Define a cor de fundo com base no estado do toggle
		Color backColor = IsToggled ? onBackColor : offBackColor;

			float radius = this.Height / 10f; // O raio deve ser metade da altura para arredondar
			path.AddArc(0, 0, this.Height, this.Height, 90, 180); // Arco esquerdo
			path.AddArc(this.Width - this.Height, 0, this.Height, this.Height, 270, 180); // Arco direito
			path.CloseFigure();

			// Preenche o fundo com a cor
			using (Brush backBrush = new SolidBrush(backColor))
			{
				g.FillPath(backBrush, path);
			}

			// Desenha a borda do controle
			using (Pen borderPen = new Pen(Color.White, 0))
			{
				g.DrawPath(borderPen, path);
			}

			// Definir um recorte para o toggle ficar dentro do círculo arredondado
			g.SetClip(path);
		}

		// Desenha o círculo do toggle (botão deslizante)
		int toggleSize = this.Height - 4;
		int toggleX = IsToggled ? this.Width - toggleSize - 2 : 2;
		using (Brush toggleBrush = new SolidBrush(toggleColor))
		{
			g.FillEllipse(toggleBrush, new Rectangle(toggleX, 2, toggleSize, toggleSize));
		}
	}
}
