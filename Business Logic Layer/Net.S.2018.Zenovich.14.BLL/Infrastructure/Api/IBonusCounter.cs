﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.S._2018.Zenovich._14.BLL.Infrastructure.Api
{
    public interface IBonusCounter
    {
        long GetBonusFromRefill(IAccountTypeFeatures accountTypeFeatures, decimal amount);

        long GetBonusFromAdded(IAccountTypeFeatures accountTypeFeatures, decimal amount);
    }
}
