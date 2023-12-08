using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMio
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ServerCodeAttribute : Attribute
    {
        public ServerCodeAttribute(string code)
        {
            ServerCode = code;
        }

        public string ServerCode { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class ServerTitleAttribute : Attribute
    {
        public ServerTitleAttribute(string code)
        {
            ServerTitle = code;
        }

        public string ServerTitle { get; private set; }
    }


    [AttributeUsage(AttributeTargets.Field)]
    public class ErrorStatusAttribute : Attribute
    {
        public ErrorStatusAttribute(ErrorStatus type)
        {
            ErrorStatus = type;
        }

        public ErrorStatus ErrorStatus { get; private set; }
    }
}
