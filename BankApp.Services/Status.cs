using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public enum Status
    {   
        BankNameInvalid,
        BankNameValid,
        UsernameInvalid,
        UsernameValid,
        PasswordInvalid,
        PasswordValid,
        InsufficientAmount,
        SufficientAmount
    }
}
