using DrawShape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrawShape.Models
{
    public class Triangle : IShape
    {
        private static Random random = new Random();
        public string ShapeCode {
            get
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                return new string(Enumerable.Repeat(chars, 1)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            set
            {

            }
        }
        public string ShapeType { get; set; }
        public string ShapeName { get; set; }
        public int ShapeLength
        {
            get
            {
                return 140;
            }
        }
    }
}