# Hashing Algorithms and Consistent Hashing Implementation

This repository contains implementations of normal hashing and consistent hashing algorithms in C#. The main focus is on simulating the behavior of these algorithms for a variable number of servers and measuring the percentage of key changes when new servers are added or removed from the system.

## Introduction

Hashing is a fundamental concept in computer science used for various purposes, including data storage, indexing, and load balancing. The goal of this project is to explore and compare the behavior of traditional hashing algorithms and consistent hashing in a distributed system scenario.

### Contents

- `NormalHashing.cs`: Implementation of a basic hashing algorithm where keys are hashed and distributed among a fixed number of servers.
- `ConsistentHashing.cs`: Implementation of consistent hashing algorithm where keys are hashed and distributed among a variable number of servers while minimizing the number of key migrations when servers are added or removed.
- `ProgramEngine.cs`: Contains code to simulate the behavior of both normal hashing and consistent hashing algorithms for N number of servers. It measures the percentage of key changes when new servers are added or removed from the system.
- `Program.cs`: Main entry point of the application to run simulations and display results.


