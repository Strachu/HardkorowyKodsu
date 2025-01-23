using AutoMapper;
using NUnit.Framework;

namespace HardkorowyKodsu.Backend.Tests;

[TestFixture]
internal class AutoMapperTests
{
	[Test]
	public void TestConfiguration()
	{
		var mapperConfiguration = new MapperConfiguration(x => x.AddMaps(typeof(Program).Assembly));
		mapperConfiguration.AssertConfigurationIsValid();
	}
}
