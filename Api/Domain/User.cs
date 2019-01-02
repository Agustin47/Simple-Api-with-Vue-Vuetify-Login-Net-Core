using System;

namespace Domain
{
    public class User
    {

        public int Id { get; set; }

        public string UserName { get; set; }
        public Role Role { get; set; }

        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Avariable { get; set; }
        public DateTime? NullDate { get; set; }

    }
}
