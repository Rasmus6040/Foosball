using System;
using DTO.Data.Entities;

namespace ELOSystem;

public class SimPlayer
{
    
    public double Rating { get; set; }
    // WinRate to use in the simulation
    public double WinRate { get; init; }
    // Pointer to actual player
    public PlayerEntity Player { get; set; }

    public SimPlayer(double winRate)
    {
        // Check that WinRate is withing allow range
        if (winRate is < 0 or > 1)
        {
            Console.WriteLine(winRate);
            throw new ArgumentException("Bad WinRate");
        }
        
        Player = new PlayerEntity
        {
            Name = "tester",
        };
        // Set the sim rating to the same as the 
        Rating = Player.Rating;
        WinRate = winRate;
    }
}