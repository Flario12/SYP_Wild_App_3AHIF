# WildApp

Lokale WPF-App für Outdoor-/Survival-Themen.

## Enthalten

- Wetterabfrage über Open-Meteo
- WaterTest mit simulierten Messwerten
- AirTest mit simulierten Messwerten
- Lokale JSON-Datenbank für Tutorials und Test-Verlauf
- Tutorial-Bereich mit Themen wie Zelt bauen, Tarp, Wasser filtern, Feuer, Luftqualität und Orientierung
- Video-Button, der einen passenden Tutorial-Link im Browser öffnet

## Datenbank

Die App legt automatisch eine lokale Datenbank an:

`%LOCALAPPDATA%/WildApp/wildapp_database.json`

Das ist bewusst ohne externe NuGet-Pakete gemacht, damit das Schulprojekt leichter in Visual Studio startet.

## Start

In Visual Studio öffnen:

`WildApp.sln`

Dann Start drücken.
