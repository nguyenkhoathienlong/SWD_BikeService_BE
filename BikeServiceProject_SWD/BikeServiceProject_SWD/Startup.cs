using BikeServiceProject_SWD.Data;
using BikeServiceProject_SWD.Helpers;
using BikeServiceProject_SWD.Service;
using FirebaseAdmin;
using FirebaseAdminAuthentication.DependencyInjection.Extensions;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Collections;

namespace BikeServiceProject_SWD;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Bike Service Project API", Version = "1.0" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
        });

        //Mapper --------------------------------------
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IAreaService, AreaService>();
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IDistrictService, DistrictService>();
        services.AddScoped<IManufacturerService, ManufacturerService>();
        services.AddScoped<IModelService, ModelService>();
        services.AddScoped<IMotorbikeService, MotorbikeService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderDetailService, OrderDetailService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IPaymentMethodService, PaymentMethodService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IStoreService, StoreService>();
        services.AddScoped<IWardService, WardService>();

        //Connect DB --------------------------------------
        services.AddDbContext<MyDbContext>(option =>
        {
            option.UseMySql(Configuration.GetConnectionString("Connectionn"),
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
        });
        services.AddEndpointsApiExplorer();

        //Firebase Authentication ------------------------------------------
        services.AddSingleton(FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.GetApplicationDefault(),
            ServiceAccountId = "firebase-adminsdk-2ut09@bike-service-c602d.iam.gserviceaccount.com",
        }));
        services.AddFirebaseAuthentication();

        // Add Cors --------------------------------------
        services.AddCors(p => p.AddPolicy("corspolicy", build =>
        {
            build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
        }));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseDeveloperExceptionPage();
        {
            app.UseCors(x => x
            .WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseCors("corspolicy");
            //global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to My Bike Service");
            });
        });
    }


    //dotnet ef dbcontext scaffold Name=Connectionn Pomelo.EntityFrameworkCore.MySql --output-dir Models --context-dir Data --namespace BikeServiceProject_SWD.Models --context-namespace BikeServiceProject_SWD.Data --context MyDbContext -f --no-onconfiguring
}