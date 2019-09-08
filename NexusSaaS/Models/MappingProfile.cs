using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NexusSaaS.Entity;

namespace NexusSaaS.Models
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<FeatureModel, FeatureEntity>();
            CreateMap<MessageModel, MessageEntity>();
        }
    }
}
