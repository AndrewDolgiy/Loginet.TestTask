using TestTask.Loginet.Data.Entities;

namespace Loginet.TestTask.Api.Dto
{
    public class CompanyDto
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }

        public Company MapToDb()
        {
            return new Company()
            {
                Name = Name,
                CatchPhrase = CatchPhrase,
                Bs = Bs 
            };
        }
    }
}