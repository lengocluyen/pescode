namespace Pes.Core
{
    public interface IConfiguration
    {
        int PageNumItem { get; }
        string ToEmailAddress { get; }
        string FromEmailAddress { get; }
        string PasswordEmail { get; }
        string SiteName { get; }
        string RootURL { get; }
        int NumberOfRecordsInPage { get; }
        int NumberOfTagsInCloud { get; }
        string CloudSortOrder { get; }
        int TagCloudSmallestFontSize { get; }
        int TagCloudLargestFontSize { get; }
        string WebSiteURL { get; }
        string AdminSiteURL { get; }
        int DefaultCacheDuration_Days { get; }
        int DefaultCacheDuration_Hours { get; }
        int DefaultCacheDuration_Minutes { get; }
        
    }
}