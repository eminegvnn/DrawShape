using DrawShape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrawShape.Models
{
    public class Rectangle : IShape
    {
        private static Random random = new Random();
        public string ShapeCode {
            get
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";   //Her şekil için random şekil kodu üretilir.
                return new string(Enumerable.Repeat(chars, 1)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            set
            {

            }
        }
        public string ShapeType { get; set; }
        public string ShapeName { get; set; }
        public int ShapeLength1
        {
            get
            {
                return 100;
            }
        }
        public int ShapeLength2
        {
            get
            {
                return 150;
            }
        }
    }
}