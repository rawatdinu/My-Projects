using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSource
{
    class Airplane
    {
        private static int lastID = 0;
        public int _id;
        public int ID
        {
            get { return _id; }
        }
        public string _model;
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
        public int _fuelKg;
        public int FuelLeftKg
        {
            get { return _fuelKg; }
            set { _fuelKg = value; }
        }

       

        public List<Passenger> _passengers = new List<Passenger>();
        public List<Passenger> Passengers
        {
            get { return _passengers; }           
        }
        
        public Airplane(string model, int fuelKg)
        {
            _id = ++lastID;
            _model = model;
            _fuelKg = fuelKg;
        }
    }

    class Passenger
    {
        public Passenger(string model)
        {
            _id = ++lastID;
            _name = model;
        }

        private static int lastID = 0;
        public int _id;
        public int ID
        {
            get { return _id; }
        }
        public string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
