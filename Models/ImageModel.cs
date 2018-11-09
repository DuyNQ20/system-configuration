using Microsoft.AspNetCore.Http;
namespace Configuration.Models
{
    public class WaterMarkImage
    {
        public IFormFile WaterMarkImg { get; set; }
        public int WaterMarkImgWidth { get; set; }
        public int WaterMarkImgHeight { get; set; }
        public int WaterMarkImgLocationWidth { get; set; }
        public int WaterMarkImgLocationHeight { get; set; }
        public string WaterMarkImgLocation { get; set; }
    }
    /// <summary>
    /// object watermarkText
    /// </summary>
    public class WatermarkText
    {
        /// <summary>
        /// 
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Font { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FontSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int alpha { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int red { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int green { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int blue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int WidthWatermarkText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int HeightWatermarkText { get; set; }

    }
}
