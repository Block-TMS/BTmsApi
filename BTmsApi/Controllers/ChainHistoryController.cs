using Microsoft.AspNetCore.Mvc;

namespace BTmsApi.Controllers;

[Route("api/chain-history")]
[ApiController]
public class ChainHistoryController : ControllerBase
{
    public ChainHistoryController()
    {

    }

    [HttpGet ("{id}")]
    public async Task<ActionResult<string>> GetChainHistory(string id)
    {
        return Ok(new { id });
    }

}
