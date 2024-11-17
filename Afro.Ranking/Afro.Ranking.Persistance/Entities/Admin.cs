﻿using Microsoft.AspNetCore.Identity;


namespace  Afro.Ranking.Persistance.Entities
{
    public class Admin : IdentityUser
    {
     public required string FirstName { get; set; }
     public required string LastName { get; set; }
    }
}