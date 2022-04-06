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
    public partial class RegistrationPage : ContentPage
    {
        private readonly ICurrentUserProvider userProvider;

        public RegistrationPage(ICurrentUserProvider userProvider)
        {
            InitializeComponent();
            rbClient.IsChecked = true;

            this.userProvider = userProvider;
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                lblError.IsVisible = false;
                lblSuccess.IsVisible = false;
                string email = tbLogin.Text;
                string password = tbPassword.Text;
                string passwordConfirm = tbPasswordConfirm.Text;
                string name = tbName.Text;
                UserType userType = rbClient.IsChecked ? UserType.Client : UserType.Hotel;

                if (string.IsNullOrWhiteSpace(email))
                {
                    lblError.Text = "Email должен быть заполнен";
                    lblError.IsVisible = true;
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    lblError.Text = "Пароль должен быть заполнен";
                    lblError.IsVisible = true;
                    return;
                }

                if (string.IsNullOrWhiteSpace(name))
                {
                    lblError.Text = "Имя должно быть заполнено";
                    lblError.IsVisible = true;
                    return;
                }

                if (password != passwordConfirm)
                {
                    lblError.Text = "Пароль и его подтверждение не совпадают";
                    lblError.IsVisible = true;
                    return;
                }

                RegisterError result = await userProvider.TryRegistration(email, password, name, userType);

                if (result == RegisterError.None)
                {
                    lblSuccess.Text = "Вы успешно зарегистрировались! Вам на почту должно прийти письмо для подтверждения учетной записи.";
                    lblSuccess.IsVisible = true;
                }
                else
                {
                    lblError.Text = GetErrorText(result);
                    lblError.IsVisible = true;
                }
            }
            catch
            {
                lblError.Text = "Непредвиденная ошибка";
                lblError.IsVisible = true;
            }
        }

        private string GetErrorText(RegisterError result)
        {
            switch (result)
            {
                case RegisterError.LoginAlreadyExists:
                    return "Такой Email уже зарегистрирован";
                case RegisterError.PasswordIsEasy:
                    return "Пароль должен содержать заглавные и строчные буквы и цифры";
                case RegisterError.DataIsEmpty:
                    return "Данные не указаны";
                case RegisterError.WrongEmailFormat:
                    return "Неверный формат email";
                case RegisterError.UnexpectedError:
                    return "Неожиданная ошибка, проверьте подключение к сети";
                default:
                    return "Неизвестная ошибка";
            }
        }
    }
}