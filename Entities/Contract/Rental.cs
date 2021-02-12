﻿using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Contract
{
    public class Rental:IEntity
    {
        public int RentalId { get; set; }

        public int CarId { get; set; }

        public int CustomerId { get; set; }

        public DateTime RentDate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}