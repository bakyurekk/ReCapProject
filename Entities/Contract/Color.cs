﻿using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Contract
{
    public class Color:IEntity
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }

    }
}
