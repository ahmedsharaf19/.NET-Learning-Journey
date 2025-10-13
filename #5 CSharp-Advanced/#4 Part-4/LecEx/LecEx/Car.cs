using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecEx
{
    internal class Car : IEquatable<Car>, IComparable<Car>
    {
        public Car(int code, string? model, decimal speed)
        {
            Code = code;
            Model = model;
            Speed = speed;
        }

        public int Code { get; set; }
        public string? Model { get; set; }
        public decimal Speed { get; set; }

        public override string ToString()
        {
            return $"{Code} :: {Model} :: {Speed}";
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(Code, Model, Speed);
        }

        public bool Equals(Car? other)
        {
            if (other is null) return false;
            return Code == other.Code && Model == other.Model && Speed == other.Speed;
        }

        public int CompareTo(Car? other)
        {
            if (other is null) return 1;
            return Code.CompareTo(other.Code);

        }
    }
}
