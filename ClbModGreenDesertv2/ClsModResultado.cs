using System;
using System.Collections.Generic;
using System.Text;

namespace ClbModGreenDesertv2
{
    public class ClsModResultado
    {
        public int Id { get; set; }
        public string MsgError { get; set; }
        public bool Error { get { return !String.IsNullOrEmpty(MsgError); } }
    }
}
