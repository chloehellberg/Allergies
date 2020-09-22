using System;
using System.Collections.Generic;
// allergen score;
// eggs         1          00000001  
// peanuts      2          00000010           3     0000000110
// shellfish    4          00000100
// strawberries 8          00001000
// tomatoes     16         00010000
// chocolate    32         00100000
// pollen       64         01000000
// cats         128;       10000000

namespace Allergens
{
  public class Allergy
  {


    public static List<string> getAllergies(int score)
    {
      string[] allergens = { "cats", "pollen", "chocolate", "tomatoes", "strawberries", "shellfish", "peanuts", "eggs" };
      List<string> results = new List<string> { };
      string binary = Convert.ToString(score, 2); //99 ===      01100011
      int zerosToAdd = 8 - binary.Length;
      for (int i = 0; i < zerosToAdd; i++) // 5 ===      00000101     101
      {
        binary = '0' + binary;
      }
      for (int i = 0; i < 8; i++)
      {
        if (binary[i] == '1')
        {
          results.Add(allergens[i]);
        }
      }
      return results;
    }


    public static List<string> getAllergies2(int score)
    {
      string[] allergens = { "cats", "pollen", "chocolate", "tomatoes", "strawberries", "shellfish", "peanuts", "eggs" };
      int[] allergensScore = { 128, 64, 32, 16, 8, 4, 2, 1 };
      List<string> results = new List<string> { };
      for (int i = 0; i < allergens.Length; i++)
      {
        if (score > allergensScore[i]) // 221 // 93 // 29 // 13 // 5 // 1
        {                                   // cats pollen tomatos straw shellf eggs
          results.Add(allergens[i]);
          score -= allergensScore[i];
        }
      }
      return results;


    }





  }

  public class main
  {
    public static void Main()
    {
      string line;
      Console.WriteLine("Enter a score between 255 and 1");
      while ((line = Console.ReadLine()) != "x")
      {
        int x = int.Parse(line);
        List<string> results = Allergy.getAllergies(x);

        foreach (string item in results)
        {
          Console.WriteLine(item);
        }
        Console.WriteLine("Enter a score between 255 and 1");
      }


    }

  }

}