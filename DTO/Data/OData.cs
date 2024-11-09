using System.Text.Json.Serialization;

namespace DTO.Data;

/// <summary>
/// Used for creating OData object from odata json response
/// </summary>
public class OData<T>
{
    [JsonPropertyName("@odata.context")]
    public string ODataContext { get; set; } = string.Empty;
    
    [JsonPropertyName("@odata.count")]
    public int ODataCount { get; set; } 
    
    /// <summary>
    /// The value of the odata response
    /// </summary>
    ///	<remarks>
    /// Only use for when you know the output from JSON is going
    /// to be a list. Otherwise, the typing will be incorrect, and
    /// you are going to get a runtime error.
    /// </remarks>
    [JsonPropertyName("value")]
    public List<T> Value { get; init; } = new();
}