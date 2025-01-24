using AutoMapper;
using HardkorowyKodsu.Backend.Api.Tables.Dto;
using HardkorowyKodsu.Backend.Tables.DataAccess.Entities;

namespace HardkorowyKodsu.Backend.Tables.MappingProfiles;

public class GetTablesReturnDtoProfile : Profile
{
	public GetTablesReturnDtoProfile()
	{
		CreateMap<TableSummary, GetTablesReturnDto>();
	}
}
