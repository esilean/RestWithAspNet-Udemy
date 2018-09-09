using System;
namespace RestfulAspNetCore.Domain.Entities
{
    public class Person
    {
        public Person()
        {
        }

        public long? Id
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
