namespace Calculator;

public partial class MainPage : ContentPage
{
	// initial values
	int first_no;
	int second_no;
	int result;
	char operation;

	public MainPage()
	{
		InitializeComponent();
	}

	// Button Click Events
	private void BTN_1_Click(object? sender, EventArgs e) => display("1");
	private void BTN_2_Click(object? sender, EventArgs e) => display("2");
	private void BTN_3_Click(object? sender, EventArgs e) => display("3");
	private void BTN_4_Click(object? sender, EventArgs e) => display("4");
	private void BTN_5_Click(object? sender, EventArgs e) => display("5");
	private void BTN_6_Click(object? sender, EventArgs e) => display("6");
	private void BTN_7_Click(object? sender, EventArgs e) => display("7");
	private void BTN_8_Click(object? sender, EventArgs e) => display("8");
	private void BTN_9_Click(object? sender, EventArgs e) => display("9");
	private void BTN_0_Click(object? sender, EventArgs e) => display("0");

	private void BTN_Plus_Click(object? sender, EventArgs e) => SetOperation('+');
	private void BTN_minus_Click(object? sender, EventArgs e) => SetOperation('-');
	private void BTN_Mul_Click(object? sender, EventArgs e) => SetOperation('*');
	private void BTN_Divide_Click(object? sender, EventArgs e) => SetOperation('/');

	private void SetOperation(char op)
	{
		first_no = ReadDisplay();
		operation = op;
		TB_Display.Text = "0";
		LBL_Op.Text = $"{first_no} {Symbol(op)}";
	}

	private void BTN_Clear_Click(object? sender, EventArgs e)
	{
		TB_Display.Text = "0";
		LBL_Op.Text = " ";
		first_no = 0;
		second_no = 0;
		operation = '\0';
	}

	private void BTN_Equal_Click(object? sender, EventArgs e)
	{
		if (operation == '\0')
			return;

		second_no = ReadDisplay();
		LBL_Op.Text = $"{first_no} {Symbol(operation)} {second_no} =";

		switch (operation)
		{
			case '+':
				result = first_no + second_no;
				TB_Display.Text = result.ToString();
				break;

			case '-':
				result = first_no - second_no;
				TB_Display.Text = result.ToString();
				break;

			case '*':
				result = first_no * second_no;
				TB_Display.Text = result.ToString();
				break;

			case '/':
				if (second_no == 0)
				{
					TB_Display.Text = "Error";
					break;
				}
				result = first_no / second_no;
				TB_Display.Text = result.ToString();
				break;
		}

		operation = '\0';
	}

	// The symbol shown on the LCD for each operation
	private static string Symbol(char op) => op switch
	{
		'+' => "+",
		'-' => "−",
		'*' => "×",
		'/' => "÷",
		_ => "",
	};

	private int ReadDisplay()
	{
		return int.TryParse(TB_Display.Text, out int value) ? value : 0;
	}

	public void display(string num)
	{
		// Typing after "=" starts a fresh number
		if (LBL_Op.Text.EndsWith("="))
			LBL_Op.Text = " ";

		if (string.IsNullOrEmpty(TB_Display.Text) || TB_Display.Text == "0" || TB_Display.Text == "Error")
		{
			TB_Display.Text = num;
		}
		else
		{
			TB_Display.Text = TB_Display.Text + num;
		}
	}
}
