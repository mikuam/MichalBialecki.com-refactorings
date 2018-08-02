using System;

namespace MichalBialecki.com.Refactorings.Dtos
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime LastModified { get; set; }

        public string Description { get; set; }
    }
}
