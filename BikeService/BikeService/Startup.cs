using BikeService.Data;
using BikeService.Helpers;
using BikeService.Models;
using BikeService.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

namespace BikeService;

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

        //Swagger --------------------------------------
        services.AddSwaggerGen();

        //Mapper --------------------------------------
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped <IAreaService, AreaService>();
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
            option.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
        });
        services.AddEndpointsApiExplorer();


        //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddScheme<AuthenticationSchemeOptions, 
        //    FirebaseAuthenticationHandler>(JwtBearerDefaults.AuthenticationScheme, o => { });

        //Authent get JWT String --------------------------------------
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
        {
            option.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            };
        });

        // Add Cors --------------------------------------
        //services.AddCors();
        services.AddCors(p => p.AddPolicy("corspolicy", build =>
        {
            build.WithOrigins("https://localhost:64391", "http://localhost:64392").AllowAnyMethod().AllowAnyHeader();
        }));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app
            .UseSwagger()
            .UseSwaggerUI(setup =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(setup.RoutePrefix) ? "." : "..";
                setup.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Version 1.0");
                setup.OAuthAppName("Lambda Api");
                setup.OAuthScopeSeparator(" ");
                setup.OAuthUsePkce();
            });
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseDeveloperExceptionPage();
        {
            app.UseCors(x => x
            .AllowAnyOrigin()
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
}