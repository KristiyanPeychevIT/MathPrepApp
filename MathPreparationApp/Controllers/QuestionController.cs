﻿namespace MathPreparationApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class QuestionController : Controller
    {
        public Task<IActionResult> Add()
        {
            
        }
    }
}
