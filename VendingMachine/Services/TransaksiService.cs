using System;
using System.Linq;
using VendingMachine.Base;
using VendingMachine.Model;
using VendingMachine.Store;

namespace VendingMachine.Services
{
	public class TransaksiService : ITransaksiService
	{
		public ModelTransaksi Pembelian(ModelTransaksi transaksi)
		{
			var barang = VendingStore.Barang.FirstOrDefault(x => x.Id == transaksi.IdBarang);
			if (barang == null)
			{
				throw new InvalidOperationException($"Barang with Id = {transaksi.IdBarang} not found.");
			}

			transaksi.Id = VendingStore.Transaksi.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault() + 1;
			transaksi.TotalHarga = transaksi.Quantity * barang.Harga;


			if (barang.Stok < transaksi.Quantity)
			{
				throw new InvalidOperationException($"Stok Barang tidak mencukup, Stok saat ini = {barang.Stok}.");
			}

			if (Pecahan.List.Where(x => transaksi.TotalUang % x == 0).Count() < 1)
			{
				throw new InvalidOperationException($"Pecahan Uang yang diterima hanya = {string.Join(",", Pecahan.List.ToArray())}.");
			}

			if (transaksi.TotalUang < transaksi.TotalHarga)
			{
				throw new InvalidOperationException($"Uang tidak mencukup, Total Harga = {transaksi.TotalHarga}.");
			}

			transaksi.TotalKembali = transaksi.TotalUang - transaksi.TotalHarga;
			barang.Stok -= transaksi.Quantity;
			VendingStore.Transaksi.Add(transaksi);
			return transaksi;
		}

		public ModelTransaksi Retur(int id)
		{
			var transaksi = VendingStore.Transaksi.FirstOrDefault(x => x.Id == id);
			if (transaksi == null)
			{
				throw new InvalidOperationException($"Transaksi with Id = {id} not found.");
			}

			var retur = new ModelTransaksi
			{
				Id = VendingStore.Transaksi.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault() + 1,
				CreatedDate = DateTime.Now,
				IdBarang = transaksi.IdBarang,
				Quantity = transaksi.Quantity,
				Tipe = TipeTransaksi.RETUR,
				TotalHarga = 0,
				TotalKembali = transaksi.TotalUang,
				TotalUang = 0
			};

			var barang = VendingStore.Barang.FirstOrDefault(x => x.Id == transaksi.IdBarang);
			barang.Stok += transaksi.Quantity;
			VendingStore.Transaksi.Add(retur);
			return retur;
		}
	}
}
