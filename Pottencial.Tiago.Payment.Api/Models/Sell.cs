using Microsoft.EntityFrameworkCore.Migrations;
using Pottencial.Tiago.Payment.Api.CrossCutting.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pottencial.Tiago.Payment.Api.Models
{
    public class Sell
    {
        [Key]
        public long Id { get; set; }
        public Seller Seller { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public List<ProductSell> ProductSells { get; set; }
        public Status Status { get; set; }

    }
}
