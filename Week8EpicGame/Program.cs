string folderPath = @"C:\lol\lol\lol\xD";
string heroFile = "Nädal8Kangelased.txt";
string villainFile = "Nädal8Kurjategijad.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapon = { "haavel", "püstol", "banaan", "kahvel", "mõõk" };

string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
Console.WriteLine($"Täna on kangelaseks {hero} ({heroHP} HP), ning tema relv on {heroWeapon}.");


string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrength = villainHP;
Console.WriteLine($"Täna on kurjategijaks {villain} ({villainHP} HP), ning tema relvaks on {villainWeapon}.");

while (heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}

Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} HP: {villainHP}");

if (heroHP > 0 )
{
    Console.WriteLine($"{hero} päästab päeva");
}
else if (villainHP > 0 )
{
    Console.WriteLine($"{villain} võitis");
}
else
{
    Console.WriteLine("Viik!");
}

static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if(characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0,characterHP);

    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made critical hit");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }
    return strike;
}