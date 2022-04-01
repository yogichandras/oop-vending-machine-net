using VendingMachine.Base;

namespace VendingMachine.Model
{
	public class ModelTransaksi : BaseModel
	{
		public int IdBarang { get; set; }
		public TipeTransaksi Tipe { get; set; }
		public int Quantity { get; set; }
		public decimal TotalHarga { get; set; }
		public decimal TotalUang { get; set; }
		public decimal TotalKembali { get; set; }
	}
}
