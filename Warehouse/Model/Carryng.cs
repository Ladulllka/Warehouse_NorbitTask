using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Warehouse.Model;

public partial class Carryng
{
    public int IdCarryng { get; set; }

    public int? IdProduct { get; set; }

    public int? IdWarehouse { get; set; }

    public int Quanity { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual Warehouse? IdWarehouseNavigation { get; set; }


    public virtual int NewIndex() // метод определения нового перчивного ключа для таблицы Carryng
    {
        using (WarehouseDataBaseContext db = new WarehouseDataBaseContext())
        {
            int Max = -1;
            var CarryngList = db.Carryngs.ToList();
            Console.WriteLine("MAX:");
            foreach (Carryng p in CarryngList)
            {
                  if (p.IdCarryng >Max) Max= p.IdCarryng;
            }
            return (Max+1);
        }
    }
    public virtual void AddNew(int idProduct, int idWarehouse, int quanity) // метод добавления новой записи в таблицу Carryng
    {
        
        Carryng newData = new Carryng();
        newData.IdCarryng = newData.NewIndex();
        newData.IdProduct = idProduct;
        newData.IdWarehouse = idWarehouse;
        newData.Quanity = quanity;
        using (WarehouseDataBaseContext db = new WarehouseDataBaseContext())
        {
            db.Add(newData);
            db.SaveChanges();
        }

    }

    public virtual List<Carryng> GetAll() //метод вывода всей таблицы Carryng
    {
        using (WarehouseDataBaseContext db = new WarehouseDataBaseContext())
        {
            return db.Carryngs.ToList();
        }
    }

    public virtual void DeleteById(int id_carryng) // метод удаления записи в таблицы Carryng по ID
    {
        using (WarehouseDataBaseContext db = new WarehouseDataBaseContext())
        {
            Carryng data = db.Carryngs.Find(id_carryng);
            if (data != null)
            {
                db.Carryngs.Remove(data);
                db.SaveChanges();
            }
        }
    }

}
