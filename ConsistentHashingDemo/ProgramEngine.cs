using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsistentHashingDemo
{
    public class ProgramEngine
    {
        private HashingFeature _hashingFeature { get; set; }
        private readonly int _numKeys;
        private readonly Random _random;
        private readonly int _maxLimit;
        private readonly int _numServers;

        public ProgramEngine(int numKeys, int maxLimit, HashingType hashingType, int numServers)
        {
            _numKeys = numKeys;
            _random = new Random();
            _maxLimit = maxLimit;
            _numServers = numServers;
            _hashingFeature = Get_hashingFeatureInstance(hashingType);
        }

        private HashingFeature? Get_hashingFeatureInstance(HashingType hashingType)
        {
            switch (hashingType)
            {
                case HashingType.NormalHashing:
                    return new NormalHashing(_numServers);
                case HashingType.ConsistentHashing:
                    return new ConsistentHashing(_numServers);
                default:
                    throw new ArgumentException($"Invalid type {hashingType}");
            }
        }

        public void IngestData()
        {
            for (int i = 0; i < _numKeys; i++)
            {
                int key = _random.Next(_maxLimit + 1);
                _hashingFeature?.IngestData(key);
            }
        }

        public void PrintServerLoadData()
        {
            var serverLoad = _hashingFeature?.GetServerLoad();
            int numServers = serverLoad.Count;

            Console.WriteLine("Load on servers : ");
            for (int i = 0; i < numServers; i++)
            {
                int serverL = serverLoad.TryGetValue(i, out int value) ? value : 0;
                Console.WriteLine($"Server{i} : {serverL}");
            }
        }

        public void PrintKeysShuffledInfoAfterAddingServer()
        {
            _hashingFeature?.AddServer();
            Console.WriteLine($"Adding server");
            PrintKeyShuffledInfo();
        }

        public void PrintKeysShuffledInfoAfterRemovingServer()
        {
            _hashingFeature?.RemoveServer();
            Console.WriteLine($"Removing server");
            PrintKeyShuffledInfo();
        }

        private void PrintKeyShuffledInfo()
        {
            int? keysShuffled = _hashingFeature?.GetKeysShuffledWhenServersChanged();
            Console.WriteLine($"Number of keys shuffled : {keysShuffled}");
            Console.WriteLine($"Percentage of keys shuffles : {GetPercentage(keysShuffled)}");
        }

        private double GetPercentage(int? keysShuffled)
        {
            return (double)keysShuffled / _numKeys * 100.0;
        }
    }
}
