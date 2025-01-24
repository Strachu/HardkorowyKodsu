using AutoMapper;
using HardkorowyKoksu;
using NUnit.Framework;

namespace HardkorowyKodsu.Tests;

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
