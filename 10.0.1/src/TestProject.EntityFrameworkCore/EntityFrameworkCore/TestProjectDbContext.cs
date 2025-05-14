using Abp.Zero.EntityFrameworkCore;
using TestProject.Authorization.Roles;
using TestProject.Authorization.Users;
using TestProject.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace TestProject.EntityFrameworkCore;

public class TestProjectDbContext : AbpZeroDbContext<Tenant, Role, User, TestProjectDbContext>
{
    /* Define a DbSet for each entity of the application */

    // migration ok 
    //public DbSet<OrganizationWithExtension> OrganizationExtension { get; set; }

    // ParentId1 ParentId2  , migration failed , ParentId1 connot be added to type OrganizationUnit
    //only ParentId2 , migration ok
    public DbSet<OrganizationWithExtension> OrganizationWithExtension { get; set; }

    public TestProjectDbContext(DbContextOptions<TestProjectDbContext> options)
        : base(options)
    {
    }
}
