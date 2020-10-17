using System;

namespace Utils
{
	public partial class Window
	{
		public bool HandledButtonOkClick { get; private set; }
		public bool HandledButtonCancelClick { get; private set; }
		
		
		public Window()
		{
			InitializeComponent();
		}
		
		private void ButtonOk_Clicked(object sender, ClickedEventArgs e)
		{
			HandledButtonOkClick = true;
			Console.WriteLine($"Handled '{e.Label}'");
		}

		private void ButtonCancel_Clicked(object sender, ClickedEventArgs e)
		{
			HandledButtonCancelClick = true;
			Console.WriteLine($"Handled '{e.Label}'");
		}
	}
}