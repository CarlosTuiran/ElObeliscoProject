using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Base
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
