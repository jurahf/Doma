using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Enums
{
    public enum RegisterError
    {
        None,

        LoginAlreadyExists,

        PasswordIsEasy,

        DataIsEmpty,

        WrongEmailFormat
    }
}
