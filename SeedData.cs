using Bogus;
using Microsoft.EntityFrameworkCore;
using WebAPI_BogusPackage.Model;

namespace WebAPI_BogusPackage
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var faker = new Faker<Student>()
                .RuleFor(s => s.Name, f => f.Name.FirstName())
                .RuleFor(s => s.MiddleName, f => f.Name.LastName())
                .RuleFor(s => s.LastName, f => f.Name.LastName())
                .RuleFor(s => s.Class, f => f.Random.Word())
                .RuleFor(s => s.Division, f => f.Random.AlphaNumeric(1))
                .RuleFor(s => s.Year, f => f.Date.Past(20).Year)
                .RuleFor(s => s.MobileNumber, f => f.Phone.PhoneNumber())
                .RuleFor(s => s.StudentId, f => f.Random.AlphaNumeric(10));

            var students = faker.Generate(50);

            context.Students.AddRange(students);
            context.SaveChanges();
        }
    }
}
