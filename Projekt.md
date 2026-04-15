# Artefakten 


## Projektstart-Dokument / Projektauftrag

### Projekttietel:
DinosaurusRex App 

### Problem: 
Keine Hilfe beim Campen und oder bei alltäglichen sachen

### Projektziele:

- Hauptziel: App erstellen 

- Teilziel: Ideen ausarbeiten bis sie realistisch sind

- Messbare Kriterien: Zeit, Qualität, Erfolgkriterien

### Ressourcen:

- Budget: 0€

- Personal: 4Personen

- Matrial/Technik: Laptops und Handys

### Zeitrahmen:

- Start: Januar

- Ende: Juni


### Beteiligte Personen / Stakeholder

- Projektleiter: Daniel Walser

- Arbeiter: Muhammet, Emir, Kenan

## Mindmap 
![Mindmap](1.png)

## Soll und Ist Zustand 

### Ist-Zustand

- Viele Menschen sind sich unsicher, wie sie sich in der Natur zurechtfinden oder Zugang zur Natur bekommen.
- Es fehlt an Wissen darüber, wie man in der Natur überlebt und mit natürlichen Bedingungen umgeht.

### Soll-Zustand

- Ziel unserer App ist es, Menschen das nötige Wissen und Verständnis zu vermitteln, um sich sicher in der Natur zu bewegen und in der Natur überleben zu können.
- Die App steht im Mittelpunkt des Konzepts.
- Zusätzlich gibt es einen Adapter, den man an das Handy anschließen kann.
- Der Adapter misst z. B. Lufttemperatur, Wasserqualität und weitere Umweltfaktoren und überträgt die Daten direkt in die App.


## Ziele definieren: Muss-Ziele, Kann-Ziele


### Muss Ziele:

- Den Leuten erklären, welche Daten wie Witterung etc. ein Ort hat.
- Tutorials wie man Tools verwendet
- Tutorials wie man nützliche Konstruktionen wie ein Lagerfeuer erbauen kann.
- Man sollte aber auch die Idee erhalten, ab wann Früchte sowie Beeren giftig sind.
- Wasserqualität messen
- Luftqualität messen
- Orte Bewerten
- Wettervorhersage
- Lebensmittel Prüfen ob essbar ist
- Anleitungen
- Tutorial/Anleitung für Wildniss

### Budget
200€


### Gesetz
Datenschutzvorgaben erfüllem

### Kann Ziele:
- Map
- Bewertung von Plätzen
- App zugänglichkeit für alle Betriebssystheme
- Verschiedene Anschlüsse (Für alle Handys)
- Kooperation mit Berühmten Unternehmen und Menschen







## Arbeitspakete

### AP-1

```
Titel: ERM und RM 
```

```
Ziel
```
- Erstellung des Datenmodells als Grundlage für die Datenbank

```
Beschreibung der Aufgabe
```

- ERM (Entity-Relationship-Modell) erstellen
- Entitäten und Beziehungen definieren
- Relationales Modell (RM) ableiten
- Primär- und Fremdschlüssel festlegen

```
Benötigte Mittel
```

- DrawIO
- Papier 

```
Abhängigkeiten
```
- Keine


### AP-02

```
Titel: AP-02 UML Erstellung
```

```
Ziel: 
```
- Eine UML für das Programm der App erstellen.

```
Beschreibung der Aufgaben
```
- Man setzt sich alleine oder als Team hin und plant die strucktur des Programmes.

```
Benötigte Mittel
```

- Mitarbieter
- Laptop
- Projekter (beamer)

```
Abhängigkeit
```
- AP-1


### AP-3
```
Titel: AP-3 Datenbank implementieren
```

```
Ziel/Zweck
```
- Erstellung eines DB Designs

```
Beschreibung der Aufgaben
```

- Mann muss SQL Tabellen erstellen
- Mann muss Daten in die Tabellen einfügen

```
Benötigte Mittel
```
- PyCharm

```
Abhängigkeiten
```
- AP-1 


### AP-4

```
Titel: Einkauf
```

- Hardware-Ressourcen besorgen

```
Ziel:
```

- Für die Hardwareimplementierung sollten die benötigten Ressourcen besorgt werden.

```
Beschreibung der Aufgaben
```
- Materiall Einkaufen 

```
Benötigte Mittel
```

- Gehäuse
- Hauptplatine
- Sensoren
    - ph-Sensor
    - Wasser
    - Leitfähigkeit
    - Temperaturfühler
    - Luft
    - Luftqualität
    - Feuchtigkeitssensor
    - Luftdrucksensor
- Strom
    - Akku
    - Lade-Modul
- Anschlüsse
    - Antenne für Funk
    - wasserdichte Steckverbinder
    - Kabeldurchführungen
- Zusatz
    - Display 
    - Speicher (SD-Karte)
    - WLAN/Funk

```
Abhängigkeit:
```
- AP-1




### AP-5

```
Titel: AP-5 Klassen implementieren
```

```
Ziel:
```
- Erstellte UML-Klassen

```
Beschreibung der Aufgaben
```
- Hier sollten die UML-Klassen erstellt werden


```
Benötigte Mittel
```
- VS 26

```
Abhängigkeiten
```
- AP2
- AP3


### AP-6

```
Titel: AP-6 GUI aufbauen
```

```
Ziel
```

