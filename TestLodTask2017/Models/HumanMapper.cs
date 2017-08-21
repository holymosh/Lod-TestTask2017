using TestLodTask2017.Entities;

namespace TestLodTask2017.Models
{
    public class HumanMapper
    {
        public ShortHumanModel HumanToShortModel(Human human)
        {
            if (human == null)
            {
                return null;
            }

            return new ShortHumanModel
            {
                Id = human.Id,
                Name = human.Name,
                Sex = human.Sex
            };
        }

        public ExpandedHumanModel HumanToExpandedHumanModel(Human human)
        {
            if (human == null)
            {
                return null;
            }

            return new ExpandedHumanModel
            {
                Age = human.Age,
                Name = human.Name,
                Sex = human.Sex
            };
        }
    }
}