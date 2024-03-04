using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsistentHashingDemo
{
    public interface IHashingFeature
    {
        public void AssignServers();
        public int GetServer(int key);
    }
}
