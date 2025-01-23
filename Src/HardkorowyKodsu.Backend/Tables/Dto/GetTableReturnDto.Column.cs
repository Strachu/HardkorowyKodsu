namespace HardkorowyKodsu.Backend.Tables.Dto;

public partial class GetTableReturnDto
{
	public class Column
	{
		public string Name { get; set; }
		public string TypeName { get; set; }
		public bool IsNullable { get; set; }
	}
}
