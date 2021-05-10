using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    { 
        List<Product> _products; // global değişken
        
        //constructor
        public InMemoryProductDal()
        {
            //sanki oracledan, sql den geliyormuş gibi simule ediyoruz
            _products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak",
                UnitPrice=15, UnitsInStock=20 },
                new Product{ProductId=2, CategoryId=2, ProductName="Kamera",
                UnitPrice=100, UnitsInStock=2 },
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon",
                UnitPrice=1600, UnitsInStock=20 },
                new Product{ProductId=4, CategoryId=1, ProductName="Bilgisayar",
                UnitPrice=2000, UnitsInStock=1 }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //referans numarasına atama var ona göre silme işlemi yapıcaz
            Product productToDelete;

            //bizim gönderdiğimiz p.productId userdan gelen ProductId ye eşit mi ona bakıcak
             productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);//LINQ kodu -- burası tek bir eleman bulmaya yarar
            
            //SingleOrDefault foreach gibi tek tek dolaşmaya yarıyor.
            //p=> işareti Lambda tek tek dolaşırken verilen takma isim
            
            _products.Remove(productToDelete);

            // Eski kullanımı

            //    foreach (var p in _products)
            //    {
            //    if(product.ProductId==p.ProductId)// bizim gönderdiğimiz product.productId userdan gelen ProductId ye eşit mi ona bakıcak
            //    {
            //        productToDelete = p;
            //    }
            //    }
            //   _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products; //Veritabanını olduğu gibi döndürür

        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);//LINQ kodu -- burası tek bir eleman bulmaya yarar
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
        }
    }
}
