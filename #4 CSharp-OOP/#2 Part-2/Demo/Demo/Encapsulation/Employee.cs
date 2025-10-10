using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Encapsulation
{
    internal struct Employee
    {
        #region Attributes
        public int Id;
        private string? Name;
        //private decimal deduction; //Derived Attribute
        #endregion


        // Encapsulation 
        // Seprate Data Deinition [Attributes] From irs Use [Getter Setter, Property]
        // 1. Attribute Private
        // 2. Apply Encapsulation [Getter Setter Approach, Property Approach]

        #region 01 Applying Encapsulation Using Old Approach Getter Setter

        //// Getter 
        //public string? GetName()
        //{
        //    return this.Name;
        //}

        //// Setter
        //public void SetName(string? name)
        //{
        //    this.Name = name.Length > 10 ? name.Substring(0, 10) : name;
        //}

        #endregion

        #region 02 Applying Encapsulation Using New Approach Property
        // 1.1 Full Property
        private decimal salary;

        public decimal Salary
        {
            get { return salary; }
            set 
            {
                
                salary = value < 10000 ? 10000 : value; 
            }
        }

        // 1.2 Automatic Property
        public int Age { get; set; }
        // Compiler Will Generate Backing Field "Private Hidden Attribute"
        
        public decimal Deduction // Read Only Property 
        {
            get { return Salary * 0.1M; }
        }

        // Code Snippet Property
        // Prop => Automatic Property 
        // PropFull => Full Property

        #endregion

        #region Constructors
        public Employee(int id, string? name, decimal salary, int age)
        {
            Id = id;
            Name = name;
            this.salary = salary;
            Age = age;
        }

        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Id : {Id}\nName : {Name}\nSalary : {Salary:c}";
        }
        #endregion
    }
}
