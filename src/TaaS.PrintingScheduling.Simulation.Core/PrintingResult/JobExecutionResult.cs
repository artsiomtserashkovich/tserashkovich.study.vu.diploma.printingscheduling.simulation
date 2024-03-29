﻿using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TaaS.PrintingScheduling.Simulation.Core.Specifications;

namespace TaaS.PrintingScheduling.Simulation.Core.PrintingResult
{
    public class JobExecutionResult<TTime> where TTime : struct
    {
        public JobExecutionResult(
            JobSpecification<TTime> job, 
            PrinterSpecification printer,
            TimeSlot<TTime> scheduledTime, 
            TimeSlot<TTime> executionTime)
        {
            Job = job;
            Printer = printer;
            ScheduledTime = scheduledTime;
            ExecutionTime = executionTime;
        }
        
        [JsonPropertyName("job")]
        public JobSpecification<TTime> Job { get; }
        
        [JsonPropertyName("printer")]
        public PrinterSpecification Printer { get; }

        [JsonPropertyName("scheduleTimeSlot")]
        public TimeSlot<TTime> ScheduledTime { get; }
        
        [JsonPropertyName("executionTimeSlot")]
        public TimeSlot<TTime> ExecutionTime { get; }
    }
}