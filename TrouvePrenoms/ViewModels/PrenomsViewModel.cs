﻿// Copyright © 2018 Damien Mayance
// This file is subject to the terms and conditions defined in
// file 'LICENSE.md', which is part of this source code package
using System;
using System.Globalization;
using TrouvePrenoms.Models;

namespace TrouvePrenoms.ViewModels
{
  public class PrenomsViewModel
  {
    public static string DATE_FORMAT = "yyyyMMdd";
    public static CultureInfo DATE_CULTURE = CultureInfo.GetCultureInfo("fr-FR");

    public Prenom[] Boys { get; set; }
    public Prenom[] Girls { get; set; }
    public DateTime Date { get; set; }

    public string DateString
    {
      get
      {
        return Date.ToString(DATE_FORMAT, DATE_CULTURE);
      }
    }

    public string PreviousDateString
    {
      get
      {
        return Date.AddDays(-1).ToString(DATE_FORMAT, DATE_CULTURE);
      }
    }

    public string NextDateString
    {
      get
      {
        return Date.AddDays(1).ToString(DATE_FORMAT, DATE_CULTURE);
      }
    }

    public bool IsTodayOrFuture
    {
      get
      {
        return Date.Day >= DateTime.Now.Day
          && Date.Month >= DateTime.Now.Month
          && Date.Year >= DateTime.Now.Year;
      }
    }
  }
}