﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net.Http;
using Newtonsoft.Json;
using AlertToCareAPI.Models;

namespace AlertToCareAPIUI
{
    /// <summary>
    /// Interaction logic for PatientDetailsWindow.xaml
    /// </summary>
    public partial class PatientDetailsWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();
        public PatientDetailsWindow()
        {
            InitializeComponent();
        }
        private async System.Threading.Tasks.Task AddPatientDetails_ClickAsync(object sender, RoutedEventArgs e)
        {
            var newAddress = new PatientAddress()
            {
                HouseNo = textBoxHouseNo.Text,
                Street = textBoxStreet.Text,
                City = textBoxCity.Text,
                State = textBoxState.Text,
                Pincode = textBoxPincode.Text,
            };

            var newVitals = new VitalsCategory()
            {
                PatientId = textBoxPatientId.Text,
                Spo2 = float.Parse(textBoxSpo2.Text),
                Bpm = float.Parse(textBoxBpm.Text),
                RespRate = float.Parse(textBoxResp.Text),

            };

            var newPatient = new PatientDetails()
            {
                PatientId = textBoxPatientId.Text,
                PatientName = textBoxPatientName.Text,
                Age = int.Parse(textBoxAge.Text),
                ContactNo = textBoxContactNo.Text,
                BedId = textBoxBedId.Text,
                IcuId = textBoxIcuId.Text,
                Email = textBoxEmail.Text,
                Address = newAddress,
                Vitals = newVitals,
            };

            var response = await client.PostAsync("http://localhost:5000/api/IcuOccupancyDetails/Patients", new StringContent(JsonConvert.SerializeObject(newPatient), Encoding.UTF8, "application/json"));

            var responseString = await response.Content.ReadAsStringAsync();

            textBoxPatientId.Text = responseString;
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            var result = AddPatientDetails_ClickAsync(sender, e);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}