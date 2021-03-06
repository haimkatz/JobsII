using System.Data.Entity.ModelConfiguration.Conventions;

namespace JobsII.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class JobsModel : DbContext
    {
        // Your context has been configured to use a 'JobsModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'JobsII.Models.JobsModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'JobsModel' 
        // connection string in the application configuration file.
        public JobsModel()
            : base("name=JobsModel")
        {
            // comment out for production
            //Database.SetInitializer<JobsModel>(new mySeed());
            

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobRequirement> JobRequirements { get; set; }
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Reviewer> Reviewers { get; set; }
        public virtual DbSet<Requirement> Requirements { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Institute> Institutes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<AppRequirement> AppRequirements { get; set; }
        public virtual DbSet<ReviewerStatus> ReviewerStatuses{get;set;}
        public virtual DbSet<jobCommitteeMember> jobCommitteeMembers {get;set;}    
        public virtual DbSet<UniversalDoc> UniversalDocs { get; set; }
        public virtual DbSet<jobDoc> JobDocs { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
      
        public virtual DbSet<MergeDoc> MergeDocs { get; set; }
        public virtual DbSet<MergeDocType> MergeDocTypes { get; set; }
        public virtual DbSet<SexField> SexFields { get; set; }
  public virtual DbSet<MissingAppDocs> MissingAppDocs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
 {
     modelBuilder.Entity<JobRequirement>()
         .HasRequired(jr => jr.requirement)
         .WithMany()
         .WillCascadeOnDelete(false);
     modelBuilder.Entity<AppRequirement>()
         .HasRequired(ar => ar.jobrequirement)
         .WithMany()
         .WillCascadeOnDelete(false);
     modelBuilder.Entity<Reviewer>()
         .HasRequired(r => r.reviewerstatus)
         .WithMany()
         .WillCascadeOnDelete(false);
           
     modelBuilder.Entity<Applicant>()
         .HasRequired(a => a.person)
         .WithMany()
         .WillCascadeOnDelete(false);
     
     modelBuilder.Entity<jobCommitteeMember>()
         .HasRequired(jc => jc.person)
         .WithMany()
         .WillCascadeOnDelete(false);
     //modelBuilder.Entity<jobCommitteeMember>()
     //    .HasRequired(jc => jc.job)
     //    .WithMany()
         //.WillCascadeOnDelete(false);
        //    modelBuilder.Entity<jobDoc>()
        //.HasRequired(jc => jc.job)
        //.WithMany()
        //.WillCascadeOnDelete(false);
            modelBuilder.Entity<Department>()
        .HasRequired(jc => jc.institute)
        .WithMany()
        .WillCascadeOnDelete(false);
        
      
        }
    }
   

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

}