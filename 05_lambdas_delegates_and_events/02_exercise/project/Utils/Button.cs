using System;

namespace Utils
{
	public class Button
	{
		public string Label { get; }
		public event EventHandler<ClickedEventArgs>? Clicked;

		public Button()
		{
			Label = "was not defined";
		}
		
		public Button(string text)
		{
			Label = text;
		}
		
		public void Click()
		{
			OnClicked();
		}

		public virtual void OnClicked()
		{
			var handler = Clicked;
			handler?.Invoke(this, new ClickedEventArgs("nowy label"));
		}
	}
}