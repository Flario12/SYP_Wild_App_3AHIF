using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using WildApp.Data;
using WildApp.Domain;
using WildApp.Models;

namespace WildApp
{
    public partial class MainWindow : Window
    {
        private readonly Controllers controller = new Controllers();
        private Tutorial? selectedTutorial;

        private readonly Dictionary<string, (double lat, double lon)> cities =
            new Dictionary<string, (double lat, double lon)>(StringComparer.OrdinalIgnoreCase)
            {
                { "Dornbirn", (47.41, 9.74) },
                { "Wien", (48.21, 16.37) },
                { "Graz", (47.07, 15.43) },
                { "Linz", (48.31, 14.29) },
                { "Salzburg", (47.80, 13.04) },
                { "Innsbruck", (47.27, 11.40) },
                { "Bregenz", (47.50, 9.75) },
                { "Klagenfurt", (46.62, 14.31) },
                { "St. Pölten", (48.21, 15.62) },
                { "Villach", (46.61, 13.85) },
                { "Wiener Neustadt", (47.81, 16.24) },
                { "Feldkirch", (47.24, 9.60) },
                { "Eisenstadt", (47.85, 16.52) }
            };

        public MainWindow()
        {
            InitializeComponent();
            LoadTutorials();
            RefreshHistory();
            DatabaseInfo.Text = $"Lokale Datenbank: {controller.DatabasePath}";
        }

        private bool TryGetCoordinates(out double lat, out double lon)
        {
            lat = 0;
            lon = 0;

            string city = Stadt.Text.Trim();

            if (string.IsNullOrWhiteSpace(city))
            {
                Temperatur.Text = "Bitte Stadt eingeben";
                Wind.Text = "Bitte Stadt eingeben";
                return false;
            }

            if (!cities.ContainsKey(city))
            {
                Temperatur.Text = "Stadt nicht gefunden";
                Wind.Text = "Stadt nicht gefunden";
                return false;
            }

            lat = cities[city].lat;
            lon = cities[city].lon;
            return true;
        }

        private async void Button_UpdateWeather_Click(object sender, RoutedEventArgs e)
        {
            if (!TryGetCoordinates(out double lat, out double lon))
                return;

            try
            {
                Temperatur.Text = "Lädt...";
                Wind.Text = "Lädt...";

                var result = await controller.UpdateWeather(lat, lon);
                Temperatur.Text = $"{result.temp} °C";
                Wind.Text = $"{result.wind} km/h";
            }
            catch (Exception ex)
            {
                Temperatur.Text = "Fehler";
                Wind.Text = "Fehler";
                MessageBox.Show(ex.Message, "API Fehler");
            }
        }

        private async void Button_WaterTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WasserStatus.Text = "Status: Lädt...";

                WaterTest result = await controller.GetRandomWaterTest();

                WasserQualitaet.Text = $"Qualität: {result.WaterQuality} %";
                WasserTemperatur.Text = $"Temperatur: {result.Temperature} °C";
                Leitfaehigkeit.Text = $"Leitfähigkeit: {result.Conductivity}";
                Sauerstoff.Text = $"Sauerstoff: {result.OxygenLevel} mg/L";
                PhWert.Text = $"pH-Wert: {result.PhValue}";
                WasserStatus.Text = $"Status: {result.GetQualityStatus()}";

                RefreshHistory();
            }
            catch (Exception ex)
            {
                WasserStatus.Text = "Status: Fehler";
                MessageBox.Show(ex.Message, "WaterTest Fehler");
            }
        }

        private async void Button_AirTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LuftStatus.Text = "Status: Lädt...";

                AirTest result = await controller.GetRandomAirTest();

                LuftQualitaet.Text = $"Qualität: {result.AirQuality} %";
                LuftDichte.Text = $"Luftdichte: {result.AirDensity} kg/m³";
                Co2.Text = $"CO2: {result.Co2Level} ppm";
                Feinstaub.Text = $"Feinstaub: {result.FineDust} µg/m³";
                Luftfeuchtigkeit.Text = $"Luftfeuchtigkeit: {result.Humidity} %";
                LuftStatus.Text = $"Status: {result.GetQualityStatus()}";

                RefreshHistory();
            }
            catch (Exception ex)
            {
                LuftStatus.Text = "Status: Fehler";
                MessageBox.Show(ex.Message, "AirTest Fehler");
            }
        }

        private void LoadTutorials()
        {
            CategoryBox.ItemsSource = controller.GetCategories();
            CategoryBox.SelectedIndex = 0;
            TutorialList.ItemsSource = controller.GetTutorials("Alle");
        }

        private void CategoryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? category = CategoryBox.SelectedItem as string;
            TutorialList.ItemsSource = controller.GetTutorials(category);
        }

        private void TutorialList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTutorial = TutorialList.SelectedItem as Tutorial;

            if (selectedTutorial == null)
                return;

            TutorialTitle.Text = selectedTutorial.Title;
            TutorialCategory.Text = selectedTutorial.Category;
            TutorialDescription.Text = selectedTutorial.Description;
            TutorialSteps.Text = selectedTutorial.Steps;
        }

        private void Button_OpenVideo_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTutorial == null || string.IsNullOrWhiteSpace(selectedTutorial.VideoUrl))
            {
                MessageBox.Show("Bitte zuerst ein Tutorial auswählen.", "Kein Tutorial ausgewählt");
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = selectedTutorial.VideoUrl,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Video konnte nicht geöffnet werden");
            }
        }

        private void RefreshHistory()
        {
            HistoryGrid.ItemsSource = null;
            HistoryGrid.ItemsSource = controller.GetHistory();
        }
    }
}
