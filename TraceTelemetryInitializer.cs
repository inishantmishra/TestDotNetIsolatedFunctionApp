using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace TestFuntionApp;

public sealed class TraceTelemetryInitializer : ITelemetryInitializer
{
    public void Initialize(ITelemetry telemetry)
    {
        if (telemetry is ISupportProperties propItem && propItem.Properties.TryGetValue("NoSample", out string? value) && propItem.Properties["NoSample"] == "True")
        {
            if (telemetry is TraceTelemetry)
            {
                var trace = telemetry as TraceTelemetry;
                if (trace is not null)
                {
                    trace.ProactiveSamplingDecision = SamplingDecision.SampledOut;
                    ((ISupportSampling)trace).SamplingPercentage = 100;
                }
            }
            else if (telemetry is ExceptionTelemetry)
            {
                var trace = telemetry as ExceptionTelemetry;
                if (trace is not null)
                {
                    trace.ProactiveSamplingDecision = SamplingDecision.SampledOut;
                    ((ISupportSampling)trace).SamplingPercentage = 100;
                }
            }
        }
    }
}
