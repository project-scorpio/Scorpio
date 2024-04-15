using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scorpio.Auditing
{
    /// <summary>
    /// 
    /// </summary>
    public class AuditActionInfo
    {

        /// <summary>
        /// 
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Parameters { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ExecutionTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TimeSpan ExecutionDuration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, object> ExtraProperties { get; }

        /// <summary>
        /// 
        /// </summary>
        public AuditActionInfo() => ExtraProperties = new Dictionary<string, object>();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"  - {ExecutionTime} {ServiceName}.{MethodName} ({ExecutionDuration} ms.)");
            sb.AppendLine($"    {Parameters}");
            if (ExtraProperties.Any())
            {
                foreach (var property in ExtraProperties)
                {
                    sb.AppendLine($"    - {property.Key,-20}: {property.Value}");
                }
            }
            return sb.ToString();
        }
    }
}