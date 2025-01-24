using AutoMapper;
using HardkorowyKodsu.Backend.Api.Tables.Dto;
using HardkorowyKodsu.Tables.ViewModels;

namespace HardkorowyKodsu.Tables.MappingProfiles;

internal class ColumnViewModelProfile : Profile
{
	public ColumnViewModelProfile()
	{
		CreateMap<GetTableReturnDto.Column, ColumnViewModel>()
			.ForMember(x => x.ColumnName, opt => opt.MapFrom(x => x.Name))
			.ForMember(x => x.IsNotNull, opt => opt.MapFrom(x => !x.IsNullable));
	}
}
