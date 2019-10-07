using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawShape.Interfaces
{
    public interface IShape
    {
        string ShapeCode { get; set; }
        string ShapeType { get; set; }
        string ShapeName { get; set; }
    }
}
