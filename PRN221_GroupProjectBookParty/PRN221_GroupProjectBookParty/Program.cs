using BO;
using PartyRepository;
using PartyService;
using PartyService.BlogPosts;
using PartyService.Helpers;
using PartyService.PhotoUpload;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddScoped<IBlogPostRepo, BlogPostRepo>();
builder.Services.AddScoped<IBlogPostService, BlogPostService>();

builder.Services.AddScoped<IBookingRepo, BookingRepo>();
builder.Services.AddScoped<IBookingService, BookingService>();

builder.Services.AddScoped<IFeedBackRepo, FeedBackRepo>();
builder.Services.AddScoped<IFeedBackService, FeedBackService>();

builder.Services.AddScoped<IPartyRepo, PartyRepo>();
builder.Services.AddScoped<IPartysService, PartysService>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(300);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddControllers();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<BookingPartyContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapRazorPages();
app.MapControllers();
app.Run();
