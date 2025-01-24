using AutoMapper;
using HardkorowyKodsu.Backend.Api;
using HardkorowyKodsu.Backend.Api.Tables.Dto;
using HardkorowyKodsu.Backend.Tables.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HardkorowyKodsu.Backend.Tables;

[Route(ResourceUrls.Tables)]
[ApiController]
public class TablesController : ControllerBase
{
	private readonly ITablesDao mTablesDao;
	private readonly IMapper mMapper;

	public TablesController(ITablesDao tablesDao, IMapper mapper)
	{
		mTablesDao = tablesDao;
		mMapper = mapper;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<GetTablesReturnDto>>> GetAsync()
	{
		var tables = await mTablesDao.GetTablesSummaryAsync();

		return Ok(mMapper.Map<IEnumerable<GetTablesReturnDto>>(tables));
	}

	[HttpGet("{id}")]
	[ProducesResponseType<GetTableReturnDto>(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<GetTableReturnDto>> GetDetailsAsync(int id)
	{
		var columns = await mTablesDao.GetTableColumnsAsync(id);
		if(!columns.Any())
		{
			return NotFound();
		}

		return Ok(new GetTableReturnDto
		{
			Id = id,
			Columns = mMapper.Map<List<GetTableReturnDto.Column>>(columns)
		});
	}
}
