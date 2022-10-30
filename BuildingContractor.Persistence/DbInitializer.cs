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
                for(int i = 0; i < 20000; i++)
                {
                    var value = values[random.Next(0, values.Length - 1)];
                    context.producers.Add(new Producer { name = value });
                }
                context.SaveChanges();
            }

            if (context.conctractorMaterials.Count() == 0)
            {
                string[] names = { "Бетон", "Сталь", "Камень", "Пластик", "Стекло", "Песок", "Кирпич", "Бревно" };
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                for (int i = 0; i < 20000; i++)
                {
                    var name = names[random.Next(0, names.Length - 1)];
                    var createdDay = start.AddDays(random.Next(range));
                    var validaty = start.AddDays(random.Next(range));
                    var producer = random.Next(1, 20000);
                    context.conctractorMaterials.Add(new ConctractorMaterial { name = name, createdDate = createdDay, validaty = validaty, producerID = producer });
                }
                context.SaveChanges();
            }

            if(context.contractorStock.Count() == 0)
            {
                for (int i = 0; i < 20000; i++)
                {
                    context.contractorStock.Add(new ContractorStock { contractorMaterialID = random.Next(1, 20000), count = random.Next(1000, 10000), price = random.Next(300, 1000000) });
                }
                context.SaveChanges();
            }

            if(context.contractorTechniques.Count() == 0)
            {
                string[] names = { "Трактор", "Бульдозер", "Эскаватор", "Самосвал", "Уплотнитель", "Грейдер", "Подъемный кран" };
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                for (int i = 0; i < 20000; i++)
                {
                    var name = names[random.Next(0, names.Length - 1)];
                    var buyDate = start.AddDays(random.Next(range));
                    var validaty = start.AddDays(random.Next(range));
                    context.contractorTechniques.Add(new ContractorTechniques { name = name, buyDate = buyDate, validaty = validaty });
                }
                context.SaveChanges();
            }

            if (context.contractors.Count() == 0)
            {
                string[] names = { "Белстрой", "Гомельстрой", "Мирстрой", "GreatBuild", "SuccessBuilding", "Элитстрой", "NewСтрой" };
                for (int i = 0; i < 20000; i++)
                {
                    context.contractors.Add(new Contractor { name = names[random.Next(0, names.Length - 1)] });
                }
                context.SaveChanges();
            }

            if (context.aboutContractor.Count() == 0)
            {
                string[] names = { "Белстрой", "Гомельстрой", "Мирстрой", "GreatBuild", "SuccessBuilding", "Элитстрой", "NewСтрой" };
                for (int i = 0; i < 20000; i++)
                {
                    context.aboutContractor.Add(new AboutContractor { contractorID = random.Next(1, 20000), contractorStockID = random.Next(1, 20000), contractorTechniquesID = random.Next(1, 20000) });
                }
                context.SaveChanges();
            }
        }
    }
}
