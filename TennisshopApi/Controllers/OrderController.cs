using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class OrderController : Controller
{

    private readonly IOrderRepository _repository;
    public OrderController(IOrderRepository repository)
    {
        _repository = repository;
    }


    [HttpPost("createorder")]
    public IActionResult CreateOrder([FromBody] CreateOrder order)
    {

        if (order == null)
        {
            return BadRequest(ModelState);
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (_repository.OrderExists(order))
        {
            ModelState.AddModelError("", "Order already exists");
            return StatusCode(409, ModelState);
        }

        if (!_repository.SufficientOrderItems(order))
        {
            return BadRequest("Insufficient items in stock");
        }

        _repository.ManageOrderItemsQuantity(order);
        _repository.CreateOrder(order);
        return Ok("Successfully created");


    }

}