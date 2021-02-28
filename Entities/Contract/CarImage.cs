using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Contract
{
    public class CarImage:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }

        public string ImagePath { get; set; }

        public DateTime Date { get; set; }
    }
}
