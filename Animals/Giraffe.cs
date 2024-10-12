namespace ZooSimulatorLibrary.Animals
{
    public class Giraffe : AbstractAnimal
    {
        public override double WalkingSpeed => 2.0;
        public override string ImgURI => "/Images/Animals/giraffe.png";
        public override string DyingImgURI => "/Images/Animals/deadGiraffe.png";
        public override float DeathThreshold => 0.5f;
        public Giraffe() { }
    }
}