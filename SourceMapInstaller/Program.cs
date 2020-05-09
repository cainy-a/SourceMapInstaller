using System;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace SourceMapInstaller
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var path = String.Empty;
			Console.WriteLine("Cain's Easy Source Map Installer.\n");
			if (args.Length == 0)
			{

				Console.WriteLine(
					"Please choose a file by typing in the path below, or alternatively you can drag a map onto this app" +
					" to install it.");
				path = Console.ReadLine();
			}
			else
			{
				path = args[1];
			}

			if (!FileIsMap(path))
			{
				Console.WriteLine("Sorry, that's not a map file.\nHint: It should be a BSP file.\n" +
				                  "If you have a VMF, then ask the mapmaker for a BSP.\n" +
				                  "If the map is yours, then on compile (F9 in hammer) it will be installed for you.");
				Console.ReadKey();
				return;
			}

			var mapName = new FileInfo(path).Name;
			
			Console.WriteLine("\nPlease select your Source Game:\n" +
			                  "Half-Life 2 [hl2]\n" +
			                  "Half-Life 2: Episode 1 [ep1]\n" +
			                  "Half-Life 2: Episode 2 [ep2]\n" +
			                  "Half-Life 1: Source [hl1s]\n" +
			                  "Team Fortress 2 [tf2]" +
			                  "Counter Strike: Source [css]\n" +
			                  "Counter Strike: Global Offensive [csgo]\n" +
			                  "Portal [portal]\n" +
			                  "Portal 2 [portal2]\n" +
			                  "Garry's Mod [gmod]\n");

			var chosenGame = Console.ReadLine();
			string pathToLaunch;
			switch (chosenGame)
			{
				case "hl2":
					if (!File.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\Half-Life 2\hl2"))
					{
						Console.WriteLine("Sorry I was not able to find that game installed. Perhaps you have a non-steam version?");
						Console.ReadKey();
						return;
					}
					File.Copy(path,
						$@"C:\Program Files (x86)\Steam\steamapps\common\Half-Life 2\hl2\maps\{mapName}");
					pathToLaunch = @"C:\Program Files (x86)\Steam\steamapps\common\Half-Life 2\hl2.exe -game hl2";
					break;
				case "ep1":
					if (!File.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\Half-Life 2\episodic"))
					{
						Console.WriteLine("Sorry I was not able to find that game installed. Perhaps you have a non-steam version?");
						Console.ReadKey();
						return;
					}
					File.Copy(path,
						$@"C:\Program Files (x86)\Steam\steamapps\common\Half-Life 2\episodic\maps\{mapName}");
					pathToLaunch = @"C:\Program Files (x86)\Steam\steamapps\common\Half-Life 2\hl2.exe -game episodic";
					break;
				case "ep2":
					if (!File.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\Half-Life 2\ep2"))
					{
						Console.WriteLine("Sorry I was not able to find that game installed. Perhaps you have a non-steam version?");
						Console.ReadKey();
						return;
					}
					File.Copy(path,
						$@"C:\Program Files (x86)\Steam\steamapps\common\Half-Life 2\ep2\maps\{mapName}");
					pathToLaunch = @"C:\Program Files (x86)\Steam\steamapps\common\Half-Life 2\hl2.exe -game ep2";
					break;
				case "hl1s":
					if (!File.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\Half-Life 2\hl1"))
					{
						Console.WriteLine("Sorry I was not able to find that game installed. Perhaps you have a non-steam version?");
						Console.ReadKey();
						return;
					}
					File.Copy(path,
						$@"C:\Program Files (x86)\Steam\steamapps\common\Half-Life 2\hl1\maps\{mapName}");
					pathToLaunch = @"C:\Program Files (x86)\Steam\steamapps\common\Half-Life 2\hl2.exe -game hl1";
					break;
				case "tf2":
					if (!File.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\Team Fortress 2\tf"))
					{
						Console.WriteLine("Sorry I was not able to find that game installed. Perhaps you have a non-steam version?");
						Console.ReadKey();
						return;
					}
					File.Copy(path,
						$@"C:\Program Files (x86)\Steam\steamapps\common\Team Fortress 2\tf\maps\{mapName}");
					pathToLaunch = @"C:\Program Files (x86)\Steam\steamapps\common\Team Fortress 2\hl2.exe -game tf";
					break;
				case "css":
					if (!File.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\counter-strike source\cstrike"))
					{
						Console.WriteLine("Sorry I was not able to find that game installed. Perhaps you have a non-steam version?");
						Console.ReadKey();
						return;
					}
					File.Copy(path,
						$@"C:\Program Files (x86)\Steam\steamapps\common\counter-strike source\cstrike\maps\{mapName}");
					pathToLaunch = @"C:\Program Files (x86)\Steam\steamapps\common\counter-strike source\hl2.exe -game cstrike";
					break;
				case "csgo":
					if (!File.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive\csgo"))
					{
						Console.WriteLine("Sorry I was not able to find that game installed. Perhaps you have a non-steam version?");
						Console.ReadKey();
						return;
					}
					File.Copy(path,
						$@"C:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive\csgo\maps\{mapName}");
					pathToLaunch = @"C:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive\csgo.exe -game csgo";
					break;
				case "portal":
					if (!File.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\Portal\portal"))
					{
						Console.WriteLine("Sorry I was not able to find that game installed. Perhaps you have a non-steam version?");
						Console.ReadKey();
						return;
					}
					File.Copy(path,
						$@"C:\Program Files (x86)\Steam\steamapps\common\Portal\portal\maps\{mapName}");
					pathToLaunch = @"C:\Program Files (x86)\Steam\steamapps\common\Portal\hl2.exe -game portal";
					break;
				case "portal2":
					if (!File.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\Portal 2\portal2"))
					{
						Console.WriteLine("Sorry I was not able to find that game installed. Perhaps you have a non-steam version?");
						Console.ReadKey();
						return;
					}
					File.Copy(path,
						$@"C:\Program Files (x86)\Steam\steamapps\common\Portal 2\portal2\maps\{mapName}");
					pathToLaunch = @"C:\Program Files (x86)\Steam\steamapps\common\Portal 2\portal2.exe -game portal2";
					break;
				case "gmod":
					if (!File.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\GarrysMod\garrysmod"))
					{
						Console.WriteLine("Sorry I was not able to find that game installed. Perhaps you have a non-steam version?");
						Console.ReadKey();
						return;
					}
					File.Copy(path,
						$@"C:\Program Files (x86)\Steam\steamapps\common\GarrysMod\garrysmod\maps\{mapName}");
					pathToLaunch = @"C:\Program Files (x86)\Steam\steamapps\common\GarrysMod\hl2.exe -game garrysmod";
					break;
				default: pathToLaunch = String.Empty; break;
			}
			Console.Write("Would you like a quick rundown on how to run your map [yes | no]?");
			var responseTutorial = Console.ReadLine();
			if (responseTutorial == "yes")
				Console.WriteLine("\n\n" +
				                  "Step 1: Go to the options, keyboard / controls, enable developer console\n" +
				                  "Step 2: Press `, which is the key left of 1\n" +
				                  $"Step 3: type \"map {mapName.Substring(0, mapName.Length - 4)}\"");
			Console.Write("Map Installed. Would you like to launch the game [yes | no]?");
			var responseLaunch = Console.ReadLine();
			if (responseLaunch == "yes")
				Process.Start(pathToLaunch);
			
			Console.WriteLine("\n\nAll finished! Press a key to exit.");
			Console.ReadKey();
		}

		public static bool FileIsMap(string path)
			=> Regex.IsMatch(path, @".+\.bsp");
	}
}