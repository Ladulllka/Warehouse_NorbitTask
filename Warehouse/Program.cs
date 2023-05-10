using Warehouse.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (WarehouseDataBaseContext db = new WarehouseDataBaseContext())
{
    var SalesList = db.Saleses.ToList();
    Console.WriteLine("Sales:");
    foreach (Sales u in SalesList)
    {
        Console.WriteLine($"{u.IdSales},{u.Quanity}");
    }

    var CarryngsList = db.Carryngs.ToList(); //вывод в консоль всех записей из таблице
    Console.WriteLine("Carryng:");
    foreach (Carryng u in CarryngsList)
    {
        Console.WriteLine($"{u.IdCarryng},{u.Quanity}");
    }
}


    app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
