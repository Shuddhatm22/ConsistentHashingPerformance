using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsistentHashingDemo
{
    public abstract class HashingFeature : IHashingFeature
    {
        private readonly Dictionary<int, int> _serverLoad;
        private readonly Dictionary<int, int> _serverDictionary;
        private Random _random;

        public HashingFeature()
        {
            _serverLoad = [];
            _serverDictionary = [];
            _random = new Random();
            AssignServers();
        }

        public Dictionary<int, int> GetServerLoad()
        {
            CalculateServerLoad();
            return _serverLoad;
        }

        public abstract void AssignServers();

        public abstract void AddServer();

        public abstract void RemoveServer();

        public abstract int GetServer(int key);

        private void CalculateServerLoad()
        {
            foreach(var kvp in _serverDictionary)
            {
                var server = kvp.Value;
                if (_serverLoad.ContainsKey(server))
                {
                    _serverLoad[server]++;
                }
                else
                {
                    _serverLoad[server] = 1;
                }
            }
        }

        public void IngestData(int key)
        {
            int server = GetServer(key);
            _serverDictionary.TryAdd(key, server);
        }

        public int GetKeysShuffledWhenServersChanged()
        {
            int count = 0;
            foreach (var kvp in _serverDictionary)
            {
                int oldServerValue = kvp.Value;
                int newServerValue = GetServer(kvp.Key);
                count += (oldServerValue != newServerValue) ? 1 : 0;
            }
            return count;
        }
    }
}
