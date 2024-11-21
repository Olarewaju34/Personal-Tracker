using PT.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Entities.User
{
    public static class UserErrors
    {
        public static Error NotFound = new Error("User.NotFound", "user with this identifier is not found");
        public static Error FailedToCreate = new Error("User.FailedToCreate", "Failed to create User");
        public static Error SameEmail = new Error("User.SameEmail", "user with this Email is already exist");
        public static Error InvalidCredentials = new Error("User.InvalidCredentials", "user InvalidCredentials");

    }
}
