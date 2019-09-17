using AutoMapper;
using NexusSaaS.Entity;
using System.Linq;

namespace NexusSaaS.Models
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<FeatureEntity, FeatureModel>();
            CreateMap<MessageEntity, MessageModel>();
            CreateMap<UserEntity, UserModel>()
                .ForMember(um => um.MessagesCount, opt => opt.MapFrom(u => u.MessageEntitys.Count()))
                .ForMember(um => um.RolesCount, opt => opt.MapFrom(u => u.RoleUsers.Where(ru => ru.UserId == u.Id).Count()))
                .ForMember(um => um.Status, opt => opt.MapFrom(u => (RoleStatus)u.Status));
            CreateMap<Role, RoleModel>()
                .ForMember(rm => rm.UserCount, opt => opt.MapFrom(r => r.RoleUsers.Where(ru => ru.RoleId == r.RoleId).Count()))
                .ForMember(rm => rm.Status, opt => opt.MapFrom(r => (RoleStatus)r.Status));

            CreateMap<FeatureModel, FeatureEntity>();
            CreateMap<MessageModel, MessageEntity>();
            CreateMap<UserModel, UserEntity>()
                .ForMember(u => u.Status, opt => opt.MapFrom(um => um.Status));
            CreateMap<RoleModel, Role>()
                .ForMember(r => r.Status, opt => opt.MapFrom(rm => rm.Status));

        }
    }
}
