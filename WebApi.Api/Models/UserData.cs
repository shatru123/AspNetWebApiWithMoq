using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WebApi.Api.Models
{
    public class UserData 
    {
        public List<User> Users { get; set; }
    }
}