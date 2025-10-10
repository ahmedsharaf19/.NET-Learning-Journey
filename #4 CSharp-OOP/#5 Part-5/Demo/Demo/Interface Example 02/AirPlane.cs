using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interface_Example_02
{
    internal class AirPlane : Vehicle, IMoveOnGround, IMoveOnAir
    {
        //// Implement Implicitly
        //public void Backward()
        //{
        //}

        //public void Forward()
        //{
        //}

        //public void Left()
        //{
        //}

        //public void Right()
        //{
        //}

        public void Forward()
        {
            Console.WriteLine("Airplane Move Forward");
        }

        // Implement Explicitly
        void IMoveOnGround.Backward()
        {
            Console.WriteLine("Airplane Move Backward On Ground");
        }

        void IMoveOnAir.Backward()
        {
            Console.WriteLine("Airplane Move Backward On Air");
        }


        void IMoveOnGround.Left()
        {
            throw new NotImplementedException();
        }

        void IMoveOnAir.Left()
        {
            throw new NotImplementedException();
        }

        void IMoveOnGround.Right()
        {
            throw new NotImplementedException();
        }

        void IMoveOnAir.Right()
        {
            throw new NotImplementedException();
        }
    }
}
