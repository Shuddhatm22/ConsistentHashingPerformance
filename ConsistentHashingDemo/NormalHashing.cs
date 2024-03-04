using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsistentHashingDemo
{
    public class NormalHashing : HashingFeature
    {
        private int _numServers;

        public NormalHashing(int numServers)
            : base()
        {
            _numServers = numServers;
        }

        public override int GetServer(int key)
        {
            int hashValue = Utils.GetMd5HashAsInteger(key.ToString());
            int server = ((hashValue % _numServers) + _numServers) % _numServers;
            return server;
        }

        public override void AssignServers() { }

        public override void AddServer()
        {
            _numServers++;
        }

        public override void RemoveServer()
        {
            _numServers--;
        }
    }
}
