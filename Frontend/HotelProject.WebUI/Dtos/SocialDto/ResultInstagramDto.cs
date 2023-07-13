namespace HotelProject.WebUI.Dtos.SocialDto
{
    public class ResultInstagramDto
    {


        public User user { get; set; }



        public class User
        {
            public int follower_count { get; set; }
        }



    }
}
