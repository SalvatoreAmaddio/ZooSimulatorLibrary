using ZooSimulatorLibrary.Animals.Services.HealthMonitorServices;

namespace ZooSimulatorLibrary.Animals
{
    public class Elephant : AbstractAnimal
    {
        public override string ImgURI => "/Images/Animals/elephant.png";
        public override string DyingImgURI => "/Images/Animals/deadElephant.png";
        public override float DeathThreshold => 0.7f;
        public override bool CanWalk => !(Health < DeathThreshold);
        public override double WalkingSpeed => 3.0;
        public Elephant() : base(null, new ElephantHealthMonitorService())
        {
        }
    }
}