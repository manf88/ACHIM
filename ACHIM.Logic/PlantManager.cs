using ACHIM.Logic.IoCBindings;
using ACHIM.Logic.Plants;
using ACHIM.Positioning;
using ACHIM.Positioning.MotorControl;
using ACHIM.PumpControl;
using Ninject;
using Raspberry.IO.GeneralPurpose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ACHIM.Logic
{
    public class PlantManager
    {
        private IKernel _kernel;

        private IMotorController _motorControl;

        private IPumpController _pump;

        private List<IStopSwitch> _switches;

        private Dictionary<IPlant, IStopSwitch> _plantSwitchDictionary;

        public List<IPlant> Plants;

        public PlantManager()
        {
            _plantSwitchDictionary = new Dictionary<IPlant, IStopSwitch>();   

            _kernel = new StandardKernel(new Bindings());
            _kernel.Load(Assembly.GetExecutingAssembly());

            _pump = _kernel.Get<IPumpController>();

            InitMotorControl();
            InitPlants();
            InitSwitches();
            SetRelations();
        }

        public void DoSomething(IPlant plant)
        {
            Console.WriteLine(String.Format("{0} has a soil moisture of {1}% and needs some water", plant.Name, plant.SoilMoisture));
        }

        private void InitPlants()
        {
            Plants = new List<IPlant>();

            var plant1 = _kernel.Get<IPlant>();
            plant1.Name = "Purple Tiger";
            plant1.Number = 1;
            plant1.ProperSoilMoisture = 40;
            plant1.OnNeedWater += DoSomething;

            Plants.Add(plant1);

            var plant2 = _kernel.Get<IPlant>();
            plant2.Name = "Jalapeno";
            plant2.Number = 2;
            plant2.ProperSoilMoisture = 30;
            plant2.OnNeedWater += DoSomething;

            Plants.Add(plant2);
        }

        private void InitSwitches()
        {
            _switches = new List<IStopSwitch>();

            var switch1 = _kernel.Get<IStopSwitch>();
            switch1.Pin = ConnectorPin.P1Pin08;
            switch1.Number = 1;
            switch1.Initialize();
            //_switches.Add(switch1);
            _motorControl.RegisterSwitch(switch1);

            var switch2 = _kernel.Get<IStopSwitch>();
            switch2.Pin = ConnectorPin.P1Pin18;
            switch2.Number = 2;
            switch2.Initialize();
            //_switches.Add(switch2);
            _motorControl.RegisterSwitch(switch2);
            
        }

        private void SetRelations()
        {
            foreach (var sswitch in _switches)
            {
                foreach (var plant in Plants)
                {
                    if (plant.Number == sswitch.Number)
                        _plantSwitchDictionary.Add(plant, sswitch);
                }
            }
        }

        private void InitMotorControl()
        {
            _motorControl = _kernel.Get<IMotorController>();
            _motorControl.MotorPin1 = ConnectorPin.P1Pin11;
            _motorControl.MotorPin2 = ConnectorPin.P1Pin13;
            _motorControl.Initialize();
        }
    }
}
