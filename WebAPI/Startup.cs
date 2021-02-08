using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Model.Requests;
using Org.BouncyCastle.Crypto.Modes;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebAPI.Database;
using WebAPI.Filters;
using WebAPI.Mail;
using WebAPI.Security;
using WebAPI.Services;

namespace WebAPI
{
    public class Startup
    {
   
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAutoMapper();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        new string[] {}
                    }
                });
            });
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);


            services.AddDbContext<RS2Context>(x => x.UseSqlServer(Configuration.GetConnectionString("local")));

            services.AddScoped<IKorisnikService, KorisnikService>();
            services.AddScoped<IService<Model.Korisnik, object>, BaseService<Model.Korisnik, object, Database.Korisnik>>();
            services.AddScoped<ICRUDService<Model.TipClanarine, TipClanarineSearchRequest, TipClanarineInsertRequest, TipClanarineInsertRequest>, TipClanarineService>();
            services.AddScoped<ICRUDService<Model.Clanarina, ClanarinaSearchRequest, ClanarinaInsertRequest, Model.Clanarina>, ClanarinaService>();
            services.AddScoped<ICRUDService<Model.PrisutnostClana, PrisutnostClanaSearchRequest, PrisutnostClanaInsertRequest, object>, PrisutnostClanaService>();
            services.AddScoped<ICRUDService<Model.Misic, MisicSearchRequest, MisicInsertRequest, Model.Misic>, MisicService>();
            services.AddScoped<ICRUDService<Model.Vjezba, VjezbaSearchRequest, VjezbaInsertRequest, VjezbaInsertRequest>, VjezbaService>();
            services.AddScoped<ICRUDService<Model.PlanIProgram, PlanIProgramSearchRequest, PlanIProgramInsertRequest, PlanIProgramUpdateRequest>, PlanIProgramService>();
            services.AddScoped<ICRUDService<Model.PlanKategorija, PlanKategorijaSearchRequest, PlanKategorijaInsertRequest, Model.PlanKategorija>, PlanKategorijaService>();
            services.AddScoped<ICRUDService<Model.Dan, DanSearchRequest, DanInsertRequest, object>, DanService>();
            services.AddScoped<ICRUDService<Model.DanSet, DanSetSearchRequest, DanSetInsertRequest, object>, DanSetService>();
            services.AddScoped<ICRUDService<Model.SetVjezba, SetVjezbaSearchRequest, SetVjezbaInsertRequest, object>, SetVjezbaService>();
            services.AddScoped<ICRUDService<Model.Ocjena, Model.Requests.OcjenaSearchRequest, OcjenaInsertRequest, object>, OcjenaService>();
            services.AddScoped<ICRUDService<Model.Komentar, KomentarSearchRequest, KomentarInsertRequest, object>, KomentarService>();
            services.AddScoped<ICRUDService<Model.TjelesniDetalji, TjelesniDetaljiSearchRequest, TjelesniDetaljiInsertRequest, object>, TjelesniDetaljiService>();
            services.AddScoped<ICRUDService<Model.KorisnikPlan, KorisnikPlanSearchRequest, KorisnikPlanInsertRequest, object>, KorisnikPlanService>();
            services.AddScoped<IRecommender, RecommenderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseAuthentication();
            //app.UseHttpsRedirection();
            app.UseMvc();
           
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
