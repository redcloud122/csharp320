using Microsoft.AspNetCore.Mvc;
using BirthdayCardGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayCardGenerator.Controllers {
  public class HomeController : Controller {
    public IActionResult Index()
    {
      return View();
    }

    // Receive the data coming from the browser
    [HttpPost]
    public IActionResult Index(Models.BirthdayCard birthdayCard)
    {
      if (ModelState.IsValid) {
        return View("Confirmation", birthdayCard);
      }
      else {
        return View(birthdayCard);
      }
    }

  }
}
