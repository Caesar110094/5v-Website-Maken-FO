﻿using System;
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
    string connectionString = "Server= informatica.st-maartenscollege.nl;Port=3306;Database=110094;Uid=110094;Pwd=iNiANTHa;";

    public IActionResult Index()
    {


      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }
    [Route("Shows")]
    public IActionResult Shows()
    {
      var toneelstukken = GetToneelstukken();
      return View(toneelstukken);
    }
    [Route("About")]
    public IActionResult About()
    {
      return View();
    }
    [Route("Details")]
    public IActionResult Details()
    {
      List<Toneelstuk> toneelstukken = new List<Toneelstuk>();
      // uncomment deze regel om producten uit je database toe te voegen
      toneelstukken = GetToneelstukken();

      return View(toneelstukken);
      
    }
    [Route("Gallery")]
    public IActionResult Gallery()
    {
      return View();
    }
    [Route("ShowsDetail/{id}")]
    public IActionResult ShowsDetail(string id)
    {
      var model = GetToneelstuk(id);

      return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private Toneelstuk GetToneelstuk(string id)
    {
      List<Toneelstuk> toneelstukken = new List<Toneelstuk>();

      using (MySqlConnection conn = new MySqlConnection(connectionString))
      {
        conn.Open();
        MySqlCommand cmd = new MySqlCommand($"select * from toneelstuk where id = {id}", conn);

        using (var reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            Toneelstuk f = new Toneelstuk
            {
              Id = Convert.ToInt32(reader["Id"]),
              Naam = reader["Naam"].ToString(),
              Beschrijving = reader["beschrijving"].ToString(),
              Datum = DateTime.Parse(reader["datum"].ToString()),
            };
            toneelstukken.Add(f);
          }
        }
      }

      return toneelstukken[0];
    }

    private List<Toneelstuk> GetToneelstukken()
    {
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
              Beschrijving = reader["beschrijving"].ToString(),

            };
            toneelstukken.Add(f);
          }
        }
      }

      return toneelstukken;
    }
  }
}
