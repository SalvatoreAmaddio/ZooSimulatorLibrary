namespace ZooSimulatorLibrary.Animals
{
    public class Monkey : AbstractAnimal
    {
        public override float DeathThreshold => 0.3f;

        public override string ImgURI => "/Images/Animals/monkey.png";

        public override string DyingImgURI => "/Images/Animals/deadMonkey.png";

        public override double WalkingSpeed => 1.0;

        public Monkey() { }
    }
}