using System.Collections.Generic;
using VendingMachine.Model;
using VendingMachine.Store;

namespace VendingMachine.Services
{
	public class BarangService : IBarangService
	{
		public List<ModelBarang> List()
		{
			return VendingStore.Barang;
		}
	}
}
