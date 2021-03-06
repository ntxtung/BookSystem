using System.Text;
using BookSystem.Application.UseCase.Authentication;
using BookSystem.Application.UseCase.BookManagement;
using BookSystem.Application.UseCase.BookReview;
using BookSystem.Application.UseCase.FundBook;
using BookSystem.Application.UseCase.RentBookManagement;
using BookSystem.Application.UseCase.RequestBookManagement;
using BookSystem.Application.UseCase.UserAccount;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BookSystem.WebApi {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddCors();
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            // Add JWT Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
//            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "AngularClientApp/dist"; });

            // Dependency Injection
            services.AddScoped<IAuthenticationServices, AuthenticationServices>();
            services.AddScoped<IBookManagementServices, BookManagementServices>();
            services.AddScoped<IBookReview, BookReviewServices>();
            services.AddScoped<IFundBookServices, FundBookServices>();
            services.AddScoped<IRentBookManagementServices, RentBookManagementServices>();
            services.AddScoped<IRequestBookManagementServices, RequestBookManagementServices>();
            services.AddScoped<IUserAccountServices, UserAccountServices>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc();

            app.UseSpa(spa => {
                 spa.Options.SourcePath = "ClientApp";
                 if (env.IsDevelopment()) {
                     spa.UseReactDevelopmentServer("start");
                 }

//               spa.Options.SourcePath = "AngularClientApp";
//                if (env.IsDevelopment()) {
//                    spa.UseAngularCliServer("start");
//                }
            });
        }
    }
}