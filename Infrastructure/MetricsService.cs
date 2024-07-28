using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using Prometheus;
using Microsoft.VisualBasic;

namespace Infrastructure
{
    public class MetricsService : BackgroundService
    {
        private readonly Gauge _cpuUsageGauge = Metrics.CreateGauge("cpu_usage_percent", "Porcentagem de uso da CPU");
        private readonly Gauge _memoryUsageGauge = Metrics.CreateGauge("memory_usage_bytes", "Bytes em uso da memória RAM");

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            var process = Process.GetCurrentProcess();

            while (!stoppingToken.IsCancellationRequested)
            {
                // Obter uso de CPU
                cpuCounter.NextValue();
                await Task.Delay(1000, stoppingToken); // Esperar um segundo para obter uma leitura precisa
                var cpuUsage = cpuCounter.NextValue();

                // Obter uso de memória
                var usedMemory = process.WorkingSet64 / (1024 * 1024);

                // Atualizar métricas
                _cpuUsageGauge.Set(cpuUsage);
                _memoryUsageGauge.Set(usedMemory);

                await Task.Delay(5000, stoppingToken); // Esperar 5 segundos antes da próxima coleta


            }
        }
    }
}
