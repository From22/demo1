using System;

namespace Nekrasov.Demo.Storage.Model
{
    public class File
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public string Title { get; set; }
        public bool IsPptx{ get; set; }
        public bool WithVideo { get; set; }

    }
}