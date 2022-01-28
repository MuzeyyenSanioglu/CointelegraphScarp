using WebScarp.Common.Settings.Interface;
namespace WebScarp.Common.Settings
{
    public class URLSettings : IURLSettings
    {
        public string Url { get; set ; } = null!;
        public string HtmlURlTag { get; set; } = null!;
        public string TagTittle { get; set; } = null!;
        public string TagContent { get; set; } = null!;
    }
}
