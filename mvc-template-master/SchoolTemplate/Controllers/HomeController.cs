using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SchoolTemplate.Database;
using SchoolTemplate.Models;

namespace SchoolTemplate.Controllers
{
  public class HomeController : Controller
  {
    // zorg ervoor dat je hier je gebruikersnaam (leerlingnummer) en wachtwoord invult
    string connectionString = "Server=172.16.160.21;Port=3306;Database=110094;Uid=110094;Pwd=iNiANTHa;";

    public IActionResult Index()
    {
      List<Toneelstuk> toneelstukken = new List<Toneelstuk>();
      // uncomment deze regel om producten uit je database toe te voegen
      toneelstukken = GetToneelstuk();

      return View(toneelstukken);
    }

    private List<Toneelstuk> GetToneelstuk() {
      List<Toneelstuk> toneelstukken = new List<Toneelstuk>();

      using (MySqlConnection conn = new MySqlConnection(connectionString))
      {
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("select * from toneelstuk", conn);

        using (var reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            Toneelstuk f = new Toneelstuk
            {
              Id = Convert.ToInt32(reader["Id"]),
              Naam = reader["Naam"].ToString(),
              Beschrijving = reader["bescrijving"].ToString(),
              Datum = DateTime.Parse(reader["datum"].ToString()),
            };
            toneelstukken.Add(f);
          }
        }
      }

      return toneelstukken;
    }

    public IActionResult Privacy()
    {
      return View();
    }
   [Route("Showall")]
   public IActionResult Showall()
    {
      return View();
    }
        [Route("About")]
        public IActionResult About()
        {
            return View();
        }
        [Route("Details")]
        public IActionResult Details()
        {
            return View();
        }
        [Route("Gallery")]
        public IActionResult Gallery()
        {
            return View();
        }
        [Route("Shows")]
        public IActionResult Shows()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
