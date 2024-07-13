using Bogus;
using WebAPI_BogusPackage.Model;

namespace WebAPI_BogusPackage
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;

        public DataSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Students.Any())
            {
                return; // Data already seeded
            }

            var faker = new Faker<Student>()
                .RuleFor(s => s.Name, f => f.Name.FirstName())
                .RuleFor(s => s.MiddleName, f => f.Name.FirstName())
                .RuleFor(s => s.LastName, f => f.Name.LastName())
                .RuleFor(s => s.Class, f => f.Random.Word())
                .RuleFor(s => s.Division, f => f.Random.Word())
                .RuleFor(s => s.Year, f => f.Date.Past(5).Year)
                .RuleFor(s => s.MobileNumber, f => f.Phone.PhoneNumber())
                .RuleFor(s => s.StudentId, f => f.Random.AlphaNumeric(10));

            var students = faker.Generate(100);

            _context.Students.AddRange(students);
            _context.SaveChanges();
        }
    }
}
