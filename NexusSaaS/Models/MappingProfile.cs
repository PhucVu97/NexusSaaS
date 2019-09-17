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
                .ForMember(um => um.RolesCount, opt => opt.MapFrom(u => u.RoleUsers.Where(ru => ru.UserId == u.UserId).Count()))
                .ForMember(um => um.Status, opt => opt.MapFrom(u => (AccountStatus)u.Status));
            CreateMap<Role, RoleModel>()
                .ForMember(rm => rm.Status, opt => opt.MapFrom(r => (RoleStatus)r.Status));
            CreateMap<RoleUser, RoleUserModel>();

            CreateMap<FeatureModel, FeatureEntity>();
            CreateMap<MessageModel, MessageEntity>();
            CreateMap<UserModel, UserEntity>()
                .ForMember(u => u.Status, opt => opt.MapFrom(um => um.Status));
            CreateMap<RoleModel, Role>()
                .ForMember(r => r.Status, opt => opt.MapFrom(rm => rm.Status));
            CreateMap<RoleUserModel, RoleUser>();

        }
    }
}
