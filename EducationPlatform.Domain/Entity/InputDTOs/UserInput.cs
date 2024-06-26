﻿using EducationPlatform.Domain.Entity.Enum;

namespace EducationPlatform.Domain.Entity
{
    public class UserInput
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string CPF { get; set; }
        public string PhoneNumber { get; set; }
        public EProfile Profile { get; set; }
        public bool IsActive { get; set; }

        public int SignatureId { get; set; }
    }
}
