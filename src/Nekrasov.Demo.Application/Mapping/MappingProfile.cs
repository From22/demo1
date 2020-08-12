using System.IO;
using AutoMapper;
using Nekrasov.Demo.Dto.ViewModel;
using Nekrasov.Demo.Storage.Model;
using StorageFile = Nekrasov.Demo.Storage.Model.File;

namespace Nekrasov.Demo.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StorageFile, FileViewModel>()
                .ForMember(d=>d.Title.Text,o=>o.MapFrom(s=>s.Title))
                .ForMember(d => d.Title.IsWarning, o => o.MapFrom(s => s.IsPptx))
                ;
        }
    }
}
