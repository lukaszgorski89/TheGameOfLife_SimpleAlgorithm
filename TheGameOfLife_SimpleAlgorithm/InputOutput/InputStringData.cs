using System.Collections.Generic;

namespace InputOutput
{
    public class InputStringData
    {
        public InputStringData()
        {
            Cells = new List<string>();
        }

        public string Height { get; set; }
        public string Width { get; set; }
        public string MoveCounter { get; set; }
        public List<string> Cells { get; set; }
    }
}
