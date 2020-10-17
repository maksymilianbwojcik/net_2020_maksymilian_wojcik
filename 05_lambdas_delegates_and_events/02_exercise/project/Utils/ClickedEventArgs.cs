namespace Utils
{
	public class ClickedEventArgs
	{
		public string Label { get; }

		public ClickedEventArgs(string text)
		{
			Label = text;
		}
	}
}