using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using FullStack.Data;

namespace FullStack.Data.Migrations
{
    [ContextType(typeof(FullStackContext))]
    partial class FullStackContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                var builder = new BasicModelBuilder()
                    .Annotation("SqlServer:ValueGeneration", "Sequence");
                
                builder.Entity("FullStack.Data.Role", b =>
                    {
                        b.Property<int>("RoleId")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 0)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("RoleName")
                            .Annotation("OriginalValueIndex", 1);
                        b.Key("RoleId");
                    });
                
                builder.Entity("FullStack.Data.User", b =>
                    {
                        b.Property<DateTime>("DateOfBirth")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("Email")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("FirstName")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<string>("LastName")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<decimal>("Salary")
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<int>("UserId")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 5)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("UserName")
                            .Annotation("OriginalValueIndex", 6);
                        b.Key("UserId");
                    });
                
                builder.Entity("FullStack.Data.UserRole", b =>
                    {
                        b.Property<int>("RoleId")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<int>("UserId")
                            .Annotation("OriginalValueIndex", 1);
                        b.Key("UserId", "RoleId");
                    });
                
                builder.Entity("FullStack.Data.UserRole", b =>
                    {
                        b.ForeignKey("FullStack.Data.Role", "RoleId");
                        b.ForeignKey("FullStack.Data.User", "UserId");
                    });
                
                return builder.Model;
            }
        }
    }
}
