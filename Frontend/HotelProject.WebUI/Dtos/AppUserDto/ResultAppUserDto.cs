namespace HotelProject.WebUI.Dtos.AppUserDto
{
    public class ResultAppUserDto
    {

            public string name { get; set; }
            public string surname { get; set; }
            public object city { get; set; }
            public string imageUrl { get; set; }
            public int workLocationId { get; set; }
            public Worklocation workLocation { get; set; }
            public int id { get; set; }
            public string userName { get; set; }
            public string normalizedUserName { get; set; }
            public string email { get; set; }
            public string normalizedEmail { get; set; }
            public bool emailConfirmed { get; set; }
            public string passwordHash { get; set; }
            public string securityStamp { get; set; }
            public string concurrencyStamp { get; set; }
            public object phoneNumber { get; set; }
            public bool phoneNumberConfirmed { get; set; }
            public bool twoFactorEnabled { get; set; }
            public object lockoutEnd { get; set; }
            public bool lockoutEnabled { get; set; }
            public int accessFailedCount { get; set; }
            

        public class Worklocation
        {
            public int workLocationId { get; set; }
            public string workLocationName { get; set; }
            public string workLocationCity { get; set; }
            public object[] appUsers { get; set; }
        }

    }
}
