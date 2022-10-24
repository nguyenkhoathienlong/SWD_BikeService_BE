using BikeService.Data;
using BikeService.Helpers;
using BikeService.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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
        //services.AddSwaggerGen();

        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
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
            option.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
        });
        services.AddEndpointsApiExplorer();


        //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddScheme<AuthenticationSchemeOptions, 
        //    FirebaseAuthenticationHandler>(JwtBearerDefaults.AuthenticationScheme, o => { });

        //Authent get JWT String --------------------------------------
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"]
                    };
                });

        // Add Cors --------------------------------------
        //services.AddCors();
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
        app.UseAuthentication();
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
}