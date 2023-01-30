using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Simple_Showcase.Pages;
using System.Diagnostics;

public class DiagnosticObserver : IObserver<DiagnosticListener>
{
	public void OnCompleted()
		=> throw new NotImplementedException();

	public void OnError(Exception error)
		=> throw new NotImplementedException();

	public void OnNext(DiagnosticListener value)
	{
		if (value.Name == DbLoggerCategory.Name) // "Microsoft.EntityFrameworkCore"
		{
			value.Subscribe(new KeyValueObserver());
		}
	}

#nullable disable
	public class KeyValueObserver : IObserver<KeyValuePair<string, object>>
	{
		public void OnCompleted()
			=> throw new NotImplementedException();

		public void OnError(Exception error)
			=> throw new NotImplementedException();

		public void OnNext(KeyValuePair<string, object> value)
		{
			if (value.Key == CoreEventId.SaveChangesCompleted.Name)
			{
				Editor.instance.UpdateHouses();
			}
		}
	}
}