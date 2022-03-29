using Doma.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Doma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientProfile : BaseViewWithAuth
    {
        private UserViewModel user;
        public UserViewModel User 
        {
            get { return user; }
            set 
            {
                if (user != value)
                {
                    user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        public ClientProfile(ICurrentUserProvider userProvider)
            : base(userProvider)
        {
            InitializeComponent();
        }

        protected override void ShowFilledView()
        {
            User = userProvider.CurrentUser;
        }

        protected override void ShowNotAuthView()
        {
        }

    }
}