using Raspberry.IO.GeneralPurpose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACHIM.Positioning
{
    public class StopSwitch : IStopSwitch
    {
        #region private members

        private GpioConnection _connection;

        private GpioConnectionSettings _settings;

        private InputPinConfiguration _pinConfiguration;

        #endregion

        #region public members

        public ConnectorPin Pin { get; set; }

        public int Number { get; set; }

        #endregion

        #region event handler

        public event EventHandler OnPressed;

        public void RaiseOnPressedEvent(EventArgs e)
        {
            if (OnPressed != null) OnPressed(this, e);
        }

        #endregion

        public bool GetStatus
        {
            get { return _settings.Driver.Read(_pinConfiguration.Pin); }
        }

        public void Initialize()
        {
            _pinConfiguration = Pin.Input().Switch().OnStatusChanged(s => {
                RaiseOnPressedEvent(null);  
            });
            _connection = new GpioConnection(_pinConfiguration);
        }
    }
}