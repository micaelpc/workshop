﻿using GymBL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBL.Contract
{
    public class Response : ObservableObject
    {


        public List<string> FailedReasons { get; set; }
        public ResponseStatusType ResponseStatus { get; set; }
        public object Value { get; set; }

    }

    public enum ResponseStatusType {

        Success,
        Failed
    }
}
