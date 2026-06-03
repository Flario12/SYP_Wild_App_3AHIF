using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using WildApp.Models;

namespace WildApp.Data
{
    public class AppDatabase
    {
        private class DatabaseState
        {
            public List<Tutorial> Tutorials { get; set; } = new();
            public List<TestHistoryEntry> TestHistory { get; set; } = new();
        }

        private readonly string databaseFile;

        public List<Tutorial> Tutorials { get; set; } = new();
        public List<TestHistoryEntry> TestHistory { get; set; } = new();

        public AppDatabase()
        {
            string folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "WildApp");

            Directory.CreateDirectory(folder);
            databaseFile = Path.Combine(folder, "wildapp_database.json");
            Load();
        }

        public string GetDatabasePath()
        {
            return databaseFile;
        }

        public void Load()
        {
            if (!File.Exists(databaseFile))
            {
                Seed();
                Save();
                return;
            }

            string json = File.ReadAllText(databaseFile);
            DatabaseState? loaded = JsonSerializer.Deserialize<DatabaseState>(json);

            if (loaded == null)
            {
                Seed();
                Save();
                return;
            }

            Tutorials = loaded.Tutorials ?? new List<Tutorial>();
            TestHistory = loaded.TestHistory ?? new List<TestHistoryEntry>();

            if (Tutorials.Count == 0)
            {
                Seed();
                Save();
            }
        }

        public void Save()
        {
            DatabaseState state = new DatabaseState
            {
                Tutorials = Tutorials,
                TestHistory = TestHistory
            };

            string json = JsonSerializer.Serialize(state, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(databaseFile, json);
        }

        public List<Tutorial> GetTutorials(string? category = null)
        {
            if (string.IsNullOrWhiteSpace(category) || category == "Alle")
                return Tutorials.OrderBy(t => t.Category).ThenBy(t => t.Title).ToList();

            return Tutorials
                .Where(t => t.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .OrderBy(t => t.Title)
                .ToList();
        }

        public List<string> GetCategories()
        {
            List<string> categories = Tutorials
                .Select(t => t.Category)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            categories.Insert(0, "Alle");
            return categories;
        }

        public void AddHistory(string testType, string summary, string status)
        {
            int nextId = TestHistory.Count == 0 ? 1 : TestHistory.Max(h => h.Id) + 1;

            TestHistory.Insert(0, new TestHistoryEntry
            {
                Id = nextId,
                TestType = testType,
                Summary = summary,
                Status = status,
                CreatedAt = DateTime.Now
            });

            Save();
        }

        private void Seed()
        {
            Tutorials = new List<Tutorial>
            {
                new Tutorial
                {
                    Id = 1,
                    Category = "Shelter",
                    Title = "Zelt richtig aufbauen",
                    Description = "Grundlagen für einen sicheren Zeltplatz, Heringe, Abspannung und Wetterschutz.",
                    Steps = "1. Ebenen Platz suchen, nicht in einer Senke.\n2. Untergrund von Steinen und Ästen befreien.\n3. Zeltboden auslegen und Gestänge verbinden.\n4. Innenzelt und Außenzelt sauber spannen.\n5. Heringe schräg in Windrichtung setzen.\n6. Abspannleinen nachziehen und Regenrinne vermeiden.",
                    VideoUrl = "https://www.youtube.com/results?search_query=Zelt+richtig+aufbauen+Tutorial"
                },
                new Tutorial
                {
                    Id = 2,
                    Category = "Shelter",
                    Title = "Notunterkunft mit Tarp bauen",
                    Description = "Schnelle Schutzlösung mit Plane, Seil und natürlichen Befestigungspunkten.",
                    Steps = "1. Zwei stabile Bäume suchen.\n2. Ridgeline auf Hüfthöhe bis Brusthöhe spannen.\n3. Tarp darüber legen.\n4. Seiten bodennah abspannen.\n5. Eingang windabgewandt ausrichten.\n6. Bodenisolierung mit Matte oder trockenem Laub nutzen.",
                    VideoUrl = "https://www.youtube.com/results?search_query=Tarp+Shelter+bauen+Tutorial"
                },
                new Tutorial
                {
                    Id = 3,
                    Category = "Wasser",
                    Title = "Wasser finden und filtern",
                    Description = "Wie man Wasserquellen einschätzt und Wasser vor dem Trinken vorbereitet.",
                    Steps = "1. Fließendes Wasser bevorzugen.\n2. Sichtbare Verschmutzung vermeiden.\n3. Grob filtern, z.B. durch Stoff.\n4. Danach abkochen oder Filter verwenden.\n5. Bei Chemikalienverdacht nicht trinken.\n6. Ergebnis im WaterTest der App dokumentieren.",
                    VideoUrl = "https://www.youtube.com/results?search_query=Wasser+filtern+Outdoor+Tutorial"
                },
                new Tutorial
                {
                    Id = 4,
                    Category = "Feuer",
                    Title = "Feuer sicher machen",
                    Description = "Basics für Feuerstelle, Zunder, Holzarten und sicheres Löschen.",
                    Steps = "1. Nur wo erlaubt Feuer machen.\n2. Feuerstelle freiräumen.\n3. Zunder, kleine Äste und Brennholz vorbereiten.\n4. Klein starten und langsam aufbauen.\n5. Wasser oder Erde zum Löschen bereithalten.\n6. Glut vollständig löschen.",
                    VideoUrl = "https://www.youtube.com/results?search_query=Feuer+machen+Outdoor+Tutorial"
                },
                new Tutorial
                {
                    Id = 5,
                    Category = "Luft",
                    Title = "Luftqualität einschätzen",
                    Description = "Zeigt, worauf man bei Rauch, Staub, CO2 und schlechter Belüftung achten sollte.",
                    Steps = "1. Rauch und starke Gerüche ernst nehmen.\n2. Geschlossene Räume regelmäßig lüften.\n3. CO2-Wert bei Müdigkeit/Kopfschmerzen beachten.\n4. Bei Staub Maske oder Abstand nutzen.\n5. AirTest in der App ausführen.\n6. Bei schlechtem Status Ort wechseln.",
                    VideoUrl = "https://www.youtube.com/results?search_query=Luftqualit%C3%A4t+messen+CO2+Feinstaub+Tutorial"
                },
                new Tutorial
                {
                    Id = 6,
                    Category = "Orientierung",
                    Title = "Orientierung ohne Handy",
                    Description = "Grundlagen zu Karte, Kompass, Sonne und markanten Punkten.",
                    Steps = "1. Standort auf Karte bestimmen.\n2. Markante Punkte suchen.\n3. Kompassrichtung festlegen.\n4. Route in kleine Abschnitte teilen.\n5. Bei Unsicherheit zurück zum letzten sicheren Punkt.\n6. Akku sparen, Handy nur gezielt nutzen.",
                    VideoUrl = "https://www.youtube.com/results?search_query=Orientierung+ohne+Handy+Karte+Kompass+Tutorial"
                }
            };

            TestHistory = new List<TestHistoryEntry>();
        }
    }
}
