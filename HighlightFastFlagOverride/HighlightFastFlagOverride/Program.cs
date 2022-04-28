using System;
using System.Data;
using System.Net;
using System.IO;
using System.Text;

Console.WriteLine("Rifthook Highlight FFlag Overrider\nStarting in 1 second.");
Thread.Sleep(1000);
Console.WriteLine("\nGetting latest Roblox version..");

// make request to roblox for latest version
var request = WebRequest.Create("http://setup.roblox.com/version"); // deprecated but fuck you
request.Method = "GET";
using var WebResponse = request.GetResponse();
using var WebStream = WebResponse.GetResponseStream();
using var reader = new StreamReader(WebStream);
string RobloxVersion = reader.ReadToEnd();

Console.WriteLine("Got Roblox Version: " + RobloxVersion);

// create ClientSettings folder & directory shit
string RobloxDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+ @"\Roblox\Versions\"+RobloxVersion;
string ClientSettingsDir = RobloxDir + @"\ClientSettings";
Directory.CreateDirectory(ClientSettingsDir);

Console.WriteLine("Created directory, writing JSON file..");

// create JSON file
string ShitToWrite = "{\"FFlagRenderHighlightPass3\": \"True\"}";
FileStream AppSettings = File.Create(ClientSettingsDir + @"\ClientAppSettings.json");
byte[] BytesToWrite = Encoding.UTF8.GetBytes(ShitToWrite);
AppSettings.Write(BytesToWrite,0, BytesToWrite.Length);
AppSettings.Close();
Console.WriteLine("Wrote ClientAppSettings.json");

Console.WriteLine("Done! Press any key to exit.");
Console.ReadKey();