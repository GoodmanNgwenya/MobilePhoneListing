using MobilePhoneListing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobilePhoneListing.Data
{
    public class DummyData
    {
        public static System.Collections.Generic.List<Product> getProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    ProductName="Samsung",
                    ShortDescription="Sumsung galaxy A20",
                    LongDescription="Get yourself a smath Sumsung galaxy A20",
                    Specification="Sumsung dalaxy A20, Android,30GB storage with 8GB Memory, Rear Camera 13-megapixel (f/1.9) + 5-megapixel (f/2.2), Front Camera 8-megapixel (f/2.0)",
                    ImagePath="~/Image/samsungA20.jpg",
                    Price=2800
                },
                new Product()
                {
                    ProductName="Nokia",
                    ShortDescription="Nokia 2.3 32GB Dual Sim - Cyan Green",
                    LongDescription="Get yourself Nokia 2.3 32GB Dual Sim - Cyan Green at a low price",
                    Specification="Memory - 2GB RAM | 32GB ROM Camera - Rear Camera: 13.0MP + 2.0MP | Front Camera: 5.0MP",
                    ImagePath="~/Image/nokia_2_3.jpg",
                    Price=2500
                },
                new Product()
                {
                    ProductName="Huawei",
                    ShortDescription="Huawei P30 Lite",
                    LongDescription="Huawei P30 Lite 128GB Dual Sim - Peacock Blue",
                    Specification="Huawei P30 Lite 128GB Dual Sim, Android, 8GB Memory,Rear Camera 40-megapixel (f/1.8) + 16-megapixel (f/2.2) + 8-megapixel (f/2.4), Front Camera 32-megapixel (f/2.0)",
                    ImagePath="~/Image/hauweiP30Lite.jpg",
                    Price=2700

                }
                // new Product()
                //{
                //    ProductName="Hisense",
                //    ShortDescription="Hisense Infinity E40 Lite 32GB Dual Sim - Charcoal",
                //    LongDescription="Hisense Infinity E40 Lite 32GB Dual Sim - Charcoal",
                //    Specification="Android, 32GB Dual Sim - Charcoal with 8GB memory",
                //    ImagePath="~/Image/hisenseE40Lite.jpg",
                //    Price=2000


                //}

            };
            return products;
        }
    }
}