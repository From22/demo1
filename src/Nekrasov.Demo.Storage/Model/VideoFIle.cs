using System;

namespace Nekrasov.Demo.Storage.Model
{
    public class VideoFIle
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public decimal Size { get; set; }
        public byte[] Content { get; set; }
    }
}
