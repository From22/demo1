using System.Threading.Tasks;
using Nekrasov.Demo.OpenXml.Model;

namespace Nekrasov.Demo.OpenXml
{
    public interface IPresentationDocumentParser
    {
        Task<PptxFIle> ParseAsync(byte[] fileContent, string fileName);
    }
}