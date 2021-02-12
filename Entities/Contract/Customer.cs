using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Contract
{
    public class Customer:IEntity
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }

        public string CompanyName { get; set; }
    }
}
