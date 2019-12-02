using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_OOP_20
{
    public enum ActivityType { Air, Water, Land };
    

    public class Activity : IComparable
    {

        //properties
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Description { get; set; }
        public ActivityType TypeOfActivity { get; set; }
        public decimal Cost { get; set; }

        public static decimal TotalExpenses { get; private set; }
        //public ActivityType SuitableFor { get; internal set; }

        //constructors
        public Activity()
        {

        }

        public Activity(decimal amount, DateTime date, string category)
        {

        }
        //public int CompareTo(Object obj)
        //{
        //     Kayaking that=obj as 
        //}


        //methods
        public override string ToString()
        {
            return $"{Name} - {ActivityDate.ToShortDateString()}";
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

    }
}
