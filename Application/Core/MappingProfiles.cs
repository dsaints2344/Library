﻿using AutoMapper;
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
            CreateMap<CategoryModel, Domain.Category>();

            CreateMap<Domain.Book, BookModel>();
            CreateMap<BookModel,Domain.Book>();
            CreateMap<LoanModel, Domain.Loan>();
        }
    }
}
