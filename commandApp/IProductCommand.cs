using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandApp
{
    internal interface IProductCommand
    {
        void Execute();
    }

    public enum PriceAction
    {
        Increase,
        Decrease
    }
}
