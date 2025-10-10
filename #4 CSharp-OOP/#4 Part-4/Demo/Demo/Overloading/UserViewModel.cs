using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Overloading
{
    // ViewModel : Is A Class That Represent Data That Will Be Render In View [Html]
    internal class UserViewModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public static explicit operator UserViewModel(User us)
        {
            string[]? names = us?.FullName?.Split(" ");
            return new UserViewModel()
            {
                Id = us?.Id ?? 0,
                Email = us?.Email,
                FirstName = names?[0],
                LastName = names?.Length > 1 ? names?[names.Length - 1] : null
            };
        }
    }
}
