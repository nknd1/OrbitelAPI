using Microsoft.EntityFrameworkCore;
using orbitel_api.Models.Clients;
using orbitel_api.Models.Contracts;
using orbitel_api.Models.Services;
using orbitel_api.Models.Tariffs;
using orbitel_api.Models.Transactions;

namespace orbitel_api.Models;

public class OrbitelContext : DbContext
{
    public OrbitelContext()
    {
    }

    public OrbitelContext(DbContextOptions<OrbitelContext> options)
        : base(options) 
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientContract> ClientContracts { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Deposit> Deposits { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceConnect> ServiceConnects { get; set; }

    public virtual DbSet<ServiceType> ServiceTypes { get; set; }

    public virtual DbSet<Tariff> Tariffs { get; set; }

    public virtual DbSet<TariffConnect> TariffConnects { get; set; }

    public virtual DbSet<Writeoff> Writeoffs { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("clients_pkey");

            entity.ToTable("clients");

            entity.HasIndex(e => e.Email, "clients_email_key").IsUnique();

            entity.HasIndex(e => e.Inn, "clients_inn_key").IsUnique();

            entity.HasIndex(e => e.Login, "clients_login_key").IsUnique();

            entity.HasIndex(e => e.NumberPass, "clients_number_pass_key").IsUnique();

            entity.HasIndex(e => e.PasswordHash, "clients_password_hash_key").IsUnique();

            entity.HasIndex(e => e.Phone, "clients_phone_key").IsUnique();

            entity.HasIndex(e => e.SeriesPass, "clients_series_pass_key").IsUnique();

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.AddressRegistration)
                .HasMaxLength(50)
                .HasColumnName("address_registration");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.Inn)
                .HasMaxLength(30)
                .HasColumnName("inn");
            entity.Property(e => e.IssueDate).HasColumnName("issue_date");
            entity.Property(e => e.IssuedBy)
                .HasMaxLength(255)
                .HasColumnName("issued_by");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.NumberPass)
                .HasMaxLength(20)
                .HasColumnName("number_pass");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.SeriesPass)
                .HasMaxLength(10)
                .HasColumnName("series_pass");
        });

        modelBuilder.Entity<ClientContract>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("client_contracts");

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");

            entity.HasOne(d => d.Client).WithMany()
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("client_contracts_client_id_fkey");

            entity.HasOne(d => d.Contract).WithMany()
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("client_contracts_contract_id_fkey");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("contracts_pkey");

            entity.ToTable("contracts");

            entity.HasIndex(e => e.ContractNumber, "contracts_contract_number_key").IsUnique();

            entity.HasIndex(e => e.Dns1, "contracts_dns1_key").IsUnique();

            entity.HasIndex(e => e.Dns2, "contracts_dns2_key").IsUnique();

            entity.HasIndex(e => e.Gateway, "contracts_gateway_key").IsUnique();

            entity.HasIndex(e => e.IpAddress, "contracts_ip_address_key").IsUnique();

            entity.HasIndex(e => e.PersonalAccount, "contracts_personal_account_key").IsUnique();

            entity.HasIndex(e => e.SubnetMask, "contracts_subnet_mask_key").IsUnique();

            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.Balance)
                .HasDefaultValueSql("0")
                .HasComment("баланс по умолчанию 0 после добавления договора")
                .HasColumnName("balance");
            entity.Property(e => e.ConnectAddress)
                .HasMaxLength(50)
                .HasColumnName("connect_address");
            entity.Property(e => e.ContractNumber)
                .HasMaxLength(20)
                .HasDefaultValueSql("(('№'::text || lpad(((floor((random() * (10000000)::double precision)))::integer)::text, 7, '0'::text)) || '-1'::text)")
                .HasColumnName("contract_number");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Dns1)
                .HasMaxLength(12)
                .HasColumnName("dns1");
            entity.Property(e => e.Dns2)
                .HasMaxLength(12)
                .HasColumnName("dns2");
            entity.Property(e => e.Gateway)
                .HasMaxLength(20)
                .HasColumnName("gateway");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(16)
                .HasColumnName("ip_address");
            entity.Property(e => e.PersonalAccount)
                .HasMaxLength(8)
                .HasDefaultValueSql("(lpad(((floor((random() * (10000000)::double precision)))::integer)::text, 6, '0'::text) || '-1'::text)")
                .HasColumnName("personal_account");
            entity.Property(e => e.SubnetMask)
                .HasMaxLength(16)
                .HasColumnName("subnet_mask");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Deposit>(entity =>
        {
            entity.HasKey(e => e.DepositId).HasName("deposits_pkey");

            entity.ToTable("deposits");

            entity.Property(e => e.DepositId).HasColumnName("deposit_id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.DateDeposit)
                .HasDefaultValueSql("now()")
                .HasColumnName("date_deposit");
            entity.Property(e => e.TimeDeposit)
                .HasDefaultValueSql("now()")
                .HasColumnName("time_deposit");

            entity.HasOne(d => d.Contract).WithMany(p => p.Deposits)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("deposits_contract_id_fkey");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("services_pkey");

            entity.ToTable("services");

            entity.HasIndex(e => e.ServiceName, "services_service_name_key").IsUnique();

            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Feature).HasColumnName("feature");
            entity.Property(e => e.Price)
                .HasComment("Цена услуги")
                .HasColumnName("price");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(50)
                .HasColumnName("service_name");
            entity.Property(e => e.ServiceTypeId).HasColumnName("service_type_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ServiceConnect>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("service_connects");

            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.TariffId).HasColumnName("tariff_id");

            entity.HasOne(d => d.Service).WithMany()
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("service_connects_service_id_fkey");

            entity.HasOne(d => d.Tariff).WithMany()
                .HasForeignKey(d => d.TariffId)
                .HasConstraintName("service_connects_tariff_id_fkey");
        });

        modelBuilder.Entity<ServiceType>(entity =>
        {
            entity.HasKey(e => e.ServiceTypeId).HasName("service_types_pkey");

            entity.ToTable("service_types");

            entity.HasIndex(e => e.ServiceTypeName, "service_types_service_type_name_key").IsUnique();

            entity.Property(e => e.ServiceTypeId).HasColumnName("service_type_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ServiceTypeName)
                .HasMaxLength(50)
                .HasColumnName("service_type_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Tariff>(entity =>
        {
            entity.HasKey(e => e.TariffId).HasName("tariffs_pkey");

            entity.ToTable("tariffs");

            entity.HasIndex(e => e.TariffName, "tariffs_tariff_name_key").IsUnique();

            entity.Property(e => e.TariffId).HasColumnName("tariff_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.PricePerMonth).HasColumnName("price_per_month");
            entity.Property(e => e.Speed)
                .HasMaxLength(30)
                .HasColumnName("speed");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasDefaultValueSql("'active'::character varying")
                .HasColumnName("status");
            entity.Property(e => e.TariffName)
                .HasMaxLength(50)
                .HasColumnName("tariff_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<TariffConnect>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tariff_connects");

            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.TariffId).HasColumnName("tariff_id");

            entity.HasOne(d => d.Contract).WithMany()
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("tariff_connects_contract_id_fkey");
        });

        modelBuilder.Entity<Writeoff>(entity =>
        {
            entity.HasKey(e => e.WriteoffId).HasName("writeoffs_pkey");

            entity.ToTable("writeoffs");

            entity.Property(e => e.WriteoffId).HasColumnName("writeoff_id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.DateWriteoff)
                .HasDefaultValueSql("now()")
                .HasColumnName("date_writeoff");
            entity.Property(e => e.Reason)
                .HasColumnType("character varying")
                .HasColumnName("reason");
            entity.Property(e => e.TimeWriteoff)
                .HasDefaultValueSql("now()")
                .HasColumnName("time_writeoff");

            entity.HasOne(d => d.Contract).WithMany(p => p.Writeoffs)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("writeoffs_contract_id_fkey");
        });
    }
}
