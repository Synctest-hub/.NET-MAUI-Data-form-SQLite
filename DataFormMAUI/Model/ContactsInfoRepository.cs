using System.Collections.ObjectModel;

namespace DataFormMAUI
{
    class ContactsInfoRepository
    {

        private Random random = new Random();
        public ContactFormModel ContactFormModel { get; set; }

        public ContactsInfoRepository()
        {
            this.ContactFormModel = new ContactFormModel();
        }

        public ObservableCollection<ContactFormModel> GetContactDetails(int count)
        {
            ObservableCollection<ContactFormModel> customerDetails = new ObservableCollection<ContactFormModel>();
            int girlsCount = 0, boysCount = 0;
            for (int i = 0; i < count; i++)
            {
                var details = new ContactFormModel()
                {
                    ID = i+1,
                    Mobile = random.Next(100, 400).ToString()  + random.Next(500, 800).ToString() + random.Next(1000, 2000).ToString(),
                    ProfileImage = "People_Circle" + (i % 19) + ".png",
                };

                if (imagePosition.Contains(i % 19))
                    details.Name = CustomerNames_Boys[boysCount++ % 32];
                else
                    details.Name = CustomerNames_Girls[girlsCount++ % 93];

                customerDetails.Add(details);
            }
            return customerDetails;
        }


        int[] imagePosition = new int[]
        {
            5,
            8,
            12,
            14,
            18
        };

        string[] CustomerNames_Girls =
        [
            "Kyle",
            "Gina",
            "Brenda",
            "Danielle",
            "Fiona",
            "Lila",
            "Jennifer",
            "Liz",
            "Pete",
            "Katie",
            "Vince",
            "Fiona",
            "Liam   ",
            "Georgia",
            "Elijah ",
            "Alivia",
            "Evan   ",
            "Ariel",
            "Vanessa",
            "Gabriel",
            "Angelina",
            "Eli    ",
            "Remi",
            "Levi",
            "Alina",
            "Layla",
            "Ella",
            "Mia",
            "Emily",
            "Clara",
            "Lily",
            "Melanie",
            "Rose",
            "Brianna",
            "Bailey",
            "Juliana",
            "Valerie",
            "Hailey",
            "Daisy",
            "Sara",
            "Victoria",
            "Grace",
            "Layla",
            "Josephine",
            "Jade",
            "Evelyn",
            "Mila",
            "Camila",
            "Chloe",
            "Zoey",
            "Nora",
            "Ava",
            "Natalia",
            "Eden",
            "Cecilia",
            "Finley",
            "Trinity",
            "Sienna",
            "Rachel",
            "Sawyer",
            "Amy",
            "Ember",
            "Rebecca",
            "Gemma",
            "Catalina",
            "Tessa",
            "Juliet",
            "Zara",
            "Malia",
            "Samara",
            "Hayden",
            "Ruth",
            "Kamila",
            "Freya",
            "Kali",
            "Leiza",
            "Myla",
            "Daleyza",
            "Maggie",
            "Zuri",
            "Millie",
            "Lilliana",
            "Kaia",
            "Nina",
            "Paislee",
            "Raelyn",
            "Talia",
            "Cassidy",
            "Rylie",
            "Laura",
            "Gracelynn",
            "Heidi",
            "Kenzie",
        ];

        string[] CustomerNames_Boys = new string[]
        {
            "Irene",
            "Watson",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Howard",
            "Daniel",
            "Frank",
            "Jack",
            "Oscar",
            "Larry",
            "Holly",
            "Steve",
            "Zeke",
            "Aiden",
            "Jackson",
            "Mason",
            "Jacob  ",
            "Jayden ",
            "Ethan  ",
            "Noah   ",
            "Lucas  ",
            "Brayden",
            "Logan  ",
            "Caleb  ",
            "Caden  ",
            "Benjamin",
            "Xaviour",
            "Ryan   ",
            "Connor ",
            "Michael",           
        };
    }
}