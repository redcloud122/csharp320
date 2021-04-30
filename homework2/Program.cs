using System;
using System.Collections.Generic;
using System.Linq;

namespace homework2 {
  class Program {
    static void Main(string[] args)
    {
      var users = new List<Models.User>();

      users.Add(new Models.User { Name = "Dave", Password = "hello" });
      users.Add(new Models.User { Name = "Steve", Password = "steve" });
      users.Add(new Models.User { Name = "Lisa", Password = "hello" });

      // 1: Display to the console, the names of the users where the password is "hello".
      var userName = from user in users
                     where user.Password == "hello"
                     select user.Name;

      foreach (var u in userName)
        Console.WriteLine(u);

      // 2: Delete any passwords that are the lower-cased version of their Name.
      users.RemoveAll(ErrorPasswordIsLowerCaseOfName);

      // 3: Delete the first User that has the password "hello".
      users.Remove(users.FirstOrDefault(s => s.Password.Equals("hello")));

      // 4: Display to the console the remaining users with their Name and Password
      foreach (var u in users)
        Console.WriteLine("\nName = {0}, Password = {1}", u.Name, u.Password);
    }

    private static bool ErrorPasswordIsLowerCaseOfName(Models.User u)
    {
      string name = u.Name.Trim();
      string pw = u.Password.Trim();

      return (pw.Equals(name.ToLower()));
    }

  }
}
