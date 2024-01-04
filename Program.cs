using HeathCare.DataBaseSettings;
using HeathCare.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configration to map admin  database setting to interface for dependancy injection
builder.Services.Configure<AdminDatabaseSettings>(
                builder.Configuration.GetSection(nameof(AdminDatabaseSettings)));

builder.Services.AddSingleton<IAdminDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<AdminDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("AdminDatabaseSettings:ConnectionString")));

// configration to map doctor  database setting to interface for dependancy injection
builder.Services.Configure<DoctorDatabaseSettings>(
                builder.Configuration.GetSection(nameof(DoctorDatabaseSettings)));

builder.Services.AddSingleton<IDoctorDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<DoctorDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("DoctorDatabaseSettings:ConnectionString")));

// configration to map patient  database setting to interface for dependancy injection 
builder.Services.Configure<PatientDatabaseSettings>(
                builder.Configuration.GetSection(nameof(PatientDatabaseSettings)));

builder.Services.AddSingleton<IPatientDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<PatientDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("PatientDatabaseSettings:ConnectionString")));

// configration to map appointment  database setting to interface for dependancy injection 
builder.Services.Configure<AppointmentDatabaseSettings>(
                builder.Configuration.GetSection(nameof(AppointmentDatabaseSettings)));

builder.Services.AddSingleton<IAppointmentDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<AppointmentDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("AppointmentDatabaseSettings:ConnectionString")));

// configration to map chat  database setting to interface for dependancy injectionn 
builder.Services.Configure<ChatDatabaseSettings>(
                builder.Configuration.GetSection(nameof(ChatDatabaseSettings)));

builder.Services.AddSingleton<IChatDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<ChatDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("ChatDatabaseSettings:ConnectionString")));

// configration to map post  database setting to interface for dependancy injectionn 
builder.Services.Configure<PostDatabaseSettings>(
                builder.Configuration.GetSection(nameof(PostDatabaseSettings)));

builder.Services.AddSingleton<IPostDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<PostDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("PostDatabaseSettings:ConnectionString")));



builder.Services.AddScoped<IPatientService, PatientService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
