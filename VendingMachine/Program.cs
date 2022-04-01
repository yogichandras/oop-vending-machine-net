using Microsoft.Extensions.DependencyInjection;
using System;
using VendingMachine.Model;
using VendingMachine.Services;

namespace VendingMachine
{
	internal class Program
	{
		private static ServiceProvider serviceProvider = new ServiceCollection()
				.AddSingleton<IBarangService, BarangService>()
				.AddSingleton<ITransaksiService, TransaksiService>()
				.BuildServiceProvider();

		private static IBarangService barangService = serviceProvider.GetService<IBarangService>();
		private static ITransaksiService transaksiService = serviceProvider.GetService<ITransaksiService>();

		static void Main(string[] args)
		{
			Console.WriteLine("----- VENDING MACHINE -----");
			Console.WriteLine("Daftar Barang :");
			foreach (var item in barangService.List())
			{
				Console.WriteLine($"{item.Id}. {item.Nama}: {item.Harga}");
			}
			GoToMenu();
		}

		protected static void GoToMenu()
		{
			Console.WriteLine("---------------------------");
			Console.WriteLine("Pilih Menu :");
			Console.WriteLine("1. Pembelian");
			Console.WriteLine("2. Pengembalian Uang");
			Console.WriteLine("3. Keluar");

			string menu = Console.ReadLine();

			if (menu == "1")
			{
				Console.WriteLine("Id Barang = ");
				string idBarang = Console.ReadLine();
				Console.WriteLine("Quantity = ");
				string quantity = Console.ReadLine();
				Console.WriteLine("Uang = ");
				string uang = Console.ReadLine();

				var trx = transaksiService.Pembelian(new ModelTransaksi
				{
					IdBarang = int.Parse(idBarang),
					Quantity = int.Parse(quantity),
					Tipe = Base.TipeTransaksi.PEMBELIAN,
					CreatedDate = DateTime.Now,
					TotalUang = decimal.Parse(uang),
				});

				Console.WriteLine("--------------------");
				Console.WriteLine($"Pembelian Berhasil!");
				Console.WriteLine("--------------------");
				Console.WriteLine($"Id Transaksi = {trx.Id}");
				Console.WriteLine($"Id Barang = {trx.IdBarang}");
				Console.WriteLine($"Tanggal = {trx.CreatedDate:dd/MM/yyyy}");
				Console.WriteLine($"Uang = {trx.TotalUang}");
				Console.WriteLine($"Total= {trx.TotalHarga}");
				Console.WriteLine($"Kembalian = {trx.TotalKembali}");
				GoToMenu();
			}
			else if (menu == "2")
			{
				Console.WriteLine("Id Transaksi = ");
				string idTransaksi = Console.ReadLine();
				var trx = transaksiService.Retur(int.Parse(idTransaksi));
				Console.WriteLine("--------------------");
				Console.WriteLine($"Pengembalian Berhasil!");
				Console.WriteLine("--------------------");
				Console.WriteLine($"Id Transaksi = {trx.Id}");
				Console.WriteLine($"Id Barang = {trx.IdBarang}");
				Console.WriteLine($"Tanggal = {trx.CreatedDate:dd/MM/yyyy}");
				Console.WriteLine($"Uang = {trx.TotalUang}");
				Console.WriteLine($"Total= {trx.TotalHarga}");
				Console.WriteLine($"Kembalian = {trx.TotalKembali}");
				GoToMenu();
			}
			else
			{
				System.Environment.Exit(0);
			}
		}
	}
}
