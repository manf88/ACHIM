using postgresModel;

namespace ACHIM.Logic
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var model = new postgresEntities())
            {
                var hans = Plant.CreatePlant(0, "hans");
                hans.PositionSwitch = PositionSwitch.CreatePositionSwitch(0, 1, 12);
                model.PositionSwitches.AddObject(hans.PositionSwitch);
                
                model.Plants.AddObject(hans);

                model.SaveChanges();
            }
        }
    }
}