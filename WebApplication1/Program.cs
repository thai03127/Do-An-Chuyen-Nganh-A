using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Data;
using System.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using WebApplication1.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WebApplication1.DAL;


var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("DefaultContext") ?? throw new InvalidOperationException("Connection string 'WebApp1ContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HotelDatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultContext")));
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultContext")));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDBContext>();

// Register the repository
builder.Services.AddScoped<ITypeRoomRepository, TypeRoomRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<ITienNghiRepository, TienNghiRepository>();
////-----------------------Identity--------------------
//// Đăng ký các dịch vụ của Identity
//builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<HotelDatabaseContext>().AddDefaultTokenProviders();

//// Truy cập IdentityOptions
builder.Services.Configure<IdentityOptions>(options =>
{
    // Thiết lập về Password
    options.Password.RequireDigit = true; // Không bắt phải có số
    options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
    options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
    options.Password.RequireUppercase = true; // Không bắt buộc chữ in
    options.Password.RequiredLength = 8; // Số ký tự tối thiểu của password
    options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

    // Cấu hình Lockout - khóa user
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
    options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
    options.Lockout.AllowedForNewUsers = true;

    // Cấu hình về User.
    options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true; // Email là duy nhất

    // Cấu hình đăng nhập.
    options.SignIn.RequireConfirmedEmail = false; // Cấu hình xác thực địa chỉ email (email phải tồn tại)
    options.SignIn.RequireConfirmedPhoneNumber = false; // Xác thực số điện thoại

});

//// Cấu hình Cookie
//builder.Services.ConfigureApplicationCookie(options => {
//    // options.Cookie.HttpOnly = true;  
//    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
//    options.LoginPath = $"/login/";                                 // Url đến trang đăng nhập
//    options.LogoutPath = $"/logout/";
//    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";   // Trang khi User bị cấm truy cập
//});
//builder.Services.Configure<SecurityStampValidatorOptions>(options =>
//{
//    // Trên 5 giây truy cập lại sẽ nạp lại thông tin User (Role)
//    // SecurityStamp trong bảng User đổi -> nạp lại thông tinn Security
//    options.ValidationInterval = TimeSpan.FromSeconds(5);
//});
//app.UseAuthentication();   // Phục hồi thông tin đăng nhập (xác thực)
//app.UseAuthorization();   // Phục hồi thông tinn về quyền của User


////--------Identity.END-----------

////-----------SendMail-----------
//builder.Services.AddOptions();                                        // Kích hoạt Options
//var mailsettings = builder.Configuration.GetSection("MailSettings");  // đọc config
//builder.Services.Configure<MailSettings>(mailsettings);               // đăng ký để Inject

//builder.Services.AddTransient<IEmailSender, SendMailService>();
////-----------SendMail.END-----------


////------------------------------Policy------------------------------------------------
////  Tạo ra Policy có tên MyPolicy1 - những User có Role là Vip thì thỏa mãn policy này
//    // policy kiểu AuthorizationPolicyBuilder, có các phương thức để thêm yêu cầu như:
//    // RequireClaim - User phải có Claim nào đó
//    // RequireRole  - User phải có Role nào đó
//    // RequireUserName - User phải có tên chỉ ra
//    // AddRequirements ...
//builder.Services.AddAuthorization(options =>
//{

//    options.AddPolicy("MyPolicy1", policy => {
//        policy.RequireRole("Vip");
//    });

//    options.AddPolicy("CanViewTest", policy => {
//        policy.RequireRole("VipMember", "Editor");
//    });
//    options.AddPolicy("CanView", policy => {
//        policy.RequireRole("Editor");
//        policy.RequireClaim("permision", "post.view");
//    });
//});

//builder.Services.AddAuthorization(options =>
//{
//    // User thỏa mãn policy khi có roleclaim: permission với giá trị manage.user
//    options.AddPolicy("AdminDropdown", policy => {
//        policy.RequireClaim("permission", "manage.user");
//    });

//});

// options.AddPolicy ... tiếp tục tạo ra các Policy khác
//------------------------------Policy.END---------------------------------


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.Run();


