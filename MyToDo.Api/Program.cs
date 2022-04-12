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
        //����ʱ���ʽ
        options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
        //���ñ���ʱ�����UTCʱ��
        options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
    });

builder.Services.AddEndpointsApiExplorer();

//��Ŀ���Ҽ������ԡ����ɡ��������ѡ���ĵ��ļ���
builder.Services.AddSwaggerGen(c =>
{
    //��ȡxml�ļ���
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //��ȡxml�ļ�·��
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //�Ƿ���ʾע��
    c.IncludeXmlComments(xmlPath, true);

});

builder.Services.AddTransient<IToDoService, ToDoService>();
builder.Services.AddTransient<IMemoService, MemoService>();
builder.Services.AddTransient<ILoginService, LoginService>();

//���AutoMapper
var automapperconfig = new MapperConfiguration(config => { config.AddProfile(new AutoMapperProFile()); });
builder.Services.AddSingleton(automapperconfig.CreateMapper());


//Sqlsugar���,ʹ�� SqlsugarSetup.cs ��Ҫ�õ�
builder.Services.AddSqlsugarSetup();

builder.Services.AddQuartzUI();
builder.Services.AddQuartzClassJobs(); //��ӱ��ص����������


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
