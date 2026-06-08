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

       

        public MainWindow()
        {
            InitializeComponent();
            LoadTutorials();
            RefreshHistory();
            DatabaseInfo.Text = $"Lokale Datenbank: {controller.DatabasePath}";
        }

        private async Task<(bool success, double lat, double lon)> TryGetCoordinates()
        {
            string city = Stadt.Text.Trim();

            var coords = await controller.GetCoordinates(city);

            if (coords == null)
            {
                Temperatur.Text = "Stadt nicht gefunden";
                Wind.Text = "Stadt nicht gefunden";
                return (false,0,0);
            }

            return (true, coords.Value.lat, coords.Value.lon);
        }

        private async void Button_UpdateWeather_Click(object sender, RoutedEventArgs e)
        {
            var result = await TryGetCoordinates();

            if (!result.success)
                return;

            try
            {
                Temperatur.Text = "Lädt...";
                Wind.Text = "Lädt...";

                var weather = await controller.UpdateWeather(result.lat, result.lon);

                Temperatur.Text = $"{weather.temp} °C";
                Wind.Text = $"{weather.wind} km/h";
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
