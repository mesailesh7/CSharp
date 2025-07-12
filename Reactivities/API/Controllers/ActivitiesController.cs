using System;
using Persistance;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    private readonly AppDbContext context;
    public ActivitiesController(AppDbContext context)
    {
        this.context = context
    }

}
