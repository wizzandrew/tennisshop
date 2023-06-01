using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class ShopitemController : Controller {

    private readonly IShopitemRepository _repository;
    public ShopitemController(IShopitemRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetShopItems() {
        var shopitems = _repository.GetShopItems();

        if(!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        return Ok(shopitems);
    }

}