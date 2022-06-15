using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.Models
{

    public class ProductModel
    {
        public string ProductName { get; set; } = string.Empty;
        public float UpperMultiplier { get; set; } = 1.0f;
        public float LowerMultiplier { get; set; } = 1.0f;
        public long PotDefaultValue { get; set; } = 1000;
        public string UpperParent { get; set; } = string.Empty;
        public string UpperChild1 { get; set; } = string.Empty;
        public string UpperChild2 { get; set; } = string.Empty;
        public string LowerParent { get; set; } = String.Empty;
        public string LowerChild1 { get; set; } = String.Empty;
        public string LowerChild2 { get; set; } = string.Empty;
    }

    public class Product
    {
        public static readonly ProductModel AL106 = new ProductModel()
        {
            ProductName = "AL106",
            LowerMultiplier = 7.7f,
            UpperMultiplier = 7.8F,
            PotDefaultValue = 1000,
            UpperParent = "R20",
            UpperChild1 = "R4",
            UpperChild2 = "R14",
            LowerParent = "R16",
            LowerChild1 = "R8",
            LowerChild2 = "R15"
        };
        public static readonly ProductModel LVD = new ProductModel()
        {
            ProductName = "LVD",
            LowerMultiplier = 6.72f,
            UpperMultiplier = 7.07f,
            PotDefaultValue = 1000,
            UpperParent = "R20",
            UpperChild1 = "R4",
            UpperChild2 = "R14",
            LowerParent = "R16",
            LowerChild1 = "R8",
            LowerChild2 = "R15"
        };
    }
}
