using Raspberry.IO.GeneralPurpose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACHIM.Positioning
{
    public interface IStopSwitch
    {
        int Number { get; set; }

        ConnectorPin Pin { get; set; }

        bool GetStatus { get; }

        void Initialize();

        event EventHandler OnPressed;

        void RaiseOnPressedEvent(EventArgs e);
    }
}