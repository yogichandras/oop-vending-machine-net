using VendingMachine.Model;

namespace VendingMachine.Services
{
	public interface ITransaksiService
	{
		ModelTransaksi Pembelian(ModelTransaksi transaksi);
		ModelTransaksi Retur(int id);
	}
}
