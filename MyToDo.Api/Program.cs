using AutoMapper;
using GZY.Quartz.MUI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyToDo.Api.Extensions;
using MyToDo.Api.Models;
using MyToDo.Api.Services;
using MyToDo.Api.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        //设置时间格式
        options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
        //设置本地时间而非UTC时间
        options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
    });

builder.Services.AddEndpointsApiExplorer();

//项目→右键→属性→生成→输出→勾选“文档文件”
builder.Services.AddSwaggerGen(c =>
{
    //获取xml文件名
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //获取xml文件路径
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //是否显示注释
    c.IncludeXmlComments(xmlPath, true);

});

builder.Services.AddTransient<IToDoService, ToDoService>();
builder.Services.AddTransient<IMemoService, MemoService>();
builder.Services.AddTransient<ILoginService, LoginService>();

//添加AutoMapper
var automapperconfig = new MapperConfiguration(config => { config.AddProfile(new AutoMapperProFile()); });
builder.Services.AddSingleton(automapperconfig.CreateMapper());


//Sqlsugar框架,使用 SqlsugarSetup.cs 需要用到
builder.Services.AddSqlsugarSetup();

builder.Services.AddQuartzUI();
builder.Services.AddQuartzClassJobs(); //添加本地调度任务访问


builder.Services.Configure<EmailOptions>(
    builder.Configuration.GetSection(EmailOptions.Email));



var app = builder.Build();

app.UseQuartz();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

//app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
