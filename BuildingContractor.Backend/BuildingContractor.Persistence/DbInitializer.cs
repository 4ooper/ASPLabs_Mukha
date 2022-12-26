using BuildingContractor.Domain;

namespace BuildingContractor.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();
                
            Random random = new Random();

            if (context.producers.Count() == 0)
            {
                string[] values = { "Авантек", "Апарен", "Бетопласт", "Конрад", "БетСет", "Derwold&Co", "Евроцемент", "Пеноплекс" };
                for (int i = 0; i < 500; i++)
                {
                    var value = values[random.Next(0, values.Length - 1)];
                    context.producers.Add(new Producer { Name = value });
                }
                context.SaveChanges();
            }

            if (context.materials.Count() < 10000)
            {
                string[] names = { "Бетон", "Сталь", "Камень", "Пластик", "Стекло", "Песок", "Кирпич", "Бревно", "Гипс" };
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                for (int i = 0; i < 10000; i++)
                {
                    var name = names[random.Next(0, names.Length - 1)];
                    var createdDay = start.AddDays(random.Next(range));
                    var validaty = start.AddDays(random.Next(range));
                    var producer = random.Next(1, 48);
                    context.materials.Add(new Material { Name = name, CreationDate = createdDay, Valid = validaty, ProducerId = producer });
                }
                context.SaveChanges();
            }
        }
    }
}
