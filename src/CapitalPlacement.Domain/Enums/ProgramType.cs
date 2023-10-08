using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Domain.Enums
{
    public enum ProgramType
    {
        None = 0,
        [Description("Part Time")]
        PartTime,
        [Description("Full Time")]
        FullTime
    }
}
