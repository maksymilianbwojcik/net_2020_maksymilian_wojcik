using System.Diagnostics.CodeAnalysis;

namespace Utils
{
	public partial class Window
	{
		
		private LoggingButton _buttonOk;
		private LoggingButton _buttonCancel;

		[ExcludeFromCodeCoverage]
		private void InitializeComponent()
		{
			_buttonOk = new LoggingButton("OK");
			_buttonCancel = new LoggingButton("Cancel");

			_buttonOk.Clicked += ButtonOk_Clicked;
			_buttonCancel.Clicked += ButtonCancel_Clicked;
		}

		[ExcludeFromCodeCoverage]
		public void SimulateClicks()
		{
			_buttonOk.Click();
			_buttonCancel.Click();
		}
	}
}