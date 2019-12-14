﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using temuinFix.ViewModels;
using temuinFix.Models;
using Xamarin.Forms.Xaml;

namespace temuinFix.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //Get All Persons
            var personList = await App.SQLiteDb.GetItemsAsync();
            if (personList != null)
            {
                lstPersons.ItemsSource = personList;
            }
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                DataModel person = new DataModel()
                {
                    Name = txtName.Text
                };

                //Add New Person
                await App.SQLiteDb.SaveItemAsync(person);
                txtName.Text = string.Empty;
                await DisplayAlert("Success", "Data Berhasil Ditambahkan", "OK");
                //Get All Persons
                var personList = await App.SQLiteDb.GetItemsAsync();
                if (personList != null)
                {
                    lstPersons.ItemsSource = personList;
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter name!", "OK");
            }
        }

        private async void BtnRead_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersonId.Text))
            {
                //Get Person
                var person = await App.SQLiteDb.GetItemAsync(Convert.ToInt32(txtPersonId.Text));
                if (person != null)
                {
                    txtName.Text = person.Name;
                    await DisplayAlert("Success", "Person Name: " + person.Name, "OK");
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter PersonID", "OK");
            }
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersonId.Text))
            {
                DataModel person = new DataModel()
                {
                    Id = Convert.ToInt32(txtPersonId.Text),
                    Name = txtName.Text
                };

                //Update Person
                await App.SQLiteDb.SaveItemAsync(person);

                txtPersonId.Text = string.Empty;
                txtName.Text = string.Empty;
                await DisplayAlert("Success", "Person Updated Successfully", "OK");
                //Get All Persons
                var personList = await App.SQLiteDb.GetItemsAsync();
                if (personList != null)
                {
                    lstPersons.ItemsSource = personList;
                }

            }
            else
            {
                await DisplayAlert("Required", "Please Enter PersonID", "OK");
            }
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersonId.Text))
            {
                //Get Person
                var person = await App.SQLiteDb.GetItemAsync(Convert.ToInt32(txtPersonId.Text));
                if (person != null)
                {
                    //Delete Person
                    await App.SQLiteDb.DeleteItemAsync(person);
                    txtPersonId.Text = string.Empty;
                    await DisplayAlert("Success", "Data Berhasil Dihapus", "OK");

                    //Get All Persons
                    var personList = await App.SQLiteDb.GetItemsAsync();
                    if (personList != null)
                    {
                        lstPersons.ItemsSource = personList;
                    }
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter PersonID", "OK");
            }
        }

    }
}