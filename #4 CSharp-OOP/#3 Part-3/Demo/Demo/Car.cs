﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Car
    {
        #region Attributes

        private int id;
        private string? model;
        private double speed;

        #endregion


        #region Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string? Model
        {
            get { return model; }
            set { model = value; }
        }

        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        #endregion

        #region Constrcutor Overloading
        public Car(int id, string? model, double speed)
        {
            this.id = id;
            this.model = model;
            this.speed = speed;
            Console.WriteLine("1st Ctor");
        }

        public Car(int id, string? model) : this(id, model, 290)
        {
            //this.id = id;
            //this.model = model;
            //this.speed = 290;
            Console.WriteLine("2nd Ctor");

        }

        public Car(int id) : this(id, "Audi", 190)
        {
            //this.id = id;
            //model = "Audi";
            //speed = 190;
            Console.WriteLine("3rd Ctor");

        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Id = {id}\nModel = {model}\nSpeed = {speed}";
        }
        #endregion

    }
}
