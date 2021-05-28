using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime ="Sistem Bakımda";
        public static string ProductListed="Ürünler Listelendi";
        public static string ProductCountCategoryError="Bir kategoride en fazla 10 ürün olabilir.";
        public static string ProductNameAlreadyExists="Bu isimde başka bir ürün var";
        public static string CategoryLimitExceded="Kategori Limit aşıldığı için yeni ürün eklenemiyor.";
    }
}
