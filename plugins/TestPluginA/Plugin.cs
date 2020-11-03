using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Xfrogcn.PluginFactory;

namespace TestPluginA
{
    [Plugin(Alias = "PluginA", Description = "测试插件")]
    public class Plugin : SupportConfigPluginBase<PluginOptions>, ISupportInitPlugin
    {

        public Plugin(IOptionsMonitor<PluginOptions> options) : base(options)
        {
        }

        public void Init(IPluginInitContext context)
        {
            // 注入服务
            //context.ServiceCollection.TryAddScoped<ICustomerService>();
            Console.WriteLine($"Init 插件配置：{Options.TestConfig}");
        }

        public override Task StartAsync(IPluginContext context)
        {
            Console.WriteLine("插件A已启动");
            Console.WriteLine($"StartAsync 插件配置：{Options.TestConfig}");
            return base.StartAsync(context);
        }

        public override Task StopAsync(IPluginContext context)
        {
            Console.WriteLine("插件B已停止");
            return base.StopAsync(context);
        }
    }
}
