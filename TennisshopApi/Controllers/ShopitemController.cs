using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class ShopitemController : Controller
{

    private readonly IShopitemRepository _repository;
    public ShopitemController(IShopitemRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetShopItems()
    {
        var shopitems = _repository.GetShopItems();

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(shopitems);
    }

    [HttpGet("newarrivals")]
    public IActionResult GetNewArrivals()
    {
        var newArrivals = _repository.GetNewArrivals();

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(newArrivals);
    }

    [HttpGet("topsellers")]
    public IActionResult GetTopSellers()
    {
        var topSellers = _repository.GetTopSellers();

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(topSellers);
    }

}