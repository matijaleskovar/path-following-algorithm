using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PathFollowingAlgorithm.Helpers.Enums;

namespace PathFollowingAlgorithm.Models
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Value { get; set; }
        public Direction LastDirection { get; set; }
    }
}
