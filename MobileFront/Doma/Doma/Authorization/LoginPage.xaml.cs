using Doma.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Enums;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Doma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly ICurrentUserProvider userProvider;

        public LoginPage(ICurrentUserProvider userProvider)
        {
            InitializeComponent();

            this.userProvider = userProvider;
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLogin.Text))
            {
                lblError.Text = "Email должен быть заполнен";
                lblError.IsVisible = true;
                return;
            }

            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                lblError.Text = "Пароль должен быть заполнен";
                lblError.IsVisible = true;
                return;
            }

            LoginError result = await userProvider.TryLogin(tbLogin.Text, tbPassword.Text);

            if (result == LoginError.None)
            {
                await Navigation.PopAsync();
            }
            else
            {
                lblError.Text = GetText(result);
                lblError.IsVisible = true;
            }
        }

        private string GetText(LoginError result)
        {
            switch (result)
            {
                case LoginError.WrongLoginOrPsw:
                    return "Неверный адрес электронной почты или пароль";
                case LoginError.UserIsNotConfirmed:
                    return "Учетная запись не подтверждена";
                case LoginError.UserIsBlocked:
                    return "Учетная запись заблокирована";
                case LoginError.DataIsEmpty:
                    return "Данные не указаны";
                case LoginError.UnexpectedError:
                    return "Неожиданная ошибка, проверьте подключение к сети";
                default:
                    return "Неизвестная ошибка";
            }
        }
    }
}