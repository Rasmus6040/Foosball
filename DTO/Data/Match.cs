using System;

namespace DTO.Data;

public class Match
{
    public const string GetMatches = "/matches";
    public int TeamAScore { get; init; }
    public int TeamBScore { get; init; }
    public bool Ranked { get; init; }
    public int EloChange { get; init; }
    public long Date { get; init; } = DateTimeOffset.Now.ToUnixTimeSeconds();
}