using AutoMapper;
using HardkorowyKodsu.Backend.Api.Tables.Dto;
using HardkorowyKodsu.Tables.ViewModels;

namespace HardkorowyKodsu.Tables.MappingProfiles;

internal class TableViewModelProfile : Profile
{
	public TableViewModelProfile()
	{
		CreateMap<GetTablesReturnDto, TableViewModel>()
			.ForMember(x => x.TableId, opt => opt.MapFrom(x => x.Id))
			.ForMember(x => x.DisplayName, opt => opt.MapFrom(x => x.Schema + "." + x.Name));
	}
}
