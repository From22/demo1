using System.Collections.Generic;

namespace Nekrasov.Demo.OpenXml.Model
{
    public class PptxFIle
    {
        public PptxFIle()
        {
            VideoItems = new List<VideoItem>();
        }

        public string FileName { get; set; }

        public IList<VideoItem> VideoItems { get; set; }
    }
}