namespace FinanceTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Centers",
                c => new
                    {
                        CenterId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.CenterId)
                .Index(t => t.Name, unique: true, name: "IX_CenterName");
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ClaimId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ReferenceNum = c.Int(nullable: true),
                        RequestType = c.String(),
                        WorkLocation = c.String(),
                        StatusDate = c.DateTime(nullable: true),
                        ClaimDate = c.DateTime(nullable: true),
                        ClaimantLiable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClaimId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CenterId = c.Int(nullable: false),
                        SSN = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Centers", t => t.CenterId, cascadeDelete: true)
                .Index(t => t.CenterId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        ClaimId = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: true),
                        AmountPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quarter = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Claims", t => t.ClaimId, cascadeDelete: true)
                .Index(t => t.ClaimId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "ClaimId", "dbo.Claims");
            DropForeignKey("dbo.Claims", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "CenterId", "dbo.Centers");
            DropIndex("dbo.Payments", new[] { "ClaimId" });
            DropIndex("dbo.Employees", new[] { "CenterId" });
            DropIndex("dbo.Claims", new[] { "EmployeeId" });
            DropIndex("dbo.Centers", "IX_CenterName");
            DropTable("dbo.Payments");
            DropTable("dbo.Employees");
            DropTable("dbo.Claims");
            DropTable("dbo.Centers");
        }
    }
}
