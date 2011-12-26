namespace Core
{
	public interface ILazyConfigSettings
	{
		LogLevel LogLevel { get; }
		string ApplicationName { get; }
		string LoggingQueue { get; }
	}
}