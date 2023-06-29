using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enums;

namespace MilitaryElite.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; set; }
    }
}
