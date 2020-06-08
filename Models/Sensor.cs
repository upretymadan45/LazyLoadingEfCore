using System;
using System.Collections.Generic;

namespace LazyLoading.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public string SensorName { get; set; }
        public string SensorType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual List<Reading> Readings { get; set; } = new List<Reading>();
    }
}
