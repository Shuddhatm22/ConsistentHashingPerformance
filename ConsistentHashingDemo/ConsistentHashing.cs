using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsistentHashingDemo
{
    public class ConsistentHashing : HashingFeature
    {
        private int _numServers;
        private SortedDictionary<int, int> _servers = new SortedDictionary<int, int>();
        private Random _random;
        private const int RING_SPACE = 100;

        public ConsistentHashing(int numServers)
            : base()
        {
            _numServers = numServers;
            _random = new Random();
            AssignServers();
            PrintServers();
        }

        public override void AssignServers()
        {
            for(int i=0; i<_numServers; i++)
            {
                SortedInsertServers(i);
            }
        }

        private void SortedInsertServers(int pos)
        {
            int serverPosition = GetRandomPosition();
            if (_servers.ContainsKey(serverPosition))
            {
                while (_servers.ContainsKey(serverPosition))
                {
                    serverPosition = GetRandomPosition();
                }
            }
            _servers.Add(serverPosition, pos);
        }

        public void PrintServers()
        {
            foreach(var kvp in _servers)
            {
                Console.WriteLine($"S{kvp.Value} :  {kvp.Key}");
            }
        }

        private int GetRandomPosition()
        {
            return _random.Next(RING_SPACE);
        }

        public override int GetServer(int key)
        {
            int hashValue = (Utils.GetMd5HashAsInteger(key.ToString())) % RING_SPACE;
            return GetNextServer(hashValue);

        }

        private int GetNextServer(int input)
        {
            int firstServer = _servers.First().Value;
            // hash value between 0 and int max
            foreach (var kvp in _servers)
            {
                if (input <= kvp.Key)
                {
                    return kvp.Value;
                }
            }
            return firstServer;
        }

        public override void AddServer()
        {
            SortedInsertServers(_numServers);
            // increase count of servers
            _numServers++;
        }

        public override void RemoveServer()
        {
            // removing first server for now
            int firstServerPos = _servers.First().Key;
            _servers.Remove(firstServerPos);
            _numServers--;
        }
    }

    // circular ring 
    // hashes of servers 
    // hashes of keys 
}
