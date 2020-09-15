using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI.Database
{
    public partial class RS2Context : DbContext
    {
        public RS2Context()
        {
        }

        public RS2Context(DbContextOptions<RS2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Clanarina> Clanarina { get; set; }
        public virtual DbSet<Dan> Dan { get; set; }
        public virtual DbSet<DanSet> DanSet { get; set; }
        public virtual DbSet<Komentar> Komentar { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<KorisnikPlanIprogram> KorisnikPlanIprogram { get; set; }
        public virtual DbSet<KorisnikUloga> KorisnikUloga { get; set; }
        public virtual DbSet<Misic> Misic { get; set; }
        public virtual DbSet<Ocjena> Ocjena { get; set; }
        public virtual DbSet<PlanIprogram> PlanIprogram { get; set; }
        public virtual DbSet<PlanKategorija> PlanKategorija { get; set; }
        public virtual DbSet<PrisutnostClana> PrisutnostClana { get; set; }
        public virtual DbSet<Sedmica> Sedmica { get; set; }
        public virtual DbSet<SetVjezba> SetVjezba { get; set; }
        public virtual DbSet<Tdslike> Tdslike { get; set; }
        public virtual DbSet<TipClanarine> TipClanarine { get; set; }
        public virtual DbSet<TjelesniDetalji> TjelesniDetalji { get; set; }
        public virtual DbSet<Uloga> Uloga { get; set; }
        public virtual DbSet<Vjezba> Vjezba { get; set; }
        public virtual DbSet<VjezbaMisic> VjezbaMisic { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=RS2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clanarina>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatumDodavanja).HasColumnType("date");

                entity.Property(e => e.DatumIsteka).HasColumnType("date");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.TipClanarineId).HasColumnName("TipClanarineID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Clanarina)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clanarina__Koris__3B75D760");

                entity.HasOne(d => d.TipClanarine)
                    .WithMany(p => p.Clanarina)
                    .HasForeignKey(d => d.TipClanarineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clanarina__TipCl__3C69FB99");
            });

            modelBuilder.Entity<Dan>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PlanIprogramId).HasColumnName("PlanIProgramID");

                entity.HasOne(d => d.PlanIprogram)
                    .WithMany(p => p.Dan)
                    .HasForeignKey(d => d.PlanIprogramId)
                    .HasConstraintName("FK__Dan__PlanIProgra__01142BA1");
            });

            modelBuilder.Entity<DanSet>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DanId).HasColumnName("DanID");

                entity.Property(e => e.VjezbaId).HasColumnName("VjezbaID");

                entity.HasOne(d => d.Dan)
                    .WithMany(p => p.DanSet)
                    .HasForeignKey(d => d.DanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DanSet__DanID__05D8E0BE");

                entity.HasOne(d => d.Vjezba)
                    .WithMany(p => p.DanSet)
                    .HasForeignKey(d => d.VjezbaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DanSet__VjezbaID__06CD04F7");
            });

            modelBuilder.Entity<Komentar>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NadKomentarId).HasColumnName("NadKomentarID");
                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");
                entity.Property(e => e.Datum).HasColumnName("Datum");

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.HasOne(d => d.NadKomentar)
                    .WithMany(p => p.InverseNadKomentar)
                    .HasForeignKey(d => d.NadKomentarId)
                    .HasConstraintName("FK__Komentar__NadKom__59063A47");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Komentar)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK__Komentar__PlanID__59FA5E80");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BrojKartice).HasMaxLength(10);

                entity.Property(e => e.DatumRodenja).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.PasswordHash).HasMaxLength(200);

                entity.Property(e => e.PasswordSalt).HasMaxLength(200);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Spol)
                    .IsRequired()
                    .HasMaxLength(7);

                entity.Property(e => e.Telefon).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<KorisnikPlanIprogram>(entity =>
            {
                entity.HasKey(e => new { e.KorisnikId, e.PlanId });

                entity.ToTable("KorisnikPlanIProgram");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.PlanId).HasColumnName("PlanID");
                entity.Property(e => e.TjelesniDetaljiId).HasColumnName("TjelesniDetaljiID");

                entity.Property(e => e.DatumVrijemeKupovine).HasColumnType("datetime");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.KorisnikPlanIprogram)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KorisnikP__Koris__52593CB8");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.KorisnikPlanIprogram)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KorisnikP__PlanI__534D60F1");
            });

            modelBuilder.Entity<KorisnikUloga>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatumIzmjene).HasColumnType("date");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.KorisnikUloga)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KorisnikU__Koris__412EB0B6");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.KorisnikUloga)
                    .HasForeignKey(d => d.UlogaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KorisnikU__Uloga__4222D4EF");
            });

            modelBuilder.Entity<Misic>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ocjena>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Rating).HasColumnName("Rating");
                entity.Property(e => e.Datum).HasColumnName("Datum");
                entity.Property(e => e.Vrijeme).HasColumnName("Vrijeme");

                entity.Property(e => e.Opis).HasMaxLength(100);
                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Ocjena)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ocjena__PlanID__5629CD9C");
            });

            modelBuilder.Entity<PlanIprogram>(entity =>
            {
                entity.ToTable("PlanIProgram");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.PlanIprogram)
                    .HasForeignKey(d => d.KategorijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlanIProg__Kateg__4F7CD00D");
            });

            modelBuilder.Entity<PlanKategorija>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PrisutnostClana>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.PrisutnostClana)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prisutnos__Koris__44FF419A");
            });

            modelBuilder.Entity<Sedmica>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<SetVjezba>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DanSetId).HasColumnName("DanSetID");

                entity.HasOne(d => d.DanSet)
                    .WithMany(p => p.SetVjezba)
                    .HasForeignKey(d => d.DanSetId)
                    .HasConstraintName("FK__SetVjezba__DanSe__08B54D69");
            });

            modelBuilder.Entity<Tdslike>(entity =>
            {
                entity.ToTable("TDSlike");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TjelesniDetaljiId).HasColumnName("TjelesniDetaljiID");

                entity.HasOne(d => d.TjelesniDetalji)
                    .WithMany(p => p.Tdslike)
                    .HasForeignKey(d => d.TjelesniDetaljiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TDSlike__Tjelesn__4AB81AF0");
            });

            modelBuilder.Entity<TipClanarine>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TjelesniDetalji>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Datum).HasColumnName("Datum");

                entity.Property(e => e.ObimBicepsa).HasMaxLength(10);

                entity.Property(e => e.ObimNoge).HasMaxLength(10);

                entity.Property(e => e.ObimPrsa).HasMaxLength(10);

                entity.Property(e => e.ObimStruka).HasMaxLength(10);

                entity.Property(e => e.Tezina).HasMaxLength(10);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.TjelesniDetalji)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TjelesniD__Koris__47DBAE45");
            });

            modelBuilder.Entity<Uloga>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Opis).HasMaxLength(250);
            });

            modelBuilder.Entity<Vjezba>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<VjezbaMisic>(entity =>
            {
                entity.HasKey(e => new { e.VjezbaId, e.MisicId });

                entity.Property(e => e.VjezbaId).HasColumnName("VjezbaID");

                entity.Property(e => e.MisicId).HasColumnName("MisicID");

                entity.HasOne(d => d.Misic)
                    .WithMany(p => p.VjezbaMisic)
                    .HasForeignKey(d => d.MisicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VjezbaMis__Misic__66603565");

                entity.HasOne(d => d.Vjezba)
                    .WithMany(p => p.VjezbaMisic)
                    .HasForeignKey(d => d.VjezbaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VjezbaMis__Vjezb__656C112C");
            });

            ////Roles 
            //modelBuilder.Entity<Uloga>().HasData(new Uloga()
            //{
            //    Id = 1,
            //    Naziv = "Administrator"
            //});
            //modelBuilder.Entity<Uloga>().HasData(new Uloga()
            //{
            //    Id = 2,
            //    Naziv = "Clan"
            //});
            //modelBuilder.Entity<Uloga>().HasData(new Uloga()
            //{
            //    Id = 3,
            //    Naziv = "AppUser"
            //});

            ////Korisnik 
            //modelBuilder.Entity<Korisnik>().HasData(new Korisnik()
            //{
            //    Id = 1,
            //    Ime = "Admin",
            //    Prezime = "Admin",
            //    Email = "admin@admin.com",
            //    Spol = "M",
            //    Username = "admin",
            //    PasswordHash = ""
            //});

        }
    }
}
