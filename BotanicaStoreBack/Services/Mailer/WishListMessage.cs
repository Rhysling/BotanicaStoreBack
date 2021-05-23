using BotanicaStoreBack.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotanicaStoreBack.Services.Mailer
{
	public class WishListMessage
	{
		private readonly string body;
		private readonly string plantRow;
		private readonly string potRow;
		private readonly vwWishListEmail data;
		private readonly int totalQty;
		private readonly decimal subtotalAmount;
		private readonly decimal taxRate;
		private readonly decimal totalAmount;
		private readonly DateTime nw;

		public WishListMessage(vwWishListEmail data, double taxRate)
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), "Templates");
			body = File.ReadAllText(Path.Combine(path, "email_wishlist.html"));
			plantRow = File.ReadAllText(Path.Combine(path, "email_wishlist_plant_row.html"));
			potRow = File.ReadAllText(Path.Combine(path, "email_wishlist_pot_row.html"));
			this.data = data;

			totalQty = data.Items.Sum(a => a.Qty);
			subtotalAmount = data.Items.Aggregate(0.0m, (acc, item) => acc += item.Qty * item.Price);
			this.taxRate = (decimal)taxRate;
			totalAmount = Decimal.Round(subtotalAmount * (1m + this.taxRate), 2);
			nw = DateTime.Now;
		}


		public string RenderHtmlBody()
		{
			var det = new StringBuilder();
			var plants = data.Items.Select(a => a.PlantName).Distinct().OrderBy(a => a);

			foreach (string p in plants)
			{
				det.Append(plantRow.Replace("[PlantName]", p));

				var pots = data.Items.Where(a => a.PlantName == p).OrderBy(a => a.Price);
				foreach (var t in pots)
				{
					det.Append(potRow
						.Replace("[PotSize]", t.PotDescription)
						.Replace("[Qty]", t.Qty.ToString())
						.Replace("[Price]", t.Price.ToString("#.00"))
						.Replace("[Ext]",( t.Price * t.Qty).ToString("#.00")));
				}
			}

			return body
				.Replace("[Date]", nw.ToShortDateString())
				.Replace("[Name]", string.IsNullOrWhiteSpace(data.FullName) ? data.Email : data.FullName)
				.Replace("[Email]", data.Email)
				.Replace("[Subtotal]", subtotalAmount.ToString("N2"))
				.Replace("[TaxRate]", (taxRate * 100m).ToString("N2"))
				.Replace("[Tax]", (subtotalAmount * taxRate).ToString("N2"))
				.Replace("[TotalQty]", totalQty.ToString("N0"))
				.Replace("[TotalAmount]", totalAmount.ToString("N2"))
				.Replace("[Year]", nw.Year.ToString())
				.Replace("[Details]", det.ToString());
		}

		public string RenderTextBody()
		{
			var sb = new StringBuilder();

			sb.AppendLine("Hi " + (string.IsNullOrWhiteSpace(data.FullName) ? data.Email : data.FullName) + ",");
			sb.AppendLine();
			sb.AppendLine("This is the list of plants you are intersted in");
			sb.AppendLine("purchasing from Botanica for pickup in the");
			sb.AppendLine("Wallingford neighborhood of Seattle. There is no");
			sb.AppendLine("obligation, and no payment is due.");
			sb.AppendLine();
			sb.AppendLine("I will contact you by email; please feel free to");
			sb.AppendLine("email me at pamela@polson.com.");
			sb.AppendLine();

			sb.AppendLine(data.Email.PadRight(36) + nw.ToShortDateString().PadLeft(12));
			sb.AppendLine();

			sb.AppendLine("Plant / Pot Size             Qty  Price   Amount");

			var plants = data.Items.Select(a => a.PlantName).Distinct().OrderBy(a => a);

			foreach (string p in plants)
			{
				sb.AppendLine(p);

				var pots = data.Items.Where(a => a.PlantName == p).OrderBy(a => a.Price);
				foreach (var t in pots)
				{
					sb.AppendLine("  " +
						t.PotDescription.PadRight(25) +
						t.Qty.ToString("N0").PadLeft(5) +
						t.Price.ToString("N2").PadLeft(7) +
						(t.Price * t.Qty).ToString("N2").PadLeft(9));
				}
				sb.AppendLine();
			}

			sb.AppendLine("Total".PadLeft(39) + subtotalAmount.ToString("N2").PadLeft(9));
			sb.AppendLine(("Tax@ " + (taxRate * 100m).ToString("N2")+"%").PadLeft(39) + (subtotalAmount * taxRate).ToString("N2").PadLeft(9));
			sb.AppendLine("TOTAL".PadLeft(27) + totalQty.ToString("N0").PadLeft(5) + totalAmount.ToString("N2").PadLeft(16));
			sb.AppendLine();
			sb.AppendLine("Thank you!");
			sb.AppendLine("Pamela");
			sb.AppendLine();
			sb.AppendLine("Botanica - https://botanicaplants.com");
			sb.AppendLine();

			return sb.ToString();
		}

		public string Subject => "Your Plant List for Botanica";

		public string To => string.IsNullOrWhiteSpace(data.FullName) ? data.Email :  $"{data.FullName} <{data.Email}>";
	}
}
