using System;
using System.Collections.Generic;
using System.Text;

namespace Tomaval_Lectura.Models
{
    public class UnitValuesResponse
    {
        private string _name;
        private string _unitGuid;
        private List<values> _values;

        public string name { get => _name; set => _name = value; }
        public string unitGuid { get => _unitGuid; set => _unitGuid = value; }
        public List<values> values { get => _values; set => _values = value; }
    }

    public class values
    {
        private string Name;
        private string ValueGuid;
        private string Value;
        private string Unit;
        private string HighLimit;
        private string LowLimit;
        private string DecimalPlaces;
        private string Timestamp;

        public string name { get => Name; set => Name = value; }
        public string valueGuid { get => ValueGuid; set => ValueGuid = value; }
        public string value { get => Value; set => Value = value; }
        public string unit { get => Unit; set => Unit = value; }
        public string highLimit { get => HighLimit; set => HighLimit = value; }
        public string lowLimit { get => LowLimit; set => LowLimit = value; }
        public string decimalPlaces { get => DecimalPlaces; set => DecimalPlaces = value; }
        public string timestamp { get => Timestamp; set => Timestamp = value; }
    }
}
