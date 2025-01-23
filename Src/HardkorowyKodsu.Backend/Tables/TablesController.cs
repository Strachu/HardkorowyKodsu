using AutoMapper;
using HardkorowyKodsu.Backend.Tables.DataAccess.Entities;
using HardkorowyKodsu.Backend.Tables.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HardkorowyKodsu.Backend.Tables;

[Route("api/[controller]")]
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
}
