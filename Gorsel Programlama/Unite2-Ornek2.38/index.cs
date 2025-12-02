using System;
using System.Drawing;
using System.Windows.Forms;

namespace CalculatorApp
{
    public class CalculatorForm : Form
    {
        // Kontroller
        private TextBox txtDisplay;
        private Panel pnlNumeric;
        private Panel pnlOperators;
        private Panel pnlClear;

        // Buton alanları
        private Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn0;
        private Button btn00, btnDot;
        private Button btnPlus, btnMinus, btnMultiply, btnDivide, btnEquals;
        private Button btnC, btnCA, btnOff;

        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // a) Form Özellikleri
            this.Text = "Calculator";
            this.Font = new Font("Segoe UI", 9F);
            this.Size = new Size(258, 210);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // b) TextBox (Ekran)
            txtDisplay = new TextBox();
            txtDisplay.Text = "0";
            txtDisplay.Location = new Point(12, 12);
            txtDisplay.Size = new Size(218, 23);
            txtDisplay.TextAlign = HorizontalAlignment.Right;
            this.Controls.Add(txtDisplay);

            // c) Panel 1 (Numeric Keys)
            pnlNumeric = new Panel();
            pnlNumeric.BorderStyle = BorderStyle.Fixed3D;
            pnlNumeric.Size = new Size(90, 120);
            pnlNumeric.Location = new Point(12, 45);
            this.Controls.Add(pnlNumeric);

            // d) Panel 2 (Operator Keys)
            pnlOperators = new Panel();
            pnlOperators.BorderStyle = BorderStyle.Fixed3D;
            pnlOperators.Size = new Size(62, 120);
            pnlOperators.Location = new Point(108, 45);
            this.Controls.Add(pnlOperators);

            // e) Panel 3 (Clear/Clear All)
            pnlClear = new Panel();
            pnlClear.BorderStyle = BorderStyle.Fixed3D;
            pnlClear.Size = new Size(54, 62);
            pnlClear.Location = new Point(176, 45);
            this.Controls.Add(pnlClear);

            // OFF Butonu
            btnOff = CreateButton(null, "OFF", 54, 23, 176, 113);
            this.Controls.Add(btnOff);

            // --- Panel 1 (Numeric) İçeriği ---

            // Satır 1
            btn7 = CreateButton(pnlNumeric, "7", 23, 23, 3, 3);
            btn8 = CreateButton(pnlNumeric, "8", 23, 23, 30, 3);
            btn9 = CreateButton(pnlNumeric, "9", 23, 23, 57, 3);

            // Satır 2
            btn4 = CreateButton(pnlNumeric, "4", 23, 23, 3, 30);
            btn5 = CreateButton(pnlNumeric, "5", 23, 23, 30, 30);
            btn6 = CreateButton(pnlNumeric, "6", 23, 23, 57, 30);

            // Satır 3
            btn1 = CreateButton(pnlNumeric, "1", 23, 23, 3, 57);
            btn2 = CreateButton(pnlNumeric, "2", 23, 23, 30, 57);
            btn3 = CreateButton(pnlNumeric, "3", 23, 23, 57, 57);

            // Satır 4
            btn0  = CreateButton(pnlNumeric, "0", 23, 23, 3, 84);
            btn00 = CreateButton(pnlNumeric, "00", 52, 23, 30, 84);

            // --- Panel 2 (Operators) İçeriği ---

            btnDivide  = CreateButton(pnlOperators, "/", 23, 23, 3, 3);
            btnMultiply = CreateButton(pnlOperators, "*", 23, 23, 3, 30);
            btnMinus   = CreateButton(pnlOperators, "-", 23, 23, 3, 57);
            btnDot     = CreateButton(pnlOperators, ".", 23, 23, 3, 84);

            // Uzun + butonu
            btnPlus = CreateButton(pnlOperators, "+", 23, 81, 30, 3);

            // = butonu
            btnEquals = CreateButton(pnlOperators, "=", 23, 23, 30, 88);

            // --- Panel 3 (Clear) İçeriği ---

            btnC  = CreateButton(pnlClear, "C", 44, 23, 3, 3);
            btnCA = CreateButton(pnlClear, "C/A", 44, 23, 3, 30);
        }

        // Buton oluşturma yardımcı metodu
        private Button CreateButton(Control parent, string text, int width, int height, int x, int y)
        {
            var btn = new Button();
            btn.Text = text;
            btn.Size = new Size(width, height);
            btn.Location = new Point(x, y);
            btn.Name = "btn" + text.Replace("/", "Div").Replace("*", "Mul");
            
            if (parent != null)
                parent.Controls.Add(btn);

            return btn;
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalculatorForm());
        }
    }
}
