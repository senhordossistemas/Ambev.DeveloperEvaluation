using Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.CreateCart;
using Ambev.DeveloperEvaluation.Application.CartFeatures.Commands.UpdateCart;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts;

[ApiController]
[Route("api/[controller]")]
public class CartsController (IMediator mediator, IMapper mapper) : BaseController
{
    // <summary>
    ///     Creates a new Cart
    /// </summary>
    /// <param name="request">The sale creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCartResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateCartRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateCartRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = mapper.Map<CreateCartCommand>(request);
        var response = await mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateCartResponse>
        {
            Success = true,
            Message = "Cart created successfully",
            Data = mapper.Map<CreateCartResponse>(response)
        });
    }
    
    [HttpPut("create-or-update-cart/{userId:guid}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateCartResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateOrUpdate([FromRoute] Guid userId, [FromBody] CartItemRequest request,
        CancellationToken cancellationToken)
    {
        var command = mapper.Map<AddOrUpdateCartItemCommand>(request) with { UserId = userId };

        var response = await mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<UpdateCartResult>
        {
            Success = true,
            Message = "Cart updated successfully",
            Data = response
        });
    }
}