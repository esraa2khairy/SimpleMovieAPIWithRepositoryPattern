using AutoMapper;
using RepositoryPatternWithUOW.Core.DTOs;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles( ) 
        {
            CreateMap<Movie, MovieDetailsDto>();
            CreateMap<MovieDto , Movie>().ForMember(scr => scr.poster , opt => opt.Ignore());
        }
    }
}
