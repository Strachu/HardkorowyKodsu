using AutoMapper;
using HardkorowyKodsu.Backend.Tables.DataAccess.Entities;
using HardkorowyKodsu.Backend.Tables.Dto;

namespace HardkorowyKodsu.Backend.Tables.MappingProfiles;

public class GetTableReturnDtoProfile : Profile
{
	public GetTableReturnDtoProfile()
	{
		CreateMap<TableColumn, GetTableReturnDto.Column>();
	}
}
