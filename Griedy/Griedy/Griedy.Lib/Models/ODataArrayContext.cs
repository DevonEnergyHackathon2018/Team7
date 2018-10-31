using System.Collections.Generic;

namespace Griedy.Lib.Models
{
    public class ODataArrayContext<T>
    {
        public List<T> value { get; set; }
    }
}
