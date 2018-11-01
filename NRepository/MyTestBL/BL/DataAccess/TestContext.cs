using Microsoft.EntityFrameworkCore;
using NRepository.MyTestBL.Models;

namespace NRepository.MyTestBL.BL.DataAccess
{
    public class TestContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
    }
}
