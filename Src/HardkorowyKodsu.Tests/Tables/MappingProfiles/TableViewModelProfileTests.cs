using AutoFixture;
using AutoMapper;
using HardkorowyKodsu.Backend.Api.Tables.Dto;
using HardkorowyKodsu.Tables.MappingProfiles;
using HardkorowyKodsu.Tables.ViewModels;
using NUnit.Framework;

namespace HardkorowyKodsu.Tests.Tables.MappingProfiles;

[TestFixture]
public class TableViewModelProfileTests
{
	private IMapper mMapper;

	[SetUp]
	public void SetUp()
	{
		var mapperConfiguration = new MapperConfiguration(x => x.AddProfile<TableViewModelProfile>());

		mMapper = new Mapper(mapperConfiguration);
	}

	[Test]
	public void DisplayName_IsConcatenatedFromSchemaAndName()
	{
		var inputDto = new Fixture().Build<GetTablesReturnDto>()
			.With(x => x.Schema, "schem")
			.With(x => x.Name, "tabela")
			.Create();

		var result = mMapper.Map<TableViewModel>(inputDto);

		Assert.That(result.DisplayName, Is.EqualTo("schem.tabela"));
	}
}
