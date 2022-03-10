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
using Repositories;
using Services;
using Services.Converters;
using Services.RepositoryDeclaration;
using Services.ServiceDeclaration;
using StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace BookingApi
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
            services.AddControllers();

            services.AddSwaggerGen();


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

            //app.UseAuthentication();
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
