// See https://aka.ms/new-console-template for more information

using lab3.Model.Weapons;

Console.WriteLine("Hello, World!");

// Sword sword = new("Sword", "asd", 1, 1, 1, 1, 1, 1);

Sword sword = Sword.SwordBuilder
    .SetName("Sword")
    .SetDescription("asd")
    .SetLevel(1)
    .SetUsageLimit(1)
    .SetWeight(1)
    .SetDamageConst(1)
    .SetReloadConst(1)
    .SetActionRadiusConst(1).Build();
    
Console.WriteLine("Hello, World!");