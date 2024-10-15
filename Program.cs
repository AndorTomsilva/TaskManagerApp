// See https://aka.ms/new-console-template for more information

using TaskManager.Service;
using Microsoft.Extensions.DependencyInjection;
using TaskManager;

var serviceProvider = new ServiceCollection()
    .AddSingleton<ITaskService, TaskService>()
    .AddSingleton<TaskManagerApp>()
    .BuildServiceProvider();

var taskService = serviceProvider.GetService<TaskManagerApp>();
taskService.Run();