- Man sollte den Appinhalt **ersichtlich** machen
- Man sollte für nachher ermöglichen, dass man die Logik einfügen kann.

```
Beschreibung der Aufgaben
```
- GUI erstellen und designen 

```
Benötigte Mittel
```
- VS 26

```
Abhängigkeiten
```
- AP5

### AP7
```
Titel: Hardware für die Datenaufnahme
```
- Daten von der Software wereden in der Hardware weitergegeben (Wie eine Brücke zwischen Hardware Software)
- Zwischenspeichern von Daten

```
Ziel / Zweck
```

- Kommunikation zwischen Hardware und Software
- Datenverzögerung minimieren
- Falls was in der Hardware verloren geht, kann man hier wieder auf die Daten zugreifen

```
Beschreibung der Aufgaben
```
- Daten werden von der Software Ausgelesen
- Danach werden sie gespeichert
- Anschließend werden sie der Hardware weitergegeben

```
Benötigte Mittel
```

- ARDUINO Controller
- Usb-c Kabel
- Android Handy für Tests
- Arduino IDE

```
Abhängigkeiten
```

- AP4 Einkauf
- AP6 GUI, (davor müssen die Implementierungen auch passen)


### AP-08
Titel: AP-08 Programm für die Aufnahme von Daten schreiben

```
Ziel: 
```
- Die Daten welche vom Arduino aufgenommen werden, sollten im Programm gelesen werden.
- Beschreibung der Aufgaben

- Programmiert im C oder MiniPython ein Programm

```
Benötigte Mittel
```
- Arduino
- Microchip Studio

```
Abhängigkeit
```
- AP-7






### AP-09

```
Titel: Ausleseprogramm in unsere App verbinden
```

```
Ziel:
```
- Das Auslese-Programm in unsere App verbinden

```
Benötigte Mittel
```
- C#

```
Abhängigkeit
```

- AP-08




### AP-10

```
Titel: AP-10 Testen
```

```
Ziel:
```
- Ganze App und hardware austesten und vergewissern dass es funktioniert

```
Beschreibung der Aufgabe:
```

- Hier sollen ihr Unittests bei eurem Programmdurchführen.
- Ihr solltet generell testen, ob eurer Projekt funktioniert.

```
Abhängigkeit
```
- AP-09






# Risikobewertung eines Messsystems (App & Hardware)

## 1. Software (App)

### Risiken
- Fehlfunktionen / Bugs  
- Falsche Messwertanzeige  
- Abstürze (z. B. ohne Internetverbindung)  
- Datenverlust  
- Fehlinterpretation durch Nutzer  
- Sicherheitslücken  

### Bewertung
- Eintritt: mittel  
- Auswirkung: hoch  

### Maßnahmen
- Intensive Tests (Unit- & Integrationstests)  
- Offline-Modus  
- Klare Visualisierung (z. B. Ampelsystem)  
- Verschlüsselung & sichere Authentifizierung  

---

## 2. Hardware (Messgerät)

### Risiken
- Messungenauigkeit  
- Umwelteinflüsse (Regen, Hitze, Kälte)  
- Materialprobleme (z. B. Kabelbruch)  
- Stromversorgung (Akku leer)  

### Bewertung
- Eintritt: mittel–hoch  
- Auswirkung: sehr hoch  

### Maßnahmen
- Kalibrierung der Sensoren  
- Wetterfestes Gehäuse (IP-Schutz)  
- Hochwertige Materialien  
- Akkuanzeige & Energiesparmodus  

---

## 3. Schnittstelle (App ↔ Gerät)

### Risiken
- Verbindungsprobleme (Bluetooth/WLAN)  
- Datenübertragungsfehler  
- Kompatibilitätsprobleme mit Smartphones  

### Bewertung
- Eintritt: mittel  
- Auswirkung: hoch  

### Maßnahmen
- Stabile Protokolle (z. B. BLE)  
- Fehlerprüfung (Checksummen)  
- Tests mit verschiedenen Geräten  

---

## 4. Benutzer & Nutzung

### Risiken
- Falsche Nutzung des Geräts  
- Blindes Vertrauen in Messdaten  
- Bedienfehler (komplizierte UI)  

### Bewertung
- Eintritt: hoch  
- Auswirkung: mittel–hoch  

### Maßnahmen
- Einfache Benutzeroberfläche  
- Klare Anleitung  
- Warnhinweise bei unsicheren Daten  

---

## 5. Recht & Datenschutz

### Risiken
- Datenschutzverletzungen (DSGVO)  
- Haftung bei falschen Messwerten  
- Fehlende Zertifizierung  

### Bewertung
- Eintritt: gering–mittel  
- Auswirkung: sehr hoch  

### Maßnahmen
- Datenschutzkonzept  
- Haftungsausschluss  
- Zertifizierungen prüfen  

# Stakeholderanalyse
# Stakeholderanalyse

| Stakeholder        | Einfluss | Interesse | Rolle                     |
|--------------------|----------|-----------|---------------------------|
| Gründer            | hoch     | hoch      | Entscheidungsträger       |
| User               | mittel   | hoch      | Nutzen die App            |
| Lehrer (Herr Fritz)| mittel   | mittel    | Feedback / Bewertung      |
| Konkurrenz         | gering   | mittel    | Marktvergleich            |
