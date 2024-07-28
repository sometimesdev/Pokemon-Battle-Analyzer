'By:sometimesdev. https://github.com/sometimesdev/Pokemon-Battle-Type-Analyzer
'Description: A basic app to compare the types of your pokemon versus your opponent pokemon.
'               using the damaage percentages based off of the Pokemon Ultra Violet Guide.
'Thanks to: LocksmithArmy for creating Pokemon Ultra Violet. https://www.pokecommunity.com/threads/pokemon-ultra-violet-version.296499/
'           Armgilles for the Pokemon.csv. https://gist.github.com/armgilles/194bcff35001e7eb53a2a8b441e8b2c6
'           HybridShivam for images yet to be used. https://github.com/HybridShivam/Pokemon
'I apologize for the sloppy code. It was heavily ChatGPT influenced for covenience because I'm playing the game right now and want quick results.


Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class Form1
    Public pokemons As New List(Of Pokemon)

    ' Type effectiveness array (2D array)
    'ChatGPT generated, I havent confirmed accuracy myself.
    Dim typeEffectiveness(,) As Double = {
        {1, 1, 1, 1, 1, 0.5, 1, 0, 0.5, 1, 1, 1, 1, 1, 1, 1, 1, 1}, ' Normal
        {2, 1, 0.5, 0.5, 1, 2, 0.5, 0, 2, 1, 1, 1, 1, 2, 1, 1, 2, 0.5}, ' Fighting
        {1, 2, 1, 1, 1, 0.5, 2, 1, 0.5, 1, 1, 2, 0.5, 1, 1, 1, 1, 1}, ' Flying
        {1, 1, 1, 0.5, 0.5, 0.5, 1, 0.5, 0, 1, 1, 2, 1, 1, 1, 1, 1, 2}, ' Poison
        {1, 1, 0, 2, 1, 2, 0.5, 1, 2, 2, 1, 0.5, 2, 1, 1, 1, 1, 1}, ' Ground
        {1, 0.5, 2, 1, 0.5, 1, 2, 1, 0.5, 2, 1, 2, 1, 1, 1, 1, 1, 1}, ' Rock
        {1, 0.5, 0.5, 0.5, 1, 1, 1, 0.5, 0.5, 0.5, 1, 2, 1, 2, 1, 1, 2, 0.5}, ' Bug
        {0, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 0.5, 1, 1, 0.5, 1}, ' Ghost
        {1, 1, 1, 1, 1, 2, 1, 1, 0.5, 0.5, 0.5, 1, 1, 1, 2, 1, 1, 1}, ' Steel
        {1, 1, 1, 1, 1, 0.5, 2, 1, 2, 0.5, 0.5, 2, 1, 1, 2, 0.5, 1, 1}, ' Fire
        {1, 1, 1, 1, 2, 2, 1, 1, 1, 2, 0.5, 0.5, 1, 1, 1, 0.5, 1, 1}, ' Water
        {1, 1, 0.5, 0.5, 2, 2, 0.5, 1, 0.5, 0.5, 2, 0.5, 1, 1, 1, 0.5, 1, 1}, ' Grass
        {1, 1, 2, 1, 0, 1, 1, 1, 1, 1, 2, 2, 0.5, 1, 1, 0.5, 1, 1}, ' Electric
        {1, 0.5, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0.5, 1, 1, 0, 1}, ' Psychic
        {1, 2, 2, 1, 1, 2, 1, 1, 1, 0.5, 0.5, 1, 1, 1, 0.5, 2, 1, 1}, ' Ice
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 0.5}, ' Dragon
        {1, 0.5, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 0.5, 0.5}, ' Dark
        {1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 1, 1} ' Fairy
    }

    'Pokemon Data thanks to Armgilles. https://gist.github.com/armgilles/194bcff35001e7eb53a2a8b441e8b2c6
    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim pokemons As New List(Of Pokemon) From {
New Pokemon With {.Id = 1, .Name = "Bulbasaur", .Type1 = "Grass", .Type2 = "Poison", .Total = 318, .HP = 45, .Attack = 49, .Defense = 49, .SpAtk = 65, .SpDef = 65, .Speed = 45, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 2, .Name = "Ivysaur", .Type1 = "Grass", .Type2 = "Poison", .Total = 405, .HP = 60, .Attack = 62, .Defense = 63, .SpAtk = 80, .SpDef = 80, .Speed = 60, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 3, .Name = "Venusaur", .Type1 = "Grass", .Type2 = "Poison", .Total = 525, .HP = 80, .Attack = 82, .Defense = 83, .SpAtk = 100, .SpDef = 100, .Speed = 80, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 3, .Name = "VenusaurMega Venusaur", .Type1 = "Grass", .Type2 = "Poison", .Total = 625, .HP = 80, .Attack = 100, .Defense = 123, .SpAtk = 122, .SpDef = 120, .Speed = 80, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 4, .Name = "Charmander", .Type1 = "Fire", .Type2 = "Nothing", .Total = 309, .HP = 39, .Attack = 52, .Defense = 43, .SpAtk = 60, .SpDef = 50, .Speed = 65, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 5, .Name = "Charmeleon", .Type1 = "Fire", .Type2 = "Nothing", .Total = 405, .HP = 58, .Attack = 64, .Defense = 58, .SpAtk = 80, .SpDef = 65, .Speed = 80, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 6, .Name = "Charizard", .Type1 = "Fire", .Type2 = "Flying", .Total = 534, .HP = 78, .Attack = 84, .Defense = 78, .SpAtk = 109, .SpDef = 85, .Speed = 100, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 6, .Name = "CharizardMega Charizard X", .Type1 = "Fire", .Type2 = "Dragon", .Total = 634, .HP = 78, .Attack = 130, .Defense = 111, .SpAtk = 130, .SpDef = 85, .Speed = 100, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 6, .Name = "CharizardMega Charizard Y", .Type1 = "Fire", .Type2 = "Flying", .Total = 634, .HP = 78, .Attack = 104, .Defense = 78, .SpAtk = 159, .SpDef = 115, .Speed = 100, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 7, .Name = "Squirtle", .Type1 = "Water", .Type2 = "Nothing", .Total = 314, .HP = 44, .Attack = 48, .Defense = 65, .SpAtk = 50, .SpDef = 64, .Speed = 43, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 8, .Name = "Wartortle", .Type1 = "Water", .Type2 = "Nothing", .Total = 405, .HP = 59, .Attack = 63, .Defense = 80, .SpAtk = 65, .SpDef = 80, .Speed = 58, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 9, .Name = "Blastoise", .Type1 = "Water", .Type2 = "Nothing", .Total = 530, .HP = 79, .Attack = 83, .Defense = 100, .SpAtk = 85, .SpDef = 105, .Speed = 78, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 9, .Name = "BlastoiseMega Blastoise", .Type1 = "Water", .Type2 = "Nothing", .Total = 630, .HP = 79, .Attack = 103, .Defense = 120, .SpAtk = 135, .SpDef = 115, .Speed = 78, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 10, .Name = "Caterpie", .Type1 = "Bug", .Type2 = "Nothing", .Total = 195, .HP = 45, .Attack = 30, .Defense = 35, .SpAtk = 20, .SpDef = 20, .Speed = 45, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 11, .Name = "Metapod", .Type1 = "Bug", .Type2 = "Nothing", .Total = 205, .HP = 50, .Attack = 20, .Defense = 55, .SpAtk = 25, .SpDef = 25, .Speed = 30, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 12, .Name = "Butterfree", .Type1 = "Bug", .Type2 = "Flying", .Total = 395, .HP = 60, .Attack = 45, .Defense = 50, .SpAtk = 90, .SpDef = 80, .Speed = 70, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 13, .Name = "Weedle", .Type1 = "Bug", .Type2 = "Poison", .Total = 195, .HP = 40, .Attack = 35, .Defense = 30, .SpAtk = 20, .SpDef = 20, .Speed = 50, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 14, .Name = "Kakuna", .Type1 = "Bug", .Type2 = "Poison", .Total = 205, .HP = 45, .Attack = 25, .Defense = 50, .SpAtk = 25, .SpDef = 25, .Speed = 35, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 15, .Name = "Beedrill", .Type1 = "Bug", .Type2 = "Poison", .Total = 395, .HP = 65, .Attack = 90, .Defense = 40, .SpAtk = 45, .SpDef = 80, .Speed = 75, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 15, .Name = "BeedrillMega Beedrill", .Type1 = "Bug", .Type2 = "Poison", .Total = 495, .HP = 65, .Attack = 150, .Defense = 40, .SpAtk = 15, .SpDef = 80, .Speed = 145, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 16, .Name = "Pidgey", .Type1 = "Normal", .Type2 = "Flying", .Total = 251, .HP = 40, .Attack = 45, .Defense = 40, .SpAtk = 35, .SpDef = 35, .Speed = 56, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 17, .Name = "Pidgeotto", .Type1 = "Normal", .Type2 = "Flying", .Total = 349, .HP = 63, .Attack = 60, .Defense = 55, .SpAtk = 50, .SpDef = 50, .Speed = 71, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 18, .Name = "Pidgeot", .Type1 = "Normal", .Type2 = "Flying", .Total = 479, .HP = 83, .Attack = 80, .Defense = 75, .SpAtk = 70, .SpDef = 70, .Speed = 101, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 18, .Name = "PidgeotMega Pidgeot", .Type1 = "Normal", .Type2 = "Flying", .Total = 579, .HP = 83, .Attack = 80, .Defense = 80, .SpAtk = 135, .SpDef = 80, .Speed = 121, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 19, .Name = "Rattata", .Type1 = "Normal", .Type2 = "Nothing", .Total = 253, .HP = 30, .Attack = 56, .Defense = 35, .SpAtk = 25, .SpDef = 35, .Speed = 72, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 20, .Name = "Raticate", .Type1 = "Normal", .Type2 = "Nothing", .Total = 413, .HP = 55, .Attack = 81, .Defense = 60, .SpAtk = 50, .SpDef = 70, .Speed = 97, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 21, .Name = "Spearow", .Type1 = "Normal", .Type2 = "Flying", .Total = 262, .HP = 40, .Attack = 60, .Defense = 30, .SpAtk = 31, .SpDef = 31, .Speed = 70, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 22, .Name = "Fearow", .Type1 = "Normal", .Type2 = "Flying", .Total = 442, .HP = 65, .Attack = 90, .Defense = 65, .SpAtk = 61, .SpDef = 61, .Speed = 100, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 23, .Name = "Ekans", .Type1 = "Poison", .Type2 = "Nothing", .Total = 288, .HP = 35, .Attack = 60, .Defense = 44, .SpAtk = 40, .SpDef = 54, .Speed = 55, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 24, .Name = "Arbok", .Type1 = "Poison", .Type2 = "Nothing", .Total = 438, .HP = 60, .Attack = 85, .Defense = 69, .SpAtk = 65, .SpDef = 79, .Speed = 80, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 25, .Name = "Pikachu", .Type1 = "Electric", .Type2 = "Nothing", .Total = 320, .HP = 35, .Attack = 55, .Defense = 40, .SpAtk = 50, .SpDef = 50, .Speed = 90, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 26, .Name = "Raichu", .Type1 = "Electric", .Type2 = "Nothing", .Total = 485, .HP = 60, .Attack = 90, .Defense = 55, .SpAtk = 90, .SpDef = 80, .Speed = 110, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 27, .Name = "Sandshrew", .Type1 = "Ground", .Type2 = "Nothing", .Total = 300, .HP = 50, .Attack = 75, .Defense = 85, .SpAtk = 20, .SpDef = 30, .Speed = 40, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 28, .Name = "Sandslash", .Type1 = "Ground", .Type2 = "Nothing", .Total = 450, .HP = 75, .Attack = 100, .Defense = 110, .SpAtk = 45, .SpDef = 55, .Speed = 65, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 29, .Name = "Nidoran♀", .Type1 = "Poison", .Type2 = "Nothing", .Total = 275, .HP = 55, .Attack = 47, .Defense = 52, .SpAtk = 40, .SpDef = 40, .Speed = 41, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 30, .Name = "Nidorina", .Type1 = "Poison", .Type2 = "Nothing", .Total = 365, .HP = 70, .Attack = 62, .Defense = 67, .SpAtk = 55, .SpDef = 55, .Speed = 56, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 31, .Name = "Nidoqueen", .Type1 = "Poison", .Type2 = "Ground", .Total = 505, .HP = 90, .Attack = 92, .Defense = 87, .SpAtk = 75, .SpDef = 85, .Speed = 76, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 32, .Name = "Nidoran♂", .Type1 = "Poison", .Type2 = "Nothing", .Total = 273, .HP = 46, .Attack = 57, .Defense = 40, .SpAtk = 40, .SpDef = 40, .Speed = 50, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 33, .Name = "Nidorino", .Type1 = "Poison", .Type2 = "Nothing", .Total = 365, .HP = 61, .Attack = 72, .Defense = 57, .SpAtk = 55, .SpDef = 55, .Speed = 65, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 34, .Name = "Nidoking", .Type1 = "Poison", .Type2 = "Ground", .Total = 505, .HP = 81, .Attack = 102, .Defense = 77, .SpAtk = 85, .SpDef = 75, .Speed = 85, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 35, .Name = "Clefairy", .Type1 = "Fairy", .Type2 = "Nothing", .Total = 323, .HP = 70, .Attack = 45, .Defense = 48, .SpAtk = 60, .SpDef = 65, .Speed = 35, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 36, .Name = "Clefable", .Type1 = "Fairy", .Type2 = "Nothing", .Total = 483, .HP = 95, .Attack = 70, .Defense = 73, .SpAtk = 95, .SpDef = 90, .Speed = 60, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 37, .Name = "Vulpix", .Type1 = "Fire", .Type2 = "Nothing", .Total = 299, .HP = 38, .Attack = 41, .Defense = 40, .SpAtk = 50, .SpDef = 65, .Speed = 65, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 38, .Name = "Ninetales", .Type1 = "Fire", .Type2 = "Nothing", .Total = 505, .HP = 73, .Attack = 76, .Defense = 75, .SpAtk = 81, .SpDef = 100, .Speed = 100, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 39, .Name = "Jigglypuff", .Type1 = "Normal", .Type2 = "Fairy", .Total = 270, .HP = 115, .Attack = 45, .Defense = 20, .SpAtk = 45, .SpDef = 25, .Speed = 20, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 40, .Name = "Wigglytuff", .Type1 = "Normal", .Type2 = "Fairy", .Total = 435, .HP = 140, .Attack = 70, .Defense = 45, .SpAtk = 85, .SpDef = 50, .Speed = 45, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 41, .Name = "Zubat", .Type1 = "Poison", .Type2 = "Flying", .Total = 245, .HP = 40, .Attack = 45, .Defense = 35, .SpAtk = 30, .SpDef = 40, .Speed = 55, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 42, .Name = "Golbat", .Type1 = "Poison", .Type2 = "Flying", .Total = 455, .HP = 75, .Attack = 80, .Defense = 70, .SpAtk = 65, .SpDef = 75, .Speed = 90, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 43, .Name = "Oddish", .Type1 = "Grass", .Type2 = "Poison", .Total = 320, .HP = 45, .Attack = 50, .Defense = 55, .SpAtk = 75, .SpDef = 65, .Speed = 30, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 44, .Name = "Gloom", .Type1 = "Grass", .Type2 = "Poison", .Total = 395, .HP = 60, .Attack = 65, .Defense = 70, .SpAtk = 85, .SpDef = 75, .Speed = 40, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 45, .Name = "Vileplume", .Type1 = "Grass", .Type2 = "Poison", .Total = 490, .HP = 75, .Attack = 80, .Defense = 85, .SpAtk = 110, .SpDef = 90, .Speed = 50, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 46, .Name = "Paras", .Type1 = "Bug", .Type2 = "Grass", .Total = 285, .HP = 35, .Attack = 70, .Defense = 55, .SpAtk = 45, .SpDef = 55, .Speed = 25, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 47, .Name = "Parasect", .Type1 = "Bug", .Type2 = "Grass", .Total = 405, .HP = 60, .Attack = 95, .Defense = 80, .SpAtk = 60, .SpDef = 80, .Speed = 30, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 48, .Name = "Venonat", .Type1 = "Bug", .Type2 = "Poison", .Total = 305, .HP = 60, .Attack = 55, .Defense = 50, .SpAtk = 40, .SpDef = 55, .Speed = 45, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 49, .Name = "Venomoth", .Type1 = "Bug", .Type2 = "Poison", .Total = 450, .HP = 70, .Attack = 65, .Defense = 60, .SpAtk = 90, .SpDef = 75, .Speed = 90, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 50, .Name = "Diglett", .Type1 = "Ground", .Type2 = "Nothing", .Total = 265, .HP = 10, .Attack = 55, .Defense = 25, .SpAtk = 35, .SpDef = 45, .Speed = 95, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 51, .Name = "Dugtrio", .Type1 = "Ground", .Type2 = "Nothing", .Total = 405, .HP = 35, .Attack = 80, .Defense = 50, .SpAtk = 50, .SpDef = 70, .Speed = 120, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 52, .Name = "Meowth", .Type1 = "Normal", .Type2 = "Nothing", .Total = 290, .HP = 40, .Attack = 45, .Defense = 35, .SpAtk = 40, .SpDef = 40, .Speed = 90, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 53, .Name = "Persian", .Type1 = "Normal", .Type2 = "Nothing", .Total = 440, .HP = 65, .Attack = 70, .Defense = 60, .SpAtk = 65, .SpDef = 65, .Speed = 115, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 54, .Name = "Psyduck", .Type1 = "Water", .Type2 = "Nothing", .Total = 320, .HP = 50, .Attack = 52, .Defense = 48, .SpAtk = 65, .SpDef = 50, .Speed = 55, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 55, .Name = "Golduck", .Type1 = "Water", .Type2 = "Nothing", .Total = 500, .HP = 80, .Attack = 82, .Defense = 78, .SpAtk = 95, .SpDef = 80, .Speed = 85, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 56, .Name = "Mankey", .Type1 = "Fighting", .Type2 = "Nothing", .Total = 305, .HP = 40, .Attack = 80, .Defense = 35, .SpAtk = 35, .SpDef = 45, .Speed = 70, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 57, .Name = "Primeape", .Type1 = "Fighting", .Type2 = "Nothing", .Total = 455, .HP = 65, .Attack = 105, .Defense = 60, .SpAtk = 60, .SpDef = 70, .Speed = 95, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 58, .Name = "Growlithe", .Type1 = "Fire", .Type2 = "Nothing", .Total = 350, .HP = 55, .Attack = 70, .Defense = 45, .SpAtk = 70, .SpDef = 50, .Speed = 60, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 59, .Name = "Arcanine", .Type1 = "Fire", .Type2 = "Nothing", .Total = 555, .HP = 90, .Attack = 110, .Defense = 80, .SpAtk = 100, .SpDef = 80, .Speed = 95, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 60, .Name = "Poliwag", .Type1 = "Water", .Type2 = "Nothing", .Total = 300, .HP = 40, .Attack = 50, .Defense = 40, .SpAtk = 40, .SpDef = 40, .Speed = 90, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 61, .Name = "Poliwhirl", .Type1 = "Water", .Type2 = "Nothing", .Total = 385, .HP = 65, .Attack = 65, .Defense = 65, .SpAtk = 50, .SpDef = 50, .Speed = 90, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 62, .Name = "Poliwrath", .Type1 = "Water", .Type2 = "Fighting", .Total = 510, .HP = 90, .Attack = 95, .Defense = 95, .SpAtk = 70, .SpDef = 90, .Speed = 70, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 63, .Name = "Abra", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 310, .HP = 25, .Attack = 20, .Defense = 15, .SpAtk = 105, .SpDef = 55, .Speed = 90, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 64, .Name = "Kadabra", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 400, .HP = 40, .Attack = 35, .Defense = 30, .SpAtk = 120, .SpDef = 70, .Speed = 105, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 65, .Name = "Alakazam", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 500, .HP = 55, .Attack = 50, .Defense = 45, .SpAtk = 135, .SpDef = 95, .Speed = 120, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 65, .Name = "AlakazamMega Alakazam", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 590, .HP = 55, .Attack = 50, .Defense = 65, .SpAtk = 175, .SpDef = 95, .Speed = 150, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 66, .Name = "Machop", .Type1 = "Fighting", .Type2 = "Nothing", .Total = 305, .HP = 70, .Attack = 80, .Defense = 50, .SpAtk = 35, .SpDef = 35, .Speed = 35, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 67, .Name = "Machoke", .Type1 = "Fighting", .Type2 = "Nothing", .Total = 405, .HP = 80, .Attack = 100, .Defense = 70, .SpAtk = 50, .SpDef = 60, .Speed = 45, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 68, .Name = "Machamp", .Type1 = "Fighting", .Type2 = "Nothing", .Total = 505, .HP = 90, .Attack = 130, .Defense = 80, .SpAtk = 65, .SpDef = 85, .Speed = 55, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 69, .Name = "Bellsprout", .Type1 = "Grass", .Type2 = "Poison", .Total = 300, .HP = 50, .Attack = 75, .Defense = 35, .SpAtk = 70, .SpDef = 30, .Speed = 40, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 70, .Name = "Weepinbell", .Type1 = "Grass", .Type2 = "Poison", .Total = 390, .HP = 65, .Attack = 90, .Defense = 50, .SpAtk = 85, .SpDef = 45, .Speed = 55, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 71, .Name = "Victreebel", .Type1 = "Grass", .Type2 = "Poison", .Total = 490, .HP = 80, .Attack = 105, .Defense = 65, .SpAtk = 100, .SpDef = 70, .Speed = 70, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 72, .Name = "Tentacool", .Type1 = "Water", .Type2 = "Poison", .Total = 335, .HP = 40, .Attack = 40, .Defense = 35, .SpAtk = 50, .SpDef = 100, .Speed = 70, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 73, .Name = "Tentacruel", .Type1 = "Water", .Type2 = "Poison", .Total = 515, .HP = 80, .Attack = 70, .Defense = 65, .SpAtk = 80, .SpDef = 120, .Speed = 100, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 74, .Name = "Geodude", .Type1 = "Rock", .Type2 = "Ground", .Total = 300, .HP = 40, .Attack = 80, .Defense = 100, .SpAtk = 30, .SpDef = 30, .Speed = 20, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 75, .Name = "Graveler", .Type1 = "Rock", .Type2 = "Ground", .Total = 390, .HP = 55, .Attack = 95, .Defense = 115, .SpAtk = 45, .SpDef = 45, .Speed = 35, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 76, .Name = "Golem", .Type1 = "Rock", .Type2 = "Ground", .Total = 495, .HP = 80, .Attack = 120, .Defense = 130, .SpAtk = 55, .SpDef = 65, .Speed = 45, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 77, .Name = "Ponyta", .Type1 = "Fire", .Type2 = "Nothing", .Total = 410, .HP = 50, .Attack = 85, .Defense = 55, .SpAtk = 65, .SpDef = 65, .Speed = 90, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 78, .Name = "Rapidash", .Type1 = "Fire", .Type2 = "Nothing", .Total = 500, .HP = 65, .Attack = 100, .Defense = 70, .SpAtk = 80, .SpDef = 80, .Speed = 105, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 79, .Name = "Slowpoke", .Type1 = "Water", .Type2 = "Psychic", .Total = 315, .HP = 90, .Attack = 65, .Defense = 65, .SpAtk = 40, .SpDef = 40, .Speed = 15, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 80, .Name = "Slowbro", .Type1 = "Water", .Type2 = "Psychic", .Total = 490, .HP = 95, .Attack = 75, .Defense = 110, .SpAtk = 100, .SpDef = 80, .Speed = 30, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 80, .Name = "SlowbroMega Slowbro", .Type1 = "Water", .Type2 = "Psychic", .Total = 590, .HP = 95, .Attack = 75, .Defense = 180, .SpAtk = 130, .SpDef = 80, .Speed = 30, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 81, .Name = "Magnemite", .Type1 = "Electric", .Type2 = "Steel", .Total = 325, .HP = 25, .Attack = 35, .Defense = 70, .SpAtk = 95, .SpDef = 55, .Speed = 45, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 82, .Name = "Magneton", .Type1 = "Electric", .Type2 = "Steel", .Total = 465, .HP = 50, .Attack = 60, .Defense = 95, .SpAtk = 120, .SpDef = 70, .Speed = 70, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 83, .Name = "Farfetch'd", .Type1 = "Normal", .Type2 = "Flying", .Total = 352, .HP = 52, .Attack = 65, .Defense = 55, .SpAtk = 58, .SpDef = 62, .Speed = 60, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 84, .Name = "Doduo", .Type1 = "Normal", .Type2 = "Flying", .Total = 310, .HP = 35, .Attack = 85, .Defense = 45, .SpAtk = 35, .SpDef = 35, .Speed = 75, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 85, .Name = "Dodrio", .Type1 = "Normal", .Type2 = "Flying", .Total = 460, .HP = 60, .Attack = 110, .Defense = 70, .SpAtk = 60, .SpDef = 60, .Speed = 100, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 86, .Name = "Seel", .Type1 = "Water", .Type2 = "Nothing", .Total = 325, .HP = 65, .Attack = 45, .Defense = 55, .SpAtk = 45, .SpDef = 70, .Speed = 45, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 87, .Name = "Dewgong", .Type1 = "Water", .Type2 = "Ice", .Total = 475, .HP = 90, .Attack = 70, .Defense = 80, .SpAtk = 70, .SpDef = 95, .Speed = 70, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 88, .Name = "Grimer", .Type1 = "Poison", .Type2 = "Nothing", .Total = 325, .HP = 80, .Attack = 80, .Defense = 50, .SpAtk = 40, .SpDef = 50, .Speed = 25, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 89, .Name = "Muk", .Type1 = "Poison", .Type2 = "Nothing", .Total = 500, .HP = 105, .Attack = 105, .Defense = 75, .SpAtk = 65, .SpDef = 100, .Speed = 50, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 90, .Name = "Shellder", .Type1 = "Water", .Type2 = "Nothing", .Total = 305, .HP = 30, .Attack = 65, .Defense = 100, .SpAtk = 45, .SpDef = 25, .Speed = 40, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 91, .Name = "Cloyster", .Type1 = "Water", .Type2 = "Ice", .Total = 525, .HP = 50, .Attack = 95, .Defense = 180, .SpAtk = 85, .SpDef = 45, .Speed = 70, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 92, .Name = "Gastly", .Type1 = "Ghost", .Type2 = "Poison", .Total = 310, .HP = 30, .Attack = 35, .Defense = 30, .SpAtk = 100, .SpDef = 35, .Speed = 80, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 93, .Name = "Haunter", .Type1 = "Ghost", .Type2 = "Poison", .Total = 405, .HP = 45, .Attack = 50, .Defense = 45, .SpAtk = 115, .SpDef = 55, .Speed = 95, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 94, .Name = "Gengar", .Type1 = "Ghost", .Type2 = "Poison", .Total = 500, .HP = 60, .Attack = 65, .Defense = 60, .SpAtk = 130, .SpDef = 75, .Speed = 110, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 94, .Name = "GengarMega Gengar", .Type1 = "Ghost", .Type2 = "Poison", .Total = 600, .HP = 60, .Attack = 65, .Defense = 80, .SpAtk = 170, .SpDef = 95, .Speed = 130, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 95, .Name = "Onix", .Type1 = "Rock", .Type2 = "Ground", .Total = 385, .HP = 35, .Attack = 45, .Defense = 160, .SpAtk = 30, .SpDef = 45, .Speed = 70, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 96, .Name = "Drowzee", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 328, .HP = 60, .Attack = 48, .Defense = 45, .SpAtk = 43, .SpDef = 90, .Speed = 42, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 97, .Name = "Hypno", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 483, .HP = 85, .Attack = 73, .Defense = 70, .SpAtk = 73, .SpDef = 115, .Speed = 67, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 98, .Name = "Krabby", .Type1 = "Water", .Type2 = "Nothing", .Total = 325, .HP = 30, .Attack = 105, .Defense = 90, .SpAtk = 25, .SpDef = 25, .Speed = 50, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 99, .Name = "Kingler", .Type1 = "Water", .Type2 = "Nothing", .Total = 475, .HP = 55, .Attack = 130, .Defense = 115, .SpAtk = 50, .SpDef = 50, .Speed = 75, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 100, .Name = "Voltorb", .Type1 = "Electric", .Type2 = "Nothing", .Total = 330, .HP = 40, .Attack = 30, .Defense = 50, .SpAtk = 55, .SpDef = 55, .Speed = 100, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 101, .Name = "Electrode", .Type1 = "Electric", .Type2 = "Nothing", .Total = 480, .HP = 60, .Attack = 50, .Defense = 70, .SpAtk = 80, .SpDef = 80, .Speed = 140, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 102, .Name = "Exeggcute", .Type1 = "Grass", .Type2 = "Psychic", .Total = 325, .HP = 60, .Attack = 40, .Defense = 80, .SpAtk = 60, .SpDef = 45, .Speed = 40, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 103, .Name = "Exeggutor", .Type1 = "Grass", .Type2 = "Psychic", .Total = 520, .HP = 95, .Attack = 95, .Defense = 85, .SpAtk = 125, .SpDef = 65, .Speed = 55, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 104, .Name = "Cubone", .Type1 = "Ground", .Type2 = "Nothing", .Total = 320, .HP = 50, .Attack = 50, .Defense = 95, .SpAtk = 40, .SpDef = 50, .Speed = 35, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 105, .Name = "Marowak", .Type1 = "Ground", .Type2 = "Nothing", .Total = 425, .HP = 60, .Attack = 80, .Defense = 110, .SpAtk = 50, .SpDef = 80, .Speed = 45, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 106, .Name = "Hitmonlee", .Type1 = "Fighting", .Type2 = "Nothing", .Total = 455, .HP = 50, .Attack = 120, .Defense = 53, .SpAtk = 35, .SpDef = 110, .Speed = 87, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 107, .Name = "Hitmonchan", .Type1 = "Fighting", .Type2 = "Nothing", .Total = 455, .HP = 50, .Attack = 105, .Defense = 79, .SpAtk = 35, .SpDef = 110, .Speed = 76, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 108, .Name = "Lickitung", .Type1 = "Normal", .Type2 = "Nothing", .Total = 385, .HP = 90, .Attack = 55, .Defense = 75, .SpAtk = 60, .SpDef = 75, .Speed = 30, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 109, .Name = "Koffing", .Type1 = "Poison", .Type2 = "Nothing", .Total = 340, .HP = 40, .Attack = 65, .Defense = 95, .SpAtk = 60, .SpDef = 45, .Speed = 35, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 110, .Name = "Weezing", .Type1 = "Poison", .Type2 = "Nothing", .Total = 490, .HP = 65, .Attack = 90, .Defense = 120, .SpAtk = 85, .SpDef = 70, .Speed = 60, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 111, .Name = "Rhyhorn", .Type1 = "Ground", .Type2 = "Rock", .Total = 345, .HP = 80, .Attack = 85, .Defense = 95, .SpAtk = 30, .SpDef = 30, .Speed = 25, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 112, .Name = "Rhydon", .Type1 = "Ground", .Type2 = "Rock", .Total = 485, .HP = 105, .Attack = 130, .Defense = 120, .SpAtk = 45, .SpDef = 45, .Speed = 40, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 113, .Name = "Chansey", .Type1 = "Normal", .Type2 = "Nothing", .Total = 450, .HP = 250, .Attack = 5, .Defense = 5, .SpAtk = 35, .SpDef = 105, .Speed = 50, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 114, .Name = "Tangela", .Type1 = "Grass", .Type2 = "Nothing", .Total = 435, .HP = 65, .Attack = 55, .Defense = 115, .SpAtk = 100, .SpDef = 40, .Speed = 60, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 115, .Name = "Kangaskhan", .Type1 = "Normal", .Type2 = "Nothing", .Total = 490, .HP = 105, .Attack = 95, .Defense = 80, .SpAtk = 40, .SpDef = 80, .Speed = 90, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 115, .Name = "KangaskhanMega Kangaskhan", .Type1 = "Normal", .Type2 = "Nothing", .Total = 590, .HP = 105, .Attack = 125, .Defense = 100, .SpAtk = 60, .SpDef = 100, .Speed = 100, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 116, .Name = "Horsea", .Type1 = "Water", .Type2 = "Nothing", .Total = 295, .HP = 30, .Attack = 40, .Defense = 70, .SpAtk = 70, .SpDef = 25, .Speed = 60, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 117, .Name = "Seadra", .Type1 = "Water", .Type2 = "Nothing", .Total = 440, .HP = 55, .Attack = 65, .Defense = 95, .SpAtk = 95, .SpDef = 45, .Speed = 85, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 118, .Name = "Goldeen", .Type1 = "Water", .Type2 = "Nothing", .Total = 320, .HP = 45, .Attack = 67, .Defense = 60, .SpAtk = 35, .SpDef = 50, .Speed = 63, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 119, .Name = "Seaking", .Type1 = "Water", .Type2 = "Nothing", .Total = 450, .HP = 80, .Attack = 92, .Defense = 65, .SpAtk = 65, .SpDef = 80, .Speed = 68, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 120, .Name = "Staryu", .Type1 = "Water", .Type2 = "Nothing", .Total = 340, .HP = 30, .Attack = 45, .Defense = 55, .SpAtk = 70, .SpDef = 55, .Speed = 85, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 121, .Name = "Starmie", .Type1 = "Water", .Type2 = "Psychic", .Total = 520, .HP = 60, .Attack = 75, .Defense = 85, .SpAtk = 100, .SpDef = 85, .Speed = 115, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 122, .Name = "Mr. Mime", .Type1 = "Psychic", .Type2 = "Fairy", .Total = 460, .HP = 40, .Attack = 45, .Defense = 65, .SpAtk = 100, .SpDef = 120, .Speed = 90, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 123, .Name = "Scyther", .Type1 = "Bug", .Type2 = "Flying", .Total = 500, .HP = 70, .Attack = 110, .Defense = 80, .SpAtk = 55, .SpDef = 80, .Speed = 105, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 124, .Name = "Jynx", .Type1 = "Ice", .Type2 = "Psychic", .Total = 455, .HP = 65, .Attack = 50, .Defense = 35, .SpAtk = 115, .SpDef = 95, .Speed = 95, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 125, .Name = "Electabuzz", .Type1 = "Electric", .Type2 = "Nothing", .Total = 490, .HP = 65, .Attack = 83, .Defense = 57, .SpAtk = 95, .SpDef = 85, .Speed = 105, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 126, .Name = "Magmar", .Type1 = "Fire", .Type2 = "Nothing", .Total = 495, .HP = 65, .Attack = 95, .Defense = 57, .SpAtk = 100, .SpDef = 85, .Speed = 93, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 127, .Name = "Pinsir", .Type1 = "Bug", .Type2 = "Nothing", .Total = 500, .HP = 65, .Attack = 125, .Defense = 100, .SpAtk = 55, .SpDef = 70, .Speed = 85, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 127, .Name = "PinsirMega Pinsir", .Type1 = "Bug", .Type2 = "Flying", .Total = 600, .HP = 65, .Attack = 155, .Defense = 120, .SpAtk = 65, .SpDef = 90, .Speed = 105, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 128, .Name = "Tauros", .Type1 = "Normal", .Type2 = "Nothing", .Total = 490, .HP = 75, .Attack = 100, .Defense = 95, .SpAtk = 40, .SpDef = 70, .Speed = 110, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 129, .Name = "Magikarp", .Type1 = "Water", .Type2 = "Nothing", .Total = 200, .HP = 20, .Attack = 10, .Defense = 55, .SpAtk = 15, .SpDef = 20, .Speed = 80, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 130, .Name = "Gyarados", .Type1 = "Water", .Type2 = "Flying", .Total = 540, .HP = 95, .Attack = 125, .Defense = 79, .SpAtk = 60, .SpDef = 100, .Speed = 81, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 130, .Name = "GyaradosMega Gyarados", .Type1 = "Water", .Type2 = "Dark", .Total = 640, .HP = 95, .Attack = 155, .Defense = 109, .SpAtk = 70, .SpDef = 130, .Speed = 81, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 131, .Name = "Lapras", .Type1 = "Water", .Type2 = "Ice", .Total = 535, .HP = 130, .Attack = 85, .Defense = 80, .SpAtk = 85, .SpDef = 95, .Speed = 60, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 132, .Name = "Ditto", .Type1 = "Normal", .Type2 = "Nothing", .Total = 288, .HP = 48, .Attack = 48, .Defense = 48, .SpAtk = 48, .SpDef = 48, .Speed = 48, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 133, .Name = "Eevee", .Type1 = "Normal", .Type2 = "Nothing", .Total = 325, .HP = 55, .Attack = 55, .Defense = 50, .SpAtk = 45, .SpDef = 65, .Speed = 55, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 134, .Name = "Vaporeon", .Type1 = "Water", .Type2 = "Nothing", .Total = 525, .HP = 130, .Attack = 65, .Defense = 60, .SpAtk = 110, .SpDef = 95, .Speed = 65, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 135, .Name = "Jolteon", .Type1 = "Electric", .Type2 = "Nothing", .Total = 525, .HP = 65, .Attack = 65, .Defense = 60, .SpAtk = 110, .SpDef = 95, .Speed = 130, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 136, .Name = "Flareon", .Type1 = "Fire", .Type2 = "Nothing", .Total = 525, .HP = 65, .Attack = 130, .Defense = 60, .SpAtk = 95, .SpDef = 110, .Speed = 65, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 137, .Name = "Porygon", .Type1 = "Normal", .Type2 = "Nothing", .Total = 395, .HP = 65, .Attack = 60, .Defense = 70, .SpAtk = 85, .SpDef = 75, .Speed = 40, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 138, .Name = "Omanyte", .Type1 = "Rock", .Type2 = "Water", .Total = 355, .HP = 35, .Attack = 40, .Defense = 100, .SpAtk = 90, .SpDef = 55, .Speed = 35, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 139, .Name = "Omastar", .Type1 = "Rock", .Type2 = "Water", .Total = 495, .HP = 70, .Attack = 60, .Defense = 125, .SpAtk = 115, .SpDef = 70, .Speed = 55, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 140, .Name = "Kabuto", .Type1 = "Rock", .Type2 = "Water", .Total = 355, .HP = 30, .Attack = 80, .Defense = 90, .SpAtk = 55, .SpDef = 45, .Speed = 55, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 141, .Name = "Kabutops", .Type1 = "Rock", .Type2 = "Water", .Total = 495, .HP = 60, .Attack = 115, .Defense = 105, .SpAtk = 65, .SpDef = 70, .Speed = 80, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 142, .Name = "Aerodactyl", .Type1 = "Rock", .Type2 = "Flying", .Total = 515, .HP = 80, .Attack = 105, .Defense = 65, .SpAtk = 60, .SpDef = 75, .Speed = 130, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 142, .Name = "AerodactylMega Aerodactyl", .Type1 = "Rock", .Type2 = "Flying", .Total = 615, .HP = 80, .Attack = 135, .Defense = 85, .SpAtk = 70, .SpDef = 95, .Speed = 150, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 143, .Name = "Snorlax", .Type1 = "Normal", .Type2 = "Nothing", .Total = 540, .HP = 160, .Attack = 110, .Defense = 65, .SpAtk = 65, .SpDef = 110, .Speed = 30, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 144, .Name = "Articuno", .Type1 = "Ice", .Type2 = "Flying", .Total = 580, .HP = 90, .Attack = 85, .Defense = 100, .SpAtk = 95, .SpDef = 125, .Speed = 85, .Generation = 1, .Legendary = True},
New Pokemon With {.Id = 145, .Name = "Zapdos", .Type1 = "Electric", .Type2 = "Flying", .Total = 580, .HP = 90, .Attack = 90, .Defense = 85, .SpAtk = 125, .SpDef = 90, .Speed = 100, .Generation = 1, .Legendary = True},
New Pokemon With {.Id = 146, .Name = "Moltres", .Type1 = "Fire", .Type2 = "Flying", .Total = 580, .HP = 90, .Attack = 100, .Defense = 90, .SpAtk = 125, .SpDef = 85, .Speed = 90, .Generation = 1, .Legendary = True},
New Pokemon With {.Id = 147, .Name = "Dratini", .Type1 = "Dragon", .Type2 = "Nothing", .Total = 300, .HP = 41, .Attack = 64, .Defense = 45, .SpAtk = 50, .SpDef = 50, .Speed = 50, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 148, .Name = "Dragonair", .Type1 = "Dragon", .Type2 = "Nothing", .Total = 420, .HP = 61, .Attack = 84, .Defense = 65, .SpAtk = 70, .SpDef = 70, .Speed = 70, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 149, .Name = "Dragonite", .Type1 = "Dragon", .Type2 = "Flying", .Total = 600, .HP = 91, .Attack = 134, .Defense = 95, .SpAtk = 100, .SpDef = 100, .Speed = 80, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 150, .Name = "Mewtwo", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 680, .HP = 106, .Attack = 110, .Defense = 90, .SpAtk = 154, .SpDef = 90, .Speed = 130, .Generation = 1, .Legendary = True},
New Pokemon With {.Id = 150, .Name = "MewtwoMega Mewtwo X", .Type1 = "Psychic", .Type2 = "Fighting", .Total = 780, .HP = 106, .Attack = 190, .Defense = 100, .SpAtk = 154, .SpDef = 100, .Speed = 130, .Generation = 1, .Legendary = True},
New Pokemon With {.Id = 150, .Name = "MewtwoMega Mewtwo Y", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 780, .HP = 106, .Attack = 150, .Defense = 70, .SpAtk = 194, .SpDef = 120, .Speed = 140, .Generation = 1, .Legendary = True},
New Pokemon With {.Id = 151, .Name = "Mew", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 600, .HP = 100, .Attack = 100, .Defense = 100, .SpAtk = 100, .SpDef = 100, .Speed = 100, .Generation = 1, .Legendary = False},
New Pokemon With {.Id = 152, .Name = "Chikorita", .Type1 = "Grass", .Type2 = "Nothing", .Total = 318, .HP = 45, .Attack = 49, .Defense = 65, .SpAtk = 49, .SpDef = 65, .Speed = 45, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 153, .Name = "Bayleef", .Type1 = "Grass", .Type2 = "Nothing", .Total = 405, .HP = 60, .Attack = 62, .Defense = 80, .SpAtk = 63, .SpDef = 80, .Speed = 60, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 154, .Name = "Meganium", .Type1 = "Grass", .Type2 = "Nothing", .Total = 525, .HP = 80, .Attack = 82, .Defense = 100, .SpAtk = 83, .SpDef = 100, .Speed = 80, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 155, .Name = "Cyndaquil", .Type1 = "Fire", .Type2 = "Nothing", .Total = 309, .HP = 39, .Attack = 52, .Defense = 43, .SpAtk = 60, .SpDef = 50, .Speed = 65, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 156, .Name = "Quilava", .Type1 = "Fire", .Type2 = "Nothing", .Total = 405, .HP = 58, .Attack = 64, .Defense = 58, .SpAtk = 80, .SpDef = 65, .Speed = 80, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 157, .Name = "Typhlosion", .Type1 = "Fire", .Type2 = "Nothing", .Total = 534, .HP = 78, .Attack = 84, .Defense = 78, .SpAtk = 109, .SpDef = 85, .Speed = 100, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 158, .Name = "Totodile", .Type1 = "Water", .Type2 = "Nothing", .Total = 314, .HP = 50, .Attack = 65, .Defense = 64, .SpAtk = 44, .SpDef = 48, .Speed = 43, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 159, .Name = "Croconaw", .Type1 = "Water", .Type2 = "Nothing", .Total = 405, .HP = 65, .Attack = 80, .Defense = 80, .SpAtk = 59, .SpDef = 63, .Speed = 58, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 160, .Name = "Feraligatr", .Type1 = "Water", .Type2 = "Nothing", .Total = 530, .HP = 85, .Attack = 105, .Defense = 100, .SpAtk = 79, .SpDef = 83, .Speed = 78, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 161, .Name = "Sentret", .Type1 = "Normal", .Type2 = "Nothing", .Total = 215, .HP = 35, .Attack = 46, .Defense = 34, .SpAtk = 35, .SpDef = 45, .Speed = 20, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 162, .Name = "Furret", .Type1 = "Normal", .Type2 = "Nothing", .Total = 415, .HP = 85, .Attack = 76, .Defense = 64, .SpAtk = 45, .SpDef = 55, .Speed = 90, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 163, .Name = "Hoothoot", .Type1 = "Normal", .Type2 = "Flying", .Total = 262, .HP = 60, .Attack = 30, .Defense = 30, .SpAtk = 36, .SpDef = 56, .Speed = 50, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 164, .Name = "Noctowl", .Type1 = "Normal", .Type2 = "Flying", .Total = 442, .HP = 100, .Attack = 50, .Defense = 50, .SpAtk = 76, .SpDef = 96, .Speed = 70, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 165, .Name = "Ledyba", .Type1 = "Bug", .Type2 = "Flying", .Total = 265, .HP = 40, .Attack = 20, .Defense = 30, .SpAtk = 40, .SpDef = 80, .Speed = 55, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 166, .Name = "Ledian", .Type1 = "Bug", .Type2 = "Flying", .Total = 390, .HP = 55, .Attack = 35, .Defense = 50, .SpAtk = 55, .SpDef = 110, .Speed = 85, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 167, .Name = "Spinarak", .Type1 = "Bug", .Type2 = "Poison", .Total = 250, .HP = 40, .Attack = 60, .Defense = 40, .SpAtk = 40, .SpDef = 40, .Speed = 30, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 168, .Name = "Ariados", .Type1 = "Bug", .Type2 = "Poison", .Total = 390, .HP = 70, .Attack = 90, .Defense = 70, .SpAtk = 60, .SpDef = 60, .Speed = 40, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 169, .Name = "Crobat", .Type1 = "Poison", .Type2 = "Flying", .Total = 535, .HP = 85, .Attack = 90, .Defense = 80, .SpAtk = 70, .SpDef = 80, .Speed = 130, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 170, .Name = "Chinchou", .Type1 = "Water", .Type2 = "Electric", .Total = 330, .HP = 75, .Attack = 38, .Defense = 38, .SpAtk = 56, .SpDef = 56, .Speed = 67, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 171, .Name = "Lanturn", .Type1 = "Water", .Type2 = "Electric", .Total = 460, .HP = 125, .Attack = 58, .Defense = 58, .SpAtk = 76, .SpDef = 76, .Speed = 67, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 172, .Name = "Pichu", .Type1 = "Electric", .Type2 = "Nothing", .Total = 205, .HP = 20, .Attack = 40, .Defense = 15, .SpAtk = 35, .SpDef = 35, .Speed = 60, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 173, .Name = "Cleffa", .Type1 = "Fairy", .Type2 = "Nothing", .Total = 218, .HP = 50, .Attack = 25, .Defense = 28, .SpAtk = 45, .SpDef = 55, .Speed = 15, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 174, .Name = "Igglybuff", .Type1 = "Normal", .Type2 = "Fairy", .Total = 210, .HP = 90, .Attack = 30, .Defense = 15, .SpAtk = 40, .SpDef = 20, .Speed = 15, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 175, .Name = "Togepi", .Type1 = "Fairy", .Type2 = "Nothing", .Total = 245, .HP = 35, .Attack = 20, .Defense = 65, .SpAtk = 40, .SpDef = 65, .Speed = 20, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 176, .Name = "Togetic", .Type1 = "Fairy", .Type2 = "Flying", .Total = 405, .HP = 55, .Attack = 40, .Defense = 85, .SpAtk = 80, .SpDef = 105, .Speed = 40, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 177, .Name = "Natu", .Type1 = "Psychic", .Type2 = "Flying", .Total = 320, .HP = 40, .Attack = 50, .Defense = 45, .SpAtk = 70, .SpDef = 45, .Speed = 70, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 178, .Name = "Xatu", .Type1 = "Psychic", .Type2 = "Flying", .Total = 470, .HP = 65, .Attack = 75, .Defense = 70, .SpAtk = 95, .SpDef = 70, .Speed = 95, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 179, .Name = "Mareep", .Type1 = "Electric", .Type2 = "Nothing", .Total = 280, .HP = 55, .Attack = 40, .Defense = 40, .SpAtk = 65, .SpDef = 45, .Speed = 35, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 180, .Name = "Flaaffy", .Type1 = "Electric", .Type2 = "Nothing", .Total = 365, .HP = 70, .Attack = 55, .Defense = 55, .SpAtk = 80, .SpDef = 60, .Speed = 45, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 181, .Name = "Ampharos", .Type1 = "Electric", .Type2 = "Nothing", .Total = 510, .HP = 90, .Attack = 75, .Defense = 85, .SpAtk = 115, .SpDef = 90, .Speed = 55, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 181, .Name = "AmpharosMega Ampharos", .Type1 = "Electric", .Type2 = "Dragon", .Total = 610, .HP = 90, .Attack = 95, .Defense = 105, .SpAtk = 165, .SpDef = 110, .Speed = 45, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 182, .Name = "Bellossom", .Type1 = "Grass", .Type2 = "Nothing", .Total = 490, .HP = 75, .Attack = 80, .Defense = 95, .SpAtk = 90, .SpDef = 100, .Speed = 50, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 183, .Name = "Marill", .Type1 = "Water", .Type2 = "Fairy", .Total = 250, .HP = 70, .Attack = 20, .Defense = 50, .SpAtk = 20, .SpDef = 50, .Speed = 40, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 184, .Name = "Azumarill", .Type1 = "Water", .Type2 = "Fairy", .Total = 420, .HP = 100, .Attack = 50, .Defense = 80, .SpAtk = 60, .SpDef = 80, .Speed = 50, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 185, .Name = "Sudowoodo", .Type1 = "Rock", .Type2 = "Nothing", .Total = 410, .HP = 70, .Attack = 100, .Defense = 115, .SpAtk = 30, .SpDef = 65, .Speed = 30, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 186, .Name = "Politoed", .Type1 = "Water", .Type2 = "Nothing", .Total = 500, .HP = 90, .Attack = 75, .Defense = 75, .SpAtk = 90, .SpDef = 100, .Speed = 70, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 187, .Name = "Hoppip", .Type1 = "Grass", .Type2 = "Flying", .Total = 250, .HP = 35, .Attack = 35, .Defense = 40, .SpAtk = 35, .SpDef = 55, .Speed = 50, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 188, .Name = "Skiploom", .Type1 = "Grass", .Type2 = "Flying", .Total = 340, .HP = 55, .Attack = 45, .Defense = 50, .SpAtk = 45, .SpDef = 65, .Speed = 80, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 189, .Name = "Jumpluff", .Type1 = "Grass", .Type2 = "Flying", .Total = 460, .HP = 75, .Attack = 55, .Defense = 70, .SpAtk = 55, .SpDef = 95, .Speed = 110, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 190, .Name = "Aipom", .Type1 = "Normal", .Type2 = "Nothing", .Total = 360, .HP = 55, .Attack = 70, .Defense = 55, .SpAtk = 40, .SpDef = 55, .Speed = 85, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 191, .Name = "Sunkern", .Type1 = "Grass", .Type2 = "Nothing", .Total = 180, .HP = 30, .Attack = 30, .Defense = 30, .SpAtk = 30, .SpDef = 30, .Speed = 30, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 192, .Name = "Sunflora", .Type1 = "Grass", .Type2 = "Nothing", .Total = 425, .HP = 75, .Attack = 75, .Defense = 55, .SpAtk = 105, .SpDef = 85, .Speed = 30, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 193, .Name = "Yanma", .Type1 = "Bug", .Type2 = "Flying", .Total = 390, .HP = 65, .Attack = 65, .Defense = 45, .SpAtk = 75, .SpDef = 45, .Speed = 95, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 194, .Name = "Wooper", .Type1 = "Water", .Type2 = "Ground", .Total = 210, .HP = 55, .Attack = 45, .Defense = 45, .SpAtk = 25, .SpDef = 25, .Speed = 15, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 195, .Name = "Quagsire", .Type1 = "Water", .Type2 = "Ground", .Total = 430, .HP = 95, .Attack = 85, .Defense = 85, .SpAtk = 65, .SpDef = 65, .Speed = 35, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 196, .Name = "Espeon", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 525, .HP = 65, .Attack = 65, .Defense = 60, .SpAtk = 130, .SpDef = 95, .Speed = 110, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 197, .Name = "Umbreon", .Type1 = "Dark", .Type2 = "Nothing", .Total = 525, .HP = 95, .Attack = 65, .Defense = 110, .SpAtk = 60, .SpDef = 130, .Speed = 65, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 198, .Name = "Murkrow", .Type1 = "Dark", .Type2 = "Flying", .Total = 405, .HP = 60, .Attack = 85, .Defense = 42, .SpAtk = 85, .SpDef = 42, .Speed = 91, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 199, .Name = "Slowking", .Type1 = "Water", .Type2 = "Psychic", .Total = 490, .HP = 95, .Attack = 75, .Defense = 80, .SpAtk = 100, .SpDef = 110, .Speed = 30, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 200, .Name = "Misdreavus", .Type1 = "Ghost", .Type2 = "Nothing", .Total = 435, .HP = 60, .Attack = 60, .Defense = 60, .SpAtk = 85, .SpDef = 85, .Speed = 85, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 201, .Name = "Unown", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 336, .HP = 48, .Attack = 72, .Defense = 48, .SpAtk = 72, .SpDef = 48, .Speed = 48, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 202, .Name = "Wobbuffet", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 405, .HP = 190, .Attack = 33, .Defense = 58, .SpAtk = 33, .SpDef = 58, .Speed = 33, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 203, .Name = "Girafarig", .Type1 = "Normal", .Type2 = "Psychic", .Total = 455, .HP = 70, .Attack = 80, .Defense = 65, .SpAtk = 90, .SpDef = 65, .Speed = 85, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 204, .Name = "Pineco", .Type1 = "Bug", .Type2 = "Nothing", .Total = 290, .HP = 50, .Attack = 65, .Defense = 90, .SpAtk = 35, .SpDef = 35, .Speed = 15, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 205, .Name = "Forretress", .Type1 = "Bug", .Type2 = "Steel", .Total = 465, .HP = 75, .Attack = 90, .Defense = 140, .SpAtk = 60, .SpDef = 60, .Speed = 40, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 206, .Name = "Dunsparce", .Type1 = "Normal", .Type2 = "Nothing", .Total = 415, .HP = 100, .Attack = 70, .Defense = 70, .SpAtk = 65, .SpDef = 65, .Speed = 45, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 207, .Name = "Gligar", .Type1 = "Ground", .Type2 = "Flying", .Total = 430, .HP = 65, .Attack = 75, .Defense = 105, .SpAtk = 35, .SpDef = 65, .Speed = 85, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 208, .Name = "Steelix", .Type1 = "Steel", .Type2 = "Ground", .Total = 510, .HP = 75, .Attack = 85, .Defense = 200, .SpAtk = 55, .SpDef = 65, .Speed = 30, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 208, .Name = "SteelixMega Steelix", .Type1 = "Steel", .Type2 = "Ground", .Total = 610, .HP = 75, .Attack = 125, .Defense = 230, .SpAtk = 55, .SpDef = 95, .Speed = 30, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 209, .Name = "Snubbull", .Type1 = "Fairy", .Type2 = "Nothing", .Total = 300, .HP = 60, .Attack = 80, .Defense = 50, .SpAtk = 40, .SpDef = 40, .Speed = 30, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 210, .Name = "Granbull", .Type1 = "Fairy", .Type2 = "Nothing", .Total = 450, .HP = 90, .Attack = 120, .Defense = 75, .SpAtk = 60, .SpDef = 60, .Speed = 45, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 211, .Name = "Qwilfish", .Type1 = "Water", .Type2 = "Poison", .Total = 430, .HP = 65, .Attack = 95, .Defense = 75, .SpAtk = 55, .SpDef = 55, .Speed = 85, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 212, .Name = "Scizor", .Type1 = "Bug", .Type2 = "Steel", .Total = 500, .HP = 70, .Attack = 130, .Defense = 100, .SpAtk = 55, .SpDef = 80, .Speed = 65, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 212, .Name = "ScizorMega Scizor", .Type1 = "Bug", .Type2 = "Steel", .Total = 600, .HP = 70, .Attack = 150, .Defense = 140, .SpAtk = 65, .SpDef = 100, .Speed = 75, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 213, .Name = "Shuckle", .Type1 = "Bug", .Type2 = "Rock", .Total = 505, .HP = 20, .Attack = 10, .Defense = 230, .SpAtk = 10, .SpDef = 230, .Speed = 5, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 214, .Name = "Heracross", .Type1 = "Bug", .Type2 = "Fighting", .Total = 500, .HP = 80, .Attack = 125, .Defense = 75, .SpAtk = 40, .SpDef = 95, .Speed = 85, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 214, .Name = "HeracrossMega Heracross", .Type1 = "Bug", .Type2 = "Fighting", .Total = 600, .HP = 80, .Attack = 185, .Defense = 115, .SpAtk = 40, .SpDef = 105, .Speed = 75, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 215, .Name = "Sneasel", .Type1 = "Dark", .Type2 = "Ice", .Total = 430, .HP = 55, .Attack = 95, .Defense = 55, .SpAtk = 35, .SpDef = 75, .Speed = 115, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 216, .Name = "Teddiursa", .Type1 = "Normal", .Type2 = "Nothing", .Total = 330, .HP = 60, .Attack = 80, .Defense = 50, .SpAtk = 50, .SpDef = 50, .Speed = 40, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 217, .Name = "Ursaring", .Type1 = "Normal", .Type2 = "Nothing", .Total = 500, .HP = 90, .Attack = 130, .Defense = 75, .SpAtk = 75, .SpDef = 75, .Speed = 55, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 218, .Name = "Slugma", .Type1 = "Fire", .Type2 = "Nothing", .Total = 250, .HP = 40, .Attack = 40, .Defense = 40, .SpAtk = 70, .SpDef = 40, .Speed = 20, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 219, .Name = "Magcargo", .Type1 = "Fire", .Type2 = "Rock", .Total = 410, .HP = 50, .Attack = 50, .Defense = 120, .SpAtk = 80, .SpDef = 80, .Speed = 30, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 220, .Name = "Swinub", .Type1 = "Ice", .Type2 = "Ground", .Total = 250, .HP = 50, .Attack = 50, .Defense = 40, .SpAtk = 30, .SpDef = 30, .Speed = 50, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 221, .Name = "Piloswine", .Type1 = "Ice", .Type2 = "Ground", .Total = 450, .HP = 100, .Attack = 100, .Defense = 80, .SpAtk = 60, .SpDef = 60, .Speed = 50, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 222, .Name = "Corsola", .Type1 = "Water", .Type2 = "Rock", .Total = 380, .HP = 55, .Attack = 55, .Defense = 85, .SpAtk = 65, .SpDef = 85, .Speed = 35, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 223, .Name = "Remoraid", .Type1 = "Water", .Type2 = "Nothing", .Total = 300, .HP = 35, .Attack = 65, .Defense = 35, .SpAtk = 65, .SpDef = 35, .Speed = 65, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 224, .Name = "Octillery", .Type1 = "Water", .Type2 = "Nothing", .Total = 480, .HP = 75, .Attack = 105, .Defense = 75, .SpAtk = 105, .SpDef = 75, .Speed = 45, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 225, .Name = "Delibird", .Type1 = "Ice", .Type2 = "Flying", .Total = 330, .HP = 45, .Attack = 55, .Defense = 45, .SpAtk = 65, .SpDef = 45, .Speed = 75, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 226, .Name = "Mantine", .Type1 = "Water", .Type2 = "Flying", .Total = 465, .HP = 65, .Attack = 40, .Defense = 70, .SpAtk = 80, .SpDef = 140, .Speed = 70, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 227, .Name = "Skarmory", .Type1 = "Steel", .Type2 = "Flying", .Total = 465, .HP = 65, .Attack = 80, .Defense = 140, .SpAtk = 40, .SpDef = 70, .Speed = 70, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 228, .Name = "Houndour", .Type1 = "Dark", .Type2 = "Fire", .Total = 330, .HP = 45, .Attack = 60, .Defense = 30, .SpAtk = 80, .SpDef = 50, .Speed = 65, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 229, .Name = "Houndoom", .Type1 = "Dark", .Type2 = "Fire", .Total = 500, .HP = 75, .Attack = 90, .Defense = 50, .SpAtk = 110, .SpDef = 80, .Speed = 95, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 229, .Name = "HoundoomMega Houndoom", .Type1 = "Dark", .Type2 = "Fire", .Total = 600, .HP = 75, .Attack = 90, .Defense = 90, .SpAtk = 140, .SpDef = 90, .Speed = 115, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 230, .Name = "Kingdra", .Type1 = "Water", .Type2 = "Dragon", .Total = 540, .HP = 75, .Attack = 95, .Defense = 95, .SpAtk = 95, .SpDef = 95, .Speed = 85, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 231, .Name = "Phanpy", .Type1 = "Ground", .Type2 = "Nothing", .Total = 330, .HP = 90, .Attack = 60, .Defense = 60, .SpAtk = 40, .SpDef = 40, .Speed = 40, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 232, .Name = "Donphan", .Type1 = "Ground", .Type2 = "Nothing", .Total = 500, .HP = 90, .Attack = 120, .Defense = 120, .SpAtk = 60, .SpDef = 60, .Speed = 50, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 233, .Name = "Porygon2", .Type1 = "Normal", .Type2 = "Nothing", .Total = 515, .HP = 85, .Attack = 80, .Defense = 90, .SpAtk = 105, .SpDef = 95, .Speed = 60, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 234, .Name = "Stantler", .Type1 = "Normal", .Type2 = "Nothing", .Total = 465, .HP = 73, .Attack = 95, .Defense = 62, .SpAtk = 85, .SpDef = 65, .Speed = 85, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 235, .Name = "Smeargle", .Type1 = "Normal", .Type2 = "Nothing", .Total = 250, .HP = 55, .Attack = 20, .Defense = 35, .SpAtk = 20, .SpDef = 45, .Speed = 75, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 236, .Name = "Tyrogue", .Type1 = "Fighting", .Type2 = "Nothing", .Total = 210, .HP = 35, .Attack = 35, .Defense = 35, .SpAtk = 35, .SpDef = 35, .Speed = 35, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 237, .Name = "Hitmontop", .Type1 = "Fighting", .Type2 = "Nothing", .Total = 455, .HP = 50, .Attack = 95, .Defense = 95, .SpAtk = 35, .SpDef = 110, .Speed = 70, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 238, .Name = "Smoochum", .Type1 = "Ice", .Type2 = "Psychic", .Total = 305, .HP = 45, .Attack = 30, .Defense = 15, .SpAtk = 85, .SpDef = 65, .Speed = 65, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 239, .Name = "Elekid", .Type1 = "Electric", .Type2 = "Nothing", .Total = 360, .HP = 45, .Attack = 63, .Defense = 37, .SpAtk = 65, .SpDef = 55, .Speed = 95, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 240, .Name = "Magby", .Type1 = "Fire", .Type2 = "Nothing", .Total = 365, .HP = 45, .Attack = 75, .Defense = 37, .SpAtk = 70, .SpDef = 55, .Speed = 83, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 241, .Name = "Miltank", .Type1 = "Normal", .Type2 = "Nothing", .Total = 490, .HP = 95, .Attack = 80, .Defense = 105, .SpAtk = 40, .SpDef = 70, .Speed = 100, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 242, .Name = "Blissey", .Type1 = "Normal", .Type2 = "Nothing", .Total = 540, .HP = 255, .Attack = 10, .Defense = 10, .SpAtk = 75, .SpDef = 135, .Speed = 55, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 243, .Name = "Raikou", .Type1 = "Electric", .Type2 = "Nothing", .Total = 580, .HP = 90, .Attack = 85, .Defense = 75, .SpAtk = 115, .SpDef = 100, .Speed = 115, .Generation = 2, .Legendary = True},
New Pokemon With {.Id = 244, .Name = "Entei", .Type1 = "Fire", .Type2 = "Nothing", .Total = 580, .HP = 115, .Attack = 115, .Defense = 85, .SpAtk = 90, .SpDef = 75, .Speed = 100, .Generation = 2, .Legendary = True},
New Pokemon With {.Id = 245, .Name = "Suicune", .Type1 = "Water", .Type2 = "Nothing", .Total = 580, .HP = 100, .Attack = 75, .Defense = 115, .SpAtk = 90, .SpDef = 115, .Speed = 85, .Generation = 2, .Legendary = True},
New Pokemon With {.Id = 246, .Name = "Larvitar", .Type1 = "Rock", .Type2 = "Ground", .Total = 300, .HP = 50, .Attack = 64, .Defense = 50, .SpAtk = 45, .SpDef = 50, .Speed = 41, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 247, .Name = "Pupitar", .Type1 = "Rock", .Type2 = "Ground", .Total = 410, .HP = 70, .Attack = 84, .Defense = 70, .SpAtk = 65, .SpDef = 70, .Speed = 51, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 248, .Name = "Tyranitar", .Type1 = "Rock", .Type2 = "Dark", .Total = 600, .HP = 100, .Attack = 134, .Defense = 110, .SpAtk = 95, .SpDef = 100, .Speed = 61, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 248, .Name = "TyranitarMega Tyranitar", .Type1 = "Rock", .Type2 = "Dark", .Total = 700, .HP = 100, .Attack = 164, .Defense = 150, .SpAtk = 95, .SpDef = 120, .Speed = 71, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 249, .Name = "Lugia", .Type1 = "Psychic", .Type2 = "Flying", .Total = 680, .HP = 106, .Attack = 90, .Defense = 130, .SpAtk = 90, .SpDef = 154, .Speed = 110, .Generation = 2, .Legendary = True},
New Pokemon With {.Id = 250, .Name = "Ho-oh", .Type1 = "Fire", .Type2 = "Flying", .Total = 680, .HP = 106, .Attack = 130, .Defense = 90, .SpAtk = 110, .SpDef = 154, .Speed = 90, .Generation = 2, .Legendary = True},
New Pokemon With {.Id = 251, .Name = "Celebi", .Type1 = "Psychic", .Type2 = "Grass", .Total = 600, .HP = 100, .Attack = 100, .Defense = 100, .SpAtk = 100, .SpDef = 100, .Speed = 100, .Generation = 2, .Legendary = False},
New Pokemon With {.Id = 252, .Name = "Treecko", .Type1 = "Grass", .Type2 = "Nothing", .Total = 310, .HP = 40, .Attack = 45, .Defense = 35, .SpAtk = 65, .SpDef = 55, .Speed = 70, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 253, .Name = "Grovyle", .Type1 = "Grass", .Type2 = "Nothing", .Total = 405, .HP = 50, .Attack = 65, .Defense = 45, .SpAtk = 85, .SpDef = 65, .Speed = 95, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 254, .Name = "Sceptile", .Type1 = "Grass", .Type2 = "Nothing", .Total = 530, .HP = 70, .Attack = 85, .Defense = 65, .SpAtk = 105, .SpDef = 85, .Speed = 120, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 254, .Name = "SceptileMega Sceptile", .Type1 = "Grass", .Type2 = "Dragon", .Total = 630, .HP = 70, .Attack = 110, .Defense = 75, .SpAtk = 145, .SpDef = 85, .Speed = 145, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 255, .Name = "Torchic", .Type1 = "Fire", .Type2 = "Nothing", .Total = 310, .HP = 45, .Attack = 60, .Defense = 40, .SpAtk = 70, .SpDef = 50, .Speed = 45, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 256, .Name = "Combusken", .Type1 = "Fire", .Type2 = "Fighting", .Total = 405, .HP = 60, .Attack = 85, .Defense = 60, .SpAtk = 85, .SpDef = 60, .Speed = 55, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 257, .Name = "Blaziken", .Type1 = "Fire", .Type2 = "Fighting", .Total = 530, .HP = 80, .Attack = 120, .Defense = 70, .SpAtk = 110, .SpDef = 70, .Speed = 80, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 257, .Name = "BlazikenMega Blaziken", .Type1 = "Fire", .Type2 = "Fighting", .Total = 630, .HP = 80, .Attack = 160, .Defense = 80, .SpAtk = 130, .SpDef = 80, .Speed = 100, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 258, .Name = "Mudkip", .Type1 = "Water", .Type2 = "Nothing", .Total = 310, .HP = 50, .Attack = 70, .Defense = 50, .SpAtk = 50, .SpDef = 50, .Speed = 40, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 259, .Name = "Marshtomp", .Type1 = "Water", .Type2 = "Ground", .Total = 405, .HP = 70, .Attack = 85, .Defense = 70, .SpAtk = 60, .SpDef = 70, .Speed = 50, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 260, .Name = "Swampert", .Type1 = "Water", .Type2 = "Ground", .Total = 535, .HP = 100, .Attack = 110, .Defense = 90, .SpAtk = 85, .SpDef = 90, .Speed = 60, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 260, .Name = "SwampertMega Swampert", .Type1 = "Water", .Type2 = "Ground", .Total = 635, .HP = 100, .Attack = 150, .Defense = 110, .SpAtk = 95, .SpDef = 110, .Speed = 70, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 261, .Name = "Poochyena", .Type1 = "Dark", .Type2 = "Nothing", .Total = 220, .HP = 35, .Attack = 55, .Defense = 35, .SpAtk = 30, .SpDef = 30, .Speed = 35, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 262, .Name = "Mightyena", .Type1 = "Dark", .Type2 = "Nothing", .Total = 420, .HP = 70, .Attack = 90, .Defense = 70, .SpAtk = 60, .SpDef = 60, .Speed = 70, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 263, .Name = "Zigzagoon", .Type1 = "Normal", .Type2 = "Nothing", .Total = 240, .HP = 38, .Attack = 30, .Defense = 41, .SpAtk = 30, .SpDef = 41, .Speed = 60, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 264, .Name = "Linoone", .Type1 = "Normal", .Type2 = "Nothing", .Total = 420, .HP = 78, .Attack = 70, .Defense = 61, .SpAtk = 50, .SpDef = 61, .Speed = 100, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 265, .Name = "Wurmple", .Type1 = "Bug", .Type2 = "Nothing", .Total = 195, .HP = 45, .Attack = 45, .Defense = 35, .SpAtk = 20, .SpDef = 30, .Speed = 20, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 266, .Name = "Silcoon", .Type1 = "Bug", .Type2 = "Nothing", .Total = 205, .HP = 50, .Attack = 35, .Defense = 55, .SpAtk = 25, .SpDef = 25, .Speed = 15, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 267, .Name = "Beautifly", .Type1 = "Bug", .Type2 = "Flying", .Total = 395, .HP = 60, .Attack = 70, .Defense = 50, .SpAtk = 100, .SpDef = 50, .Speed = 65, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 268, .Name = "Cascoon", .Type1 = "Bug", .Type2 = "Nothing", .Total = 205, .HP = 50, .Attack = 35, .Defense = 55, .SpAtk = 25, .SpDef = 25, .Speed = 15, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 269, .Name = "Dustox", .Type1 = "Bug", .Type2 = "Poison", .Total = 385, .HP = 60, .Attack = 50, .Defense = 70, .SpAtk = 50, .SpDef = 90, .Speed = 65, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 270, .Name = "Lotad", .Type1 = "Water", .Type2 = "Grass", .Total = 220, .HP = 40, .Attack = 30, .Defense = 30, .SpAtk = 40, .SpDef = 50, .Speed = 30, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 271, .Name = "Lombre", .Type1 = "Water", .Type2 = "Grass", .Total = 340, .HP = 60, .Attack = 50, .Defense = 50, .SpAtk = 60, .SpDef = 70, .Speed = 50, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 272, .Name = "Ludicolo", .Type1 = "Water", .Type2 = "Grass", .Total = 480, .HP = 80, .Attack = 70, .Defense = 70, .SpAtk = 90, .SpDef = 100, .Speed = 70, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 273, .Name = "Seedot", .Type1 = "Grass", .Type2 = "Nothing", .Total = 220, .HP = 40, .Attack = 40, .Defense = 50, .SpAtk = 30, .SpDef = 30, .Speed = 30, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 274, .Name = "Nuzleaf", .Type1 = "Grass", .Type2 = "Dark", .Total = 340, .HP = 70, .Attack = 70, .Defense = 40, .SpAtk = 60, .SpDef = 40, .Speed = 60, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 275, .Name = "Shiftry", .Type1 = "Grass", .Type2 = "Dark", .Total = 480, .HP = 90, .Attack = 100, .Defense = 60, .SpAtk = 90, .SpDef = 60, .Speed = 80, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 276, .Name = "Taillow", .Type1 = "Normal", .Type2 = "Flying", .Total = 270, .HP = 40, .Attack = 55, .Defense = 30, .SpAtk = 30, .SpDef = 30, .Speed = 85, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 277, .Name = "Swellow", .Type1 = "Normal", .Type2 = "Flying", .Total = 430, .HP = 60, .Attack = 85, .Defense = 60, .SpAtk = 50, .SpDef = 50, .Speed = 125, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 278, .Name = "Wingull", .Type1 = "Water", .Type2 = "Flying", .Total = 270, .HP = 40, .Attack = 30, .Defense = 30, .SpAtk = 55, .SpDef = 30, .Speed = 85, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 279, .Name = "Pelipper", .Type1 = "Water", .Type2 = "Flying", .Total = 430, .HP = 60, .Attack = 50, .Defense = 100, .SpAtk = 85, .SpDef = 70, .Speed = 65, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 280, .Name = "Ralts", .Type1 = "Psychic", .Type2 = "Fairy", .Total = 198, .HP = 28, .Attack = 25, .Defense = 25, .SpAtk = 45, .SpDef = 35, .Speed = 40, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 281, .Name = "Kirlia", .Type1 = "Psychic", .Type2 = "Fairy", .Total = 278, .HP = 38, .Attack = 35, .Defense = 35, .SpAtk = 65, .SpDef = 55, .Speed = 50, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 282, .Name = "Gardevoir", .Type1 = "Psychic", .Type2 = "Fairy", .Total = 518, .HP = 68, .Attack = 65, .Defense = 65, .SpAtk = 125, .SpDef = 115, .Speed = 80, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 282, .Name = "GardevoirMega Gardevoir", .Type1 = "Psychic", .Type2 = "Fairy", .Total = 618, .HP = 68, .Attack = 85, .Defense = 65, .SpAtk = 165, .SpDef = 135, .Speed = 100, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 283, .Name = "Surskit", .Type1 = "Bug", .Type2 = "Water", .Total = 269, .HP = 40, .Attack = 30, .Defense = 32, .SpAtk = 50, .SpDef = 52, .Speed = 65, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 284, .Name = "Masquerain", .Type1 = "Bug", .Type2 = "Flying", .Total = 414, .HP = 70, .Attack = 60, .Defense = 62, .SpAtk = 80, .SpDef = 82, .Speed = 60, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 285, .Name = "Shroomish", .Type1 = "Grass", .Type2 = "Nothing", .Total = 295, .HP = 60, .Attack = 40, .Defense = 60, .SpAtk = 40, .SpDef = 60, .Speed = 35, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 286, .Name = "Breloom", .Type1 = "Grass", .Type2 = "Fighting", .Total = 460, .HP = 60, .Attack = 130, .Defense = 80, .SpAtk = 60, .SpDef = 60, .Speed = 70, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 287, .Name = "Slakoth", .Type1 = "Normal", .Type2 = "Nothing", .Total = 280, .HP = 60, .Attack = 60, .Defense = 60, .SpAtk = 35, .SpDef = 35, .Speed = 30, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 288, .Name = "Vigoroth", .Type1 = "Normal", .Type2 = "Nothing", .Total = 440, .HP = 80, .Attack = 80, .Defense = 80, .SpAtk = 55, .SpDef = 55, .Speed = 90, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 289, .Name = "Slaking", .Type1 = "Normal", .Type2 = "Nothing", .Total = 670, .HP = 150, .Attack = 160, .Defense = 100, .SpAtk = 95, .SpDef = 65, .Speed = 100, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 290, .Name = "Nincada", .Type1 = "Bug", .Type2 = "Ground", .Total = 266, .HP = 31, .Attack = 45, .Defense = 90, .SpAtk = 30, .SpDef = 30, .Speed = 40, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 291, .Name = "Ninjask", .Type1 = "Bug", .Type2 = "Flying", .Total = 456, .HP = 61, .Attack = 90, .Defense = 45, .SpAtk = 50, .SpDef = 50, .Speed = 160, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 292, .Name = "Shedinja", .Type1 = "Bug", .Type2 = "Ghost", .Total = 236, .HP = 1, .Attack = 90, .Defense = 45, .SpAtk = 30, .SpDef = 30, .Speed = 40, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 293, .Name = "Whismur", .Type1 = "Normal", .Type2 = "Nothing", .Total = 240, .HP = 64, .Attack = 51, .Defense = 23, .SpAtk = 51, .SpDef = 23, .Speed = 28, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 294, .Name = "Loudred", .Type1 = "Normal", .Type2 = "Nothing", .Total = 360, .HP = 84, .Attack = 71, .Defense = 43, .SpAtk = 71, .SpDef = 43, .Speed = 48, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 295, .Name = "Exploud", .Type1 = "Normal", .Type2 = "Nothing", .Total = 490, .HP = 104, .Attack = 91, .Defense = 63, .SpAtk = 91, .SpDef = 73, .Speed = 68, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 296, .Name = "Makuhita", .Type1 = "Fighting", .Type2 = "Nothing", .Total = 237, .HP = 72, .Attack = 60, .Defense = 30, .SpAtk = 20, .SpDef = 30, .Speed = 25, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 297, .Name = "Hariyama", .Type1 = "Fighting", .Type2 = "Nothing", .Total = 474, .HP = 144, .Attack = 120, .Defense = 60, .SpAtk = 40, .SpDef = 60, .Speed = 50, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 298, .Name = "Azurill", .Type1 = "Normal", .Type2 = "Fairy", .Total = 190, .HP = 50, .Attack = 20, .Defense = 40, .SpAtk = 20, .SpDef = 40, .Speed = 20, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 299, .Name = "Nosepass", .Type1 = "Rock", .Type2 = "Nothing", .Total = 375, .HP = 30, .Attack = 45, .Defense = 135, .SpAtk = 45, .SpDef = 90, .Speed = 30, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 300, .Name = "Skitty", .Type1 = "Normal", .Type2 = "Nothing", .Total = 260, .HP = 50, .Attack = 45, .Defense = 45, .SpAtk = 35, .SpDef = 35, .Speed = 50, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 301, .Name = "Delcatty", .Type1 = "Normal", .Type2 = "Nothing", .Total = 380, .HP = 70, .Attack = 65, .Defense = 65, .SpAtk = 55, .SpDef = 55, .Speed = 70, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 302, .Name = "Sableye", .Type1 = "Dark", .Type2 = "Ghost", .Total = 380, .HP = 50, .Attack = 75, .Defense = 75, .SpAtk = 65, .SpDef = 65, .Speed = 50, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 302, .Name = "SableyeMega Sableye", .Type1 = "Dark", .Type2 = "Ghost", .Total = 480, .HP = 50, .Attack = 85, .Defense = 125, .SpAtk = 85, .SpDef = 115, .Speed = 20, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 303, .Name = "Mawile", .Type1 = "Steel", .Type2 = "Fairy", .Total = 380, .HP = 50, .Attack = 85, .Defense = 85, .SpAtk = 55, .SpDef = 55, .Speed = 50, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 303, .Name = "MawileMega Mawile", .Type1 = "Steel", .Type2 = "Fairy", .Total = 480, .HP = 50, .Attack = 105, .Defense = 125, .SpAtk = 55, .SpDef = 95, .Speed = 50, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 304, .Name = "Aron", .Type1 = "Steel", .Type2 = "Rock", .Total = 330, .HP = 50, .Attack = 70, .Defense = 100, .SpAtk = 40, .SpDef = 40, .Speed = 30, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 305, .Name = "Lairon", .Type1 = "Steel", .Type2 = "Rock", .Total = 430, .HP = 60, .Attack = 90, .Defense = 140, .SpAtk = 50, .SpDef = 50, .Speed = 40, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 306, .Name = "Aggron", .Type1 = "Steel", .Type2 = "Rock", .Total = 530, .HP = 70, .Attack = 110, .Defense = 180, .SpAtk = 60, .SpDef = 60, .Speed = 50, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 306, .Name = "AggronMega Aggron", .Type1 = "Steel", .Type2 = "Nothing", .Total = 630, .HP = 70, .Attack = 140, .Defense = 230, .SpAtk = 60, .SpDef = 80, .Speed = 50, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 307, .Name = "Meditite", .Type1 = "Fighting", .Type2 = "Psychic", .Total = 280, .HP = 30, .Attack = 40, .Defense = 55, .SpAtk = 40, .SpDef = 55, .Speed = 60, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 308, .Name = "Medicham", .Type1 = "Fighting", .Type2 = "Psychic", .Total = 410, .HP = 60, .Attack = 60, .Defense = 75, .SpAtk = 60, .SpDef = 75, .Speed = 80, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 308, .Name = "MedichamMega Medicham", .Type1 = "Fighting", .Type2 = "Psychic", .Total = 510, .HP = 60, .Attack = 100, .Defense = 85, .SpAtk = 80, .SpDef = 85, .Speed = 100, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 309, .Name = "Electrike", .Type1 = "Electric", .Type2 = "Nothing", .Total = 295, .HP = 40, .Attack = 45, .Defense = 40, .SpAtk = 65, .SpDef = 40, .Speed = 65, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 310, .Name = "Manectric", .Type1 = "Electric", .Type2 = "Nothing", .Total = 475, .HP = 70, .Attack = 75, .Defense = 60, .SpAtk = 105, .SpDef = 60, .Speed = 105, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 310, .Name = "ManectricMega Manectric", .Type1 = "Electric", .Type2 = "Nothing", .Total = 575, .HP = 70, .Attack = 75, .Defense = 80, .SpAtk = 135, .SpDef = 80, .Speed = 135, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 311, .Name = "Plusle", .Type1 = "Electric", .Type2 = "Nothing", .Total = 405, .HP = 60, .Attack = 50, .Defense = 40, .SpAtk = 85, .SpDef = 75, .Speed = 95, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 312, .Name = "Minun", .Type1 = "Electric", .Type2 = "Nothing", .Total = 405, .HP = 60, .Attack = 40, .Defense = 50, .SpAtk = 75, .SpDef = 85, .Speed = 95, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 313, .Name = "Volbeat", .Type1 = "Bug", .Type2 = "Nothing", .Total = 400, .HP = 65, .Attack = 73, .Defense = 55, .SpAtk = 47, .SpDef = 75, .Speed = 85, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 314, .Name = "Illumise", .Type1 = "Bug", .Type2 = "Nothing", .Total = 400, .HP = 65, .Attack = 47, .Defense = 55, .SpAtk = 73, .SpDef = 75, .Speed = 85, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 315, .Name = "Roselia", .Type1 = "Grass", .Type2 = "Poison", .Total = 400, .HP = 50, .Attack = 60, .Defense = 45, .SpAtk = 100, .SpDef = 80, .Speed = 65, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 316, .Name = "Gulpin", .Type1 = "Poison", .Type2 = "Nothing", .Total = 302, .HP = 70, .Attack = 43, .Defense = 53, .SpAtk = 43, .SpDef = 53, .Speed = 40, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 317, .Name = "Swalot", .Type1 = "Poison", .Type2 = "Nothing", .Total = 467, .HP = 100, .Attack = 73, .Defense = 83, .SpAtk = 73, .SpDef = 83, .Speed = 55, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 318, .Name = "Carvanha", .Type1 = "Water", .Type2 = "Dark", .Total = 305, .HP = 45, .Attack = 90, .Defense = 20, .SpAtk = 65, .SpDef = 20, .Speed = 65, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 319, .Name = "Sharpedo", .Type1 = "Water", .Type2 = "Dark", .Total = 460, .HP = 70, .Attack = 120, .Defense = 40, .SpAtk = 95, .SpDef = 40, .Speed = 95, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 319, .Name = "SharpedoMega Sharpedo", .Type1 = "Water", .Type2 = "Dark", .Total = 560, .HP = 70, .Attack = 140, .Defense = 70, .SpAtk = 110, .SpDef = 65, .Speed = 105, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 320, .Name = "Wailmer", .Type1 = "Water", .Type2 = "Nothing", .Total = 400, .HP = 130, .Attack = 70, .Defense = 35, .SpAtk = 70, .SpDef = 35, .Speed = 60, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 321, .Name = "Wailord", .Type1 = "Water", .Type2 = "Nothing", .Total = 500, .HP = 170, .Attack = 90, .Defense = 45, .SpAtk = 90, .SpDef = 45, .Speed = 60, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 322, .Name = "Numel", .Type1 = "Fire", .Type2 = "Ground", .Total = 305, .HP = 60, .Attack = 60, .Defense = 40, .SpAtk = 65, .SpDef = 45, .Speed = 35, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 323, .Name = "Camerupt", .Type1 = "Fire", .Type2 = "Ground", .Total = 460, .HP = 70, .Attack = 100, .Defense = 70, .SpAtk = 105, .SpDef = 75, .Speed = 40, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 323, .Name = "CameruptMega Camerupt", .Type1 = "Fire", .Type2 = "Ground", .Total = 560, .HP = 70, .Attack = 120, .Defense = 100, .SpAtk = 145, .SpDef = 105, .Speed = 20, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 324, .Name = "Torkoal", .Type1 = "Fire", .Type2 = "Nothing", .Total = 470, .HP = 70, .Attack = 85, .Defense = 140, .SpAtk = 85, .SpDef = 70, .Speed = 20, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 325, .Name = "Spoink", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 330, .HP = 60, .Attack = 25, .Defense = 35, .SpAtk = 70, .SpDef = 80, .Speed = 60, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 326, .Name = "Grumpig", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 470, .HP = 80, .Attack = 45, .Defense = 65, .SpAtk = 90, .SpDef = 110, .Speed = 80, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 327, .Name = "Spinda", .Type1 = "Normal", .Type2 = "Nothing", .Total = 360, .HP = 60, .Attack = 60, .Defense = 60, .SpAtk = 60, .SpDef = 60, .Speed = 60, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 328, .Name = "Trapinch", .Type1 = "Ground", .Type2 = "Nothing", .Total = 290, .HP = 45, .Attack = 100, .Defense = 45, .SpAtk = 45, .SpDef = 45, .Speed = 10, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 329, .Name = "Vibrava", .Type1 = "Ground", .Type2 = "Dragon", .Total = 340, .HP = 50, .Attack = 70, .Defense = 50, .SpAtk = 50, .SpDef = 50, .Speed = 70, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 330, .Name = "Flygon", .Type1 = "Ground", .Type2 = "Dragon", .Total = 520, .HP = 80, .Attack = 100, .Defense = 80, .SpAtk = 80, .SpDef = 80, .Speed = 100, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 331, .Name = "Cacnea", .Type1 = "Grass", .Type2 = "Nothing", .Total = 335, .HP = 50, .Attack = 85, .Defense = 40, .SpAtk = 85, .SpDef = 40, .Speed = 35, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 332, .Name = "Cacturne", .Type1 = "Grass", .Type2 = "Dark", .Total = 475, .HP = 70, .Attack = 115, .Defense = 60, .SpAtk = 115, .SpDef = 60, .Speed = 55, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 333, .Name = "Swablu", .Type1 = "Normal", .Type2 = "Flying", .Total = 310, .HP = 45, .Attack = 40, .Defense = 60, .SpAtk = 40, .SpDef = 75, .Speed = 50, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 334, .Name = "Altaria", .Type1 = "Dragon", .Type2 = "Flying", .Total = 490, .HP = 75, .Attack = 70, .Defense = 90, .SpAtk = 70, .SpDef = 105, .Speed = 80, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 334, .Name = "AltariaMega Altaria", .Type1 = "Dragon", .Type2 = "Fairy", .Total = 590, .HP = 75, .Attack = 110, .Defense = 110, .SpAtk = 110, .SpDef = 105, .Speed = 80, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 335, .Name = "Zangoose", .Type1 = "Normal", .Type2 = "Nothing", .Total = 458, .HP = 73, .Attack = 115, .Defense = 60, .SpAtk = 60, .SpDef = 60, .Speed = 90, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 336, .Name = "Seviper", .Type1 = "Poison", .Type2 = "Nothing", .Total = 458, .HP = 73, .Attack = 100, .Defense = 60, .SpAtk = 100, .SpDef = 60, .Speed = 65, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 337, .Name = "Lunatone", .Type1 = "Rock", .Type2 = "Psychic", .Total = 440, .HP = 70, .Attack = 55, .Defense = 65, .SpAtk = 95, .SpDef = 85, .Speed = 70, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 338, .Name = "Solrock", .Type1 = "Rock", .Type2 = "Psychic", .Total = 440, .HP = 70, .Attack = 95, .Defense = 85, .SpAtk = 55, .SpDef = 65, .Speed = 70, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 339, .Name = "Barboach", .Type1 = "Water", .Type2 = "Ground", .Total = 288, .HP = 50, .Attack = 48, .Defense = 43, .SpAtk = 46, .SpDef = 41, .Speed = 60, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 340, .Name = "Whiscash", .Type1 = "Water", .Type2 = "Ground", .Total = 468, .HP = 110, .Attack = 78, .Defense = 73, .SpAtk = 76, .SpDef = 71, .Speed = 60, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 341, .Name = "Corphish", .Type1 = "Water", .Type2 = "Nothing", .Total = 308, .HP = 43, .Attack = 80, .Defense = 65, .SpAtk = 50, .SpDef = 35, .Speed = 35, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 342, .Name = "Crawdaunt", .Type1 = "Water", .Type2 = "Dark", .Total = 468, .HP = 63, .Attack = 120, .Defense = 85, .SpAtk = 90, .SpDef = 55, .Speed = 55, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 343, .Name = "Baltoy", .Type1 = "Ground", .Type2 = "Psychic", .Total = 300, .HP = 40, .Attack = 40, .Defense = 55, .SpAtk = 40, .SpDef = 70, .Speed = 55, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 344, .Name = "Claydol", .Type1 = "Ground", .Type2 = "Psychic", .Total = 500, .HP = 60, .Attack = 70, .Defense = 105, .SpAtk = 70, .SpDef = 120, .Speed = 75, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 345, .Name = "Lileep", .Type1 = "Rock", .Type2 = "Grass", .Total = 355, .HP = 66, .Attack = 41, .Defense = 77, .SpAtk = 61, .SpDef = 87, .Speed = 23, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 346, .Name = "Cradily", .Type1 = "Rock", .Type2 = "Grass", .Total = 495, .HP = 86, .Attack = 81, .Defense = 97, .SpAtk = 81, .SpDef = 107, .Speed = 43, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 347, .Name = "Anorith", .Type1 = "Rock", .Type2 = "Bug", .Total = 355, .HP = 45, .Attack = 95, .Defense = 50, .SpAtk = 40, .SpDef = 50, .Speed = 75, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 348, .Name = "Armaldo", .Type1 = "Rock", .Type2 = "Bug", .Total = 495, .HP = 75, .Attack = 125, .Defense = 100, .SpAtk = 70, .SpDef = 80, .Speed = 45, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 349, .Name = "Feebas", .Type1 = "Water", .Type2 = "Nothing", .Total = 200, .HP = 20, .Attack = 15, .Defense = 20, .SpAtk = 10, .SpDef = 55, .Speed = 80, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 350, .Name = "Milotic", .Type1 = "Water", .Type2 = "Nothing", .Total = 540, .HP = 95, .Attack = 60, .Defense = 79, .SpAtk = 100, .SpDef = 125, .Speed = 81, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 351, .Name = "Castform", .Type1 = "Normal", .Type2 = "Nothing", .Total = 420, .HP = 70, .Attack = 70, .Defense = 70, .SpAtk = 70, .SpDef = 70, .Speed = 70, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 352, .Name = "Kecleon", .Type1 = "Normal", .Type2 = "Nothing", .Total = 440, .HP = 60, .Attack = 90, .Defense = 70, .SpAtk = 60, .SpDef = 120, .Speed = 40, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 353, .Name = "Shuppet", .Type1 = "Ghost", .Type2 = "Nothing", .Total = 295, .HP = 44, .Attack = 75, .Defense = 35, .SpAtk = 63, .SpDef = 33, .Speed = 45, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 354, .Name = "Banette", .Type1 = "Ghost", .Type2 = "Nothing", .Total = 455, .HP = 64, .Attack = 115, .Defense = 65, .SpAtk = 83, .SpDef = 63, .Speed = 65, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 354, .Name = "BanetteMega Banette", .Type1 = "Ghost", .Type2 = "Nothing", .Total = 555, .HP = 64, .Attack = 165, .Defense = 75, .SpAtk = 93, .SpDef = 83, .Speed = 75, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 355, .Name = "Duskull", .Type1 = "Ghost", .Type2 = "Nothing", .Total = 295, .HP = 20, .Attack = 40, .Defense = 90, .SpAtk = 30, .SpDef = 90, .Speed = 25, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 356, .Name = "Dusclops", .Type1 = "Ghost", .Type2 = "Nothing", .Total = 455, .HP = 40, .Attack = 70, .Defense = 130, .SpAtk = 60, .SpDef = 130, .Speed = 25, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 357, .Name = "Tropius", .Type1 = "Grass", .Type2 = "Flying", .Total = 460, .HP = 99, .Attack = 68, .Defense = 83, .SpAtk = 72, .SpDef = 87, .Speed = 51, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 358, .Name = "Chimecho", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 425, .HP = 65, .Attack = 50, .Defense = 70, .SpAtk = 95, .SpDef = 80, .Speed = 65, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 359, .Name = "Absol", .Type1 = "Dark", .Type2 = "Nothing", .Total = 465, .HP = 65, .Attack = 130, .Defense = 60, .SpAtk = 75, .SpDef = 60, .Speed = 75, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 359, .Name = "AbsolMega Absol", .Type1 = "Dark", .Type2 = "Nothing", .Total = 565, .HP = 65, .Attack = 150, .Defense = 60, .SpAtk = 115, .SpDef = 60, .Speed = 115, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 360, .Name = "Wynaut", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 260, .HP = 95, .Attack = 23, .Defense = 48, .SpAtk = 23, .SpDef = 48, .Speed = 23, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 361, .Name = "Snorunt", .Type1 = "Ice", .Type2 = "Nothing", .Total = 300, .HP = 50, .Attack = 50, .Defense = 50, .SpAtk = 50, .SpDef = 50, .Speed = 50, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 362, .Name = "Glalie", .Type1 = "Ice", .Type2 = "Nothing", .Total = 480, .HP = 80, .Attack = 80, .Defense = 80, .SpAtk = 80, .SpDef = 80, .Speed = 80, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 362, .Name = "GlalieMega Glalie", .Type1 = "Ice", .Type2 = "Nothing", .Total = 580, .HP = 80, .Attack = 120, .Defense = 80, .SpAtk = 120, .SpDef = 80, .Speed = 100, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 363, .Name = "Spheal", .Type1 = "Ice", .Type2 = "Water", .Total = 290, .HP = 70, .Attack = 40, .Defense = 50, .SpAtk = 55, .SpDef = 50, .Speed = 25, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 364, .Name = "Sealeo", .Type1 = "Ice", .Type2 = "Water", .Total = 410, .HP = 90, .Attack = 60, .Defense = 70, .SpAtk = 75, .SpDef = 70, .Speed = 45, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 365, .Name = "Walrein", .Type1 = "Ice", .Type2 = "Water", .Total = 530, .HP = 110, .Attack = 80, .Defense = 90, .SpAtk = 95, .SpDef = 90, .Speed = 65, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 366, .Name = "Clamperl", .Type1 = "Water", .Type2 = "Nothing", .Total = 345, .HP = 35, .Attack = 64, .Defense = 85, .SpAtk = 74, .SpDef = 55, .Speed = 32, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 367, .Name = "Huntail", .Type1 = "Water", .Type2 = "Nothing", .Total = 485, .HP = 55, .Attack = 104, .Defense = 105, .SpAtk = 94, .SpDef = 75, .Speed = 52, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 368, .Name = "Gorebyss", .Type1 = "Water", .Type2 = "Nothing", .Total = 485, .HP = 55, .Attack = 84, .Defense = 105, .SpAtk = 114, .SpDef = 75, .Speed = 52, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 369, .Name = "Relicanth", .Type1 = "Water", .Type2 = "Rock", .Total = 485, .HP = 100, .Attack = 90, .Defense = 130, .SpAtk = 45, .SpDef = 65, .Speed = 55, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 370, .Name = "Luvdisc", .Type1 = "Water", .Type2 = "Nothing", .Total = 330, .HP = 43, .Attack = 30, .Defense = 55, .SpAtk = 40, .SpDef = 65, .Speed = 97, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 371, .Name = "Bagon", .Type1 = "Dragon", .Type2 = "Nothing", .Total = 300, .HP = 45, .Attack = 75, .Defense = 60, .SpAtk = 40, .SpDef = 30, .Speed = 50, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 372, .Name = "Shelgon", .Type1 = "Dragon", .Type2 = "Nothing", .Total = 420, .HP = 65, .Attack = 95, .Defense = 100, .SpAtk = 60, .SpDef = 50, .Speed = 50, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 373, .Name = "Salamence", .Type1 = "Dragon", .Type2 = "Flying", .Total = 600, .HP = 95, .Attack = 135, .Defense = 80, .SpAtk = 110, .SpDef = 80, .Speed = 100, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 373, .Name = "SalamenceMega Salamence", .Type1 = "Dragon", .Type2 = "Flying", .Total = 700, .HP = 95, .Attack = 145, .Defense = 130, .SpAtk = 120, .SpDef = 90, .Speed = 120, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 374, .Name = "Beldum", .Type1 = "Steel", .Type2 = "Psychic", .Total = 300, .HP = 40, .Attack = 55, .Defense = 80, .SpAtk = 35, .SpDef = 60, .Speed = 30, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 375, .Name = "Metang", .Type1 = "Steel", .Type2 = "Psychic", .Total = 420, .HP = 60, .Attack = 75, .Defense = 100, .SpAtk = 55, .SpDef = 80, .Speed = 50, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 376, .Name = "Metagross", .Type1 = "Steel", .Type2 = "Psychic", .Total = 600, .HP = 80, .Attack = 135, .Defense = 130, .SpAtk = 95, .SpDef = 90, .Speed = 70, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 376, .Name = "MetagrossMega Metagross", .Type1 = "Steel", .Type2 = "Psychic", .Total = 700, .HP = 80, .Attack = 145, .Defense = 150, .SpAtk = 105, .SpDef = 110, .Speed = 110, .Generation = 3, .Legendary = False},
New Pokemon With {.Id = 377, .Name = "Regirock", .Type1 = "Rock", .Type2 = "Nothing", .Total = 580, .HP = 80, .Attack = 100, .Defense = 200, .SpAtk = 50, .SpDef = 100, .Speed = 50, .Generation = 3, .Legendary = True},
New Pokemon With {.Id = 378, .Name = "Regice", .Type1 = "Ice", .Type2 = "Nothing", .Total = 580, .HP = 80, .Attack = 50, .Defense = 100, .SpAtk = 100, .SpDef = 200, .Speed = 50, .Generation = 3, .Legendary = True},
New Pokemon With {.Id = 379, .Name = "Registeel", .Type1 = "Steel", .Type2 = "Nothing", .Total = 580, .HP = 80, .Attack = 75, .Defense = 150, .SpAtk = 75, .SpDef = 150, .Speed = 50, .Generation = 3, .Legendary = True},
New Pokemon With {.Id = 380, .Name = "Latias", .Type1 = "Dragon", .Type2 = "Psychic", .Total = 600, .HP = 80, .Attack = 80, .Defense = 90, .SpAtk = 110, .SpDef = 130, .Speed = 110, .Generation = 3, .Legendary = True},
New Pokemon With {.Id = 380, .Name = "LatiasMega Latias", .Type1 = "Dragon", .Type2 = "Psychic", .Total = 700, .HP = 80, .Attack = 100, .Defense = 120, .SpAtk = 140, .SpDef = 150, .Speed = 110, .Generation = 3, .Legendary = True},
New Pokemon With {.Id = 381, .Name = "Latios", .Type1 = "Dragon", .Type2 = "Psychic", .Total = 600, .HP = 80, .Attack = 90, .Defense = 80, .SpAtk = 130, .SpDef = 110, .Speed = 110, .Generation = 3, .Legendary = True},
New Pokemon With {.Id = 381, .Name = "LatiosMega Latios", .Type1 = "Dragon", .Type2 = "Psychic", .Total = 700, .HP = 80, .Attack = 130, .Defense = 100, .SpAtk = 160, .SpDef = 120, .Speed = 110, .Generation = 3, .Legendary = True},
New Pokemon With {.Id = 382, .Name = "Kyogre", .Type1 = "Water", .Type2 = "Nothing", .Total = 670, .HP = 100, .Attack = 100, .Defense = 90, .SpAtk = 150, .SpDef = 140, .Speed = 90, .Generation = 3, .Legendary = True},
New Pokemon With {.Id = 382, .Name = "KyogrePrimal Kyogre", .Type1 = "Water", .Type2 = "Nothing", .Total = 770, .HP = 100, .Attack = 150, .Defense = 90, .SpAtk = 180, .SpDef = 160, .Speed = 90, .Generation = 3, .Legendary = True},
New Pokemon With {.Id = 383, .Name = "Groudon", .Type1 = "Ground", .Type2 = "Nothing", .Total = 670, .HP = 100, .Attack = 150, .Defense = 140, .SpAtk = 100, .SpDef = 90, .Speed = 90, .Generation = 3, .Legendary = True},
New Pokemon With {.Id = 383, .Name = "GroudonPrimal Groudon", .Type1 = "Ground", .Type2 = "Fire", .Total = 770, .HP = 100, .Attack = 180, .Defense = 160, .SpAtk = 150, .SpDef = 90, .Speed = 90, .Generation = 3, .Legendary = True},
New Pokemon With {.Id = 384, .Name = "Rayquaza", .Type1 = "Dragon", .Type2 = "Flying", .Total = 680, .HP = 105, .Attack = 150, .Defense = 90, .SpAtk = 150, .SpDef = 90, .Speed = 95, .Generation = 3, .Legendary = True},
New Pokemon With {.Id = 384, .Name = "RayquazaMega Rayquaza", .Type1 = "Dragon", .Type2 = "Flying", .Total = 780, .HP = 105, .Attack = 180, .Defense = 100, .SpAtk = 180, .SpDef = 100, .Speed = 115, .Generation = 3, .Legendary = True},
New Pokemon With {.Id = 385, .Name = "Jirachi", .Type1 = "Steel", .Type2 = "Psychic", .Total = 600, .HP = 100, .Attack = 100, .Defense = 100, .SpAtk = 100, .SpDef = 100, .Speed = 100, .Generation = 3, .Legendary = True},
New Pokemon With {.Id = 386, .Name = "DeoxysNormal Forme", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 600, .HP = 50, .Attack = 150, .Defense = 50, .SpAtk = 150, .SpDef = 50, .Speed = 150, .Generation = 3, .Legendary = True},
New Pokemon With {.Id = 386, .Name = "DeoxysAttack Forme", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 600, .HP = 50, .Attack = 180, .Defense = 20, .SpAtk = 180, .SpDef = 20, .Speed = 150, .Generation = 3, .Legendary = True},
New Pokemon With {.Id = 386, .Name = "DeoxysDefense Forme", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 600, .HP = 50, .Attack = 70, .Defense = 160, .SpAtk = 70, .SpDef = 160, .Speed = 90, .Generation = 3, .Legendary = True},
New Pokemon With {.Id = 386, .Name = "DeoxysSpeed Forme", .Type1 = "Psychic", .Type2 = "Nothing", .Total = 600, .HP = 50, .Attack = 95, .Defense = 90, .SpAtk = 95, .SpDef = 90, .Speed = 180, .Generation = 3, .Legendary = True}
}
        ' Populate the ComboBox with Pokémon names
        For Each pokemon In pokemons
            cbOpponent.Items.Add(pokemon)
            cbPkmn1.Items.Add(pokemon)
            cbPkmn2.Items.Add(pokemon)
            cbPkmn3.Items.Add(pokemon)
            cbPkmn4.Items.Add(pokemon)
            cbPkmn5.Items.Add(pokemon)
            cbPkmn6.Items.Add(pokemon)
        Next

        EnableAutoComplete(cbPkmn1)
        EnableAutoComplete(cbPkmn2)
        EnableAutoComplete(cbPkmn3)
        EnableAutoComplete(cbPkmn4)
        EnableAutoComplete(cbPkmn5)
        EnableAutoComplete(cbPkmn6)
        EnableAutoComplete(cbOpponent)

        AddHandler cbOpponent.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
        AddHandler cbPkmn1.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
        AddHandler cbPkmn2.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
        AddHandler cbPkmn3.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
        AddHandler cbPkmn4.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
        AddHandler cbPkmn5.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged
        AddHandler cbPkmn6.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged

    End Sub

    Private Sub EnableAutoComplete(comboBox As System.Windows.Forms.ComboBox)
        comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        comboBox.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    ' Method to get type index
    Private Function GetTypeIndex(type As String) As Integer
        Select Case type.ToLower()
            Case "normal"
                Return 0
            Case "fighting"
                Return 1
            Case "flying"
                Return 2
            Case "poison"
                Return 3
            Case "ground"
                Return 4
            Case "rock"
                Return 5
            Case "bug"
                Return 6
            Case "ghost"
                Return 7
            Case "steel"
                Return 8
            Case "fire"
                Return 9
            Case "water"
                Return 10
            Case "grass"
                Return 11
            Case "electric"
                Return 12
            Case "psychic"
                Return 13
            Case "ice"
                Return 14
            Case "dragon"
                Return 15
            Case "dark"
                Return 16
            Case "fairy"
                Return 17
            Case Else
                Return -1 ' Unknown type
        End Select
    End Function

    ' Method to get type effectiveness
    Private Function GetTypeEffectiveness(attackingType As String, defendingType As String) As Double
        Dim attackingIndex As Integer = GetTypeIndex(attackingType)
        Dim defendingIndex As Integer = GetTypeIndex(defendingType)

        If attackingIndex = -1 OrElse defendingIndex = -1 Then
            Return 1 ' If unknown type, return neutral effectiveness
        End If

        Return typeEffectiveness(attackingIndex, defendingIndex)
    End Function

    'Event handler madness. Updates the form when selections are made in the comboboxes.
    Public Sub ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim comboBox As System.Windows.Forms.ComboBox = CType(sender, System.Windows.Forms.ComboBox)

        If comboBox.SelectedItem IsNot Nothing Then
            Dim selectedPokemon As Pokemon = CType(comboBox.SelectedItem, Pokemon)

            ' Get opponent's types
            Dim opponent As Pokemon = If(cbOpponent.SelectedItem IsNot Nothing, CType(cbOpponent.SelectedItem, Pokemon), Nothing)
            Dim opponentType1 As String = If(opponent IsNot Nothing, opponent.Type1, "")
            Dim opponentType2 As String = If(opponent IsNot Nothing, opponent.Type2, "")

            ' Update labels based on ComboBox name
            Select Case comboBox.Name
                Case "cbOpponent"
                    lblOppType1.Text = selectedPokemon.Type1
                    lblOppType2.Text = If(String.IsNullOrEmpty(selectedPokemon.Type2), "", selectedPokemon.Type2)
                    ' Update effectiveness for all Pokémon types against the opponent
                    SetEffectivenessLabel(lblP1T1vO, lblPkmn1Type1.Text)
                    SetEffectivenessLabel(lblP1T2vO, lblPkmn1Type2.Text)
                    SetEffectivenessLabel(lblP2T1vO, lblPkmn2Type1.Text)
                    SetEffectivenessLabel(lblP2T2vO, lblPkmn2Type2.Text)
                    SetEffectivenessLabel(lblP3T1vO, lblPkmn3Type1.Text)
                    SetEffectivenessLabel(lblP3T2vO, lblPkmn3Type2.Text)
                    SetEffectivenessLabel(lblP4T1vO, lblPkmn4Type1.Text)
                    SetEffectivenessLabel(lblP4T2vO, lblPkmn4Type2.Text)
                    SetEffectivenessLabel(lblP5T1vO, lblPkmn5Type1.Text)
                    SetEffectivenessLabel(lblP5T2vO, lblPkmn5Type2.Text)
                    SetEffectivenessLabel(lblP6T1vO, lblPkmn6Type1.Text)
                    SetEffectivenessLabel(lblP6T2vO, lblPkmn6Type2.Text)

                    lblPkmn1Tot.Text = CalculateTotalEffectiveness(lblPkmn1Type1.Text, lblPkmn1Type2.Text).ToString()
                    lblPkmn2Tot.Text = CalculateTotalEffectiveness(lblPkmn2Type1.Text, lblPkmn2Type2.Text).ToString()
                    lblPkmn3Tot.Text = CalculateTotalEffectiveness(lblPkmn3Type1.Text, lblPkmn3Type2.Text).ToString()
                    lblPkmn4Tot.Text = CalculateTotalEffectiveness(lblPkmn4Type1.Text, lblPkmn4Type2.Text).ToString()
                    lblPkmn5Tot.Text = CalculateTotalEffectiveness(lblPkmn5Type1.Text, lblPkmn5Type2.Text).ToString()
                    lblPkmn6Tot.Text = CalculateTotalEffectiveness(lblPkmn6Type1.Text, lblPkmn6Type2.Text).ToString()
                Case "cbPkmn1"
                    lblPkmn1Type1.Text = selectedPokemon.Type1
                    lblPkmn1Type2.Text = If(String.IsNullOrEmpty(selectedPokemon.Type2), "", selectedPokemon.Type2)
                    SetEffectivenessLabel(lblP1T1vO, selectedPokemon.Type1)
                    SetEffectivenessLabel(lblP1T2vO, selectedPokemon.Type2)
                    lblPkmn1Tot.Text = CalculateTotalEffectiveness(selectedPokemon.Type1, selectedPokemon.Type2).ToString()
                Case "cbPkmn2"
                    lblPkmn2Type1.Text = selectedPokemon.Type1
                    lblPkmn2Type2.Text = If(String.IsNullOrEmpty(selectedPokemon.Type2), "", selectedPokemon.Type2)
                    SetEffectivenessLabel(lblP2T1vO, selectedPokemon.Type1)
                    SetEffectivenessLabel(lblP2T2vO, selectedPokemon.Type2)
                    lblPkmn2Tot.Text = CalculateTotalEffectiveness(selectedPokemon.Type1, selectedPokemon.Type2).ToString()
                Case "cbPkmn3"
                    lblPkmn3Type1.Text = selectedPokemon.Type1
                    lblPkmn3Type2.Text = If(String.IsNullOrEmpty(selectedPokemon.Type2), "", selectedPokemon.Type2)
                    SetEffectivenessLabel(lblP3T1vO, selectedPokemon.Type1)
                    SetEffectivenessLabel(lblP3T2vO, selectedPokemon.Type2)
                    lblPkmn3Tot.Text = CalculateTotalEffectiveness(selectedPokemon.Type1, selectedPokemon.Type2).ToString()
                Case "cbPkmn4"
                    lblPkmn4Type1.Text = selectedPokemon.Type1
                    lblPkmn4Type2.Text = If(String.IsNullOrEmpty(selectedPokemon.Type2), "", selectedPokemon.Type2)
                    SetEffectivenessLabel(lblP4T1vO, selectedPokemon.Type1)
                    SetEffectivenessLabel(lblP4T2vO, selectedPokemon.Type2)
                    lblPkmn4Tot.Text = CalculateTotalEffectiveness(selectedPokemon.Type1, selectedPokemon.Type2).ToString()
                Case "cbPkmn5"
                    lblPkmn5Type1.Text = selectedPokemon.Type1
                    lblPkmn5Type2.Text = If(String.IsNullOrEmpty(selectedPokemon.Type2), "", selectedPokemon.Type2)
                    SetEffectivenessLabel(lblP5T1vO, selectedPokemon.Type1)
                    SetEffectivenessLabel(lblP5T2vO, selectedPokemon.Type2)
                    lblPkmn5Tot.Text = CalculateTotalEffectiveness(selectedPokemon.Type1, selectedPokemon.Type2).ToString()
                Case "cbPkmn6"
                    lblPkmn6Type1.Text = selectedPokemon.Type1
                    lblPkmn6Type2.Text = If(String.IsNullOrEmpty(selectedPokemon.Type2), "", selectedPokemon.Type2)
                    SetEffectivenessLabel(lblP6T1vO, selectedPokemon.Type1)
                    SetEffectivenessLabel(lblP6T2vO, selectedPokemon.Type2)
                    lblPkmn6Tot.Text = CalculateTotalEffectiveness(selectedPokemon.Type1, selectedPokemon.Type2).ToString()
            End Select
        End If

    End Sub

    ' Helper method to set effectiveness label
    Sub SetEffectivenessLabel(label As Label, type As String)
        ' Get opponent's types
        Dim opponent As Pokemon = If(cbOpponent.SelectedItem IsNot Nothing, CType(cbOpponent.SelectedItem, Pokemon), Nothing)
        Dim opponentType1 As String = If(opponent IsNot Nothing, opponent.Type1, "")
        Dim opponentType2 As String = If(opponent IsNot Nothing, opponent.Type2, "")
        If type <> "" AndAlso opponentType1 <> "" Then
            Dim effectiveness1 As Double = GetTypeEffectiveness(type, opponentType1)
            Dim effectiveness2 As Double = If(opponentType2 <> "", GetTypeEffectiveness(type, opponentType2), 1)
            label.Text = $"{effectiveness1}|{effectiveness2}"
        Else
            label.Text = ""
        End If
    End Sub

    ' Helper method to calculate total effectiveness
    Function CalculateTotalEffectiveness(type1 As String, type2 As String) As Double
        Dim opponent As Pokemon = If(cbOpponent.SelectedItem IsNot Nothing, CType(cbOpponent.SelectedItem, Pokemon), Nothing)
        Dim opponentType1 As String = If(opponent IsNot Nothing, opponent.Type1, "")
        Dim opponentType2 As String = If(opponent IsNot Nothing, opponent.Type2, "")
        If type1 <> "" AndAlso opponentType1 <> "" Then
            Dim effectiveness1 As Double = GetTypeEffectiveness(type1, opponentType1)
            Dim effectiveness2 As Double = If(opponentType2 <> "", GetTypeEffectiveness(type1, opponentType2), 1)
            Dim effectiveness3 As Double = If(type2 <> "", GetTypeEffectiveness(type2, opponentType1), 1)
            Dim effectiveness4 As Double = If(type2 <> "", GetTypeEffectiveness(type2, opponentType2), 1)
            'Maybe not the best way to do this as You can have a pokemon w/ 2x type and 0 type and total = 0. 
            Return effectiveness1 * effectiveness2 * effectiveness3 * effectiveness4
        End If
        Return 1 ' Neutral effectiveness if types are not defined
    End Function

End Class

Public Class Pokemon
    Public Property Id As Integer
    Public Property Name As String
    Public Property Type1 As String
    Public Property Type2 As String
    Public Property Total As Integer
    Public Property HP As Integer
    Public Property Attack As Integer
    Public Property Defense As Integer
    Public Property SpAtk As Integer
    Public Property SpDef As Integer
    Public Property Speed As Integer
    Public Property Generation As Integer
    Public Property Legendary As Boolean

    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class
