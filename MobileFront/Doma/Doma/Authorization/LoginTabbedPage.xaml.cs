using Doma.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Doma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginTabbedPage : TabbedPage
    {
        public LoginTabbedPage(ICurrentUserProvider userProvider)
        {
            InitializeComponent();

            Children.Add(new LoginPage(userProvider));
            Children.Add(new RegistrationPage(userProvider));
        }
    }
}