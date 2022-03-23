using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Enums
{
    public enum LoginError
    {
        None,

        /// <summary>
        /// Неверный логин или пароль
        /// </summary>
        WrongLoginOrPsw,

        /// <summary>
        /// Учетная запись не подтверждена
        /// </summary>
        UserIsNotConfirmed,

        /// <summary>
        /// Учетная запись заблокирована
        /// </summary>
        UserIsBlocked,

        DataIsEmpty,

        UnexpectedError,
    }
}
