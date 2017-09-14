using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCore.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Games")]
    public class GamesController : Controller
    {
        Model.Game[] Games = new Model.Game[]
        {
            new Model.Game { Id=1, Name="Destiny 2", Publisher="Bungie", Category="FPS" },
            new Model.Game { Id=2, Name="Final Fantasy XV", Publisher="Square Enix", Category="RPG" },
            new Model.Game { Id=3, Name="Raibow Six Siege", Publisher="Ubisoft", Category="FPS" },
            new Model.Game { Id=4, Name="Nier Automata", Publisher="Square Enix", Category="RPG" },
            new Model.Game { Id=5, Name="Stardew Valley", Publisher="Chucklefish Games", Category="Simulator" }
        };
    }
}