using System.Linq;
using AutoMapper;
using VEGA.Controllers.Resources;
using VEGA.Models;

namespace VEGA.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain o API Resources
            CreateMap<Make, MakeResource>();
            CreateMap<Make, KeyValuePairResource>();
            CreateMap<Model, KeyValuePairResource>();
            CreateMap<Feature, KeyValuePairResource>();
            CreateMap<Vehicle, SaveVehicleResource>()
                .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource
                {
                    Email = v.ContactEmail,
                    Phone = v.ContactPhone,
                    Name = v.ContactName
                }))
                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource
                {
                    Email = v.ContactEmail,
                    Phone = v.ContactPhone,
                    Name = v.ContactName
                }))
                .ForMember(vr => vr.Features,
                    opt => opt.MapFrom(v =>
                        v.Features.Select(vf => new KeyValuePairResource() {Id = vf.Feature.Id, Name = vf.Feature.Name})))
                .ForMember(vr => vr.Make, opt => opt.MapFrom(v => v.Model.Make));

            //API Resources to Domain
            CreateMap<SaveVehicleResource, Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) =>
                {
                    var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId));
                    foreach (var removedFeature in removedFeatures.ToList())
                        v.Features.Remove(removedFeature);

                    var addedFeatures = vr.Features.Where(f => v.Features.All(x => x.FeatureId != f))
                        .Select(x => new VehicleFeature { FeatureId = x });
                    foreach (var addedFeature in addedFeatures.ToList())
                        v.Features.Add(addedFeature);
                    
                });

        }
    }
}
