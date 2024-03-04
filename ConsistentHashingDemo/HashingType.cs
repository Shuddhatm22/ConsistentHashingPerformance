using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsistentHashingDemo
{
    public enum HashingType
    {
        NormalHashing,
        ConsistentHashing,
        ConsistentHashingWithVirtualNodes
    }

    public enum OperationType
    {
        LoadPrint,
        AddServer,
        RemoveServer
    }
}
