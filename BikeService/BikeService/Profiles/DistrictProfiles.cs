﻿using AutoMapper;
using BikeService.DTOs.Response;
using BikeService.Models;

namespace BikeService.Profiles
{
    public class DistrictProfiles : Profile
    {
        public DistrictProfiles()
        {
            CreateMap<District, DistrictResponse>();
        }
    }
}
// dotnet ef dbcontext scaffold Name=DefaultConnection Pomelo.EntityFrameworkCore.MySql --output-dir Models --context-dir Data --namespace BikeService.Models --context-namespace BikeService.Data --context MyDbContext -f --no-onconfiguring