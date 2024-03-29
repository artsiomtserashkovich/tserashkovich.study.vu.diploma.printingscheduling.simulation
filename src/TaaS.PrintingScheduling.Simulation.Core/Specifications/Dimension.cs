﻿using System;
using System.Runtime.Serialization;

namespace TaaS.PrintingScheduling.Simulation.Core.Specifications
{
    [DataContract]
    public struct Dimension
    {
        public Dimension(double x, double y, double z)
        {
            if (x <= 0)
            {
                throw new ArgumentException($"Can't be less or equal 0. Current value: '{x}'", nameof(x));
            }
            if (y <= 0)
            {
                throw new ArgumentException($"Can't be less or equal 0. Current value: '{y}'", nameof(y));
            }
            if (z <= 0)
            {
                throw new ArgumentException($"Can't be less or equal 0. Current value: '{z}'", nameof(z));
            }
            
            X = x;
            Y = y;
            Z = z;
        }
        
        public double X { get; }
        
        public double Y { get; }
        
        public double Z { get; }

        public double Volume => X * Y * Z;
        
        public override int GetHashCode() => (X, Y, Z).GetHashCode();
        
        public static bool operator !=(Dimension left, Dimension right)
        {
            return !(left == right);
        }
        
        public static bool operator ==(Dimension left, Dimension right)
        {
            return (left.X == right.X) && (left.Y == right.Y) && (left.Z == right.Z);
        }
        
        public static bool operator <(Dimension left, Dimension right)
        {
            return (left.X <= right.X) && (left.Y <= right.Y) && (left.Z <= right.Z) && left != right;
        }
        
        public static bool operator >(Dimension left, Dimension right)
        {
            return (left.X >= right.X) && (left.Y >= right.Y) && (left.Z >= right.Z) && left != right;
        }
        
        public bool Equals(Dimension other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        public override bool Equals(object obj)
        {
            return obj is Dimension other && Equals(other);
        }
    }
}