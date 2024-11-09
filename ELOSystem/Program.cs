// See https://aka.ms/new-console-template for more information

using ELOSystem;

Simulator sim = new Simulator();

var players = sim.Simulate(100, 0.8, 0.5, 0.2);

players.ForEach(x => Console.WriteLine(x.Player.Rating));