using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using ClientApp.Models;

namespace ClientApp.Services;

public sealed class ProductApi
{
    private readonly HttpClient _http;
    private Product[]? _cache;
    private DateTimeOffset _cacheTime;
    private readonly TimeSpan _cacheTtl = TimeSpan.FromSeconds(30);

    private static readonly JsonSerializerOptions _jsonOpts = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public ProductApi(HttpClient http) => _http = http;

    public async Task<Product[]> GetProductsAsync(CancellationToken ct = default)
    {
        if (_cache is not null && DateTimeOffset.UtcNow - _cacheTime < _cacheTtl)
            return _cache;

        using var resp = await _http.GetAsync("/api/productlist", ct);
        if (!resp.IsSuccessStatusCode)
        {
            var status = (int)resp.StatusCode;
            var msg = $"API error: {(HttpStatusCode)status} ({status})";
            throw new HttpRequestException(msg);
        }

        var stream = await resp.Content.ReadAsStreamAsync(ct);
        var data = await JsonSerializer.DeserializeAsync<Product[]>(stream, _jsonOpts, ct);
        _cache = data ?? Array.Empty<Product>();
        _cacheTime = DateTimeOffset.UtcNow;
        return _cache;
    }
}