using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMio
{
    public interface IKeypad : IDisposable
    {
        event EventHandler<KeypadKeys> OnPressKeypadKey;
    }
}
