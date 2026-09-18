using PersonManager_WPF_CLIENT.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManager_WPF_CLIENT.Services
{
    internal interface IPersonService
    {

        Task<List<Person>> GetAllPersonsAsync();
    }
}
