using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SHGAPI.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AntenatalCare> AntenatalCares { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<BikramSambatRefTbl> BikramSambatRefTbls { get; set; }

    public virtual DbSet<Calendar> Calendars { get; set; }

    public virtual DbSet<Calendar1> Calendars1 { get; set; }

    public virtual DbSet<CallRequest> CallRequests { get; set; }

    public virtual DbSet<ChildImmunization> ChildImmunizations { get; set; }

    public virtual DbSet<Complient> Complients { get; set; }

    public virtual DbSet<ConfirmDiagnosis> ConfirmDiagnoses { get; set; }

    public virtual DbSet<Daysinmonth> Daysinmonths { get; set; }

    public virtual DbSet<Daysinmonth1> Daysinmonths1 { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<DeliveryChild> DeliveryChildren { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Encounter> Encounters { get; set; }

    public virtual DbSet<Growth> Growths { get; set; }

    public virtual DbSet<HealthFacility> HealthFacilities { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<HomeBabyPostnatalCare> HomeBabyPostnatalCares { get; set; }

    public virtual DbSet<HomeMotherPostnatalCare> HomeMotherPostnatalCares { get; set; }

    public virtual DbSet<ImmunizationHistory> ImmunizationHistories { get; set; }

    public virtual DbSet<LabTest> LabTests { get; set; }

    public virtual DbSet<Medication> Medications { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<PasswordReset> PasswordResets { get; set; }

    public virtual DbSet<PatientData> Patients { get; set; }

    public virtual DbSet<PhysicalExamination> PhysicalExaminations { get; set; }

    public virtual DbSet<PostnatalCare> PostnatalCares { get; set; }

    public virtual DbSet<Pregnancy> Pregnancies { get; set; }

    public virtual DbSet<PregnancyMv> PregnancyMvs { get; set; }

    public virtual DbSet<PrismaMigration> PrismaMigrations { get; set; }

    public virtual DbSet<ProvisionalDiagnosis> ProvisionalDiagnoses { get; set; }

    public virtual DbSet<RadiologyTest> RadiologyTests { get; set; }

    public virtual DbSet<RefreshLog> RefreshLogs { get; set; }

    public virtual DbSet<Roster> Rosters { get; set; }

    public virtual DbSet<ServiceEngagementConsolMv> ServiceEngagementConsolMvs { get; set; }

    public virtual DbSet<ServiceEngagementMv> ServiceEngagementMvs { get; set; }

    public virtual DbSet<SmsLog> SmsLogs { get; set; }

    public virtual DbSet<Treatment> Treatments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<Vital> Vitals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=shg1;Username=postgres;Password=sudip100");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AntenatalCare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AntenatalCare_pkey");

            entity.ToTable("AntenatalCare");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Albendazole).HasColumnName("albendazole");
            entity.Property(e => e.AncVisitDate)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("ancVisitDate");
            entity.Property(e => e.Anemia).HasColumnName("anemia");
            entity.Property(e => e.BabyPresentation).HasColumnName("babyPresentation");
            entity.Property(e => e.Calcium).HasColumnName("calcium");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DangerSign).HasColumnName("dangerSign");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.Diastolic).HasColumnName("diastolic");
            entity.Property(e => e.DoctorFeedback).HasColumnName("doctorFeedback");
            entity.Property(e => e.Document).HasColumnName("document");
            entity.Property(e => e.Edema).HasColumnName("edema");
            entity.Property(e => e.FolicAcid).HasColumnName("folicAcid");
            entity.Property(e => e.FundalHeight).HasColumnName("fundalHeight");
            entity.Property(e => e.HeartRate).HasColumnName("heartRate");
            entity.Property(e => e.Investigation).HasColumnName("investigation");
            entity.Property(e => e.IronTablet).HasColumnName("ironTablet");
            entity.Property(e => e.MedicalAdvice).HasColumnName("medicalAdvice");
            entity.Property(e => e.MotherWeight).HasColumnName("motherWeight");
            entity.Property(e => e.NextVisitSchedule)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("nextVisitSchedule");
            entity.Property(e => e.ObstrcutiveComplications).HasColumnName("obstrcutiveComplications");
            entity.Property(e => e.OtherProblems).HasColumnName("otherProblems");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.PregnancyId).HasColumnName("pregnancyId");
            entity.Property(e => e.PregnancyPeriodWeek).HasColumnName("pregnancyPeriodWeek");
            entity.Property(e => e.Refer).HasColumnName("refer");
            entity.Property(e => e.ReferReason).HasColumnName("referReason");
            entity.Property(e => e.ServiceProvidedBy).HasColumnName("serviceProvidedBy");
            entity.Property(e => e.Systolic).HasColumnName("systolic");
            entity.Property(e => e.TdVaccination).HasColumnName("tdVaccination");
            entity.Property(e => e.Treatment).HasColumnName("treatment");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.VisitingTimeMonth).HasColumnName("visitingTimeMonth");
            entity.Property(e => e.VisitingTimeWeek).HasColumnName("visitingTimeWeek");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AntenatalCareCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("AntenatalCare_createdBy_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.AntenatalCares)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("AntenatalCare_patientId_fkey");

            entity.HasOne(d => d.Pregnancy).WithMany(p => p.AntenatalCares)
                .HasForeignKey(d => d.PregnancyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("AntenatalCare_pregnancyId_fkey");

            entity.HasOne(d => d.ServiceProvidedByNavigation).WithMany(p => p.AntenatalCareServiceProvidedByNavigations)
                .HasForeignKey(d => d.ServiceProvidedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("AntenatalCare_serviceProvidedBy_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.AntenatalCareUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("AntenatalCare_updatedBy_fkey");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Appointment_pkey");

            entity.ToTable("Appointment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CallDuration)
                .HasDefaultValue(0)
                .HasColumnName("callDuration");
            entity.Property(e => e.ChildImmunizationId).HasColumnName("childImmunizationId");
            entity.Property(e => e.Consent)
                .HasDefaultValue(1)
                .HasColumnName("consent");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("date");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.DoctorId).HasColumnName("doctorId");
            entity.Property(e => e.EncounterId).HasColumnName("encounterId");
            entity.Property(e => e.FacilityId).HasColumnName("facilityId");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.PregnancyId).HasColumnName("pregnancyId");
            entity.Property(e => e.Service).HasColumnName("service");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

            entity.HasOne(d => d.ChildImmunization).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ChildImmunizationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Appointment_childImmunizationId_fkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AppointmentCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Appointment_createdBy_fkey");

            entity.HasOne(d => d.Doctor).WithMany(p => p.AppointmentDoctors)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Appointment_doctorId_fkey");

            entity.HasOne(d => d.Encounter).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.EncounterId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Appointment_encounterId_fkey");

            entity.HasOne(d => d.Facility).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.FacilityId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Appointment_facilityId_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Appointment_patientId_fkey");

            entity.HasOne(d => d.Pregnancy).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PregnancyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Appointment_pregnancyId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.AppointmentUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Appointment_updatedBy_fkey");
        });

        modelBuilder.Entity<BikramSambatRefTbl>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("bikram_sambat_ref_tbl", "analytics");

            entity.Property(e => e.EndDateAd).HasColumnName("end_date_ad");
            entity.Property(e => e.EndDateBs).HasColumnName("end_date_bs");
            entity.Property(e => e.FyEndYrBs).HasColumnName("fy_end_yr_bs");
            entity.Property(e => e.FyStartYrBs).HasColumnName("fy_start_yr_bs");
            entity.Property(e => e.Intervaltype).HasColumnName("intervaltype");
            entity.Property(e => e.StartDateAd).HasColumnName("start_date_ad");
            entity.Property(e => e.StartDateBs).HasColumnName("start_date_bs");
            entity.Property(e => e.TimePeroid).HasColumnName("time_peroid");
        });

        modelBuilder.Entity<Calendar>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("calendar", "analytics");

            entity.HasIndex(e => e.Gregorian, "gregorian_date_uidx").IsUnique();

            entity.Property(e => e.BikramSambat).HasColumnName("bikram_sambat");
            entity.Property(e => e.BikramSambatNe).HasColumnName("bikram_sambat_ne");
            entity.Property(e => e.DayNe).HasColumnName("day_ne");
            entity.Property(e => e.Gregorian).HasColumnName("gregorian");
            entity.Property(e => e.MonthNe).HasColumnName("month_ne");
            entity.Property(e => e.MonthNeText).HasColumnName("month_ne_text");
            entity.Property(e => e.StartEndFlgNe).HasColumnName("start_end_flg_ne");
            entity.Property(e => e.YrNe).HasColumnName("yr_ne");
        });

        modelBuilder.Entity<Calendar1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("calendar");

            entity.HasIndex(e => e.Gregorian, "gregorian_date_uidx").IsUnique();

            entity.Property(e => e.BikramSambat).HasColumnName("bikram_sambat");
            entity.Property(e => e.BikramSambatNe).HasColumnName("bikram_sambat_ne");
            entity.Property(e => e.Gregorian).HasColumnName("gregorian");
        });

        modelBuilder.Entity<CallRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("CallRequest_pkey");

            entity.ToTable("CallRequest");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.FromUserId).HasColumnName("fromUserId");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.ToUserId).HasColumnName("toUserId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.FromUser).WithMany(p => p.CallRequestFromUsers)
                .HasForeignKey(d => d.FromUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("CallRequest_fromUserId_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.CallRequests)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("CallRequest_patientId_fkey");

            entity.HasOne(d => d.ToUser).WithMany(p => p.CallRequestToUsers)
                .HasForeignKey(d => d.ToUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("CallRequest_toUserId_fkey");
        });

        modelBuilder.Entity<ChildImmunization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ChildImmunization_pkey");

            entity.ToTable("ChildImmunization");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.FacilityId).HasColumnName("facilityId");
            entity.Property(e => e.FathersName).HasColumnName("fathersName");
            entity.Property(e => e.MothersName).HasColumnName("mothersName");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.WeightAtBirth).HasColumnName("weightAtBirth");

            entity.HasOne(d => d.Facility).WithMany(p => p.ChildImmunizations)
                .HasForeignKey(d => d.FacilityId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ChildImmunization_facilityId_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.ChildImmunizations)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ChildImmunization_patientId_fkey");
        });

        modelBuilder.Entity<Complient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Complient_pkey");

            entity.ToTable("Complient");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.EncounterId).HasColumnName("encounterId");
            entity.Property(e => e.Interval).HasColumnName("interval");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.Severity).HasColumnName("severity");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ComplientCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Complient_createdBy_fkey");

            entity.HasOne(d => d.Encounter).WithMany(p => p.Complients)
                .HasForeignKey(d => d.EncounterId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Complient_encounterId_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Complients)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Complient_patientId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ComplientUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Complient_updatedBy_fkey");
        });

        modelBuilder.Entity<ConfirmDiagnosis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ConfirmDiagnosis_pkey");

            entity.ToTable("ConfirmDiagnosis");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EncounterId).HasColumnName("encounterId");
            entity.Property(e => e.IcdCode).HasColumnName("icdCode");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ConfirmDiagnosisCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ConfirmDiagnosis_createdBy_fkey");

            entity.HasOne(d => d.Encounter).WithMany(p => p.ConfirmDiagnoses)
                .HasForeignKey(d => d.EncounterId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ConfirmDiagnosis_encounterId_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.ConfirmDiagnoses)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ConfirmDiagnosis_patientId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ConfirmDiagnosisUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ConfirmDiagnosis_updatedBy_fkey");
        });

        modelBuilder.Entity<Daysinmonth>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("daysinmonth");

            entity.Property(e => e.NeighthMonth).HasColumnName("neighth_month");
            entity.Property(e => e.NeleventhMonth).HasColumnName("neleventh_month");
            entity.Property(e => e.NfifthMonth).HasColumnName("nfifth_month");
            entity.Property(e => e.NfirstMonth).HasColumnName("nfirst_month");
            entity.Property(e => e.NfourthMonth).HasColumnName("nfourth_month");
            entity.Property(e => e.NninthMonth).HasColumnName("nninth_month");
            entity.Property(e => e.NsecondMonth).HasColumnName("nsecond_month");
            entity.Property(e => e.NseventhMonth).HasColumnName("nseventh_month");
            entity.Property(e => e.NsixthMonth).HasColumnName("nsixth_month");
            entity.Property(e => e.NtenthMonth).HasColumnName("ntenth_month");
            entity.Property(e => e.NthirdMonth).HasColumnName("nthird_month");
            entity.Property(e => e.NtwelfthMonth).HasColumnName("ntwelfth_month");
            entity.Property(e => e.Nyear).HasColumnName("nyear");
        });

        modelBuilder.Entity<Daysinmonth1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("daysinmonth", "analytics");

            entity.Property(e => e.NeighthMonth).HasColumnName("neighth_month");
            entity.Property(e => e.NeleventhMonth).HasColumnName("neleventh_month");
            entity.Property(e => e.NfifthMonth).HasColumnName("nfifth_month");
            entity.Property(e => e.NfirstMonth).HasColumnName("nfirst_month");
            entity.Property(e => e.NfourthMonth).HasColumnName("nfourth_month");
            entity.Property(e => e.NninthMonth).HasColumnName("nninth_month");
            entity.Property(e => e.NsecondMonth).HasColumnName("nsecond_month");
            entity.Property(e => e.NseventhMonth).HasColumnName("nseventh_month");
            entity.Property(e => e.NsixthMonth).HasColumnName("nsixth_month");
            entity.Property(e => e.NtenthMonth).HasColumnName("ntenth_month");
            entity.Property(e => e.NthirdMonth).HasColumnName("nthird_month");
            entity.Property(e => e.NtwelfthMonth).HasColumnName("ntwelfth_month");
            entity.Property(e => e.Nyear).HasColumnName("nyear");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Delivery_pkey");

            entity.ToTable("Delivery");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BabyPresentation).HasColumnName("babyPresentation");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.DeliveryAttendedBy).HasColumnName("deliveryAttendedBy");
            entity.Property(e => e.DeliveryDate)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deliveryDate");
            entity.Property(e => e.DoctorFeedback).HasColumnName("doctorFeedback");
            entity.Property(e => e.Investigation).HasColumnName("investigation");
            entity.Property(e => e.NoOfFreshStillBirth).HasColumnName("noOfFreshStillBirth");
            entity.Property(e => e.NoOfLiveFemaleBaby).HasColumnName("noOfLiveFemaleBaby");
            entity.Property(e => e.NoOfLiveMaleBaby).HasColumnName("noOfLiveMaleBaby");
            entity.Property(e => e.NoOfMaceratedStillBirth).HasColumnName("noOfMaceratedStillBirth");
            entity.Property(e => e.NoOfStillFemaleBaby).HasColumnName("noOfStillFemaleBaby");
            entity.Property(e => e.NoOfStillMaleBaby).HasColumnName("noOfStillMaleBaby");
            entity.Property(e => e.OtherPlaceOfDelivery).HasColumnName("otherPlaceOfDelivery");
            entity.Property(e => e.OtherProblems).HasColumnName("otherProblems");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.PlaceOfDelivery).HasColumnName("placeOfDelivery");
            entity.Property(e => e.PregnancyId).HasColumnName("pregnancyId");
            entity.Property(e => e.Refer).HasColumnName("refer");
            entity.Property(e => e.ReferReason).HasColumnName("referReason");
            entity.Property(e => e.Treatment).HasColumnName("treatment");
            entity.Property(e => e.TypeOfDelivery).HasColumnName("typeOfDelivery");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.VitaminK).HasColumnName("vitaminK");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.DeliveryCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Delivery_createdBy_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Delivery_patientId_fkey");

            entity.HasOne(d => d.Pregnancy).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.PregnancyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Delivery_pregnancyId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.DeliveryUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Delivery_updatedBy_fkey");
        });

        modelBuilder.Entity<DeliveryChild>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("DeliveryChildren_pkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.DeliveryId).HasColumnName("deliveryId");
            entity.Property(e => e.NewBornBabyStatus).HasColumnName("newBornBabyStatus");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.PregnancyId).HasColumnName("pregnancyId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.WeigntOfBaby).HasColumnName("weigntOfBaby");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.DeliveryChildCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("DeliveryChildren_createdBy_fkey");

            entity.HasOne(d => d.Delivery).WithMany(p => p.DeliveryChildren)
                .HasForeignKey(d => d.DeliveryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("DeliveryChildren_deliveryId_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.DeliveryChildren)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("DeliveryChildren_patientId_fkey");

            entity.HasOne(d => d.Pregnancy).WithMany(p => p.DeliveryChildren)
                .HasForeignKey(d => d.PregnancyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("DeliveryChildren_pregnancyId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.DeliveryChildUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("DeliveryChildren_updatedBy_fkey");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Document_pkey");

            entity.ToTable("Document");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.EncounterId).HasColumnName("encounterId");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Path).HasColumnName("path");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

            entity.HasOne(d => d.Encounter).WithMany(p => p.Documents)
                .HasForeignKey(d => d.EncounterId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Document_encounterId_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Documents)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Document_patientId_fkey");
        });

        modelBuilder.Entity<Encounter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Encounter_pkey");

            entity.ToTable("Encounter");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("date");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.DoctorId).HasColumnName("doctorId");
            entity.Property(e => e.FacilityId).HasColumnName("facilityId");
            entity.Property(e => e.FollowUpId).HasColumnName("followUpId");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.Service).HasColumnName("service");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Encounters)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Encounter_doctorId_fkey");

            entity.HasOne(d => d.Facility).WithMany(p => p.Encounters)
                .HasForeignKey(d => d.FacilityId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Encounter_facilityId_fkey");

            entity.HasOne(d => d.FollowUp).WithMany(p => p.InverseFollowUp)
                .HasForeignKey(d => d.FollowUpId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Encounter_followUpId_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Encounters)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Encounter_patientId_fkey");
        });

        modelBuilder.Entity<Growth>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Growth_pkey");

            entity.ToTable("Growth");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChildImmunizationId).HasColumnName("childImmunizationId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("date");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Muac).HasColumnName("muac");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.ChildImmunization).WithMany(p => p.Growths)
                .HasForeignKey(d => d.ChildImmunizationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Growth_childImmunizationId_fkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.GrowthCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Growth_createdBy_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Growths)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Growth_patientId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.GrowthUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Growth_updatedBy_fkey");
        });

        modelBuilder.Entity<HealthFacility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("HealthFacility_pkey");

            entity.ToTable("HealthFacility");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Authority).HasColumnName("authority");
            entity.Property(e => e.AuthorityLevel).HasColumnName("authorityLevel");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.District).HasColumnName("district");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FacilityType).HasColumnName("facilityType");
            entity.Property(e => e.HfCode).HasColumnName("hfCode");
            entity.Property(e => e.InchargeName).HasColumnName("inchargeName");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Ownership).HasColumnName("ownership");
            entity.Property(e => e.Palika).HasColumnName("palika");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Province).HasColumnName("province");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.Ward).HasColumnName("ward");
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("History_pkey");

            entity.ToTable("History");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.DrugHistory).HasColumnName("drugHistory");
            entity.Property(e => e.EncounterId).HasColumnName("encounterId");
            entity.Property(e => e.FamilyHistory).HasColumnName("familyHistory");
            entity.Property(e => e.GyeObs).HasColumnName("gyeObs");
            entity.Property(e => e.MedicalHistory).HasColumnName("medicalHistory");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.SocialHistory).HasColumnName("socialHistory");
            entity.Property(e => e.SurgicalHistory).HasColumnName("surgicalHistory");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.HistoryCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("History_createdBy_fkey");

            entity.HasOne(d => d.Encounter).WithMany(p => p.Histories)
                .HasForeignKey(d => d.EncounterId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("History_encounterId_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Histories)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("History_patientId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.HistoryUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("History_updatedBy_fkey");
        });

        modelBuilder.Entity<HomeBabyPostnatalCare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("HomeBabyPostnatalCare_pkey");

            entity.ToTable("HomeBabyPostnatalCare");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activities).HasColumnName("activities");
            entity.Property(e => e.BreastFeeding).HasColumnName("breastFeeding");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.Eye).HasColumnName("eye");
            entity.Property(e => e.HealthCareProvider).HasColumnName("healthCareProvider");
            entity.Property(e => e.Jundice).HasColumnName("jundice");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.PregnancyId).HasColumnName("pregnancyId");
            entity.Property(e => e.Respiration).HasColumnName("respiration");
            entity.Property(e => e.Skin).HasColumnName("skin");
            entity.Property(e => e.Stool).HasColumnName("stool");
            entity.Property(e => e.Temperature).HasColumnName("temperature");
            entity.Property(e => e.UmblicalArea).HasColumnName("umblicalArea");
            entity.Property(e => e.UmblicalCream).HasColumnName("umblicalCream");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.Urination).HasColumnName("urination");
            entity.Property(e => e.VisitDate)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("visitDate");
            entity.Property(e => e.VisitTime).HasColumnName("visitTime");
            entity.Property(e => e.VisitingTime).HasColumnName("visitingTime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.HomeBabyPostnatalCareCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("HomeBabyPostnatalCare_createdBy_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.HomeBabyPostnatalCares)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("HomeBabyPostnatalCare_patientId_fkey");

            entity.HasOne(d => d.Pregnancy).WithMany(p => p.HomeBabyPostnatalCares)
                .HasForeignKey(d => d.PregnancyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("HomeBabyPostnatalCare_pregnancyId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.HomeBabyPostnatalCareUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("HomeBabyPostnatalCare_updatedBy_fkey");
        });

        modelBuilder.Entity<HomeMotherPostnatalCare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("HomeMotherPostnatalCare_pkey");

            entity.ToTable("HomeMotherPostnatalCare");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BodyTemperature).HasColumnName("bodyTemperature");
            entity.Property(e => e.BpDiastolic).HasColumnName("bpDiastolic");
            entity.Property(e => e.BpSystolic).HasColumnName("bpSystolic");
            entity.Property(e => e.BreastExamination).HasColumnName("breastExamination");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.Edema).HasColumnName("edema");
            entity.Property(e => e.ExaminationOfUterus).HasColumnName("examinationOfUterus");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.PpHeamorage).HasColumnName("ppHeamorage");
            entity.Property(e => e.PpHeamorageTreatment).HasColumnName("ppHeamorageTreatment");
            entity.Property(e => e.PregnancyId).HasColumnName("pregnancyId");
            entity.Property(e => e.Pulse).HasColumnName("pulse");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.UrinationDifficulties).HasColumnName("urinationDifficulties");
            entity.Property(e => e.VaginalDischarge).HasColumnName("vaginalDischarge");
            entity.Property(e => e.VaginalExamination).HasColumnName("vaginalExamination");
            entity.Property(e => e.VisitDate)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("visitDate");
            entity.Property(e => e.VisitTime).HasColumnName("visitTime");
            entity.Property(e => e.VisitingTime).HasColumnName("visitingTime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.HomeMotherPostnatalCareCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("HomeMotherPostnatalCare_createdBy_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.HomeMotherPostnatalCares)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("HomeMotherPostnatalCare_patientId_fkey");

            entity.HasOne(d => d.Pregnancy).WithMany(p => p.HomeMotherPostnatalCares)
                .HasForeignKey(d => d.PregnancyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("HomeMotherPostnatalCare_pregnancyId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.HomeMotherPostnatalCareUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("HomeMotherPostnatalCare_updatedBy_fkey");
        });

        modelBuilder.Entity<ImmunizationHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ImmunizationHistory_pkey");

            entity.ToTable("ImmunizationHistory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aefi).HasColumnName("aefi");
            entity.Property(e => e.ChildImmunizationId).HasColumnName("childImmunizationId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("date");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.Vaccinated).HasColumnName("vaccinated");
            entity.Property(e => e.VaccinatedDate)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("vaccinatedDate");
            entity.Property(e => e.VaccineName).HasColumnName("vaccineName");

            entity.HasOne(d => d.ChildImmunization).WithMany(p => p.ImmunizationHistories)
                .HasForeignKey(d => d.ChildImmunizationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ImmunizationHistory_childImmunizationId_fkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ImmunizationHistoryCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ImmunizationHistory_createdBy_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.ImmunizationHistories)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ImmunizationHistory_patientId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ImmunizationHistoryUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ImmunizationHistory_updatedBy_fkey");
        });

        modelBuilder.Entity<LabTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("LabTest_pkey");

            entity.ToTable("LabTest");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.EncounterId).HasColumnName("encounterId");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.TestName).HasColumnName("testName");
            entity.Property(e => e.TestResult).HasColumnName("testResult");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.LabTestCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("LabTest_createdBy_fkey");

            entity.HasOne(d => d.Encounter).WithMany(p => p.LabTests)
                .HasForeignKey(d => d.EncounterId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("LabTest_encounterId_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.LabTests)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("LabTest_patientId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.LabTestUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("LabTest_updatedBy_fkey");
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Medication_pkey");

            entity.ToTable("Medication");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BeforeAfter).HasColumnName("beforeAfter");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.Dosage).HasColumnName("dosage");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.EncounterId).HasColumnName("encounterId");
            entity.Property(e => e.MedicineName).HasColumnName("medicineName");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.Route).HasColumnName("route");
            entity.Property(e => e.SpecialNotes).HasColumnName("specialNotes");
            entity.Property(e => e.Times).HasColumnName("times");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.MedicationCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Medication_createdBy_fkey");

            entity.HasOne(d => d.Encounter).WithMany(p => p.Medications)
                .HasForeignKey(d => d.EncounterId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Medication_encounterId_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Medications)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Medication_patientId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.MedicationUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Medication_updatedBy_fkey");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Notification_pkey");

            entity.ToTable("Notification");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Module).HasColumnName("module");
            entity.Property(e => e.ModuleId).HasColumnName("moduleId");
            entity.Property(e => e.Seen).HasColumnName("seen");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Notification_userId_fkey");
        });

        modelBuilder.Entity<PasswordReset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PasswordReset_pkey");

            entity.ToTable("PasswordReset");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.Expires)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("expires");
            entity.Property(e => e.Token).HasColumnName("token");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.PasswordResets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("PasswordReset_userId_fkey");
        });

        modelBuilder.Entity<PatientData>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Patient_pkey");

            entity.ToTable("Patient");

            entity.HasIndex(e => e.PatientId, "Patient_patientId_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.AgeUnit)
                .HasDefaultValueSql("'Years'::text")
                .HasColumnName("ageUnit");
            entity.Property(e => e.AssignedUserId).HasColumnName("assignedUserId");
            entity.Property(e => e.Caste).HasColumnName("caste");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.District).HasColumnName("district");
            entity.Property(e => e.Dob)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("dob");
            entity.Property(e => e.FacilityId).HasColumnName("facilityId");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.NationalId).HasColumnName("nationalId");
            entity.Property(e => e.NhisNumber).HasColumnName("nhisNumber");
            entity.Property(e => e.Palika).HasColumnName("palika");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.Province).HasColumnName("province");
            entity.Property(e => e.Service).HasColumnName("service");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.Ward).HasColumnName("ward");

            entity.HasOne(d => d.AssignedUser).WithMany(p => p.Patients)
                .HasForeignKey(d => d.AssignedUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Patient_assignedUserId_fkey");

            entity.HasOne(d => d.Facility).WithMany(p => p.Patients)
                .HasForeignKey(d => d.FacilityId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Patient_facilityId_fkey");
        });

        modelBuilder.Entity<PhysicalExamination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PhysicalExamination_pkey");

            entity.ToTable("PhysicalExamination");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Chest).HasColumnName("chest");
            entity.Property(e => e.Cns).HasColumnName("cns");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Cvs).HasColumnName("cvs");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.EncounterId).HasColumnName("encounterId");
            entity.Property(e => e.GeneralCondition).HasColumnName("generalCondition");
            entity.Property(e => e.LocalExamination).HasColumnName("localExamination");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.Perabominal).HasColumnName("perabominal");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PhysicalExaminationCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("PhysicalExamination_createdBy_fkey");

            entity.HasOne(d => d.Encounter).WithMany(p => p.PhysicalExaminations)
                .HasForeignKey(d => d.EncounterId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PhysicalExamination_encounterId_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.PhysicalExaminations)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PhysicalExamination_patientId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.PhysicalExaminationUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("PhysicalExamination_updatedBy_fkey");
        });

        modelBuilder.Entity<PostnatalCare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PostnatalCare_pkey");

            entity.ToTable("PostnatalCare");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calcium).HasColumnName("calcium");
            entity.Property(e => e.CheckupAttendedBy).HasColumnName("checkupAttendedBy");
            entity.Property(e => e.Complications).HasColumnName("complications");
            entity.Property(e => e.ConditionOfBaby).HasColumnName("conditionOfBaby");
            entity.Property(e => e.ConditionOfMother).HasColumnName("conditionOfMother");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DangerSignsOnBaby).HasColumnName("dangerSignsOnBaby");
            entity.Property(e => e.DangerSignsOnMother).HasColumnName("dangerSignsOnMother");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.DoctorFeedback).HasColumnName("doctorFeedback");
            entity.Property(e => e.FamilyPlanningServices).HasColumnName("familyPlanningServices");
            entity.Property(e => e.Investigation).HasColumnName("investigation");
            entity.Property(e => e.IronTablet).HasColumnName("ironTablet");
            entity.Property(e => e.MedicalAdvice).HasColumnName("medicalAdvice");
            entity.Property(e => e.NewBornBabyStatus).HasColumnName("newBornBabyStatus");
            entity.Property(e => e.OtherProblems).HasColumnName("otherProblems");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.PregnancyId).HasColumnName("pregnancyId");
            entity.Property(e => e.Refer).HasColumnName("refer");
            entity.Property(e => e.ReferReason).HasColumnName("referReason");
            entity.Property(e => e.ServiceProvidedBy).HasColumnName("serviceProvidedBy");
            entity.Property(e => e.Treatment).HasColumnName("treatment");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.VisitDate)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("visitDate");
            entity.Property(e => e.VisitTime).HasColumnName("visitTime");
            entity.Property(e => e.VisitingTime).HasColumnName("visitingTime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PostnatalCareCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("PostnatalCare_createdBy_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.PostnatalCares)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PostnatalCare_patientId_fkey");

            entity.HasOne(d => d.Pregnancy).WithMany(p => p.PostnatalCares)
                .HasForeignKey(d => d.PregnancyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("PostnatalCare_pregnancyId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.PostnatalCareUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("PostnatalCare_updatedBy_fkey");
        });

        modelBuilder.Entity<Pregnancy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pregnancy_pkey");

            entity.ToTable("Pregnancy");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.ExpectedDeliveryDate).HasColumnName("expectedDeliveryDate");
            entity.Property(e => e.FacilityId).HasColumnName("facilityId");
            entity.Property(e => e.FirstVisit)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("firstVisit");
            entity.Property(e => e.Gravida).HasColumnName("gravida");
            entity.Property(e => e.LastMensuratonPeriod).HasColumnName("lastMensuratonPeriod");
            entity.Property(e => e.Para).HasColumnName("para");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Facility).WithMany(p => p.Pregnancies)
                .HasForeignKey(d => d.FacilityId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Pregnancy_facilityId_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Pregnancies)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Pregnancy_patientId_fkey");
        });

        modelBuilder.Entity<PregnancyMv>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("pregnancy_mv", "analytics");

            entity.Property(e => e.ConsultantionFlg).HasColumnName("consultantion_flg");
            entity.Property(e => e.District).HasColumnName("district");
            entity.Property(e => e.FilterRange).HasColumnName("filter_range");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Palika).HasColumnName("palika");
            entity.Property(e => e.PregCountFlg).HasColumnName("preg_count_flg");
            entity.Property(e => e.PregLess20Flg).HasColumnName("preg_less_20_flg");
            entity.Property(e => e.PregMore20Flg).HasColumnName("preg_more_20_flg");
            entity.Property(e => e.Ward).HasColumnName("ward");
        });

        modelBuilder.Entity<PrismaMigration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("_prisma_migrations_pkey");

            entity.ToTable("_prisma_migrations");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.AppliedStepsCount)
                .HasDefaultValue(0)
                .HasColumnName("applied_steps_count");
            entity.Property(e => e.Checksum)
                .HasMaxLength(64)
                .HasColumnName("checksum");
            entity.Property(e => e.FinishedAt).HasColumnName("finished_at");
            entity.Property(e => e.Logs).HasColumnName("logs");
            entity.Property(e => e.MigrationName)
                .HasMaxLength(255)
                .HasColumnName("migration_name");
            entity.Property(e => e.RolledBackAt).HasColumnName("rolled_back_at");
            entity.Property(e => e.StartedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("started_at");
        });

        modelBuilder.Entity<ProvisionalDiagnosis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ProvisionalDiagnosis_pkey");

            entity.ToTable("ProvisionalDiagnosis");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EncounterId).HasColumnName("encounterId");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ProvisionalDiagnosisCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ProvisionalDiagnosis_createdBy_fkey");

            entity.HasOne(d => d.Encounter).WithMany(p => p.ProvisionalDiagnoses)
                .HasForeignKey(d => d.EncounterId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ProvisionalDiagnosis_encounterId_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.ProvisionalDiagnoses)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ProvisionalDiagnosis_patientId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ProvisionalDiagnosisUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ProvisionalDiagnosis_updatedBy_fkey");
        });

        modelBuilder.Entity<RadiologyTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("RadiologyTest_pkey");

            entity.ToTable("RadiologyTest");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.EncounterId).HasColumnName("encounterId");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.TestName).HasColumnName("testName");
            entity.Property(e => e.TestResult).HasColumnName("testResult");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RadiologyTestCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("RadiologyTest_createdBy_fkey");

            entity.HasOne(d => d.Encounter).WithMany(p => p.RadiologyTests)
                .HasForeignKey(d => d.EncounterId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("RadiologyTest_encounterId_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.RadiologyTests)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("RadiologyTest_patientId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.RadiologyTestUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("RadiologyTest_updatedBy_fkey");
        });

        modelBuilder.Entity<RefreshLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("refresh_log", "analytics");

            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.LoggedOn).HasColumnName("logged_on");
            entity.Property(e => e.ViewName)
                .HasColumnType("character varying")
                .HasColumnName("view_name");
        });

        modelBuilder.Entity<Roster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Roster_pkey");

            entity.ToTable("Roster");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("date");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.FacilityId).HasColumnName("facilityId");
            entity.Property(e => e.FromTime).HasColumnName("fromTime");
            entity.Property(e => e.Service).HasColumnName("service");
            entity.Property(e => e.Status)
                .HasDefaultValue(0)
                .HasColumnName("status");
            entity.Property(e => e.ToTime).HasColumnName("toTime");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RosterCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Roster_createdBy_fkey");

            entity.HasOne(d => d.Facility).WithMany(p => p.Rosters)
                .HasForeignKey(d => d.FacilityId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Roster_facilityId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.RosterUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Roster_updatedBy_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.RosterUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Roster_userId_fkey");
        });

        modelBuilder.Entity<ServiceEngagementConsolMv>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("service_engagement_consol_mv", "analytics");

            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.District).HasColumnName("district");
            entity.Property(e => e.FilterRange).HasColumnName("filter_range");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Growth).HasColumnName("growth");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImmunFlg).HasColumnName("immun_flg");
            entity.Property(e => e.MhFlg).HasColumnName("mh_flg");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.OpdFlg).HasColumnName("opd_flg");
            entity.Property(e => e.Palika).HasColumnName("palika");
            entity.Property(e => e.Refered).HasColumnName("refered");
            entity.Property(e => e.Service).HasColumnName("service");
            entity.Property(e => e.TelehealthFlg).HasColumnName("telehealth_flg");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.Ward).HasColumnName("ward");
        });

        modelBuilder.Entity<ServiceEngagementMv>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("service_engagement_mv", "analytics");

            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.District).HasColumnName("district");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Growth).HasColumnName("growth");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImmunFlg).HasColumnName("immun_flg");
            entity.Property(e => e.MhFlg).HasColumnName("mh_flg");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.OpdFlg).HasColumnName("opd_flg");
            entity.Property(e => e.Palika).HasColumnName("palika");
            entity.Property(e => e.Refered).HasColumnName("refered");
            entity.Property(e => e.Service).HasColumnName("service");
            entity.Property(e => e.TelehealthFlg).HasColumnName("telehealth_flg");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.Ward).HasColumnName("ward");
        });

        modelBuilder.Entity<SmsLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SmsLog_pkey");

            entity.ToTable("SmsLog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.DeliveryDate)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deliveryDate");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.ScheduleDate)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("scheduleDate");
            entity.Property(e => e.SmsBody).HasColumnName("smsBody");
            entity.Property(e => e.Status)
                .HasDefaultValue(0)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.SmsLogCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SmsLog_createdBy_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.SmsLogs)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("SmsLog_patientId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.SmsLogUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("SmsLog_updatedBy_fkey");
        });

        modelBuilder.Entity<Treatment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Treatment_pkey");

            entity.ToTable("Treatment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.EncounterId).HasColumnName("encounterId");
            entity.Property(e => e.FollowUpDate).HasColumnName("followUpDate");
            entity.Property(e => e.FollowUpText).HasColumnName("followUpText");
            entity.Property(e => e.MedicalAdvise).HasColumnName("medicalAdvise");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.Refer).HasColumnName("refer");
            entity.Property(e => e.ReferReason).HasColumnName("referReason");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TreatmentCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Treatment_createdBy_fkey");

            entity.HasOne(d => d.Encounter).WithMany(p => p.Treatments)
                .HasForeignKey(d => d.EncounterId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Treatment_encounterId_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Treatments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Treatment_patientId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TreatmentUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Treatment_updatedBy_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "User_email_key").IsUnique();

            entity.HasIndex(e => e.Username, "User_username_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CallStatus).HasColumnName("callStatus");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.Designation).HasColumnName("designation");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FacilityId).HasColumnName("facilityId");
            entity.Property(e => e.FirstName).HasColumnName("firstName");
            entity.Property(e => e.LastName).HasColumnName("lastName");
            entity.Property(e => e.NmcRegistrationNumber).HasColumnName("nmcRegistrationNumber");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.Specialization).HasColumnName("specialization");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UserRoleId).HasColumnName("userRoleId");
            entity.Property(e => e.UserType).HasColumnName("userType");
            entity.Property(e => e.Username).HasColumnName("username");

            entity.HasOne(d => d.Facility).WithMany(p => p.Users)
                .HasForeignKey(d => d.FacilityId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("User_facilityId_fkey");

            entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("User_userRoleId_fkey");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("UserRole_pkey");

            entity.ToTable("UserRole");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<Vital>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Vital_pkey");

            entity.ToTable("Vital");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BpDiastolic).HasColumnName("bpDiastolic");
            entity.Property(e => e.BpSystolic).HasColumnName("bpSystolic");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("deletedAt");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.EncounterId).HasColumnName("encounterId");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.Pulse).HasColumnName("pulse");
            entity.Property(e => e.RespiratoryRate).HasColumnName("respiratoryRate");
            entity.Property(e => e.Spo2).HasColumnName("spo2");
            entity.Property(e => e.Temperature).HasColumnName("temperature");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(3) without time zone")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.VitalCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Vital_createdBy_fkey");

            entity.HasOne(d => d.Encounter).WithMany(p => p.Vitals)
                .HasForeignKey(d => d.EncounterId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Vital_encounterId_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Vitals)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Vital_patientId_fkey");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.VitalUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("Vital_updatedBy_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
