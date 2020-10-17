using System;

namespace Utils
{
	public class LoggingButton : Button
	{
		public LoggingButton(string label) : base(label) {}

		public override void OnClicked()
		{
			base.OnClicked();
			Console.WriteLine(Label);
		}
	}
}