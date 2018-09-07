using System;
namespace RestfulAspNetCore.Application.Model
{
    public class PersonModel
    {

        public PersonModel()
        {
        }
        public long Id
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string Gender
        {
            get;
            set;
        }
    }
}
