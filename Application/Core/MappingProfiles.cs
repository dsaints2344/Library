using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<Domain.Category, CategoryModel>();
            CreateMap<CategoryModel, Domain.Category>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Domain.Book, BookModel>();
            CreateMap<BookModel,Domain.Book>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<LoanModel, Domain.Loan>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); ;
        }
    }
}
