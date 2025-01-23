using AutoFixture;
using AutoFixture.AutoFakeItEasy;
using AutoMapper;
using FakeItEasy;
using HardkorowyKodsu.Backend.Tables;
using HardkorowyKodsu.Backend.Tables.DataAccess.Entities;
using HardkorowyKodsu.Backend.Tables.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NUnit.Framework;

namespace HardkorowyKodsu.Backend.Tests.Tables;

[TestFixture]
public class TablesControllerTests
{
	private ITablesDao mTablesDaoMock;
	private IMapper mMapperMock;

	private TablesController mTestedTablesController;

	[SetUp]
	public void SetUp()
	{
		var fixture = new Fixture();
		fixture.Customize(new AutoFakeItEasyCustomization() { ConfigureMembers = true });
		fixture.Customize<BindingInfo>(x => x.OmitAutoProperties());

		mTablesDaoMock = fixture.Freeze<ITablesDao>();
		mMapperMock = fixture.Freeze<IMapper>();

		mTestedTablesController = fixture.Create<TablesController>();
	}

	[Test]
	public async Task GetAsync_ReturnsDtosMappedFromDaoResult()
	{
		var fixture = new Fixture();
		var daoReturnValue = (IReadOnlyCollection<TableSummary>)fixture.CreateMany<TableSummary>().ToList();
		var mapperResult = fixture.CreateMany<GetTablesReturnDto>();

		A.CallTo(() => mTablesDaoMock.GetTablesSummaryAsync()).Returns(Task.FromResult(daoReturnValue));
		A.CallTo(() => mMapperMock.Map<IEnumerable<GetTablesReturnDto>>(daoReturnValue)).Returns(mapperResult);

		var result = await mTestedTablesController.GetAsync();
		var objectResult = result.Result as ObjectResult;

		Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
		Assert.That(objectResult.Value, Is.EqualTo(mapperResult));
	}
}
