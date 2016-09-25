using AutoMapper;
using NCD_Web.Models;
using NCD_Web.NCD_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCD_Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<SearchParamsViewModel, SearchParams>()
                    .ForMember(dest => dest.Names, opt => opt.ResolveUsing(src => ParseString(src.Names)))
                    .ForMember(dest => dest.Nationality, opt => opt.ResolveUsing(src => ParseString(src.Nationality)))
                    .ForMember(dest => dest.Sex, opt => opt.ResolveUsing(src => src.Sex))
                    .ForMember(dest => dest.StartAge, opt => opt.MapFrom(src => src.StartAge))
                    .ForMember(dest => dest.EndAge, opt => opt.MapFrom(src => src.EndAge))
                    .ForMember(dest => dest.StartHeight, opt => opt.MapFrom(src => src.StartHeight))
                    .ForMember(dest => dest.EndHeight, opt => opt.MapFrom(src => src.EndHeight))
                    .ForMember(dest => dest.StartWeight, opt => opt.MapFrom(src => src.StartWeight))
                    .ForMember(dest => dest.EndWeight, opt => opt.MapFrom(src => src.EndWeight))
                    .ForAllOtherMembers(opt => opt.Ignore());

            });
            Mapper.AssertConfigurationIsValid();
        }

        public static string[] ParseString(string input)
        {
            return string.IsNullOrEmpty(input) ? null : input.Split(',').Where(x => !string.IsNullOrEmpty(x.Trim())).ToArray();
        }
    }
}