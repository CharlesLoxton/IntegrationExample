﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationExample2
{
    internal interface IEntity
    {
        public void Create(object x, Action<object> successCallback, Action<Exception> errorCallback);
        public void Read();
        public void Update();
        public void Delete();
    }
}
