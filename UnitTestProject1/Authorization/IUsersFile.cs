using System.Collections.Generic;

namespace ClassLibrary
{
    public interface IUsersFile
    {
        List<User> ReadUsers();
    }
}
