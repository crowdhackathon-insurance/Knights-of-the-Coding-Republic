namespace Ilida.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccidentActions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        PreviousWorkflowStatusId = c.Long(nullable: false),
                        NextWorkflowStatusId = c.Long(nullable: false),
                        Comment = c.String(),
                        AccidentId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        WorkflowActionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accidents", t => t.AccidentId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.WorkflowActions", t => t.WorkflowActionId)
                .Index(t => t.AccidentId)
                .Index(t => t.UserId)
                .Index(t => t.WorkflowActionId);
            
            CreateTable(
                "dbo.Accidents",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OccuredOn = c.DateTime(nullable: false),
                        HasInjuries = c.Boolean(nullable: false),
                        HasOtherVehicleDamages = c.Boolean(nullable: false),
                        HasOtherItemsDamages = c.Boolean(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        UserId = c.Long(nullable: false),
                        DiagramUrl = c.String(),
                        WorkflowStatusId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.WorkflowStatus", t => t.WorkflowStatusId)
                .Index(t => t.UserId)
                .Index(t => t.WorkflowStatusId);
            
            CreateTable(
                "dbo.AccidentCars",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CarPlate = c.String(nullable: false, maxLength: 10),
                        DamageText = c.String(),
                        Remarks = c.String(),
                        AccidentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accidents", t => t.AccidentId)
                .Index(t => t.AccidentId);
            
            CreateTable(
                "dbo.CarAccidentConditions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AccidentId = c.Long(nullable: false),
                        AccidentCarId = c.Long(nullable: false),
                        AccidentConditionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accidents", t => t.AccidentId)
                .ForeignKey("dbo.AccidentCars", t => t.AccidentCarId)
                .ForeignKey("dbo.AccidentConditions", t => t.AccidentConditionId)
                .Index(t => t.AccidentId)
                .Index(t => t.AccidentCarId)
                .Index(t => t.AccidentConditionId);
            
            CreateTable(
                "dbo.AccidentConditions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccidentCompanies",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AccidentId = c.Long(nullable: false),
                        CompanyId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accidents", t => t.AccidentId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.AccidentId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccidentParticipants",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IdCard = c.String(nullable: false, maxLength: 10),
                        IsDriver = c.Boolean(nullable: false),
                        HasInjuries = c.Boolean(nullable: false),
                        SignUrl = c.String(),
                        AccidentId = c.Long(nullable: false),
                        AccidentCar_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accidents", t => t.AccidentId)
                .ForeignKey("dbo.AccidentCars", t => t.AccidentCar_Id)
                .Index(t => t.AccidentId)
                .Index(t => t.AccidentCar_Id);
            
            CreateTable(
                "dbo.AccidentPhotoes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Url = c.String(nullable: false),
                        AccidentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accidents", t => t.AccidentId)
                .Index(t => t.AccidentId);
            
            CreateTable(
                "dbo.AccidentWitnesses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IdCard = c.String(nullable: false, maxLength: 10),
                        AccidentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accidents", t => t.AccidentId)
                .Index(t => t.AccidentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        FullName = c.String(nullable: false, maxLength: 255),
                        IdCard = c.String(nullable: false, maxLength: 10),
                        Company_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkflowStatus",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkflowActions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccidentActions", "WorkflowActionId", "dbo.WorkflowActions");
            DropForeignKey("dbo.AccidentActions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Accidents", "WorkflowStatusId", "dbo.WorkflowStatus");
            DropForeignKey("dbo.Accidents", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.AccidentWitnesses", "AccidentId", "dbo.Accidents");
            DropForeignKey("dbo.AccidentPhotoes", "AccidentId", "dbo.Accidents");
            DropForeignKey("dbo.AccidentParticipants", "AccidentCar_Id", "dbo.AccidentCars");
            DropForeignKey("dbo.AccidentParticipants", "AccidentId", "dbo.Accidents");
            DropForeignKey("dbo.AccidentCompanies", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.AccidentCompanies", "AccidentId", "dbo.Accidents");
            DropForeignKey("dbo.CarAccidentConditions", "AccidentConditionId", "dbo.AccidentConditions");
            DropForeignKey("dbo.CarAccidentConditions", "AccidentCarId", "dbo.AccidentCars");
            DropForeignKey("dbo.CarAccidentConditions", "AccidentId", "dbo.Accidents");
            DropForeignKey("dbo.AccidentCars", "AccidentId", "dbo.Accidents");
            DropForeignKey("dbo.AccidentActions", "AccidentId", "dbo.Accidents");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Company_Id" });
            DropIndex("dbo.AccidentWitnesses", new[] { "AccidentId" });
            DropIndex("dbo.AccidentPhotoes", new[] { "AccidentId" });
            DropIndex("dbo.AccidentParticipants", new[] { "AccidentCar_Id" });
            DropIndex("dbo.AccidentParticipants", new[] { "AccidentId" });
            DropIndex("dbo.AccidentCompanies", new[] { "CompanyId" });
            DropIndex("dbo.AccidentCompanies", new[] { "AccidentId" });
            DropIndex("dbo.CarAccidentConditions", new[] { "AccidentConditionId" });
            DropIndex("dbo.CarAccidentConditions", new[] { "AccidentCarId" });
            DropIndex("dbo.CarAccidentConditions", new[] { "AccidentId" });
            DropIndex("dbo.AccidentCars", new[] { "AccidentId" });
            DropIndex("dbo.Accidents", new[] { "WorkflowStatusId" });
            DropIndex("dbo.Accidents", new[] { "UserId" });
            DropIndex("dbo.AccidentActions", new[] { "WorkflowActionId" });
            DropIndex("dbo.AccidentActions", new[] { "UserId" });
            DropIndex("dbo.AccidentActions", new[] { "AccidentId" });
            DropTable("dbo.WorkflowActions");
            DropTable("dbo.WorkflowStatus");
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.AccidentWitnesses");
            DropTable("dbo.AccidentPhotoes");
            DropTable("dbo.AccidentParticipants");
            DropTable("dbo.Companies");
            DropTable("dbo.AccidentCompanies");
            DropTable("dbo.AccidentConditions");
            DropTable("dbo.CarAccidentConditions");
            DropTable("dbo.AccidentCars");
            DropTable("dbo.Accidents");
            DropTable("dbo.AccidentActions");
        }
    }
}
