namespace DTO.Data.Models;

public class Player
{
    public const string GetPlayers = "/players";
    public int Id { get; init; }
    public required string Name { get; init; }
    public int Rating { get; init; } = 1200;
    public string ImageUrl { get; init; } = "https://www.google.com/search?sca_esv=c75784e51e2fff17&sxsrf=ADLYWIKX4X9y6AwI7FOepSbzknbTR8i6Og:1731164389147&q=image+placeholder+png&udm=2&fbs=AEQNm0Aa4sjWe7Rqy32pFwRj0UkWd8nbOJfsBGGB5IQQO6L3J_86uWOeqwdnV0yaSF-x2jopn8p7xL4A1Dm_DA2mNSwQf3Ts-oLed-fok38HK-L3touqFtv6wIt8FVCSDg7FOXl9BZhwvwkKnTuEN51hFYXnnYqV40IDAPbrBOsskslGNy0Z6pM&sa=X&ved=2ahUKEwjCztnzwc-JAxWjLRAIHT9RPdQQtKgLegQIFRAB&biw=1691&bih=851&dpr=2#vhid=HPW5D-7HQKEKnM&vssid=mosaic";
    public long CreatedAt { get; init; } = DateTimeOffset.Now.ToUnixTimeSeconds();
}