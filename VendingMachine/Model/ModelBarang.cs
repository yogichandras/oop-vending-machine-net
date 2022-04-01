using VendingMachine.Base;

namespace VendingMachine.Model
{
	public class ModelBarang : BaseModel
	{
		public string Nama { get; set; }
		public decimal Harga { get; set; }
		public int Stok { get; set; }
	}
}
