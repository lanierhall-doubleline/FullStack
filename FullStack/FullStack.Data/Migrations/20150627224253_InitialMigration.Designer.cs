using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using FullStack.Data;

namespace FullStack.Data.Migrations
{
    [ContextType(typeof(FullStackContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20150627224253_InitialMigration"; }
        }
        
        public override string ProductVersion
        {
            get { return "7.0.0-beta4-12943"; }
        }
        
        public override IModel Target
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
                        b.Property<int>("UserId")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 0)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("UserName")
                            .Annotation("OriginalValueIndex", 1);
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
