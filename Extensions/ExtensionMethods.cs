public static class ExtensionMethods
{
	public static void RepeatAction(this object _, int repeatCount, Action action)
	{
		for (int i = 0; i < repeatCount; i++)
			action();
	}
}
