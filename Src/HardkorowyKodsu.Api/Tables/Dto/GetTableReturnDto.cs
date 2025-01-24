namespace HardkorowyKodsu.Backend.Api.Tables.Dto;

public partial class GetTableReturnDto
{
	public int Id { get; set; }

	public ICollection<Column> Columns { get; set; }
}
