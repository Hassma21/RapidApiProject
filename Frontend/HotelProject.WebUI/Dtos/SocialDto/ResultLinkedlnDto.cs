namespace HotelProject.WebUI.Dtos.SocialDto
{
    public class ResultLinkedlnDto
    {


        public Extractor extractor { get; set; }

        public class Extractor
        {

            public Interactionstatistic1 interactionStatistic { get; set; }
        }

        public class Interactionstatistic1
        {
            public string type { get; set; }
            public string interactionType { get; set; }
            public string name { get; set; }
            public int userInteractionCount { get; set; }
        }



    }
}
