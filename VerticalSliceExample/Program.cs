global using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VerticalSliceExample.Features.ExampleFeature;
using VerticalSliceExample.Shared.Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options => options.RootDirectory = "/Shared/Pages");
builder.Services.AddServerSideBlazor();

// Add features to the container.
builder.AddExampleFeatureFeature();

builder.Services.AddMediatR(typeof(Program));

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
