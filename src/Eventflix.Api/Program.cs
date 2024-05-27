using Eventflix.Api.Application.Events.UseCases;
using Eventflix.Api.Application.Organizations.UseCases;
using Eventflix.Api.Application.Tickets.UseCases;
using Eventflix.Api.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseInMemoryDatabase("EventflixDb"));

builder.Services.AddCreateOrganization();
builder.Services.AddListOrganizations();
builder.Services.AddCreateEvent();
builder.Services.AddListOrganizationEvents();
builder.Services.AddListEvents();
builder.Services.AddCreateTicket();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseCreateOrganization();
app.UseListOrganizations();
app.UseCreateEvent();
app.UseListOrganizationEvents();
app.UseListEvents();
app.UseCreateTicket();

app.Run();
