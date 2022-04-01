using System;
using System.Collections.Generic;
using VendingMachine.Model;

namespace VendingMachine.Store
{
	public static class VendingStore
	{
		public static List<ModelBarang> Barang = new List<ModelBarang>
		{
			new ModelBarang
			{
				Id = 1,
				CreatedDate = DateTime.Now,
				Harga = 6000,
				Nama = "Biskuit",
				Stok = 10
			},
			new ModelBarang
			{
				Id = 2,
				CreatedDate = DateTime.Now,
				Harga = 8000,
				Nama = "Chips",
				Stok = 5
			},
			new ModelBarang
			{
				Id = 3,
				CreatedDate = DateTime.Now,
				Harga = 10000,
				Nama = "Oreo",
				Stok = 1
			},
			new ModelBarang
			{
				Id = 4,
				CreatedDate = DateTime.Now,
				Harga = 12000,
				Nama = "Tango",
				Stok = 3
			},
			new ModelBarang
			{
				Id = 5,
				CreatedDate = DateTime.Now,
				Harga = 15000,
				Nama = "Cokelat",
				Stok = 2
			}
		};
		public static List<ModelTransaksi> Transaksi = new List<ModelTransaksi>();
	}
}
