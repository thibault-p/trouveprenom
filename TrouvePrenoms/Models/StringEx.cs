﻿using System;

namespace TrouvePrenoms.Models
{
  public static class StringEx
  {
    public static int MinLevenshteinDistance(this string s, string t)
    {
      if (String.IsNullOrEmpty(s) || String.IsNullOrEmpty(t)) return 0;
      if (s == t) return 0;

      int distance = 99;

      // Distance with the whole name
      distance = Math.Min(distance, s.LevenshteinDistance(t));

      // Distance splitting the "-"
      string[] ss = s.Split("-");
      for (int i = 0; i < ss.Length; i++)
      {
        distance = Math.Min(distance, ss[i].LevenshteinDistance(t));
      }
      return distance;
    }

    public static int LevenshteinDistance(this string s, string t)
    {
      // Source https://stackoverflow.com/questions/9453731/how-to-calculate-distance-similarity-measure-of-given-2-strings
      if (String.IsNullOrEmpty(s) || String.IsNullOrEmpty(t)) return 0;
      if (s == t) return 0;

      var a = s.ToLower().Trim();
      var b = t.ToLower().Trim();

      int lengthA = a.Length;
      int lengthB = b.Length;
      var distances = new int[lengthA + 1, lengthB + 1];
      for (int i = 0; i <= lengthA; distances[i, 0] = i++) ;
      for (int j = 0; j <= lengthB; distances[0, j] = j++) ;

      for (int i = 1; i <= lengthA; i++)
        for (int j = 1; j <= lengthB; j++)
        {
          int cost = b[j - 1] == a[i - 1] ? 0 : 1;
          distances[i, j] = Math.Min
              (
              Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1),
              distances[i - 1, j - 1] + cost
              );
        }
      return distances[lengthA, lengthB];
    }
  }
}
