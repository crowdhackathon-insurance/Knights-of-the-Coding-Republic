using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ilida.Api.Models
{
    public class IlidaApiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public IlidaApiContext() : base("name=IlidaApiContext")
        {
        }

        public System.Data.Entity.DbSet<Ilida.Api.Models.Role> Roles { get; set; }

        public System.Data.Entity.DbSet<Ilida.Api.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<Ilida.Api.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<Ilida.Api.Models.WorkflowStatus> WorkflowStatuses { get; set; }

        public System.Data.Entity.DbSet<Ilida.Api.Models.WorkflowAction> WorkflowActions { get; set; }

        public System.Data.Entity.DbSet<Ilida.Api.Models.AccidentWitness> AccidentWitnesses { get; set; }

        public System.Data.Entity.DbSet<Ilida.Api.Models.AccidentPhoto> AccidentPhotos { get; set; }

        public System.Data.Entity.DbSet<Ilida.Api.Models.AccidentCondition> AccidentConditions { get; set; }

        public System.Data.Entity.DbSet<Ilida.Api.Models.AccidentCar> AccidentCars { get; set; }

        public System.Data.Entity.DbSet<Ilida.Api.Models.AccidentParticipant> AccidentParticipants { get; set; }

        public System.Data.Entity.DbSet<Ilida.Api.Models.AccidentAction> AccidentActions { get; set; }

        public System.Data.Entity.DbSet<Ilida.Api.Models.Accident> Accidents { get; set; }

        public System.Data.Entity.DbSet<Ilida.Api.Models.AccidentCompany> AccidentCompanies { get; set; }

        public System.Data.Entity.DbSet<Ilida.Api.Models.UserRole> UserRoles { get; set; }

        public System.Data.Entity.DbSet<Ilida.Api.Models.CarAccidentCondition> CarAccidentConditions { get; set; }

    }
}
