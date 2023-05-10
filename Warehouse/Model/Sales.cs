namespace Warehouse.Model
{
    public class Sales
    {
        public int IdSales { get; set; }
        public int? idProduct { get; set; }
        public int? idWarehouse { get; set; }
        public int Quanity { get; set; } 

        public virtual Product? IdProductNavigation { get; set; }
        public virtual Warehouse? IdWarehouseNavigation { get; set; }

        public virtual int NewIndex() //метод определение нового первичного ключа 
        {
            using (WarehouseDataBaseContext db = new WarehouseDataBaseContext())
            {
                int Max = -1;
                var SalesList = db.Saleses.ToList();
                Console.WriteLine("Sales:");
                foreach (Sales p in SalesList)
                {
                    if (p.IdSales > Max) Max = p.IdSales;
                }
                return (Max+1);
            }
        }
        public virtual void AddNew(int idProduct, int idWarehouse, int quanity) //метод добавления в таблицу Sales новой записи 
        {
            //Создаем новый объект Carryng из параметров запроса
            Sales newData = new Sales();
            newData.IdSales = newData.NewIndex();
            newData.idProduct = idProduct;
            newData.idWarehouse = idWarehouse;
            newData.Quanity = quanity;
            using (WarehouseDataBaseContext db = new WarehouseDataBaseContext())
            {
                db.Add(newData);
                db.SaveChanges();
            }

        }
  
        public virtual List<Sales> GetAll()// метод вывода всей таблицы Sales
        {
            using (WarehouseDataBaseContext db = new WarehouseDataBaseContext())
            {
                return db.Saleses.ToList();
            }
        }

        public virtual void DeleteById(int id_sales)//метод удаления записи по ID из таблицы Sales
        {
            using (WarehouseDataBaseContext db = new WarehouseDataBaseContext())
            {
                Sales data = db.Saleses.Find(id_sales);
                if (data != null)
                {
                    db.Saleses.Remove(data);
                    db.SaveChanges();
                }
            }
        }

    }
}
