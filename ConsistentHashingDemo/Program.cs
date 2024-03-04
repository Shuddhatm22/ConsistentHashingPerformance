// See https://aka.ms/new-console-template for more information


// normal hashing

// taking hash function modulo N

// assuming there are 10 servers
// calculating the load on each server

using ConsistentHashingDemo;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;



int numServers = 10;
int numKeys = 10000;
int maxLimit = (int)1e5;


void Run(OperationType type, HashingType hashingType)
{
    Console.WriteLine($"Hashing type: {hashingType.ToString()}");
    var engine = new ProgramEngine(numKeys, maxLimit, hashingType, numServers);
    engine.IngestData();

    switch (type)
    {
        case OperationType.LoadPrint:
            engine.PrintServerLoadData();
            break;
        case OperationType.AddServer:
            engine.PrintKeysShuffledInfoAfterAddingServer();
            break;
        case OperationType.RemoveServer:
            engine.PrintKeysShuffledInfoAfterRemovingServer();
            break;
        default:
            throw new ArgumentException($"Invalid operation type : {type}");

    }
}

// normal hashing 
// 1. print load data
Run(OperationType.LoadPrint, HashingType.NormalHashing);
// 2. add server 
Run(OperationType.AddServer, HashingType.NormalHashing);
// 3. remove server
Run(OperationType.RemoveServer, HashingType.NormalHashing);

//consistent hashing
// 1. print load data
Run(OperationType.LoadPrint, HashingType.ConsistentHashing);
// 2. add server 
Run(OperationType.AddServer, HashingType.ConsistentHashing);
// 3. remove server
Run(OperationType.RemoveServer, HashingType.ConsistentHashing);

//TODO
// consistent hashing with k virtual servers








