using BackEnd.Entities;
using BackEnd.NewFolder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackEnd
{
    public class ApplicationDBContext  :IdentityDbContext<User>
    {
        public ApplicationDBContext()
        {
        }
       
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        public DbSet<Individual> Individual { get; set; }
        public DbSet<FamilyRegestrationCard> familyRegestrationCards { get;set; }
        public DbSet<InitialClassTest> initialClassTests { get; set; }
        public DbSet<Relationship> relationships { get; set; }
        public DbSet<ResidentialAddress> residentialAddresses { get; set; }
        public DbSet<Area> areas { get; set; }
        public DbSet<OriginalPlace> originalPlaces { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Work> works { get; set; }
        public DbSet<Team> teams { get; set; }
        public DbSet<Nationality> nationalities { get; set; }
        public DbSet<HealthCenter> healthCenters { get; set; }
        public DbSet<Complaint> complaints { get; set; }
        public DbSet<IllnessType> illnessTypes { get; set; }
        public DbSet<Illness> illnesses { get; set; }
        public DbSet<Preview> previews { get; set; }
        public DbSet<PreviewComplaint> previewComplaints { get; set; }
        public DbSet<PreviewIllness> previewIllnesses { get; set; }
        public DbSet<MedicineType> medicineTypes { get; set; }
        public DbSet<Medicine> medicines { get; set; }
        public DbSet<TreatmentPlan> treatmentPlans { get; set; }
        public DbSet<Measurement> measurements { get; set; }
        public DbSet<IndividualMeasurementResult> individualMeasurementResults { get; set; }
        public DbSet<ChildCard> childCards { get; set; }
        public DbSet<ChildCardMeasurementResult> childCardMeasurementResults { get; set; }
        public DbSet<NCDCard> ncdCards { get; set; }
        public DbSet<FollwUpVisit> follwUpVisits { get; set; }
        public DbSet<LateComplication> lateComplications { get; set; }
        public DbSet<NCDDiagnosis> ncdDiagnoses { get; set; }
        public DbSet<FollwUpNCDDiagnosis> follwUpNCDDiagnoses { get; set; }
        public DbSet<NCDMedicine> ncdMedicines { get; set; }
        public DbSet<LabTestType> labTestTypes { get; set; }
        public DbSet<LabTest> labTests { get; set; }
        public DbSet<LabTestResult> labTestResults { get; set; }
        public DbSet<Dose> doses { get; set; }
        public DbSet<Vaccine> vaccines { get; set; }
        public DbSet<ImmunizationProgramme> immunizationProgrammes { get; set; }
        public DbSet<ImmunizationDate> immunizationDates { get; set; }
        public DbSet<SideEffect> sideEffects { get; set; }
        public DbSet<ImmunizationDateSideEffect> immunizationDateSideEffects { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<RequiredLabTest> requiredLabTests { get; set; }
        public DbSet<TimeSlote> timeSlotes { get; set; }
        public DbSet<StudyLevel> studyLevels { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
            //SelfJoin RelatopnShip => to do in part three
            builder.Entity<Individual>()
                .HasMany<Individual>()
                .WithOne(n=> n.individual)
                .HasForeignKey(a => a.FatherId)
                .OnDelete(DeleteBehavior.NoAction);

            //One To many relationship
            builder.Entity<StudyLevel>()
                    .HasMany<Individual>()
                    .WithOne(n => n.studyLevel)
                    .HasForeignKey(t => t.StudyLevelId);

            builder.Entity<Service>()
            .HasMany<Reservation>()
            .WithOne(n => n.service)
            .HasForeignKey(t => t.ServiceId);

            builder.Entity<Employee>()
            .HasMany<Reservation>()
            .WithOne(n => n.employeeForService)
            .HasForeignKey(t => t.EmployeeForServiceId)
            .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Employee>()
            .HasMany<Reservation>()
            .WithOne(n => n.clerick)
            .HasForeignKey(t => t.ClerickId);


            builder.Entity<Individual>()
            .HasMany<Reservation>()
            .WithOne(n => n.individual)
            .HasForeignKey(t => t.IndevisualId)
            .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<LabTest>()
            .HasMany<RequiredLabTest>()
            .WithOne(n => n.labTest)
            .HasForeignKey(t => t.LabTestId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Reservation>()
           .HasMany<RequiredLabTest>()
           .WithOne(n => n.reservation)
           .HasForeignKey(t => t.ReservationId);

            builder.Entity<Vaccine>()
              .HasMany<ImmunizationProgramme>()
              .WithOne(n => n.vaccine)
              .HasForeignKey(t => t.VaccieId);

           builder.Entity<Dose>()
             .HasMany<ImmunizationProgramme>()
             .WithOne(n => n.dose)
             .HasForeignKey(t => t.DoseId);


            builder.Entity<ImmunizationProgramme>()
              .HasMany<ImmunizationDate>()
              .WithOne(n => n.immunizationProgramme)
              .HasForeignKey(t => t.ImmunizationProgrammeId);


            builder.Entity<ChildCard>()
              .HasMany<ImmunizationDate>()
              .WithOne(n => n.childCard)
              .HasForeignKey(t => t.ChildCardId);

            builder.Entity<ImmunizationDate>()
             .HasMany<ImmunizationDateSideEffect>()
             .WithOne(n => n.immunizationDate)
             .HasForeignKey(t => t.ImmunizationDateId);

            builder.Entity<SideEffect>()
           .HasMany<ImmunizationDateSideEffect>()
           .WithOne(n => n.sideEffect)
           .HasForeignKey(t => t.SideEffectId);

            builder.Entity<MedicineType>()
              .HasMany<Medicine>()
              .WithOne(n => n.medicineType)
              .HasForeignKey(t => t.MedicineTypeId);

            builder.Entity<LabTestType>()
             .HasMany<LabTest>()
             .WithOne(n => n.labTestType)
             .HasForeignKey(t => t.LabTestTypeId);

            builder.Entity<LabTest>()
            .HasMany<LabTestResult>()
            .WithOne(n => n.labTest)
            .HasForeignKey(t => t.LabTestId);

            builder.Entity<Individual>()
            .HasMany<LabTestResult>()
            .WithOne(n => n.individual)
            .HasForeignKey(t => t.IndividualId);

            builder.Entity<Medicine>()
             .HasMany<NCDMedicine>()
             .WithOne(n => n.medicine)
             .HasForeignKey(m => m.MedicineId)
             .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<NCDCard>()
             .HasMany<NCDMedicine>()
             .WithOne(n => n.ncdCard)
             .HasForeignKey(ncd => ncd.NCDCardId);

            builder.Entity<NCDDiagnosis>()
             .HasMany<FollwUpNCDDiagnosis>()
             .WithOne(n => n.ncdDiagnosis)
             .HasForeignKey(d => d.NCDDiagnosisId);

            builder.Entity<LateComplication>()
             .HasMany<NCDDiagnosis>()
             .WithOne(n => n.lateComplication)
             .HasForeignKey(l => l.LateComplicationId);

            builder.Entity<NCDCard>()
          .HasMany<NCDDiagnosis>()
          .WithOne(n => n.ncdCard)
          .HasForeignKey(ncd => ncd.NCDCardId);

            builder.Entity<NCDCard>()
             .HasMany<FollwUpVisit>()
             .WithOne(n => n.ncdCard)
             .HasForeignKey(ncd => ncd.NCDCardId);

            builder.Entity<ChildCard>()
             .HasMany<ChildCardMeasurementResult>()
             .WithOne(n => n.childCard)
             .HasForeignKey(c => c.ChiledCardId);


            builder.Entity<Measurement>()
             .HasMany<ChildCardMeasurementResult>()
             .WithOne(n => n.measurement)
             .HasForeignKey(m => m.MeasurementId)
             .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Measurement>()
             .HasMany<IndividualMeasurementResult>()
             .WithOne(n => n.measurement)
             .HasForeignKey(m => m.MeasurementId);

            builder.Entity<Individual>()
             .HasMany<IndividualMeasurementResult>()
             .WithOne(n => n.individual)
             .HasForeignKey(i => i.IndividualId);

            builder.Entity<Medicine>()
             .HasMany<TreatmentPlan>()
             .WithOne(n => n.medicine)
             .HasForeignKey(m => m.MedicineId);

            builder.Entity<Preview>()
           .HasMany<TreatmentPlan>()
           .WithOne(n => n.preview)
           .HasForeignKey(p => p.PreviewId);

            builder.Entity<IllnessType>()
               .HasMany<Illness>()
               .WithOne(n => n.illnessType)
               .HasForeignKey(i => i.IllnessTypeId);

            builder.Entity<Preview>()
             .HasMany<PreviewIllness>()
             .WithOne(n => n.preview)
             .HasForeignKey(p => p.PreviewId);

            builder.Entity<Illness>()
          .HasMany<PreviewIllness>()
          .WithOne(n => n.illness)
          .HasForeignKey(i => i.IllnessId);

            builder.Entity<Area>()
                .HasMany<ResidentialAddress>()
                .WithOne(n=>n.area)
                .HasForeignKey(a => a.AreaId);

            builder.Entity<Area>()
                .HasMany<HealthCenter>()
                .WithOne(n => n.area)
                .HasForeignKey(a => a.AreaId ); 

            builder.Entity<Relationship>()
              .HasMany<Individual>()
              .WithOne(n=> n.relatioship)
              .HasForeignKey(r => r.RelationShipId);

            builder.Entity<Nationality>()
              .HasMany<Individual>()
              .WithOne(n => n.nationality)
              .HasForeignKey(r => r.NationalityId);

            builder.Entity<FamilyRegestrationCard>()
              .HasMany<Individual>()
              .WithOne(n=> n.familyRegestrationCard)
              .HasForeignKey(c => c.FamilyRegestrationCardId);

            builder.Entity<Individual>()
              .HasMany<Preview>()
              .WithOne(n => n.individual)
              .HasForeignKey(i => i.IndividialId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Employee>()
            .HasMany<Preview>()
            .WithOne(n => n.doctore)
            .HasForeignKey(d => d.DoctorId); 

            builder.Entity<IllnessType>()
            .HasMany<Illness>()
            .WithOne(n => n.illnessType)
            .HasForeignKey(i => i.IllnessTypeId);


            builder.Entity<Work>()
             .HasMany<Employee>()
             .WithOne(n=> n.work)
             .HasForeignKey(w => w.WorkId);

            builder.Entity<Team>()
             .HasMany<Employee>()
             .WithOne(n => n.team)
             .HasForeignKey(t => t.TeamId);

            builder.Entity<HealthCenter>()
             .HasMany<Employee>()
             .WithOne(n => n.healthCenter)
             .HasForeignKey(t => t.HealthCenterId)
             .OnDelete(DeleteBehavior.NoAction); 

            builder.Entity<OriginalPlace>()
             .HasMany<Individual>()
             .WithOne(n=> n.originalPlace)
             .HasForeignKey(o => o.OriginalPlaceId);

            builder.Entity<Complaint>()
              .HasMany<PreviewComplaint>()
              .WithOne(n => n.complaint)
              .HasForeignKey(c => c.ComplaintId);

            builder.Entity<Preview>()
             .HasMany<PreviewComplaint>()
             .WithOne(n => n.preview)
             .HasForeignKey(p => p.PreviewId);

            //One To One RelationShip
            builder.Entity<Employee>()
             .HasOne<User>()
             .WithOne(n => n.employee)
             .HasForeignKey<User>(i => i.EmployeeId);

            builder.Entity<Individual>()
             .HasOne<Employee>()
             .WithOne(n => n.individual)
             .HasForeignKey<Employee>(i => i.IndividualId);

            builder.Entity<Individual>()
            .HasOne<ChildCard>()
            .WithOne(n => n.individual)
            .HasForeignKey<ChildCard>(i => i.IndivisualId);

            builder.Entity<Individual>()
           .HasOne<NCDCard>()
           .WithOne(n => n.individual)
           .HasForeignKey<NCDCard>(i => i.IndividualId);

          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {
            base.OnConfiguring(modelBuilder);
            modelBuilder.UseSqlServer(@"Data Source=DESKTOP-79PJ7V9\SQLEXPRESS;Initial Catalog=UNWRWAProgrammeDB;Integrated Security=True;MultipleActiveResultSets=true");
        }
    }
}