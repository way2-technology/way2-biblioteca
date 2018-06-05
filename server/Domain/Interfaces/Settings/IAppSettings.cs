namespace Domain.Interfaces.Settings
{
    public interface IAppSettings
    {
        string Secret { get; set; }
        string JsonBookFilePath { get; set; }
    }
}