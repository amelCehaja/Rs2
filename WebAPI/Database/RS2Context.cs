using System;
using System.ComponentModel.Design;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Manage.Internal;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
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

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
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
                    .HasMaxLength(2000);

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

            //Uloge 
            modelBuilder.Entity<Uloga>().HasData(new Uloga()
            {
                Id = 1,
                Naziv = "Administrator"
            });
            modelBuilder.Entity<Uloga>().HasData(new Uloga()
            {
                Id = 2,
                Naziv = "Clan"
            });
            modelBuilder.Entity<Uloga>().HasData(new Uloga()
            {
                Id = 3,
                Naziv = "AppUser"
            });

            //Korisnici 
            Korisnik _admin = new Korisnik
            {
                Id = 1,
                Ime = "Admin",
                Prezime = "Admin",
                Email = "admin@admin.com",
                Spol = "M",
                Username = "admin",
                Slika = File.ReadAllBytes("SlikeSeed/index.jpg"),
                PasswordSalt = GenerateSalt()
            };
            _admin.PasswordHash = GenerateHash(_admin.PasswordSalt, "admin");
            modelBuilder.Entity<Korisnik>().HasData(_admin);

            Korisnik _clan1 = new Korisnik
            {
                Id = 2,
                Ime = "Amel",
                Prezime = "Cehaja",
                Email = "cehaja18@gmail.com",
                BrojKartice = "11111111",
                Spol = "M",
                Username = "amel.cehaja",
                Slika = File.ReadAllBytes("SlikeSeed/index.jpg"),
                PasswordSalt = GenerateSalt()
            };
            _clan1.PasswordHash = GenerateHash(_clan1.PasswordSalt, "password");
            modelBuilder.Entity<Korisnik>().HasData(_clan1);
            Korisnik _clan2 = new Korisnik
            {
                Id = 3,
                Ime = "Adel",
                Prezime = "Dadic",
                Email = "dadic123@gmail.com",
                BrojKartice = "22222222",
                Spol = "M",
                Slika = File.ReadAllBytes("SlikeSeed/index.jpg"),
                Username = "adel.dadic",
                PasswordSalt = GenerateSalt()
            };
            _clan2.PasswordHash = GenerateHash(_clan2.PasswordSalt, "password");
            modelBuilder.Entity<Korisnik>().HasData(_clan2);

            Korisnik _clan3 = new Korisnik
            {
                Id = 4,
                Ime = "Riad",
                Prezime = "Muratspahic",
                Email = "zmigi123@gmail.com",
                BrojKartice = "12345678",
                Spol = "M",
                Username = "zmigi",
                Slika = File.ReadAllBytes("SlikeSeed/index.jpg"),
                PasswordSalt = GenerateSalt()
            };
            _clan3.PasswordHash = GenerateHash(_clan3.PasswordSalt, "password");
            modelBuilder.Entity<Korisnik>().HasData(_clan3);

            //korisnikUloge
            modelBuilder.Entity<KorisnikUloga>().HasData(new KorisnikUloga
            {
                Id = 1,
                KorisnikId = 1,
                UlogaId = 1,
                DatumIzmjene = DateTime.Today
            });
            modelBuilder.Entity<KorisnikUloga>().HasData(new KorisnikUloga
            {
                Id = 2,
                KorisnikId = 2,
                UlogaId = 2,
                DatumIzmjene = DateTime.Today
            });
            modelBuilder.Entity<KorisnikUloga>().HasData(new KorisnikUloga
            {
                Id = 3,
                KorisnikId = 3,
                UlogaId = 2,
                DatumIzmjene = DateTime.Today
            });
            modelBuilder.Entity<KorisnikUloga>().HasData(new KorisnikUloga
            {
                Id = 4,
                KorisnikId = 4,
                UlogaId = 3,
                DatumIzmjene = DateTime.Today
            });

            //TipoviClanarine
            modelBuilder.Entity<TipClanarine>().HasData(new TipClanarine
            {
                Id = 1,
                Naziv = "Standard",
                Cijena = 50,
                Trajanje = 30
            });
            modelBuilder.Entity<TipClanarine>().HasData(new TipClanarine
            {
                Id = 2,
                Naziv = "Studentska",
                Cijena = 30,
                Trajanje = 30
            });
            modelBuilder.Entity<TipClanarine>().HasData(new TipClanarine
            {
                Id = 3,
                Naziv = "Polumjesecna",
                Cijena = 25,
                Trajanje = 15
            });

            //Clanarine
            modelBuilder.Entity<Clanarina>().HasData(new Clanarina
            {
                Id = 1,
                KorisnikId = 2,
                TipClanarineId = 1,
                Cijena = 50,
                DatumDodavanja = new DateTime(2020, 5, 1),
                DatumIsteka = new DateTime(2020, 6, 1)
            });
            modelBuilder.Entity<Clanarina>().HasData(new Clanarina
            {
                Id = 2,
                KorisnikId = 2,
                TipClanarineId = 1,
                Cijena = 50,
                DatumDodavanja = new DateTime(2020, 6, 1),
                DatumIsteka = new DateTime(2020, 7, 1)
            });
            modelBuilder.Entity<Clanarina>().HasData(new Clanarina
            {
                Id = 3,
                KorisnikId = 2,
                TipClanarineId = 3,
                Cijena = 50,
                DatumDodavanja = new DateTime(2020, 7, 1),
                DatumIsteka = new DateTime(2020, 7, 15)
            });
            modelBuilder.Entity<Clanarina>().HasData(new Clanarina
            {
                Id = 4,
                KorisnikId = 3,
                TipClanarineId = 2,
                Cijena = 30,
                DatumDodavanja = new DateTime(2020, 5, 13),
                DatumIsteka = new DateTime(2020, 6, 13)
            });

            //PrisutnostiClana
            modelBuilder.Entity<PrisutnostClana>().HasData(new PrisutnostClana
            {
                Id = 1,
                KorisnikId = 2,
                Datum = new DateTime(2020, 5, 2),
                VrijemeDolaska = new TimeSpan(12, 20, 00),
                VrijemeOdlaska = new TimeSpan(12, 55, 00)
            });
            modelBuilder.Entity<PrisutnostClana>().HasData(new PrisutnostClana
            {
                Id = 2,
                KorisnikId = 2,
                Datum = new DateTime(2020, 5, 4),
                VrijemeDolaska = new TimeSpan(13, 20, 00),
                VrijemeOdlaska = new TimeSpan(14, 55, 00)
            });
            modelBuilder.Entity<PrisutnostClana>().HasData(new PrisutnostClana
            {
                Id = 3,
                KorisnikId = 2,
                Datum = new DateTime(2020, 5, 5),
                VrijemeDolaska = new TimeSpan(12, 20, 00),
                VrijemeOdlaska = new TimeSpan(12, 55, 00)
            });
            modelBuilder.Entity<PrisutnostClana>().HasData(new PrisutnostClana
            {
                Id = 4,
                KorisnikId = 2,
                Datum = new DateTime(2020, 6, 22),
                VrijemeDolaska = new TimeSpan(11, 00, 00),
                VrijemeOdlaska = new TimeSpan(12, 55, 00)
            });
            modelBuilder.Entity<PrisutnostClana>().HasData(new PrisutnostClana
            {
                Id = 5,
                KorisnikId = 2,
                Datum = new DateTime(2020, 6, 23),
                VrijemeDolaska = new TimeSpan(10, 20, 00),
                VrijemeOdlaska = new TimeSpan(12, 15, 00)
            });
            modelBuilder.Entity<PrisutnostClana>().HasData(new PrisutnostClana
            {
                Id = 6,
                KorisnikId = 3,
                Datum = new DateTime(2020, 5, 5),
                VrijemeDolaska = new TimeSpan(12, 20, 00),
                VrijemeOdlaska = new TimeSpan(12, 55, 00)
            });
            modelBuilder.Entity<PrisutnostClana>().HasData(new PrisutnostClana
            {
                Id = 7,
                KorisnikId = 3,
                Datum = new DateTime(2020, 6, 22),
                VrijemeDolaska = new TimeSpan(11, 12, 00),
                VrijemeOdlaska = new TimeSpan(12, 55, 00)
            });
            modelBuilder.Entity<PrisutnostClana>().HasData(new PrisutnostClana
            {
                Id = 8,
                KorisnikId = 3,
                Datum = new DateTime(2020, 6, 23),
                VrijemeDolaska = new TimeSpan(15, 1, 00),
                VrijemeOdlaska = new TimeSpan(16, 22, 00)
            });

            //TjelesniDetalji
            modelBuilder.Entity<TjelesniDetalji>().HasData(new TjelesniDetalji
            {
                Id = 1,
                Datum = new DateTime(2020, 7, 7),
                KorisnikId = 2,
                Tezina = 90,
                ObimBicepsa = 25,
                ObimNoge = 35,
                ObimPrsa = 60,
                ObimStruka = 52
            });
            modelBuilder.Entity<TjelesniDetalji>().HasData(new TjelesniDetalji
            {
                Id = 2,
                Datum = new DateTime(2020, 7, 30),
                KorisnikId = 2,
                Tezina = 92,
                ObimBicepsa = 26,
                ObimNoge = 37,
                ObimPrsa = 63,
                ObimStruka = 48
            });
            modelBuilder.Entity<TjelesniDetalji>().HasData(new TjelesniDetalji
            {
                Id = 3,
                Datum = new DateTime(2020, 6, 5),
                KorisnikId = 3,
                Tezina = 77,
                ObimBicepsa = 20,
                ObimNoge = 32,
                ObimPrsa = 55,
                ObimStruka = 45
            });
            modelBuilder.Entity<TjelesniDetalji>().HasData(new TjelesniDetalji
            {
                Id = 4,
                Datum = new DateTime(2020, 6, 2),
                KorisnikId = 4,
                Tezina = 93,
                ObimBicepsa = 27,
                ObimNoge = 37.5,
                ObimPrsa = 55,
                ObimStruka = 45.2
            });

            //PlanoKategorije
            modelBuilder.Entity<PlanKategorija>().HasData(new PlanKategorija
            {
                Id = 1,
                Naziv = "Mrsanje"
            });
            modelBuilder.Entity<PlanKategorija>().HasData(new PlanKategorija
            {
                Id = 2,
                Naziv = "Povecanje misica"
            });
            modelBuilder.Entity<PlanKategorija>().HasData(new PlanKategorija
            {
                Id = 3,
                Naziv = "Povecanje snage"
            });

            //Planovi
            modelBuilder.Entity<PlanIprogram>().HasData(new PlanIprogram
            {
                Id = 1,
                Naziv = "Plan 1",
                Cijena = 124,
                KategorijaId = 1,
                Opis = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos, qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui dolorem ipsum, quia dolor sit, amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt, ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit, qui in ea voluptate velit esse, quam nihil molestiae consequatur, vel illum, qui dolorem eum fugiat, quo voluptas nulla pariatur? [33] At vero eos et accusamus et iusto odio dignissimos ducimus, qui blanditiis praesentium voluptatum deleniti atque corrupti, quos dolores et quas molestias excepturi sint, obcaecati cupiditate non provident, similique sunt in culpa, qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio, cumque nihil impedit, quo minus id, quod maxime placeat, facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet, ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.",
            });
            modelBuilder.Entity<PlanIprogram>().HasData(new PlanIprogram
            {
                Id = 2,
                Naziv = "Plan 2",
                Cijena = 95,
                KategorijaId = 1,
                Opis = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos, qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui dolorem ipsum, quia dolor sit, amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt, ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit, qui in ea voluptate velit esse, quam nihil molestiae consequatur, vel illum, qui dolorem eum fugiat, quo voluptas nulla pariatur? [33] At vero eos et accusamus et iusto odio dignissimos ducimus, qui blanditiis praesentium voluptatum deleniti atque corrupti, quos dolores et quas molestias excepturi sint, obcaecati cupiditate non provident, similique sunt in culpa, qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio, cumque nihil impedit, quo minus id, quod maxime placeat, facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet, ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.",
            });
            modelBuilder.Entity<PlanIprogram>().HasData(new PlanIprogram
            {
                Id = 3,
                Naziv = "Plan 3",
                Cijena = 75,
                KategorijaId = 2,
                Opis = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos, qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui dolorem ipsum, quia dolor sit, amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt, ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit, qui in ea voluptate velit esse, quam nihil molestiae consequatur, vel illum, qui dolorem eum fugiat, quo voluptas nulla pariatur? [33] At vero eos et accusamus et iusto odio dignissimos ducimus, qui blanditiis praesentium voluptatum deleniti atque corrupti, quos dolores et quas molestias excepturi sint, obcaecati cupiditate non provident, similique sunt in culpa, qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio, cumque nihil impedit, quo minus id, quod maxime placeat, facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet, ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.",
            });

            //PlanKorisnik
            modelBuilder.Entity<KorisnikPlanIprogram>().HasData(new KorisnikPlanIprogram
            {
                KorisnikId = 2,
                TjelesniDetaljiId = 1,
                PlanId = 1,
                Cijena = 124,
                DatumVrijemeKupovine = DateTime.Today
            });
            modelBuilder.Entity<KorisnikPlanIprogram>().HasData(new KorisnikPlanIprogram
            {
                KorisnikId = 3,
                TjelesniDetaljiId = 3,
                PlanId = 2,
                Cijena = 90,
                DatumVrijemeKupovine = DateTime.Today
            });

            //Ocjena
            modelBuilder.Entity<Ocjena>().HasData(new Ocjena
            {
                Id = 1,
                KorisnikId = 2,
                PlanId = 1,
                Rating = 4,
                Datum = DateTime.Today,
                Vrijeme = new TimeSpan(12,12,12),
                Opis = "Dobar plan"
            });
            modelBuilder.Entity<Ocjena>().HasData(new Ocjena
            {
                Id = 2,
                KorisnikId = 3,
                PlanId = 2,
                Rating = 2,
                Datum = DateTime.Today,
                Vrijeme = new TimeSpan(12, 12, 12)
            });

            //Pitanje
            modelBuilder.Entity<Komentar>().HasData(new Komentar
            {
                Id = 1,
                KorisnikId = 2,
                Datum = DateTime.Today,
                PlanId = 1,
                Opis = "Neko pitanje?"
            });
            modelBuilder.Entity<Komentar>().HasData(new Komentar
            {
                Id = 2,
                KorisnikId = 2,
                Datum = DateTime.Today,
                PlanId = 2,
                Opis = "Neko pitanje?"
            });
            modelBuilder.Entity<Komentar>().HasData(new Komentar
            {
                Id = 3,
                Datum = DateTime.Today,
                PlanId = 2,
                KorisnikId = 1,
                Opis = "Neki odgovor!",
                NadKomentarId = 2
            });

            //Misic
            modelBuilder.Entity<Misic>().HasData(new Misic
            {
                Id = 1,
                Naziv = "Biceps"
            });
            modelBuilder.Entity<Misic>().HasData(new Misic
            {
                Id = 2,
                Naziv = "Triceps"
            });
            modelBuilder.Entity<Misic>().HasData(new Misic
            {
                Id = 3,
                Naziv = "Lats"
            });
            modelBuilder.Entity<Misic>().HasData(new Misic
            {
                Id = 4,
                Naziv = "Kvadriceps"
            });

            //Vjezba
            modelBuilder.Entity<Vjezba>().HasData(new Vjezba
            {
                Id = 1,
                Naziv = "Sklek",
                Opis = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos, qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui"
                , Gif = File.ReadAllBytes("SlikeSeed/giphy.gif")
            });
            modelBuilder.Entity<Vjezba>().HasData(new Vjezba
            {
                Id = 2,
                Naziv = "Zgib",
                Opis = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos, qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui"
                , Gif = File.ReadAllBytes("SlikeSeed/pullups.gif")
            });
            modelBuilder.Entity<Vjezba>().HasData(new Vjezba
            {
                Id = 3,
                Naziv = "Cucanj",
                Opis = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos, qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui"
                , Gif = File.ReadAllBytes("SlikeSeed/squat.gif")
            });

            //VjezbaMisic
            modelBuilder.Entity<VjezbaMisic>().HasData(new VjezbaMisic
            {
                VjezbaId = 1,
                MisicId = 1
            });
            modelBuilder.Entity<VjezbaMisic>().HasData(new VjezbaMisic
            {
                VjezbaId = 2,
                MisicId = 2
            });
            modelBuilder.Entity<VjezbaMisic>().HasData(new VjezbaMisic
            {
                VjezbaId = 2,
                MisicId = 3
            });
            modelBuilder.Entity<VjezbaMisic>().HasData(new VjezbaMisic
            {
                VjezbaId = 3,
                MisicId = 4
            });

            //Dan
            modelBuilder.Entity<Dan>().HasData(new Dan { 
                Id = 1,
                PlanIprogramId = 1,
                RedniBroj = 1
            });
            modelBuilder.Entity<Dan>().HasData(new Dan
            {
                Id = 2,
                PlanIprogramId = 1,
                RedniBroj = 2
            }); 
            modelBuilder.Entity<Dan>().HasData(new Dan
            {
                Id = 3,
                PlanIprogramId = 1,
                RedniBroj = 3
            });
            modelBuilder.Entity<Dan>().HasData(new Dan
            {
                Id = 4,
                PlanIprogramId = 2,
                RedniBroj = 1
            });
            modelBuilder.Entity<Dan>().HasData(new Dan
            {
                Id = 5,
                PlanIprogramId = 2,
                RedniBroj = 2
            });
            modelBuilder.Entity<Dan>().HasData(new Dan
            {
                Id = 6,
                PlanIprogramId = 3,
                RedniBroj = 1
            });
            modelBuilder.Entity<Dan>().HasData(new Dan
            {
                Id = 7,
                PlanIprogramId = 3,
                RedniBroj = 2
            });

            //DanSet
            modelBuilder.Entity<DanSet>().HasData(new DanSet
            {
                Id = 1,
                DanId = 1,
                RedniBroj = 1,
                VjezbaId = 1
            });
            modelBuilder.Entity<DanSet>().HasData(new DanSet
            {
                Id = 2,
                DanId = 1,
                RedniBroj = 2,
                VjezbaId = 2
            });
            modelBuilder.Entity<DanSet>().HasData(new DanSet
            {
                Id = 3,
                DanId = 2,
                RedniBroj = 1,
                VjezbaId = 1
            });
            modelBuilder.Entity<DanSet>().HasData(new DanSet
            {
                Id = 4,
                DanId = 3,
                RedniBroj = 1,
                VjezbaId = 3
            });
            modelBuilder.Entity<DanSet>().HasData(new DanSet
            {
                Id = 5,
                DanId = 4,
                RedniBroj = 1,
                VjezbaId = 3
            });
            modelBuilder.Entity<DanSet>().HasData(new DanSet
            {
                Id = 6,
                DanId = 5,
                RedniBroj = 1,
                VjezbaId = 2
            });
            modelBuilder.Entity<DanSet>().HasData(new DanSet
            {
                Id = 7,
                DanId = 6,
                RedniBroj = 1,
                VjezbaId = 1
            });
            modelBuilder.Entity<DanSet>().HasData(new DanSet
            {
                Id = 8,
                DanId = 7,
                RedniBroj = 1,
                VjezbaId = 3
            });

            //Set
            modelBuilder.Entity<SetVjezba>().HasData(new SetVjezba
            {
                Id = 1,
                DanSetId = 1,
                RedniBroj = 1,
                BrojPonavljanja = 10,
                TrajanjeOdmora = 45
            });
            modelBuilder.Entity<SetVjezba>().HasData(new SetVjezba
            {
                Id = 2,
                DanSetId = 1,
                RedniBroj = 2,
                BrojPonavljanja = 10,
                TrajanjeOdmora = 35
            });
            modelBuilder.Entity<SetVjezba>().HasData(new SetVjezba
            {
                Id = 3,
                DanSetId = 2,
                RedniBroj = 1,
                BrojPonavljanja = 10,
                TrajanjeOdmora = 45
            });
            modelBuilder.Entity<SetVjezba>().HasData(new SetVjezba
            {
                Id = 4,
                DanSetId = 2,
                RedniBroj = 2,
                BrojPonavljanja = 12,
                TrajanjeOdmora = 60
            });
            modelBuilder.Entity<SetVjezba>().HasData(new SetVjezba
            {
                Id = 5,
                DanSetId = 3,
                RedniBroj = 1,
                BrojPonavljanja = 10,
                TrajanjeOdmora = 45
            });
            modelBuilder.Entity<SetVjezba>().HasData(new SetVjezba
            {
                Id = 6,
                DanSetId = 3,
                RedniBroj = 2,
                BrojPonavljanja = 10,
                TrajanjeOdmora = 45
            });
            modelBuilder.Entity<SetVjezba>().HasData(new SetVjezba
            {
                Id = 7,
                DanSetId = 4,
                RedniBroj = 1,
                BrojPonavljanja = 10,
                TrajanjeOdmora = 45
            });
            modelBuilder.Entity<SetVjezba>().HasData(new SetVjezba
            {
                Id = 8,
                DanSetId = 4,
                RedniBroj = 2,
                BrojPonavljanja = 10,
                TrajanjeOdmora = 45
            });
            modelBuilder.Entity<SetVjezba>().HasData(new SetVjezba
            {
                Id = 9,
                DanSetId = 5,
                RedniBroj = 1,
                BrojPonavljanja = 10,
                TrajanjeOdmora = 45
            });
            modelBuilder.Entity<SetVjezba>().HasData(new SetVjezba
            {
                Id = 10,
                DanSetId = 5,
                RedniBroj = 2,
                BrojPonavljanja = 10,
                TrajanjeOdmora = 45
            });
            modelBuilder.Entity<SetVjezba>().HasData(new SetVjezba
            {
                Id = 11,
                DanSetId = 6,
                RedniBroj = 1,
                BrojPonavljanja = 10,
                TrajanjeOdmora = 45
            });
            modelBuilder.Entity<SetVjezba>().HasData(new SetVjezba
            {
                Id = 12,
                DanSetId = 6,
                RedniBroj = 2,
                BrojPonavljanja = 10,
                TrajanjeOdmora = 45
            });
            modelBuilder.Entity<SetVjezba>().HasData(new SetVjezba
            {
                Id = 13,
                DanSetId = 7,
                RedniBroj = 1,
                BrojPonavljanja = 10,
                TrajanjeOdmora = 45
            });
            modelBuilder.Entity<SetVjezba>().HasData(new SetVjezba
            {
                Id = 14,
                DanSetId = 7,
                RedniBroj = 2,
                BrojPonavljanja = 10,
                TrajanjeOdmora = 45
            });
            modelBuilder.Entity<SetVjezba>().HasData(new SetVjezba
            {
                Id = 15,
                DanSetId = 8,
                RedniBroj = 1,
                BrojPonavljanja = 10,
                TrajanjeOdmora = 45
            });
            modelBuilder.Entity<SetVjezba>().HasData(new SetVjezba
            {
                Id = 16,
                DanSetId = 8,
                RedniBroj = 2,
                BrojPonavljanja = 10,
                TrajanjeOdmora = 45
            });
        }
    }
}
