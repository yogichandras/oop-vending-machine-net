using System.Collections.Generic;
using VendingMachine.Model;

namespace VendingMachine.Services
{
	public interface IBarangService
	{
		List<ModelBarang> List();
	}
}
