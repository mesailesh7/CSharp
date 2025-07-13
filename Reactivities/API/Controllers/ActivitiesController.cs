using System;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace API.Controllers;

//The way it is doing right now is using private constructor
public class ActivitiesController(AppDbContext context) : BaseApiController
{
    //This is the old of way doing
    // private readonly AppDbContext context;
    // public ActivitiesController(AppDbContext context)
    // {
    //     this.context = context;
    // }

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await context.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        var activity = await context.Activities.FindAsync(id);

        if (activity == null) return NotFound();

        return activity;
    }

}
