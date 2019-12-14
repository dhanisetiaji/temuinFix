using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Xamarin.Forms;
using temuinFix.Models;

namespace temuinFix.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e) {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabse.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<LoginModel>();

            var item = new LoginModel()
            {
                UserName = EntryUsername.Text,
                Password = EntryPassword.Text,
                Email = EntryUserEmail.Text,
                Phone = EntryPhoneNumber.Text
            };

            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () => {
                var result = await this.DisplayAlert("Selamat", "Pendaftaran Berhasil!", "Yes", "Cencel");
            }); 
        }
    }
}