﻿using System;
using System.Collections.Generic;
using System.Text;
using ECE.Core.DomainObjects;

namespace ECE.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {

    }
}
