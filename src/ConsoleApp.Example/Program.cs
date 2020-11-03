using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Xfrogcn.PluginFactory;

namespace ConsoleApp.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);

            builder.UsePluginFactory();

            var host = builder.Build();

            //// 手动启动
            //IServiceProvider provider = host.Services;
            //var pluginFactory = provider.GetRequiredService<IPluginFactory>();
            //await pluginFactory.StartAsync(default);
            //await pluginFactory.StopAsync(default);

            await host.StartAsync();

            Console.WriteLine("已启动, 输入q回车退出");

            while (true)
            {
                String cmd = Console.ReadLine();
                if (cmd == "q")
                {
                    await host.StopAsync();
                    host.Dispose();
                    break;
                }
            }
        }
    }
}
