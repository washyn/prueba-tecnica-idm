using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;
using Washyn.Kfc.Prices;
using Washyn.Kfc.Products;

namespace Washyn.Kfc.Controllers;

[Route("api/prices")]
[ApiController]
public class PricesController : AbpController
{
    public PricesController()
    {
    }

    [HttpGet]
    public Task<PriceDto> GetAsync([FromQuery]PricesFilter filter)
    {
        return Task.FromResult(new PriceDto()
        {
            ProductId = filter.ProductId,
            Channel = new Channel()
            {
                Code = "WEB",
                Name = "Web",
                IsActive = true
            },
            Currency = "USD",
            ChannelId = Guid.NewGuid().ToString(),
            Product = new ProductDto()
            {
                Name = "Product",
                Sku = "7896354VPAEOFJNK"
            }
        });
    }

    [HttpPost]
    public async Task<PriceDto> CreateAsync(CreateUpdateProduct input)
    {
        CheckIfExiststActive();
        // TODO: Create price and return created price
        return await Task.FromResult(new PriceDto()
        {
            Currency = "USD",
            ProductId = Guid.NewGuid(),
            ChannelId = Guid.NewGuid().ToString(),
            Product = new ProductDto()
            {
                Name = "Product",
                Sku = "7896354VPAEOFJNK"
            },
            Channel = new Channel()
            {
                Code = "WEB",
                Name = "Web",
                IsActive = true
            },
        });
    }
    
    private void CheckIfExiststActive()
    {
        if (ExistsActiveChannel())
        {
            throw new AbpValidationException(new List<ValidationResult>()
            {
                new ValidationResult("Already exists an active price.")
            });
        }
    }
    
    private bool ExistsActiveChannel()
    {
        return true;
    }
    
    [Route("{id}")]
    [HttpPut]
    public Task UpdateAsync(Guid id, CreateUpdateProduct input)
    {
        return Task.CompletedTask;
    }

    [Route("{id}")]
    [HttpDelete]
    public Task DeleteAsync(Guid id)
    {
        return Task.CompletedTask;
    }
}