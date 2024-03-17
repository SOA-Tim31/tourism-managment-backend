using AutoMapper;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.TourExecutionsDTO;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.TourExecutions;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.Core.Domain.Problems;
using Explorer.Tours.Core.Domain.TourBundle;
using Explorer.Tours.Core.Domain.Competitions;

namespace Explorer.Tours.Core.Mappers;

public class ToursProfile : Profile
{
    public ToursProfile()
    {
        CreateMap<EquipmentDto, Equipment>().ReverseMap();



        CreateMap<TouristEquipmentDto, TouristEquipment>().ReverseMap();


        CreateMap<PublicTourPointDto, PublicTourPoint>().ReverseMap();



        CreateMap<TourReviewDto, TourReview>().ReverseMap();


        CreateMap<PublicTourObjectDto, PublicTourObject>().ReverseMap();


        CreateMap<TourObjectDto, TourObject>()
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
        .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
        .ForMember(dest => dest.Category, opt => opt.MapFrom(src => Enum.Parse(typeof(ObjectCategory), src.Category)))
        .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
        .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude));

        CreateMap<TourObject, TourObjectDto>()
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
        .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
        .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()))
        .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
        .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude));

        CreateMap<ObjInTourDto, ObjInTour>().ReverseMap();
        CreateMap<ObjInTour, ObjInTourDto>().ReverseMap();

        CreateMap<TourDTO, Tour>().IncludeAllDerived()

     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
     .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
      .ForMember(dest => dest.DifficultyLevel, opt => opt.MapFrom(src => Enum.Parse(typeof(DifficultyLevel), src.DifficultyLevel)))
      .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse(typeof(TourStatus), src.Status)))
     .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
     .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
    // .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
     .ForMember(dest => dest.PublishedDateTime, opt => opt.MapFrom(src => src.PublishedDateTime));


        CreateMap<Tour, TourDTO>()
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
        .ForMember(dest => dest.DifficultyLevel, opt => opt.MapFrom(src => src.DifficultyLevel.ToString()))
        .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
        .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
        .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
        .ForMember(dest => dest.PublishedDateTime, opt => opt.MapFrom(src => src.PublishedDateTime));


        CreateMap<TourEquipmentDto, TourEquipment>().ReverseMap();

        CreateMap<TourPointDto, TourPoint>().ReverseMap();

        CreateMap<GuideReviewDto, GuideReview>().ReverseMap();

        CreateMap<PreferencesDto, Preferences>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.PreferredDifficulty, opt => opt.MapFrom(src => Enum.Parse(typeof(DifficultyLevel), src.PreferredDifficulty)))
            .ForMember(dest => dest.TransportationPreferences, opt => opt.MapFrom(src => src.TransportationPreferences))
            .ForMember(dest => dest.InterestTags, opt => opt.MapFrom(src => src.InterestTags));

        CreateMap<Preferences, PreferencesDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.PreferredDifficulty, opt => opt.MapFrom(src => src.PreferredDifficulty.ToString()))
            .ForMember(dest => dest.TransportationPreferences, opt => opt.MapFrom(src => src.TransportationPreferences))
            .ForMember(dest => dest.InterestTags, opt => opt.MapFrom(src => src.InterestTags));

        CreateMap<TourCharacteristicDTO, TourCharacteristic>()
            .ForMember(dest => dest.Distance, opt => opt.MapFrom(src => src.Distance))
            .ForMember(dest => dest.TransportType, opt => opt.MapFrom(src => Enum.Parse(typeof(DifficultyLevel), src.TransportType)))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration));

        CreateMap<TourCharacteristic, TourCharacteristicDTO>()
            .ForMember(dest => dest.Distance, opt => opt.MapFrom(src => src.Distance))
            .ForMember(dest => dest.TransportType, opt => opt.MapFrom(src => src.TransportType.ToString()))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration));

        CreateMap<TourPointExecutionDto, TourPointExecution>().ReverseMap();

        CreateMap<TourExecutionDto, TourExecution>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.TourId, opt => opt.MapFrom(src => src.TourId))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse(typeof(TourExecutionStatus), src.Status)));


        CreateMap<TourExecution, TourExecutionDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.TourId, opt => opt.MapFrom(src => src.TourId))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));


        CreateMap<TourExecutionPositionDto, TourExecutionPosition>().ReverseMap();

        CreateMap<ProblemDto, Problem>().ReverseMap();
        CreateMap<ProblemMessageDto, ProblemMessage>().ReverseMap();

        CreateMap<TourBundleDto, TourBundle>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse(typeof(TourBundleStatus), src.Status)))
            .ForMember(dest => dest.TourIds, opt => opt.MapFrom(src => src.TourIds))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

        CreateMap<TourBundle, TourBundleDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.TourIds, opt => opt.MapFrom(src => src.TourIds))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

        CreateMap<Competition, CompetitionDto>()
        .ForMember(dest => dest.TourId, opt => opt.MapFrom(src => src.TourId))
        .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
        .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
        .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration));

        CreateMap<CompetitionDto, Competition>().IncludeAllDerived()

    .ForMember(dest => dest.TourId, opt => opt.MapFrom(src => src.TourId))
    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
     .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse(typeof(DifficultyLevel), src.Status)))

    .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration));


		CreateMap<CompetitionApply, CompetitionApplyDto>()
		.ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
		.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
		
		.ForMember(dest => dest.NumLikes, opt => opt.MapFrom(src => src.NumLikes));

		CreateMap<CompetitionApplyDto, CompetitionApply>().IncludeAllDerived()

   .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
   .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
	

   .ForMember(dest => dest.NumLikes, opt => opt.MapFrom(src => src.NumLikes));



	}

}
