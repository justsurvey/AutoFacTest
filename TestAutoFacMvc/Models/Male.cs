using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAutoFacMvc.Models
{
    public class Male : IPerson
    {
        public string Talk()
        {
            return "开心地谈着什么。。。";
        }
    }
}