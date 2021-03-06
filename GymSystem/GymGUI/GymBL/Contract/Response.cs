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
        public ResponseStatusEnum ResponseStatus { get; set; }
        public object Value { get; set; }

        public static Response FromException(Exception e) {
            return new Response { FailedReasons = new List<string>() { e.Message }, ResponseStatus = ResponseStatusEnum.Failed };
        }
    }

    public enum ResponseStatusEnum {
        Success,
        Failed
    }
}
