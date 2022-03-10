using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repositories;
using Services;
using Services.Converters;
using Services.RepositoryDeclaration;
using Services.ServiceDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BookingApi
{
    // Ключ для создания подписи (приватный)
    public interface IJwtSigningEncodingKey
    {
        string SigningAlgorithm { get; }

        SecurityKey GetKey();
    }

    // Ключ для проверки подписи (публичный)
    public interface IJwtSigningDecodingKey
    {
        SecurityKey GetKey();
    }

    public class SigningSymmetricKey : IJwtSigningEncodingKey, IJwtSigningDecodingKey
    {
        private readonly SymmetricSecurityKey _secretKey;

        public string SigningAlgorithm { get; } = SecurityAlgorithms.HmacSha256;

        public SigningSymmetricKey(string key)
        {
            this._secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }

        public SecurityKey GetKey() => this._secretKey;
    }



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
            const string signingSecurityKey = "0d5b3235a8b403c3dab9c3f4f65c07fcalskd234n1k41230";
            var signingKey = new SigningSymmetricKey(signingSecurityKey);
            services.AddSingleton<IJwtSigningEncodingKey>(signingKey);

            services.AddControllers();

            const string jwtSchemeName = "Bearer";
            var signingDecodingKey = (IJwtSigningDecodingKey)signingKey;
            services
                .AddAuthentication(options => 
                {
                    options.DefaultAuthenticateScheme = jwtSchemeName;
                    options.DefaultChallengeScheme = jwtSchemeName;
                })
                .AddJwtBearer(jwtSchemeName, jwtBearerOptions => 
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingDecodingKey.GetKey(),

                        ValidateIssuer = true,
                        ValidIssuer = "DomaApp",

                        ValidateAudience = true,
                        ValidAudience = "DomaAppClient",

                        ValidateLifetime = true,

                        ClockSkew = TimeSpan.FromSeconds(5)
                    };
                });


            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "Main API v1.0", Version = "v1.0" });
                c.AddSecurityDefinition(jwtSchemeName, new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer 1234567890\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    { jwtSchemeName , new string[] { }},
                };

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = jwtSchemeName
                            }
                        },
                        new string[]{}
                    }
                });
            });


            services.AddSingleton<IConfiguration>(Configuration);

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

#if DEBUG
            // это нужно для интерпретации IQueriable.Skip в SQL Server 2008
            services.AddDbContext<BookingDatabaseContext>(options =>
                options.UseSqlServer(connectionString)
                .ReplaceService<IQueryTranslationPostprocessorFactory, SqlServer2008QueryTranslationPostprocessorFactory>());
#else
            services.AddDbContext<BookingDatabaseContext>(options =>
                options.UseSqlServer(connectionString));
#endif

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
            services.AddScoped<ICommodityRepository, CommodityRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IHotelOptionRepository, HotelOptionRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IRoomCategoryRepository, RoomCategoryRepository>();
            services.AddScoped<IRoomPhotoRepository, RoomPhotoRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ISupportRequestRepository, SupportRequestRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IChatMessageService, ChatMessageService>();
            services.AddScoped<ICommodityService, CommodityService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IHotelOptionService, HotelOptionService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IRoomCategoryService, RoomCategoryService>();
            services.AddScoped<IRoomPhotoService, RoomPhotoService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<ISupportRequestService, SupportRequestService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IEntityViewModelConverter<BookingViewModel, Booking>, BookingConverter>();
            services.AddScoped<IEntityViewModelConverter<ChatMessageViewModel, ChatMessage>, ChatMessageConverter>();
            services.AddScoped<IEntityViewModelConverter<CommodityViewModel, Commodity>, CommodityConverter>();
            services.AddScoped<IEntityViewModelConverter<EmployeeViewModel, Employee>, EmployeeConverter>();
            services.AddScoped<IEntityViewModelConverter<FeedbackViewModel, Feedback>, FeedbackConverter>();
            services.AddScoped<IEntityViewModelConverter<HotelOptionViewModel, HotelOption>, HotelOptionConverter>();
            services.AddScoped<IEntityViewModelConverter<HotelViewModel, Hotel>, HotelConverter>();
            services.AddScoped<IEntityViewModelConverter<NotificationViewModel, Notification>, NotificationConverter>();
            services.AddScoped<IEntityViewModelConverter<RoomCategoryViewModel, RoomCategory>, RoomCategoryConverter>();
            services.AddScoped<IEntityViewModelConverter<RoomPhotoViewModel, RoomPhoto>, RoomPhotoConverter>();
            services.AddScoped<IEntityViewModelConverter<RoomViewModel, Room>, RoomConverter>();
            services.AddScoped<IEntityViewModelConverter<SupportRequestViewModel, SupportRequest>, SupportRequestConverter>();
            services.AddScoped<IEntityViewModelConverter<UserViewModel, User>, UserConverter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            app.UseHttpsRedirection();
            //app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
            app.UseSwaggerUI();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}");
            });
        }
    }
}
