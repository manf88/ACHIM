﻿using Raspberry.IO.GeneralPurpose;
using System;

namespace ACHIM.Positioning
{
    public class StopSwitch : IStopSwitch
    {
        #region private members

        private GpioConnection _connection;

        private GpioConnectionSettings _settings;

        private InputPinConfiguration _pinConfiguration;

        #endregion

        #region properties

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
            _pinConfiguration = Pin.Input().OnStatusChanged(s => {
                RaiseOnPressedEvent(null);  
            });
            _connection = new GpioConnection(_pinConfiguration);
        }
    }
}