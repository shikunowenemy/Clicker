using System.Collections.Generic;
using UnityEngine;

public class NameRandomizer
{
    private static List<string> _names = new() { "Grandpa's computer", "Grandma's computer", "School computer", "Work computer", "President's computer", "Teacher's computer", "Friend's computer" };

    public static string GetRandomName() => _names[Random.Range(0, _names.Count)];
}
