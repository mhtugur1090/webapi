using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SahinKereste.DbContext;
using SahinKereste.Entity;
using SahinKereste.Repostories;
using SahinKereste.TestData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SahinKereste
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


            services.AddCors(options => {

                options.AddPolicy(name: "MyAllowedSpecificOrigins",
                    builder => {
                        builder.WithOrigins("https://sahinkereste.store")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader();//WithHeaders("*");// AllowAnyHeader();
                    });
            });



            services.AddControllers();
            services.AddIdentity<User,Role>().AddEntityFrameworkStores<DataContext>();
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("uzakDb")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

            services.Configure<IdentityOptions>(options => {
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false; //özel karakterlerden en az 1 i olacak
                options.Password.RequiredLength = 6;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-. _ @ +";
                options.User.RequireUniqueEmail = false; // Ayný maile ait kullanýcý olmayacak demektir.
            });
            


            //::::::::::::TOKEN VALÝDATE:::::::::::::::::

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = false; //Token isteði sadece https den gelenlerden mi gelsin 
                    x.SaveToken = true; // Token bilgisi server da kaydedilsin mi?
                    x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Secret").Value)),
                       ValidateIssuer = false,//Token ý kim yazmýþ onun bilgisi kontrol edilsin mi ?
                        ValidateAudience = false //Bu token bilgisini hangi firmalar için oluþturulmuþ kontrol edilsin mi ?
                    };
               });


            //:::::::::::::: File upload options::::::::::

            services.Configure<FormOptions>(o=> 
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<User> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed(userManager).Wait();
                
            }

            
            app.UseHttpsRedirection();
            app.UseRouting();

            //::::::::::::Upload Ettiðimiz resimleri/dosyalarý clientlara açmak ::::::::::::::
            app.UseStaticFiles();// File upload için static dosya kullanmayý aktif ettik
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),@"Resources")),
                RequestPath = new PathString("/Resources")
            });
            //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::


            app.UseCors("MyAllowedSpecificOrigins");

            app.UseAuthentication();// Mutlaka UseAuthorization'ýn üzerinde olacak
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
