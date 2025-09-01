using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Hosting;
using Shouldly;
using Volo.Abp.AspNetCore.TestBase;
using Volo.Abp.Http;

namespace Api.Tests;

public abstract class AppApiTestBase : AbpAspNetCoreIntegratedTestBase<ApiTestStartup>
{
    protected override IHostBuilder CreateHostBuilder()
    {
        return base.CreateHostBuilder();
    }

    #region GET Helpers

    /// <summary>
    /// Hace un GET y deserializa la respuesta JSON en un objeto de tipo T.
    /// </summary>
    protected virtual async Task<T> GetJsonAsync<T>(string url, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
    {
        var responseBody = await GetStringAsync(url, expectedStatusCode);
        var tempResult = JsonSerializer.Deserialize<T>(responseBody, new JsonSerializerOptions(JsonSerializerDefaults.Web));
        if (tempResult == null)
        {
            throw new ShouldAssertException($"Response body is null. Response body: {responseBody}");
        }

        return tempResult!;
    }

    /// <summary>
    /// Hace un GET y devuelve la respuesta como string.
    /// </summary>
    protected virtual async Task<string> GetStringAsync(string url, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
    {
        var response = await GetHttpResponseAsync(url, expectedStatusCode);
        return await response.Content.ReadAsStringAsync();
    }

    /// <summary>
    /// Hace un GET y devuelve el HttpResponseMessage para más validaciones.
    /// </summary>
    protected virtual async Task<HttpResponseMessage> GetHttpResponseAsync(string url, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
    {
        var response = await Client.GetAsync(url);
        response.StatusCode.ShouldBe(expectedStatusCode);
        return response;
    }

    #endregion

    #region POST Helpers

    /// <summary>
    /// Hace un POST con un objeto serializado a JSON y deserializa la respuesta en TResponse.
    /// </summary>
    protected virtual async Task<TResponse> PostJsonAsync<TRequest, TResponse>(string url, TRequest requestObject, HttpStatusCode? expectedStatusCode = null)
    {
        var responseBody = await PostJsonAsync(url, requestObject, expectedStatusCode);
        var tempResult = JsonSerializer.Deserialize<TResponse>(responseBody, new JsonSerializerOptions(JsonSerializerDefaults.Web));
        if (tempResult == null)
        {
            throw new ShouldAssertException($"Response body is null. Response body: {responseBody}");
        }

        return tempResult!;
    }

    /// <summary>
    /// Hace un POST con un objeto serializado a JSON y devuelve la respuesta como string.
    /// </summary>
    protected virtual async Task<string> PostJsonAsync<TRequest>(string url, TRequest requestObject, HttpStatusCode? expectedStatusCode = null)
    {
        var response = await PostHttpResponseAsync(url, requestObject, expectedStatusCode);
        return await response.Content.ReadAsStringAsync();
    }

    /// <summary>
    /// Hace un POST con un objeto serializado a JSON y devuelve el HttpResponseMessage.
    /// </summary>
    protected virtual async Task<HttpResponseMessage> PostHttpResponseAsync<TRequest>(string url, TRequest requestObject, HttpStatusCode? expectedStatusCode = null)
    {
        var json = JsonSerializer.Serialize(requestObject, new JsonSerializerOptions(JsonSerializerDefaults.Web));
        var data = new StringContent(json, Encoding.UTF8, MimeTypes.Application.Json);

        var response = await Client.PostAsync(url, data);

        // Validaciones
        response.IsSuccessStatusCode.ShouldBeTrue();
        if (expectedStatusCode.HasValue)
        {
            response.StatusCode.ShouldBe(expectedStatusCode.Value);
        }

        return response;
    }
    #endregion
}
