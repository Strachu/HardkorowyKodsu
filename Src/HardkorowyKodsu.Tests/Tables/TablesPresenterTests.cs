using AutoFixture;
using AutoFixture.AutoFakeItEasy;
using AutoMapper;
using FakeItEasy;
using HardkorowyKodsu.Backend.Api.Tables.Dto;
using HardkorowyKodsu.Tables;
using HardkorowyKodsu.Tables.Interfaces;
using HardkorowyKodsu.Tables.ViewModels;
using NUnit.Framework;

namespace HardkorowyKodsu.Tests.Tables;

[TestFixture]
public class TablesPresenterTests
{
	private ITablesView mTablesViewMock;
	private ITablesBackendClient mTablesBackendClientMock;
	private IMapper mMapperMock;

	private TablesPresenter mTestedTablesPresenter;

	[SetUp]
	public void SetUp()
	{
		var fixture = new Fixture();
		fixture.Customize(new AutoFakeItEasyCustomization() { ConfigureMembers = true });

		mTablesViewMock = A.Fake<ITablesView>();
		mTablesBackendClientMock = fixture.Freeze<ITablesBackendClient>();
		mMapperMock = fixture.Freeze<IMapper>();

		fixture.Inject(mTablesViewMock);

		mTestedTablesPresenter = fixture.Create<TablesPresenter>();
	}

	[Test]
	public void DataLoadingRequested_LoadsAndShowsTablesFromBackend()
	{
		var fixture = new Fixture();
		var tablesInBackend = fixture.CreateMany<GetTablesReturnDto>();
		var viewModelsFromTablesInBacked = fixture.CreateMany<TableViewModel>().ToList();

		A.CallTo(() => mTablesBackendClientMock.GetTablesAsync(A<CancellationToken>.Ignored)).Returns(Task.FromResult(tablesInBackend));
		A.CallTo(() => mMapperMock.Map<List<TableViewModel>>(tablesInBackend)).Returns(viewModelsFromTablesInBacked);

		mTablesViewMock.DataLoadingRequested += Raise.WithEmpty();

		A.CallTo(() => mTablesViewMock.ShowTables(viewModelsFromTablesInBacked)).MustHaveHappened();
	}

	[Test]
	public void DataLoadingRequested_Success_EnablesLoadDataButton()
	{
		mTablesViewMock.DataLoadingRequested += Raise.WithEmpty();

		A.CallTo(mTablesViewMock).Where(call => call.Method.Name == "set_" + nameof(ITablesView.DataLoadingButtonEnabled) && call.GetArgument<bool>(0) == true).MustHaveHappened();
	}

	[Test]
	public void DataLoadingRequested_Failed_StillEnablesLoadDataButton()
	{
		A.CallTo(() => mTablesBackendClientMock.GetTablesAsync(A<CancellationToken>.Ignored)).Throws<Exception>();

		mTablesViewMock.DataLoadingRequested += Raise.WithEmpty();

		A.CallTo(mTablesViewMock).Where(call => call.Method.Name == "set_" + nameof(ITablesView.DataLoadingButtonEnabled) && call.GetArgument<bool>(0) == true).MustHaveHappened();
	}
	
	[Test]
	public void DataLoadingRequested_Failed_ShowsErrorMessage()
	{
		A.CallTo(() => mTablesBackendClientMock.GetTablesAsync(A<CancellationToken>.Ignored)).Throws<Exception>();

		mTablesViewMock.DataLoadingRequested += Raise.WithEmpty();

		A.CallTo(() => mTablesViewMock.SetErrorStatusMessage(A<string>.Ignored)).MustHaveHappened();
	}
	
	[Test]
	public void DataLoadingRequested_Success_EnablesTableList()
	{
		mTablesViewMock.DataLoadingRequested += Raise.WithEmpty();

		A.CallTo(mTablesViewMock).Where(call => call.Method.Name == "set_" + nameof(ITablesView.TableListEnabled) && call.GetArgument<bool>(0) == true).MustHaveHappened();
	}

	[Test]
	public void DataLoadingRequested_Failed_DoesNotEnableTableList()
	{
		A.CallTo(() => mTablesBackendClientMock.GetTablesAsync(A<CancellationToken>.Ignored)).Throws<Exception>();

		mTablesViewMock.DataLoadingRequested += Raise.WithEmpty();
		
		A.CallTo(mTablesViewMock).Where(call => call.Method.Name == "set_" + nameof(ITablesView.TableListEnabled) && call.GetArgument<bool>(0) == true).MustNotHaveHappened();
	}

	// TODO Remaining tests
}
