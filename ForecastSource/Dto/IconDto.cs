namespace ForecastSource.Dto
{
    public class IconDto
    {
        /// <summary>
        /// Binary data of the icon file
        /// </summary>
        public byte[] ContentData { get; set; }
        /// <summary>
        /// MIME Content Type of the icon file. e.g. image/png
        /// </summary>
        public string ContentType { get; set; }
    }
}
