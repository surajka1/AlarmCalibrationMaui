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
        public static readonly ProductModel Al107Bat = new ProductModel()
        {
            ProductName = "Al107Bat",
            LowerMultiplier = 7.4f,
            UpperMultiplier = 6.67f,
            PotDefaultValue = 1000,
            UpperParent = "R27",
            UpperChild1 = "R11",
            UpperChild2 = "R14",
            LowerParent = "R18",
            LowerChild1 = "R26",
            LowerChild2 = "R22"
        };
        public static readonly ProductModel Al107Temp = new ProductModel()
        {
            ProductName = "Al107Temp",
            LowerMultiplier = 1.855f,
            UpperMultiplier = 7.855f,
            PotDefaultValue = 1000,
            UpperParent = "R16",
            UpperChild1 = "R4",
            UpperChild2 = "R5",
            LowerParent = "R12",
            LowerChild1 = "R28",
            LowerChild2 = "R25"
        };
        public static readonly ProductModel Al112Bat = new ProductModel()
        {
            ProductName = "Al112Bat",
            LowerMultiplier = 7.716f,
            UpperMultiplier = 9.145f,
            PotDefaultValue = 1000,
            UpperParent = "R30",
            UpperChild1 = "R32",
            UpperChild2 = "R33",
            LowerParent = "R45",
            LowerChild1 = "R43",
            LowerChild2 = "R44"
        };
        public static readonly ProductModel Al112Temp = new ProductModel()
        {
            ProductName = "Al112Temp",
            LowerMultiplier = 1.855f,
            UpperMultiplier = 7.829f,
            PotDefaultValue = 1000,
            UpperParent = "R18",
            UpperChild1 = "R20",
            UpperChild2 = "R21",
            LowerParent = "R28",
            LowerChild1 = "R25",
            LowerChild2 = "R26"
        };
    }
}
