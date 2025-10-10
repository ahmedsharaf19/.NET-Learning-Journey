using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Encapsulation
{
    internal struct PhoneNotebook
    {
        #region Attributes
        private string[]? names;
        private int[]? numbers;
        private int size;
        #endregion

        #region Constructor
        public PhoneNotebook(int noteSize)
        {
            size = noteSize;
            names = new string[size];
            numbers = new int[size];
        }
        #endregion

        #region Properties
        public int Size // Read Only Property
        {
            get { return size; }
        }
        #endregion

        #region Getter Setter
        // Geter 
        public int GetNumber(string name)
        {
            if(names is not null && numbers is not null)
            {
                for (int i = 0; i < names.Length; i++) 
                {
                    if (names[i] == name)
                    {
                        return numbers[i];
                    }
                }
            }
            return -1;
        }

        // Setter
        public void SetNumber(string name, int newNumber)
        {
            if (names is not null && numbers is not null)
            {
                for (int i = 0; i <= names.Length; i++) 
                {
                    if (names[i] == name)
                    {
                        numbers[i] = newNumber;
                        return;
                    }
                }
            }
        }
        #endregion

        #region Indexer
        // Is A Special Property [Named With Keyword This]
        // Can Take Parameter
        public int this[string name]
        {
            get
            {
                if (names is not null && numbers is not null) 
                    for (int i = 0; i < names.Length; i++)
                        if (names[i] == name)
                            return numbers[i];
                return -1;
            }
            set
            {
                if (names is not null && numbers is not null)
                    for (int i = 0; i < numbers.Length; i++)
                        if (names[i] == name)
                        {
                            numbers[i] = value;
                            return;
                        }
            }
        }

        public string this[int index]
        {
            get
            {
                return $"Page = {index + 1} :: Name = {names[index]} :: Number = {numbers[index]}";
            }
        }
        #endregion

        #region Methods

        public void AddNewPerson(int position, string name, int number)
        {
            if(names is not null && numbers is not null)
            {
                if (position < Size && position >= 0)
                {
                    names[position] = name;
                    numbers[position] = number;
                }
            }
        }


        #endregion
    }
}
